using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardRepository
    {
        IEnumerable<PunchCard> GetPunchCardsPurchasedByMember(int memberID);
        IEnumerable<PunchCard> GetPunchCardsHeldByMember(int memberID);
        PunchCard GetPunchCard(int punchCardID);
    }
}
