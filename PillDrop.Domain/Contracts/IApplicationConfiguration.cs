namespace PillDrop.Domain.Contracts
{
    public interface IApplicationConfiguration
    {
        string GetSetting(string key);
    }
}