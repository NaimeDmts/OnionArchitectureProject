using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.BLL.Services.AppUserService;
using KatmanliSinavProject.UI.Models.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KatmanliSinavProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public AccountController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterDTO registerDTO = _mapper.Map<RegisterDTO>(registerVM);
                    IdentityResult result = await _service.Register(registerDTO);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description.ToString());
                        }
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return View(registerVM);
            }


        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginDTO = _mapper.Map<LoginDTO>(loginVM);
                    bool login = await _service.Login(loginDTO);
                    if (login)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Content("Giriş Gerçeklerşmedi");
                    }
                }
                return View(loginVM);
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return View(loginVM);
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await _service.LogOut();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Ayarlar()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            AppUserDTO appUserDTO = await _service.GetById(userId);
            AppUserUpdateVM userUpdateVM = _mapper.Map<AppUserUpdateVM>(appUserDTO);
            return View(userUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Ayarlar(AppUserUpdateVM updateVM)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                AppUserUpdateDTO DTO = _mapper.Map<AppUserUpdateDTO>(updateVM);
                DTO.Id = userId;
                var result = await _service.UpdateUser(DTO);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return View();
            }


        }
    }
}
