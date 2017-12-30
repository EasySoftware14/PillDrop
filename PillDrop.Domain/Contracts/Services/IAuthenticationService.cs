using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IAuthenticationService
    {
        User Validate(string username, string password);
        string GetPasswordHash(string userName, string password);
        bool CredentialsIsValid(User user, string userName, string password);
    }
}