using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IDefaultRepository
    {
        Default GetDefault(string defaultName);
        Default GetDefault(int defaultID);
        decimal GetDefaultValue(string defaultName);
        decimal GetDefaultValue(int defaultID);
    }
}
