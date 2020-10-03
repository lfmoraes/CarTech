using AutoMapper;
using CarTech.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarTech.App.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Modal()
        {
            return PartialView();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _userManager.Users.ToListAsync();

            var users = _mapper.Map<List<UserViewModel>>(response);

            return View(users);
        }

        public async Task<IActionResult> Create(string id)
        {
            UserViewModel model = new UserViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user != null)
                {
                    model = _mapper.Map<UserViewModel>(user);
                }
            }

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            bool result = false;
            var message = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(model.Id))
                {
                    var oldUser = await _userManager.FindByIdAsync(model.Id);

                    var user = _mapper.Map<IdentityUser>(model);

                    if (oldUser.Email != model.Email)
                    {
                        var token = _userManager.GenerateChangeEmailTokenAsync(oldUser, model.Email);
                        var response = await _userManager.ChangeEmailAsync(oldUser, model.Email, token.Result.ToString());
                    }

                    if (oldUser.UserName != model.UserName)
                    {
                        var response = await _userManager.SetUserNameAsync(oldUser, model.UserName);
                    }

                    result = true;
                    message = "Cadastro atualizado com sucesso!";
                }
                else
                {
                    var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                    var response = await _userManager.CreateAsync(user, model.Password);

                    if (response.Succeeded)
                    {
                        result = true;
                        message = "Cadastro realizado com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new { Success = result, Message = message });
        }

        public async Task<IActionResult> Delete(string id)
        {
            bool success = true;

            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user != null)
                {
                    var response = await _userManager.DeleteAsync(user);
                    success = response.Succeeded;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success });
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
