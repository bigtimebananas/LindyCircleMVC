using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LindyCircleMVC.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;

        public PracticeController(IPracticeRepository practiceRepository) {
            _practiceRepository = practiceRepository;
        }

        public ViewResult List() {
            ViewBag.Title = "Practices";
            return View();
        }

        public PartialViewResult GetPartial(DateTime? startDate, DateTime? endDate) {
            var practices = _practiceRepository.SearchPractices(startDate, endDate).ToList();
            return PartialView("_PracticeList", practices);
        }

        public IActionResult Details(int id) {
            var practice = _practiceRepository.GetPractice(id);
            if (practice == null)
                return RedirectToAction("List", "Practice");
            ViewBag.Title = $"Practice #{practice.PracticeNumber}";
            var practiceDetailsViewModel = new PracticeDetailsViewModel
            {
                Practice = practice,
                Attendances = practice.Attendances.OrderBy(o => o.Member.FirstLastName).ToList()
            };
            return View(practiceDetailsViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Practice practice) {
            if (!ModelState.IsValid)
                return View();
            if (_practiceRepository.PracticeNumberUsed(practice.PracticeID, practice.PracticeNumber)) {
                TempData["Message"] = $"Practice #{practice.PracticeNumber} has already been used.";
                TempData["Style"] = "alert alert-danger";
                return RedirectToAction("Details", "Practice", new { id = practice.PracticeID });
            }
            _practiceRepository.UpdatePractice(practice);
            TempData["Message"] = $"Practice #{practice.PracticeNumber} has been updated.";
            TempData["Style"] = "alert alert-info";
            return RedirectToAction("Details", "Practice", new { id = practice.PracticeID });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) {
            var practice = _practiceRepository.GetPractice(id);
            if (practice == null)
                return RedirectToAction("List", "Practice");
            if (_practiceRepository.HasParticipants(practice)) {
                TempData["Message"] = $"Practice #{practice.PracticeNumber} has attendees and cannot be deleted.";
                TempData["Style"] = "alert alert-danger";
                return RedirectToAction("Details", "Practice", new { id = practice.PracticeID });
            }
            _practiceRepository.DeletePractice(practice);
            TempData["Message"] = $"Practice #{practice.PracticeNumber} has been deleted.";
            TempData["Style"] = "alert alert-info";
            return RedirectToAction("List", "Practice");
        }
    }
}