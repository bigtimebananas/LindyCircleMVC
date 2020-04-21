using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LindyCircleMVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository) {
            _memberRepository = memberRepository;
        }

        public ViewResult List(bool activeOnly = true) {
            var membersListViewModel = new MembersListViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                ActiveOnly = activeOnly,
                Message = TempData["Message"] != null ? TempData["Message"].ToString() : string.Empty
            };
            ViewBag.Title = "Members";
            return View(membersListViewModel);
        }

        [HttpPost]
        public IActionResult List(Member newMember) {
            if (!ModelState.IsValid)
                return View();

            _memberRepository.AddMember(newMember);
            TempData["Message"] = $"{newMember.FirstLastName} added.";
            return RedirectToAction("List", "Member");
        }

        public IActionResult GetPartial(bool activeOnly) {
            var membersListViewModel = new MembersListViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                ActiveOnly = activeOnly
            };
            return PartialView("_MemberList", membersListViewModel);
        }

        public IActionResult Details(int id) {
            var member = _memberRepository.GetMember(id);
            if (member == null)
                return RedirectToAction("List", "Member");
            ViewBag.Title = member.FirstLastName;
            return View(member);
        }

        [HttpPost]
        public IActionResult ToggleActive(Member member) {
            member.Inactive = !member.Inactive;
            _memberRepository.UpdateMember(member);
            return RedirectToAction("Details", "Member", new { id = member.MemberID });
        }

        public IActionResult Edit(int id) {
            var member = _memberRepository.GetMember(id);
            if (member == null)
                return RedirectToAction("List", "Member");
            ViewBag.Title = member.FirstLastName;
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member) {
            _memberRepository.UpdateMember(member);
            return RedirectToAction("Details", "Member", new { id = member.MemberID });
        }
    }
}