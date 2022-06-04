using AutoMapper;
using Domain.Abstrct;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WrestlingSchool.Controllers
{
    public class WrestlingController : Controller
    {
        #region [Ctor]
        private readonly IWrestlingService _wrestlingService;
        private readonly IMapper _mapper;
        public WrestlingController(IWrestlingService wrestlingService,IMapper mapper)
        {
            _wrestlingService = wrestlingService;

            _mapper = mapper;
        } 
        #endregion

        #region [Index]
        [HttpGet]
        public IActionResult Index()
        {
            var list = _wrestlingService.GetAll();
            return View(list);
        } 
        #endregion

        #region [Create]

        [HttpGet]
        public ViewResult Create()
        {
            return View(new WrestlingModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WrestlingModel model)
        {
            var result = _wrestlingService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(model);
            }

        }
        #endregion

        #region [Edit]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _wrestlingService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WrestlingModel model)
        {
            var result = _wrestlingService.Update(model);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);


        }
        #endregion

        #region [Delete]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _wrestlingService.GetById(id);
            _wrestlingService.Delete(model.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(WrestlingModel model)
        {
            var result = _wrestlingService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            ViewBag.Message = result.Message;
            return View(model);

        }
        #endregion

    }
}
