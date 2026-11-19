using LoginMVCCore.Models;

namespace LoginMVCCore.Repositories
{
    public interface ILoginRepository
    {
        Login ValidateUser(string username, string password);
    }
}
