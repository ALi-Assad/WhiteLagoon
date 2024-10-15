using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        public IActionResult Index()
        {
            return View(unitOfWork.Villa.GetAll());
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name == obj.Descreption)
            {
                ModelState.AddModelError("name", "The Name and Descreption can\'t be the same");
            }

            if (ModelState.IsValid)
            {

                if(obj.Image is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImages");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VillaImages\" + fileName;
                }
                else
                {
                    obj.ImageUrl = "http://placehold.co/600x400";
                }

                unitOfWork.Villa.Add(obj);
                unitOfWork.Save();
                TempData["success"] = "Villa has been created successfully";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "Something went wrong";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Villa? villa = unitOfWork.Villa.Get(x => x.Id == villaId);
            if (villa is null)
            {
                return RedirectToAction("error", "home");
            }

            return View(villa);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            Villa? vil = unitOfWork.Villa.Get(x => x.Id == villa.Id);
            if (vil is null)
            {
                return RedirectToAction("error", "home");
            }

            vil.Name = villa.Name;
            vil.Price = villa.Price;
            vil.Sqft = villa.Sqft;
            vil.ImageUrl = villa.ImageUrl;
            vil.Image = villa.Image;
            vil.Descreption = villa.Descreption;

            if (ModelState.IsValid)
            {
                if (vil.Image is not null)
                {

                    if(vil.ImageUrl is not null)
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, vil.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(vil.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VillaImages");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    vil.Image.CopyTo(fileStream);

                    vil.ImageUrl = @"\images\VillaImages\" + fileName;
                }



                unitOfWork.Villa.Update(vil);
                unitOfWork.Save();
                TempData["success"] = "Villa has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(villa);
        }   
        
        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? vil = unitOfWork.Villa.Get(x => x.Id == villa.Id);
            if (vil is not null)
            {

                if (vil.ImageUrl is not null)
                {
                    string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, vil.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                unitOfWork.Villa.Delete(vil);
                unitOfWork.Save();
                TempData["success"] = "Villa has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "something went wrong";
            return RedirectToAction("error", "home");
        }
    }
}
