using Microsoft.AspNetCore.Http;

namespace AkarSoft.Core.Extentions.HttpContextExtentions
{
    public static class HttpContextExtentions
    {
        public static bool TryGetValueWithCastingTypeForCookie<T>(this IHttpContextAccessor accessor, string key, out T value)
        {
            var CookieString = string.Empty;
            accessor.HttpContext.Request.Cookies.TryGetValue(key, out CookieString);
            if (CookieString != string.Empty)
            {
                value = System.Text.Json.JsonSerializer.Deserialize<T>(CookieString);
                return true;
            }
            else
            {
                value = default;
                return false;
            }

        }

        public static bool TryGetValueWithCastingTypeForSession<T>(this IHttpContextAccessor accessor, string key, out T value)
        {
            var CookieString = string.Empty;
            CookieString= accessor.HttpContext.Session.GetString(key);
            if (CookieString != string.Empty)
            {
                value = System.Text.Json.JsonSerializer.Deserialize<T>(CookieString);
                return true;
            }
            else
            {
                value = default;
                return false;
            }

        }
    }
}
