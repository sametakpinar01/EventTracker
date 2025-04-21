using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventTracker.Controllers
{
    public class EventsController : Controller
    {
        // Etkinlikleri saklamak için statik bir liste
        private static List<EventModel> eventList = new()
        {
            new EventModel {
                Id = 1,
                Title = "Yazılım Geliştirme Konferansı",
                Description = "ASP.NET Core MVC hakkında detaylı bilgiler paylaşılacaktır.",
                Date = DateTime.UtcNow.AddDays(7)
            },
            new EventModel {
                Id = 2,
                Title = "Takım Toplantısı",
                Description = "Aylık proje değerlendirme toplantısı.",
                Date = DateTime.UtcNow.AddMonths(1)
            },
        };

        // Etkinlikleri listeleme işlemi
        public IActionResult List()
        {
            // Etkinlik listesini görüntüleme
            return View(eventList);
        }

        // Belirli bir etkinliğin detaylarını görüntüleme
        public IActionResult Details(int id)
        {
            // ID'ye göre etkinlik bulma
            var eventItem = eventList.FirstOrDefault(e => e.Id == id);
            if (eventItem == null)
            {
                // Etkinlik bulunamazsa 404 döndür
                return NotFound();
            }
            return View(eventItem);
        }

        // Yeni etkinlik oluşturma formunu görüntüleme (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Yeni etkinlik oluşturma işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                // Yeni bir ID oluşturma
                int newId = eventList.Count > 0 ? eventList.Max(e => e.Id) + 1 : 1;
                eventModel.Id = newId;

                // Yeni etkinliği listeye ekleme
                eventList.Add(eventModel);

                // Etkinlik listesine yönlendirme
                return RedirectToAction(nameof(List));
            }
            return View(eventModel);
        }

        // Mevcut bir etkinliği düzenleme formunu görüntüleme (GET)
        public IActionResult Edit(int id)
        {
            // ID'ye göre etkinlik bulma
            var eventItem = eventList.FirstOrDefault(e => e.Id == id);
            if (eventItem == null)
            {
                // Etkinlik bulunamazsa 404 döndür
                return NotFound();
            }
            return View(eventItem);
        }

        // Mevcut bir etkinliği düzenleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EventModel eventModel)
        {
            if (id != eventModel.Id)
            {
                // ID'ler eşleşmiyorsa 404 döndür
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Etkinliği listede güncelleme
                var index = eventList.FindIndex(e => e.Id == id);
                if (index == -1)
                {
                    return NotFound();
                }

                eventList[index] = eventModel;
                return RedirectToAction(nameof(List));
            }
            return View(eventModel);
        }

        // Mevcut bir etkinliği silme işlemi
        public IActionResult Delete(int id)
        {
            // ID'ye göre etkinlik bulma
            var eventItem = eventList.FirstOrDefault(e => e.Id == id);
            if (eventItem == null)
            {
                // Etkinlik bulunamazsa 404 döndür
                return NotFound();
            }

            // Etkinliği listeden kaldırma
            eventList.Remove(eventItem);
            return RedirectToAction(nameof(List));
        }
    }
}
