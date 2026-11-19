using LoginMVCCore.Models;

namespace LoginMVCCore.Repositories
{
    public class LoginRepositary : ILoginRepository
    {
        private readonly LoginDbContext _context;

        public LoginRepositary(LoginDbContext context)
        {
            _context = context;
        }

        public Login ValidateUser(string username, string password)
        {
            return _context.Logins.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
