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
    public class AttendanceController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;
        private readonly IDefaultRepository _defaultRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IPracticeRepository practiceRepository, IDefaultRepository defaultRepository,
            IMemberRepository memberRepository, IAttendanceRepository attendanceRepository) {
            _practiceRepository = practiceRepository;
            _defaultRepository = defaultRepository;
            _memberRepository = memberRepository;
            _attendanceRepository = attendanceRepository;
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
            if (practice == null) {
                practice = new Practice
                {
                    PracticeID = 0,
                    PracticeDate = practiceDate,
                    PracticeNumber = _practiceRepository.GetNextPracticeNumber(),
                    PracticeTopic = string.Empty,
                    PracticeCost = _defaultRepository.GetDefaultValue("Rental cost"),
                    MiscExpense = 0M,
                    MiscRevenue = 0M
                };
            }
            var practiceDetailsViewModel = new PracticeDetailsViewModel
            {
                Practice = practice,
                PracticeDate = practiceDate
            };
            if (practice.PracticeID == 0)
                return PartialView("_NewPractice", practiceDetailsViewModel);
            else return PartialView("_PracticeDetails", practiceDetailsViewModel);
        }

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

        public IActionResult Delete(int id) {
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

        public PartialViewResult CheckInPartial(int practiceID) {
            var paymentOptions = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "None" },
                    new SelectListItem { Value = "1", Text = "Cash" },
                    new SelectListItem { Value = "2", Text = "Punch card" },
                    new SelectListItem { Value = "3", Text = "Other" }
                };
            var attendanceCheckInViewModel = new AttendanceCheckInViewModel
            {
                Practice = _practiceRepository.GetPractice(practiceID),
                MembersList = _memberRepository.GetPracticeMemberList(practiceID),
                Members = _memberRepository.GetMembers(true),
                PaymentMethods = paymentOptions,
                AdmissionCost = _defaultRepository.GetDefaultValue("Door price"),
                Attendances = _attendanceRepository.GetAttendancesByPractice(practiceID).ToList()
            };
            return PartialView("_CheckInForm", attendanceCheckInViewModel);
        }
    }
}