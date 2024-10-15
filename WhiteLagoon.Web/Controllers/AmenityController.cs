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
    public class AmenityController(IUnitOfWork unitOfWork, ApplicationDbContext db) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public IActionResult Index()
        {
            var amenity = _unitOfWork.Amenity.GetAll(expressions: [vn => vn.Villa]);
             return View(amenity);
        }

        public IActionResult Create()
        {
            AmenityVM aminetyVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                })
            };
         
            return View(aminetyVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Add(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been created successfully";
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
        public IActionResult Update(int amenityId)
        {
            Amenity? amenity = _unitOfWork.Amenity.Get(x => x.Id == amenityId);
            if (amenity is null)
            {
                return RedirectToAction("error", "home");
            }

            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString(),
                }),
                Amenity = amenity
            };

            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Update(AmenityVM amenityVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(amenityVM.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been updated successfully";
                return RedirectToAction(nameof(Index));
            }


            amenityVM.VillaList = _unitOfWork.Villa.GetAll()
           .Select(v => new SelectListItem
           {
               Text = v.Name,
               Value = v.Id.ToString(),
           });
            return View(amenityVM);
        }   
        
        [HttpPost]
        public IActionResult Delete(Amenity amenity)
        {
            Amenity? ami = _unitOfWork.Amenity.Get(x => x.Id == amenity.Id);
            if (ami is not null)
            {
                _unitOfWork.Amenity.Delete(ami);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "something went wrong";
            return RedirectToAction("error", "home");
        }
    }
}
