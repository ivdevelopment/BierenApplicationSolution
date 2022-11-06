using Microsoft.AspNetCore.Mvc;

namespace BierenApplication.ViewComponents
{
    public class MijnFooter : ViewComponent
    {
        public IViewComponentResult Invoke(string footerTekst)
        {
            return View((object)footerTekst);
        }
    }
}
