using Microsoft.AspNetCore.Mvc;
using ZooManage.Data;
using ZooManage.Models;

namespace ZooManage.Controllers
{
    public class CountryController : Controller
    {
        readonly ZooManageDbContext _zooManage;
        public CountryController(ZooManageDbContext zooManage)
        {
            _zooManage = zooManage;
        }

        public IActionResult Index()
        {
            return View(_zooManage.Countries.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                country.Id = country.Id;
                _zooManage.Countries.Add(country);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("index");

        }
        public IActionResult Delete(int Id)
        {
            var countryToRemove = _zooManage.Countries.Find(Id);

            if (countryToRemove != null)
            {
                _zooManage.Countries.Remove(countryToRemove);
                _zooManage.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var countryToFinde = _zooManage.Countries.SingleOrDefault(x => x.Id == id);

            if (countryToFinde == null)
            {
                return RedirectToAction(nameof(countryToFinde));
                //return NotFound();//404
            }

            return View(countryToFinde);
        }
    }
}
