using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        public IActionResult Purchase(PunchCard newPunchCard, string ddlSelectMembers) {
            var memberID = int.Parse(ddlSelectMembers);
            newPunchCard.PurchaseMemberID = memberID;
            TempData["SelectedMemberID"] = memberID;
            _punchCardRepository.PurchasePunchCard(newPunchCard);
            return RedirectToAction("Index", "PunchCard");
        }

        public PartialViewResult GetPartial(int selectedMemberID) {
            var punchCardListViewModel = new PunchCardListViewModel
            {
                PunchCards = _punchCardRepository.GetPunchCardsByMember(selectedMemberID).ToList(),
                SelectedMember = _memberRepository.GetMember(selectedMemberID)
            };
            return PartialView("_PunchCardList", punchCardListViewModel);
        }

        public IActionResult Delete(int punchCardID, int memberID) {
            _punchCardRepository.DeletePunchCard(punchCardID);
            TempData["Message"] = "Punch card deleted.";
            TempData["Style"] = "alert alert-danger";
            TempData["SelectedMemberID"] = memberID;
            return RedirectToAction("Index", "PunchCard");
        }

        public ViewResult Transfer(int punchCardID, int memberID) {
            var punchCardTransferViewModel = new PunchCardTransferViewModel
            {
                CurrentMember = _memberRepository.GetMember(memberID),
                PunchCard = _punchCardRepository.GetPunchCard(punchCardID),
                TransferMembers = _memberRepository.GetTransferMemberList(memberID)
            };
            ViewBag.Title = "Transfer Punch Card";
            return View(punchCardTransferViewModel);
        }

        [HttpPost]
        public IActionResult Transfer(PunchCard punchCard, string ddlTransferMembers) {
            punchCard.CurrentMemberID = int.Parse(ddlTransferMembers);
            TempData["SelectedMemberID"] = punchCard.CurrentMemberID;
            _punchCardRepository.TransferPunchCard(punchCard);
            TempData["Message"] = "Punch card transferred.";
            TempData["Style"] = "alert alert-info";
            return RedirectToAction("Index", "PunchCard");
        }
    }
}