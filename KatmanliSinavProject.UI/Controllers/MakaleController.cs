using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.AppUserDTOs;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.BLL.Services.AppUserService;
using KatmanliSinavProject.BLL.Services.KonuService;
using KatmanliSinavProject.BLL.Services.MakaleService;
using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;
using KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs;
using KatmanliSinavProject.UI.Models.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace KatmanliSinavProject.UI.Controllers
{

    public class MakaleController : Controller
    {
        private readonly IMakaleService _makaleService;
        private IUserService _userService;
        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;

        public MakaleController(IMakaleService makaleService, IUserService userService, IKonuService konuService, IMapper mapper)
        {
            _makaleService = makaleService;
            _userService = userService;
            _konuService = konuService;
            _mapper = mapper;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            IList<MakaleDTO> makaleDTOs = _makaleService.GetUserMakales(userId);
            IList<MakaleVM> makaleVMs = _mapper.Map<IList<MakaleDTO>, IList<MakaleVM>>(makaleDTOs);
            return View(makaleVMs);
        }
        [HttpGet]
        public async Task<IActionResult> MakaleAdd()
        {
            try
            {
                IList<KonuDTO> konuDTOs = _konuService.GetNotPassiveAll();
                IList<KonuVM> konuVMs = _mapper.Map<IList<KonuDTO>, IList<KonuVM>>(konuDTOs);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                AppUserDTO appUserDTO = await _userService.GetById(userId);
                AppUserVM appUserVM = _mapper.Map<AppUserVM>(appUserDTO);

                MakaleCreateVM makaleCreateVM = new MakaleCreateVM();
                makaleCreateVM.Konus = konuVMs.ToList();
                makaleCreateVM.AppUser = appUserVM;
                return View(makaleCreateVM);
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult MakaleAdd(MakaleCreateVM makaleCreateVM)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                MakaleCreateDTO makaleCreateDTO = _mapper.Map<MakaleCreateDTO>(makaleCreateVM);
                makaleCreateDTO.AppUserId = userId;
                bool result = _makaleService.MakaleAdd(makaleCreateDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> MakaleEdit(int id)
        {
            try
            {
                MakaleDTO makaleDTO = _makaleService.MakaleGetById(id);
                if (makaleDTO != null)
                {

                    IList<KonuDTO> konuDTOs = _konuService.GetNotPassiveAll();
                    IList<KonuVM> konuVMs = _mapper.Map<IList<KonuDTO>, IList<KonuVM>>(konuDTOs);

                    MakaleUpdateVM makaleUpdateVM = _mapper.Map<MakaleUpdateVM>(makaleDTO);
                    makaleUpdateVM.Konus = konuVMs.ToList();
                    return View(makaleUpdateVM);
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public async Task<IActionResult> MakaleEdit(MakaleUpdateVM makaleUpdateVM)
        {
            try
            {
                if (makaleUpdateVM != null)
                {
                    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    MakaleUpdateDTO makaleUpdateDTO = _mapper.Map<MakaleUpdateDTO>(makaleUpdateVM);
                    makaleUpdateDTO.AppUserId = userId;
                    _makaleService.MakaleUpdate(makaleUpdateDTO);

                    return RedirectToAction("Index");
                }
                return View(makaleUpdateVM);
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult MakaleDelete(int id)
        {
            try
            {

                _makaleService.MakaleDelete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
