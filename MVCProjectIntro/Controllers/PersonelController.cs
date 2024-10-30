using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MVCProjectIntro.Models;

namespace MVCProjectIntro.Controllers
{
    public class PersonelController : Controller
    {
        private static List<Personel> personels = new List<Personel>()
        {
            new Personel {Id= 1 ,Name = "Meltem", Surname="Ceran" },
            new Personel {Id= 2 ,Name = "Alkın", Surname="Bayrak" },
            new Personel {Id= 3 ,Name = "Batuhan", Surname="Özbakır" },
            new Personel {Id= 4 ,Name = "Efnan", Surname="Genç" }
        };
        public IActionResult Index()
        {
            return View(personels);
        }

        [HttpGet]
        public IActionResult PersonelAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelAdd(Personel personel)
        {
            personel.Id = personels.Count + 1;
            personels.Add(personel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var personel = personels.Find(p => p.Id == id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        public IActionResult Update(Personel personel)
        {
           var currentPersonel = personels.Find(p => p.Id == personel.Id);
            if (currentPersonel == null)
            {
                return NotFound();
            }
            currentPersonel.Name = personel.Name;
            currentPersonel.Surname = personel.Surname;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var personel = personels.Find(p => p.Id == id);
            if (personel != null)
            {
                personels.Remove(personel);
            }
            return RedirectToAction("Index");
        }
    }
}
