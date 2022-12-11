using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using ZooManage.Data;
using ZooManage.Models;

namespace ZooManage.Controllers
{
    public class AnimalVeterinaryController : Controller
    {
       
        readonly ZooManageDbContext _zooManage;
        public AnimalVeterinaryController(ZooManageDbContext zooManage)
        {
            _zooManage = zooManage;
        }

        public IActionResult Index(int id)
        {
            {
                var animal = _zooManage.Animals.Include(x => x.Veterinaries).FirstOrDefault(x => x.Id == id);

                ViewBag.AnimalId = animal.Id;
                ViewBag.Name = animal.AnimalName;
                ViewBag.Veternaries = new SelectList(_zooManage.Veterinaries.ToList(), "Id", "Name");

                return View(animal.Veterinaries);
            }
        }
        public IActionResult AddAnimalToVeterinary()
        {
            ViewBag.Animals = new SelectList(_zooManage.Animals.ToList(), "Id", "AnimalName");
            //ViewBag.Veterinaries = new SelectList(_zooManage.Veterinaries.ToList(), "Id", "Name");
            ViewBag.Veterinaries = _zooManage.Veterinaries.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddAnimalToVeterinary(int id, int VetId)
        {
            var animal = _zooManage.Animals.Include(x => x.Veterinaries).FirstOrDefault(x => x.Id == id);
            var veterinary = _zooManage.Veterinaries.Find(VetId);

            if (!animal.Veterinaries.Any(c => c.Id == veterinary.Id))
            {
                animal.Veterinaries.Add(veterinary);
                _zooManage.SaveChanges();
            }
            else
            {
                ViewBag.Animals = new SelectList(_zooManage.Animals, "Id", "AnimalName");
                //ViewBag.Veterinaries = new SelectList(_zooManage.Veterinaries, "id", "Name");
                ViewBag.Veterinaries = _zooManage.Veterinaries.ToList();
                ViewBag.Message = $"You already have this Animal: {veterinary.Id}!";

                return View();
            }


            return RedirectToAction("Index", new { id = id });
        }
        public IActionResult RemoveVeterinaryFromAnimal(int id, int vetId)
        {
            var animal = _zooManage.Animals.Include(x => x.Veterinaries).SingleOrDefault(x => x.Id == id);
            var veterinaryToRemove = _zooManage.Veterinaries.SingleOrDefault(veterinary => veterinary.Id == vetId);

            animal?.Veterinaries.Remove(veterinaryToRemove);
            _zooManage.SaveChanges();
            return RedirectToAction("Index", new { id = id });

        }

    }
}
