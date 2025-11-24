using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.JWT.JWTService
{
    public class JwtService(IConfiguration _configuration) : IJwtService
    {
        public Task<string> GenerateRefreshToken()
        {
            return System.Threading.Tasks.Task.FromResult(Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)));
        }

        public Task<string> GenerateToken(int UserId, string? Email, Role role)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var keyString = jwtSettings["Key"];
            
            if (string.IsNullOrEmpty(keyString))
                throw new InvalidOperationException("JWT Key is not configured. Please set 'Jwt:Key' in appsettings.json");
            
            if (keyString.Length < 32)
                throw new InvalidOperationException($"JWT Key must be at least 32 characters long for HS256 algorithm. Current length: {keyString.Length}");
            
            var key = Encoding.UTF8.GetBytes(keyString);
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"]!));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, Email ?? string.Empty),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return System.Threading.Tasks.Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
