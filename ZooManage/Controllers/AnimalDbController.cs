using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManage.Data;
using ZooManage.Models;

namespace ZooManage.Controllers
{
    public class AnimalDbController : Controller
    {
        readonly ZooManageDbContext _zooManage;
        public AnimalDbController(ZooManageDbContext zooManage)
        {
            _zooManage=zooManage;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_zooManage.Animals.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Create(Animal animal)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                animal.Id=animal.Id;
                _zooManage.Animals.Add(animal);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("index");
            
        }
        public IActionResult Delete(int Id)
        {
            var animalToRemove = _zooManage.Animals.Find(Id);

            if (animalToRemove != null)
            {
                _zooManage.Animals.Remove(animalToRemove);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var animalToFind = _zooManage.Animals.Include(x => x.Veterinaries).SingleOrDefault(x => x.Id == id);

            if (animalToFind == null)
            {
                return RedirectToAction(nameof(animalToFind));
                //return NotFound();//404
            }

            return View(animalToFind);
        }
    }
}
