using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LindyCircleMVC.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;
        private readonly IDefaultRepository _defaultRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IPunchCardRepository _punchCardRepository;

        public AttendanceController(IPracticeRepository practiceRepository, IDefaultRepository defaultRepository,
            IMemberRepository memberRepository, IAttendanceRepository attendanceRepository,
            IPunchCardRepository punchCardRepository) {
            _practiceRepository = practiceRepository;
            _defaultRepository = defaultRepository;
            _memberRepository = memberRepository;
            _attendanceRepository = attendanceRepository;
            _punchCardRepository = punchCardRepository;
        }
        public ViewResult Index() {
            var attendanceIndexViewModel = new AttendanceIndexViewModel
            {
                PracticeDate = TempData["PracticeDate"] == null ? DateTime.Today :
                    DateTime.Parse(TempData["PracticeDate"].ToString())
            };
            ViewBag.Title = "Attendance";
            return View(attendanceIndexViewModel);
        }

        public PartialViewResult GetPracticeDetails(DateTime practiceDate) {
            var practice = _practiceRepository.GetPracticeByDate(practiceDate);
            var viewName = "_PracticeDetails";
            if (practice == null) {
                practice = new Practice
                {
                    PracticeDate = practiceDate,
                    PracticeNumber = _practiceRepository.GetNextPracticeNumber(),
                    PracticeTopic = string.Empty,
                    PracticeCost = _defaultRepository.GetDefaultValue("Rental cost"),
                    MiscExpense = 0M,
                    MiscRevenue = 0M
                };
                viewName = "_NewPractice";
            }
            var practiceDetailsViewModel = new PracticeDetailsViewModel
            {
                Practice = practice,
                PracticeDate = practiceDate
            };
            return PartialView(viewName, practiceDetailsViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add(Practice practice) {
            if (!ModelState.IsValid) {
                var practiceDetailsViewModel = new PracticeDetailsViewModel
                {
                    PracticeDate = practice.PracticeDate
                };
                return PartialView("_NewPractice", practiceDetailsViewModel); ;
            }
            if (_practiceRepository.PracticeNumberUsed(practice.PracticeID, practice.PracticeNumber)) {
                TempData["Message2"] = $"Practice #{practice.PracticeNumber} has already been used.";
                TempData["Style2"] = "alert alert-danger";
            }
            else {
                practice = _practiceRepository.AddPractice(practice);
                TempData["Message2"] = $"Practice #{practice.PracticeNumber} has been added.";
                TempData["Style2"] = "alert alert-info";
            }
            TempData["PracticeDate"] = practice.PracticeDate;
            return RedirectToAction("Index", "Attendance");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Practice practice) {
            if (!ModelState.IsValid) {
                var practiceDetailsViewModel = new PracticeDetailsViewModel
                {
                    Practice = _practiceRepository.GetPractice(practice.PracticeID),
                    PracticeDate = practice.PracticeDate
                };
                return PartialView("_PracticeDetails", practiceDetailsViewModel);
            }
            if (_practiceRepository.PracticeNumberUsed(practice.PracticeID, practice.PracticeNumber)) {
                TempData["Message2"] = $"Practice #{practice.PracticeNumber} has already been used.";
                TempData["Style2"] = "alert alert-danger";
            }
            else {
                _practiceRepository.UpdatePractice(practice);
                TempData["Message2"] = $"Practice #{practice.PracticeNumber} has been updated.";
                TempData["Style2"] = "alert alert-info";
            }
            TempData["PracticeDate"] = practice.PracticeDate;
            return RedirectToAction("Index", "Attendance");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePractice(int id) {
            var practice = _practiceRepository.GetPractice(id);
            if (practice.AttendeeCount > 0) {
                TempData["Message2"] = $"Practice #{practice.PracticeNumber} has attendees and cannot be deleted.";
                TempData["Style2"] = "alert alert-danger";
                TempData["PracticeDate"] = practice.PracticeDate;
                return RedirectToAction("Index", "Attendance");
            }
            _practiceRepository.DeletePractice(practice);
            TempData["Message2"] = $"Practice #{practice.PracticeNumber} has been deleted.";
            TempData["Style2"] = "alert alert-danger";
            TempData["PracticeDate"] = practice.PracticeDate;
            return RedirectToAction("Index", "Attendance");
        }

        public PartialViewResult GetMembersPartial(int practiceID) {
            var attendanceMembersViewModel = new AttendanceMembersViewModel
            {
                PracticeID = practiceID,
                Members = _memberRepository.GetPracticeMemberList(practiceID).ToList()
            };
            return PartialView("_Members", attendanceMembersViewModel);
        }

        public PartialViewResult CheckInPartial(int practiceID, int memberID) {
            var member = _memberRepository.GetMember(memberID);
            var paymentOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "None" },
                    new SelectListItem { Value = "1", Text = "Cash" },
                    new SelectListItem { Value = "2", Text = "Punch card" },
                    new SelectListItem { Value = "3", Text = "Other" }
                };
            if (member.RemainingPunches == 0)
                paymentOptions.RemoveAt(2);
            var attendanceCheckInViewModel = new AttendanceCheckInViewModel
            {
                Practice = _practiceRepository.GetPractice(practiceID),
                Member = member,
                PaymentMethods = paymentOptions,
                AdmissionCost = _defaultRepository.GetDefaultValue("Door price"),
                Attendances = _attendanceRepository.GetAttendancesByPractice(practiceID).ToList()
            };
            return PartialView("_CheckInForm", attendanceCheckInViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CheckIn(int memberID, int practiceID, int paymentType, decimal paymentAmount) {
            var attendance = new Attendance
            {
                MemberID = memberID,
                PracticeID = practiceID,
                PaymentType = paymentType,
                PaymentAmount = paymentAmount
            };
            if (paymentType == 2) {
                var punchCard = _punchCardRepository.GetUsablePunchCard(memberID);
                _attendanceRepository.AddAttendance(attendance, punchCard);
            }
            else _attendanceRepository.AddAttendance(attendance);
            var attendanceMembersViewModel = new AttendanceMembersViewModel
            {
                PracticeID = practiceID,
                Members = _memberRepository.GetPracticeMemberList(practiceID).ToList()
            };
            return PartialView("_Members", attendanceMembersViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAttendance(int id) {
            var attendance = _attendanceRepository.GetAttendance(id);
            var practiceID = attendance.PracticeID;
            _attendanceRepository.DeleteAttendance(attendance);
            var attendanceMembersViewModel = new AttendanceMembersViewModel
            {
                PracticeID = practiceID,
                Members = _memberRepository.GetPracticeMemberList(practiceID).ToList()
            };
            return PartialView("_Members", attendanceMembersViewModel);
        }
    }
}