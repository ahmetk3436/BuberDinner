using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
            private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // 1. Validate user exists
            if(_userRepository.GetUserByEmail(query.Email) is not User user)
                {
                    return await Task.FromResult(Domain.Common.Errors.Errors.Authentication.InvalidCredentials);
                }
            // 2. Validate password is correct
            if(user.Password != query.Password)
                {
                    return await Task.FromResult( new[] { Domain.Common.Errors.Errors.Authentication.InvalidCredentials});
                }
            // 3. Create JWT token
            var token = _jwtTokenGenerator.CreateToken(user);
     
           return await    Task.FromResult(new AuthenticationResult(user,
                                           token));
        }
    }
}