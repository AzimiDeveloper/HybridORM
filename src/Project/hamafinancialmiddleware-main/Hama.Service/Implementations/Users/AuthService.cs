using Hama.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Hama.Service.Interfaces.Users;
using Hama.Infrastructure.Repositories.Interfaces;
using Hama.Share.Results;
using Hama.Share.Models.Login;

namespace Hama.Service.Implementations.Users
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepoDbRepository<User> _repoDBBaseRepository;
        private readonly IBaseEfRepository<User> _efBaseRepository;

        public AuthService(
            IBaseRepoDbRepository<User> repoDBBaseRepository,
            IBaseEfRepository<User> efBaseRepository)
        {
            _repoDBBaseRepository = repoDBBaseRepository;
            _efBaseRepository = efBaseRepository;
        }

        public async Task<ServiceResult<User>> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return ServiceResult<User>.Fail(500,"نام کاربری و رمز عبور الزامی است");

            // در حالت واقعی باید پسورد هش شود (SHA256 / BCrypt)
            var user = (await _repoDBBaseRepository.GetAsync(x =>
                x.UserName == request.UserName &&
                x.PasswordHash == request.Password &&
                x.IsActive)).FirstOrDefault();

            if (user == null)
                return ServiceResult<User>.Fail(500,"نام کاربری یا رمز عبور اشتباه است");

            user.LastLogin = DateTime.Now;
            await _repoDBBaseRepository.UpdateAsync(user);

            return ServiceResult<User>.Ok(user, "ورود موفقیت‌آمیز بود",200);
        }
    }
}
