namespace NSE.WebApp.MVC.Models
{
    public class ResponseResultViewModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; } = new ResponseErrorMessages();
    }

    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; } = new List<string>();
    }
}
