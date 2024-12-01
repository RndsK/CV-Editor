using CV.Core.Services;
using Latvijas_Pasts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Latvijas_Pasts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICvService _cvService;

        public HomeController(ICvService cvService)
        {
            _cvService = cvService;
        }

        public IActionResult Index()
        {
            var cvs = _cvService.GetCvs();
            return View(cvs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var cv = new Cv
            {
                Address = new Address(),
                EducationList = new List<Education> { new Education() },  
                ExperienceList = new List<Experience> { new Experience() } 
            };

            return View(cv);
        }

        [HttpPost]
        public IActionResult Create(Cv cv)
        {
            if (!ModelState.IsValid) return View(cv);
            _cvService.AddCv(cv);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cv = _cvService.GetCvById(id);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

        [HttpPost]
        public IActionResult Edit(Cv cv)
        {
            if (ModelState.IsValid)
            {
                _cvService.UpdateCv(cv);
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cv = _cvService.GetCvById(id);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCv(int id)
        {
            _cvService.DeleteCv(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var cv = _cvService.GetCvById(id);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }

    }
}
