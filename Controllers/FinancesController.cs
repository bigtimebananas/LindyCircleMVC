using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Controllers
{
    public class FinancesController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;
        private readonly IPunchCardRepository _punchCardRepository;

        public FinancesController(IPracticeRepository practiceRepository, IPunchCardRepository punchCardRepository) {
            _practiceRepository = practiceRepository;
            _punchCardRepository = punchCardRepository;
        }
        public ViewResult Index()
        {
            var practices = _practiceRepository.AllPractices.OrderBy(o => o.PracticeDate);
            var practiceList = GetPracticeDetails(practices.ToList());
            var financesIndexViewModel = new FinancesIndexViewModel
            {
                Practices = practiceList
            };
            ViewBag.Title = "Finances";
            return View(financesIndexViewModel);
        }

        public PartialViewResult GetPartial(DateTime? startDate, DateTime? endDate) {
            var practices = _practiceRepository.AllPractices.OrderBy(o => o.PracticeDate);
            if (startDate != null)
                practices = practices.Where(p => p.PracticeDate >= startDate.Value).OrderBy(o => o.PracticeDate);
            if (endDate != null)
                practices = practices.Where(p => p.PracticeDate <= endDate.Value).OrderBy(o => o.PracticeDate);
            var practiceList = GetPracticeDetails(practices.ToList());
            var financesIndexViewModel = new FinancesIndexViewModel
            {
                Practices = practiceList
            };
            return PartialView("_Details", financesIndexViewModel);
        }

        private List<Practice> GetPracticeDetails(List<Practice> practices) {
            var punchCards = _punchCardRepository.AllPunchCards;
            foreach (var practice in practices) {
                var index = practices.FindIndex(p => p.PracticeID == practice.PracticeID);
                if (index == 0) {
                    practice.PunchCardsSold = punchCards.Where(p => p.PurchaseDate <= practice.PracticeDate).Count();
                    practice.PunchCardRevenue = punchCards.Where(p => p.PurchaseDate <= practice.PracticeDate).Sum(p => p.PurchaseAmount);
                }
                else {
                    practice.PunchCardsSold = punchCards.Where(p => p.PurchaseDate <= practice.PracticeDate &&
                        p.PurchaseDate > practices[index - 1].PracticeDate).Count();
                    practice.PunchCardRevenue = punchCards.Where(p => p.PurchaseDate <= practice.PracticeDate &&
                        p.PurchaseDate > practices[index - 1].PracticeDate).Sum(p => p.PurchaseAmount);
                }
            }
            return practices;
        }
    }
}