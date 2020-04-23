using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LindyCircleMVC.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;

        public HistoryController(IPracticeRepository practiceRepository) {
            _practiceRepository = practiceRepository;
        }
        public ViewResult Index() {
            var currentYearStart = new DateTime(DateTime.Now.Year, 1, 1);
            var historyIndexViewModel = new HistoryIndexViewModel
            {
                StartDate = currentYearStart
            };
            ViewBag.Title = "History";
            return View(historyIndexViewModel);
        }

        public PartialViewResult GetPartial(DateTime? startDate, DateTime? endDate) {
            var historyIndexViewModel = new HistoryIndexViewModel
            {
                StartDate = startDate,
                EndDate = endDate
            };
            return PartialView("_Details", historyIndexViewModel);
        }

        public JsonResult GetData(DateTime? startDate, DateTime? endDate) {
            var practices = _practiceRepository.AllPractices;
            if (startDate != null)
                practices = practices.Where(p => p.PracticeDate >= startDate.Value);
            if (endDate != null)
                practices = practices.Where(p => p.PracticeDate <= endDate.Value);
            practices = practices.OrderBy(o => o.PracticeDate);
            var practiceList = from p in practices
                               select new { p.PracticeDateString, p.AttendeeCount };
            return Json(practiceList);
        }
    }
}