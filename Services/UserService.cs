using ProjectsApi.Entities;
using ProjectsApi.Helpers;
using System;
using System.Linq;

namespace ProjectsApi.Services
{
    public class UserService: IUserService
    {
        public UserService(DataContext context)
        {
            _context = context;
        }

        #region Fields
        private DataContext _context;
        #endregion

        #region Public Methods
        public User Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            if (user == null) return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        public User GetById(string id)
        {
            return _context.Users.Find(id);
        }
        #endregion

        #region Private Methods
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        #endregion
    }
}
