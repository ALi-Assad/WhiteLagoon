using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Infrastructure.Repository;
using WhiteLagoon.Web.ViewModels;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController(IUnitOfWork unitOfWork, ApplicationDbContext db) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public IActionResult Index()
        {
            var villas = _unitOfWork.VillaNumber.GetAll(expressions: [vn => vn.Villa]);
             return View(villas);
        }

        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                })
            };
         
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            bool villaNumberExists = _unitOfWork.VillaNumber.Any(vn => vn.Villa_Number == obj.VillaNumber.Villa_Number);

            if (villaNumberExists)
            {
                TempData["error"] = "you can't duplicate Villa Number";
                ModelState.AddModelError("Villa_Number", "This villa number already exist");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Add(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "Villa Numbers has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Something went wrong";

            obj.VillaList = _unitOfWork.Villa.GetAll()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                });
            return View(obj);
        }

        [HttpGet]
        public IActionResult Update(int villaNumber)
        {
            VillaNumber? villaN = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumber);
            if (villaN is null)
            {
                return RedirectToAction("error", "home");
            }

            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                }),
                VillaNumber = villaN
            };

            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Update(villaNumberVM.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "Villa has been updated successfully";
                return RedirectToAction(nameof(Index));
            }


            villaNumberVM.VillaList = _unitOfWork.Villa.GetAll()
           .Select(v => new SelectListItem
           {
               Text = v.Name,
               Value = v.Id.ToString(),
           });
            return View(villaNumberVM);
        }   
        
        [HttpPost]
        public IActionResult Delete(VillaNumber villaNumber)
        {
            VillaNumber? vil = _unitOfWork.VillaNumber.Get(x => x.Villa_Number == villaNumber.Villa_Number);
            if (vil is not null)
            {
                _unitOfWork.VillaNumber.Delete(vil);
                _unitOfWork.Save();
                TempData["success"] = "Villa has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "something went wrong";
            return RedirectToAction("error", "home");
        }
    }
}
