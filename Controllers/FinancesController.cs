using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Controllers
{
    [Authorize(Roles = "Admin")]
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
            ViewBag.Title = "Finances";
            return View();
        }

        public PartialViewResult GetPartial(DateTime? startDate, DateTime? endDate) {
            var practices = _practiceRepository.AllPractices.OrderBy(o => o.PracticeDate);
            var practiceList = GetPracticeDetails(practices.ToList());
            if (startDate != null)
                practiceList = practiceList.Where(p => p.PracticeDate >= startDate.Value).ToList();
            if (endDate != null)
                practiceList = practiceList.Where(p => p.PracticeDate <= endDate.Value).ToList();
            return PartialView("_Details", practiceList);
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