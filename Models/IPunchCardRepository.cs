using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardRepository
    {
        IEnumerable<PunchCard> GetPunchCardsPurchasedByMember(int memberID);
        IEnumerable<PunchCard> GetPunchCardsHeldByMember(int memberID);
        PunchCard GetPunchCard(int punchCardID);
    }
}
