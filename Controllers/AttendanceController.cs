using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LindyCircleMVC.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IPracticeRepository _practiceRepository;

        public AttendanceController(IPracticeRepository practiceRepository) {
            _practiceRepository = practiceRepository;
        }
        public ViewResult Index()
        {
            var attendanceIndexViewModel = new AttendanceIndexViewModel
            {
                PracticeDate = DateTime.Today
            };
            return View(attendanceIndexViewModel);
        }

        public PartialViewResult PracticeDetails(DateTime practiceDate) {
            var practice = _practiceRepository.GetPracticeByDate(practiceDate);

            return PartialView();
        }
    }
}