using Microsoft.AspNetCore.Mvc;

using ZooManage.Models;
using ZooManage.Data;
using Microsoft.EntityFrameworkCore;

namespace ZooManage.Controllers
{
    
 
    public class ContinetController : Controller
    {
        readonly ZooManageDbContext _zooManage;

        public ContinetController(ZooManageDbContext zooManage)
        {
            _zooManage= zooManage;
        }
        public IActionResult Index()
        {
            return View(_zooManage.Continetns.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Continent continent)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                continent.Id = continent.Id;
                _zooManage.Continetns.Add(continent);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("index");

        }
        public IActionResult Delete(int Id)
        {
            var continentToRemove = _zooManage.Continetns.Find(Id);

            if (continentToRemove != null)
            {
                _zooManage.Continetns.Remove(continentToRemove);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var continentToFinde = _zooManage.Continetns.SingleOrDefault(x => x.Id == id);

            if (continentToFinde == null)
            {
                return RedirectToAction(nameof(continentToFinde));
                //return NotFound();//404
            }

            return View(continentToFinde);
        }

    }
}
