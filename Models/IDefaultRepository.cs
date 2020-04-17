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
