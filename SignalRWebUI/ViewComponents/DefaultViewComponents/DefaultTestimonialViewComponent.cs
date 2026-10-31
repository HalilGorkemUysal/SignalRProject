using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultTestimonialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
