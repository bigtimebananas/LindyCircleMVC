using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardRepository
    {
        IEnumerable<PunchCard> GetPunchCardsPurchasedByMember(int memberID);
        IEnumerable<PunchCard> GetPunchCardsHeldByMember(int memberID);
        PunchCard GetPunchCard(int punchCardID);
        PunchCard PurchasePunchCard(PunchCard punchCard);
        PunchCard TransferPunchCard(PunchCard punchCard);
        void DeletePunchCard(PunchCard punchCard);
    }
}
