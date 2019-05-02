using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;


namespace WebStore.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);//Проверяем логин/пароль пользователя

                if (loginResult.Succeeded)//если проверка успешна
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))//и returnUrl - локальный
                    {
                        return Redirect(model.ReturnUrl);//перенаправляем туда откуда пришли
                    }

                    return RedirectToAction("Index", "Home");//иначе на главную
                }

            }

            ModelState.AddModelError("", "Вход невозможен");//говорим пользователю что вход невозможен
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User { UserName = model.UserName, Email = model.Email };   
            var createResult = await _userManager.CreateAsync(user, model.Password);  
            if (createResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);       
                await _userManager.AddToRoleAsync(user, Roles.Student);
                return RedirectToAction("Index", "Home");
            }

            foreach (var identityError in createResult.Errors)           
            {
                ModelState.AddModelError("", identityError.Description);
            }
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}