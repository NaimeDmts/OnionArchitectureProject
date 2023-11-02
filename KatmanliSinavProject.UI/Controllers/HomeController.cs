using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.BLL.DTOs.MakaleDTOs;
using KatmanliSinavProject.BLL.Services.KonuService;
using KatmanliSinavProject.BLL.Services.MakaleService;
using KatmanliSinavProject.Core.Entities.Concretes;
using KatmanliSinavProject.UI.Models;
using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;
using KatmanliSinavProject.UI.Models.ViewModels.MakaleVMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace KatmanliSinavProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMakaleService _makaleService;
        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;
        public HomeController(IKonuService konuService, ILogger<HomeController> logger, IMakaleService makaleService, IMapper mapper)
        {
            _logger = logger;
            _konuService = konuService;
            _makaleService = makaleService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                IList<MakaleDTO> makaleDTO = _makaleService.GetUserMakales(userId);
                IList<MakaleVM> makaleVM = _mapper.Map<IList<MakaleDTO>, IList<MakaleVM>>(makaleDTO);
                ViewBag.UserMakale = makaleVM;
            }
            IList<KonuDTO> konuDTOs = _konuService.GetNotPassiveAll();
            IList<KonuVM> konuVMs = _mapper.Map<IList<KonuDTO>, IList<KonuVM>>(konuDTOs);
            ViewBag.konu = konuVMs;

            IList<MakaleDTO> makaleDTOs = _makaleService.GetRastgeleMakale();
            IList<MakaleVM> makaleVMs = _mapper.Map<IList<MakaleDTO>, IList<MakaleVM>>(makaleDTOs);
            return View(makaleVMs);
        }
        public IActionResult MakaleOku(int id)
        {
            MakaleDTO makaleDTO = _makaleService.MakaleGetById(id);
            MakaleVM makaleVM = _mapper.Map<MakaleVM>(makaleDTO);
            return View(makaleVM);
        }
        public IActionResult KonuDetay(int id)
        {
            IList<MakaleDTO> makaleDTO = _makaleService.GetKonuMakales(id);
            IList<MakaleVM> makaleVM = _mapper.Map<IList<MakaleDTO>, IList<MakaleVM>>(makaleDTO);
            return View(makaleVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}