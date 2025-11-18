using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.JWT.JWTService
{
    public interface IJwtService
    {
        Task<string> GenerateToken(int UserId, string? Email, Role role);
        Task<string> GenerateRefreshToken();
    }
}
