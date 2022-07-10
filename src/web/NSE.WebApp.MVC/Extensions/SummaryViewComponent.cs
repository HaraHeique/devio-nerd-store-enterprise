using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
