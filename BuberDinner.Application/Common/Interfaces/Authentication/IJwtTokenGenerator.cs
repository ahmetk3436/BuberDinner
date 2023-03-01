using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
         string CreateToken(User user);
    }
}