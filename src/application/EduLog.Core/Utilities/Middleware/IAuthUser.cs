using Microsoft.AspNetCore.Http;
using EduLog.Core.Entities.Concrete;

namespace EduLog.Core.Utilities.Middleware
{
    public interface IAuthUser : IHttpContextAccessor
    {
        string GetHeaders();

        string GetHeaderValue(string key);

        int GetUserId();

        UserRoles? GetUserRoleId();

        string GetRemoteIpAddress();
    }
}