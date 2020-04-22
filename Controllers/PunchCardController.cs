using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LindyCircleMVC.Controllers
{
    public class PunchCardController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IPunchCardRepository _punchCardRepository;
        private readonly IDefaultRepository _defaultRepository;

        public PunchCardController(IMemberRepository memberRepository,
            IPunchCardRepository punchCardRepository, IDefaultRepository defaultRepository) {
            _memberRepository = memberRepository;
            _punchCardRepository = punchCardRepository;
            _defaultRepository = defaultRepository;
        }

        public ViewResult Index() {
            var punchCardIndexViewModel = new PunchCardIndexViewModel
            {
                Members = _memberRepository.GetMemberList(),
                NewPunchCard = new PunchCard
                {
                    PurchaseAmount = _defaultRepository.GetDefaultValue("Punch card price"),
                    PurchaseDate = DateTime.Today
                },
                SelectedMemberID = TempData["SelectedMemberID"] == null ? "0" : TempData["SelectedMemberID"].ToString()
            };
            ViewBag.Title = "Punch Cards";
            return View(punchCardIndexViewModel);
        }

        [HttpPost]
        public IActionResult Purchase(PunchCard newPunchCard) {
            TempData["SelectedMemberID"] = newPunchCard.PurchaseMemberID;
            _punchCardRepository.PurchasePunchCard(newPunchCard);
            return RedirectToAction("Index", "PunchCard");
        }

        public PartialViewResult GetPartial(int memberID) {
            var punchCardListViewModel = new PunchCardListViewModel
            {
                PunchCards = _punchCardRepository.GetPunchCardsByMember(memberID).ToList(),
                SelectedMember = _memberRepository.GetMember(memberID)
            };
            return PartialView("_PunchCardList", punchCardListViewModel);
        }

        public IActionResult Delete(int punchCardID, int memberID) {
            var punchCard = _punchCardRepository.GetPunchCard(punchCardID);
            if (punchCard.RemainingPunches < 5)
                TempData["Message"] = "Unable to delete used punch card.";
            else {
                _punchCardRepository.DeletePunchCard(punchCard);
                TempData["Message"] = "Punch card deleted.";
            }
                TempData["Style"] = "alert alert-danger";
                TempData["SelectedMemberID"] = memberID;
            return RedirectToAction("Index", "PunchCard");
        }
    }
}