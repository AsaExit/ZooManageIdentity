using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManage.Data;
using ZooManage.Models;

namespace ZooManage.Controllers
{
    public class VeterinaryDbController : Controller
    {
        readonly ZooManageDbContext _zooManage;
        public VeterinaryDbController(ZooManageDbContext zooManage)
        {
            _zooManage = zooManage;
        }

        public IActionResult Index()
        {
            return View(_zooManage.Veterinaries.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Veterinary veterinary)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                veterinary.Id = veterinary.Id;
                _zooManage.Veterinaries.Add(veterinary);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("index");

        }
        public IActionResult Delete(int Id)
        {
            var veterinaryToRemove = _zooManage.Veterinaries.Find(Id);

            if (veterinaryToRemove != null)
            {
                _zooManage.Veterinaries.Remove(veterinaryToRemove);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
