using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTeapotsWebProject.Data.DBContexts;
using SmartTeapotsWebProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SmartTeapotsWebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly SmartTeapotsDbContext _dbContext;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, SmartTeapotsDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Orders()
        {
            string username = User.Identity.Name;

            User user = _dbContext.MyUsers.FirstOrDefault(u => u.Login == username)!;

            var orderList = user.Orders.ToList();

            return View(orderList);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Login };

                User userDetails = new User 
                { 
                    Email = model.Email, 
                    SurName = model.SurName, 
                    FirstName = model.FirstName, 
                    Login = model.Login, 
                    Password = model.Password,
                    RoleId = 2
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    _dbContext.MyUsers.Add(userDetails);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
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
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or(and) password");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UserProfile()
        {
            IdentityUser? user;
            UProfile? model;
            User userDetails;

            string? userName = User.Identity.Name;

            if (userName != null)
            {
                user = await _userManager.FindByNameAsync(userName);
                userDetails = _dbContext.MyUsers.FirstOrDefault(u => u.Login == userName)!;
                model = new UProfile {
                    Login = user.UserName,
                    Email = user.Email,
                    FirstName = userDetails.FirstName,
                    SurName = userDetails.SurName,
                    OldPassword = userDetails.Password,
                    NewPassword = userDetails.Password,
                    ConfirmNewPassword = userDetails.Password
                };
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserProfile(UProfile model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser? user = await _userManager.FindByNameAsync(model.Login);
                User userDetails = _dbContext.MyUsers.FirstOrDefault(u => u.Login == model.Login)!;

                if (user != null && userDetails != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Login;
                    userDetails.Email = model.Email;
                    userDetails.Login = model.Login;
                    userDetails.FirstName = model.FirstName;
                    userDetails.SurName = model.SurName;
                    userDetails.Password = model.NewPassword;

                    var result = await _userManager.UpdateAsync(user);

                    if (!string.IsNullOrEmpty(model.NewPassword))
                    {
                        result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        _dbContext.MyUsers.Update(userDetails);
                    }

                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserProfile", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
