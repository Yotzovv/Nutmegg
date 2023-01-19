using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.Web.Areas.Information.Controllers
{
    [Area("TermsOfUse")]
    public class TermsOfUseController : Controller
    {
        [Route("termsOfuse")]
        public IActionResult TermsOfUse()
        {
            return View();
        }

        [Route("dataProtection")]
        public IActionResult DataProtection()
        {
            return View();
        }
    }
}
