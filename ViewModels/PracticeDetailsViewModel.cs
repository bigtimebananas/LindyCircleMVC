﻿using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class PracticeDetailsViewModel {
        public Practice Practice { get; set; }
        public IList<Attendance> Attendances { get; set; }
        public DateTime PracticeDate { get; set; }
    }
}
