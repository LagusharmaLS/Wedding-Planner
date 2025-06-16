using Microsoft.AspNetCore.Mvc;
using DreamDays.Models;
using DreamDays.Data;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace DreamDays.Controllers
{
    public class AuthController : Controller
    {
        private readonly DreamDaysDbContext _context;

        public AuthController(DreamDaysDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Message = TempData["Message"] as string;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "Invalid login attempt. Please try again.");
                return View(new LoginViewModel());
            }

            if (ModelState.IsValid)
            {
#pragma warning disable CS8600
                string email = model.Email;
                string password = model.Password;
#pragma warning restore CS8600

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "Email and password are required.");
                    return View(model);
                }

                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    ModelState.AddModelError("", "Please enter a valid email address.");
                    return View(model);
                }

                string role = null;
                bool isMFAEnabled = false;

                var user = _context.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        role = user.Role;
                        isMFAEnabled = user.IsMFAEnabled;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Incorrect password for this email.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found. Please register or check your email.");
                    return View(model);
                }

                if (role != null)
                {
                    if (isMFAEnabled)
                    {
                        TempData["MFARequired"] = true;
                        TempData["Email"] = email;
                        TempData["Role"] = role;
                        return RedirectToAction("VerifyMFA");
                    }

                    TempData["Message"] = "Login successful! Redirecting to your dashboard.";
                    return role switch
                    {
                        "Admin" => RedirectToAction("AdminDashboard", "Home"),
                        "Planner" => RedirectToAction("PlannerDashboard", "Home"),
                        "Couple" => RedirectToAction("CoupleDashboard", "Home"),
                        _ => RedirectToAction("CoupleDashboard", "Home")
                    };
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyMFA()
        {
            if (TempData["MFARequired"] == null || TempData["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.Email = TempData["Email"];
            TempData.Keep("Email");
            TempData.Keep("Role");
            return View();
        }

        [HttpPost]
        public IActionResult VerifyMFA(string mfaCode)
        {
            if (mfaCode == "123456")
            {
                string role = TempData["Role"]?.ToString() ?? "Couple";
                TempData["Message"] = "MFA verified! Redirecting to your dashboard.";
                return role switch
                {
                    "Admin" => RedirectToAction("AdminDashboard", "Home"),
                    "Planner" => RedirectToAction("PlannerDashboard", "Home"),
                    "Couple" => RedirectToAction("CoupleDashboard", "Home"),
                    _ => RedirectToAction("CoupleDashboard", "Home")
                };
            }
            ViewBag.ErrorMessage = "Invalid MFA code.";
            ViewBag.Email = TempData["Email"];
            TempData.Keep("Email");
            TempData.Keep("Role");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Password) || !IsPasswordValid(model.Password))
                {
                    ModelState.AddModelError("Password", "Password must be at least 8 characters long and include alphanumeric and special characters.");
                    return View(model);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                    return View(model);
                }

                var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(model);
                }

#pragma warning disable CS8600
                var newUser = new User
                {
                    Email = model.Email,
                    Password = model.Password,
                    IsMFAEnabled = model.EnableMFA,
                    WeddingEventId = Guid.NewGuid().ToString(),
                    Role = "Couple"
                };
#pragma warning restore CS8600

                _context.Users.Add(newUser);
                _context.SaveChanges();

                TempData["Message"] = $"Registration successful for {model.Email}! Please log in.";
                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"]?.ToString();
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Email not found.";
                return RedirectToAction("ForgotPassword");
            }

            TempData["Message"] = $"A password reset link has been sent to {email}. (Simulated)";
            return RedirectToAction("Login");
        } 

        [HttpGet]
        public IActionResult CoupleDashboard()
        {
            return RedirectToAction("CoupleDashboard", "Home");
        }

        private static bool IsPasswordValid(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};:'"",.<>?]).{8,}$", RegexOptions.Compiled);
            return regex.IsMatch(password);
        }
    }
}