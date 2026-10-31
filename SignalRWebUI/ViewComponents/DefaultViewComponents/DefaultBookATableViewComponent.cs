using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultBookATableViewComponent  :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
