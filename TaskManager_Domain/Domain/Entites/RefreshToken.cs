using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain.Domain.Entites
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiresOnUtc { get; set; }

        virtual public User? User { get; set; }

        public RefreshToken() { }

        public RefreshToken( string? token, int userId, DateTime expiresOnUtc)
        {
            Token = token;
            UserId = userId;
            ExpiresOnUtc = expiresOnUtc;
        }
    }
}
