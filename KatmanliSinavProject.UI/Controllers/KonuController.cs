using AutoMapper;
using KatmanliSinavProject.BLL.DTOs.KonuDTOs;
using KatmanliSinavProject.BLL.Services.KonuService;
using KatmanliSinavProject.UI.Models.ViewModels.KonuVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KatmanliSinavProject.UI.Controllers
{
    [Authorize]
    public class KonuController : Controller
    {
        private readonly IKonuService _konuService;
        private readonly IMapper _mapper;

        public KonuController(IKonuService konuService, IMapper mapper)
        {
            _konuService = konuService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                IList<KonuDTO> konuDTOs = _konuService.GetNotPassiveAll();
                IList<KonuVM> konuVMs = _mapper.Map<IList<KonuDTO>, IList<KonuVM>>(konuDTOs);

                return View(konuVMs);
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult KonuAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KonuAdd(KonuCreateVM konuCreateVM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    KonuCreateDTO konuCreateDTO = _mapper.Map<KonuCreateDTO>(konuCreateVM);
                    bool result = _konuService.KonuAdd(konuCreateDTO);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public IActionResult KonuEdit(int id)
        {
            try
            {

                KonuDTO konuDTO = _konuService.KonuGetById(id);
                if (konuDTO != null)
                {
                    KonuUpdateVM konuUpdateVM = _mapper.Map<KonuUpdateVM>(konuDTO);
                    return View(konuUpdateVM);
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
        public IActionResult KonuEdit(KonuUpdateVM konuUpdateVM)
        {
            try
            {
                if (konuUpdateVM != null)
                {
                    KonuUpdateDTO konuUpdateDTO = _mapper.Map<KonuUpdateDTO>(konuUpdateVM);
                    _konuService.KonuUpdate(konuUpdateDTO);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Erorr"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public IActionResult KonuDelete(int id)
        {
            try
            {
                _konuService.KonuDelete(id);
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
