using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Common.HashHelper
{
    public class HashPasswordService : IHashPassword
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string PlainPassword, string HashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(PlainPassword, HashedPassword);
        }
    }
}
