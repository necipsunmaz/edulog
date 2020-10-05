using Microsoft.AspNetCore.Http;
using EduLog.Core.Entities.Concrete;
using System;
using System.Linq;

namespace EduLog.Core.Utilities.Middleware
{
    public class AuthUser : HttpContextAccessor, IAuthUser
    {
        public string GetHeaderValue(string key)
        {
            HttpContext.Request.Headers.TryGetValue(key, out var names);
            return names.FirstOrDefault();
        }

        public int GetUserId() => int.TryParse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value, out int id) ? id : default;

        public UserRoles? GetUserRoleId() => (UserRoles)Enum.Parse(typeof(UserRoles), HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userRoleId")?.Value);

        public string GetHeaders()
        {
            string headers = null;
            foreach (var key in HttpContext.Request.Headers.Keys)
                headers += $"{key} = {HttpContext.Request.Headers[key]}{Environment.NewLine}";
            return headers;
        }

        public string GetRemoteIpAddress() => HttpContext.Connection.RemoteIpAddress.ToString();
    }
}