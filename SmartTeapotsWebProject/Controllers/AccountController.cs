using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTeapotsWebProject.Data.DBContexts;
using SmartTeapotsWebProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SmartTeapotsWebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SmartTeapotsDbContext _dbContext;

        public AccountController(SmartTeapotsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Orders()
        {
            string? username = User.Identity!.Name;

            User user = _dbContext.Users.FirstOrDefault(u => u.Login == username)!;

            var orderList = user.Orders.ToList();

            return View(orderList);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);

                if (user == null)
                {
                    Role? role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Client");

                    user = new User
                    {
                        Email = model.Email,
                        SurName = model.SurName,
                        FirstName = model.FirstName,
                        Login = model.Login,
                        Password = model.Password,
                        Role = role!
                    };

                    _dbContext.Users.Add(user);
                    await _dbContext.SaveChangesAsync();

                    await Authenticate(model.Login);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or(and) password");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn(string returnUrl)
        {
            return View(new SignIn { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignIn model)
        {
            if (ModelState.IsValid)
            {
                User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(model.Login); // аутентификация
 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or(and) password");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            UProfile? model;
            User? user;

            string? userName = User.Identity!.Name;

            user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == userName)!;

            if (user != null)
            {
                model = new UProfile
                {
                    Login = user.Login,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    SurName = user.SurName,
                    OldPassword = user.Password,
                    NewPassword = user.Password,
                    ConfirmNewPassword = user.Password
                };
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProfile(UProfile model)
        {
            if (ModelState.IsValid)
            {
                User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);

                if (user != null)
                {
                    user.Email = model.Email;
                    user.Login = model.Login;
                    user.FirstName = model.FirstName;
                    user.SurName = model.SurName;
                    user.Password = model.NewPassword;

                    _dbContext.Users.Update(user);

                    return RedirectToAction("UserProfile", "Account");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
