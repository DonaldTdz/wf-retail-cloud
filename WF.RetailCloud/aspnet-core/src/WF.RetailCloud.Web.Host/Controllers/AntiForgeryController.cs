using Microsoft.AspNetCore.Antiforgery;
using WF.RetailCloud.Controllers;

namespace WF.RetailCloud.Web.Host.Controllers
{
    public class AntiForgeryController : RetailCloudControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

