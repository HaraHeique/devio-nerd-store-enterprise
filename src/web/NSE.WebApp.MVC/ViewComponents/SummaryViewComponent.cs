using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
