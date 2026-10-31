using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultAboutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
