using Hama.Core.Models;
using Hama.Share.Models.Login;
using Hama.Share.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Service.Interfaces.Users
{
    public interface IAuthService
    {
        Task<ServiceResult<User>> LoginAsync(LoginRequest request);
    }
}
