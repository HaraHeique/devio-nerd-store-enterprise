using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models.ViewModels
{
    public class ErrorResponseResultViewModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; }
    }
}
