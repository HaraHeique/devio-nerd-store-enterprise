using Microsoft.AspNetCore.Mvc;

namespace NSE.WebApp.MVC.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
