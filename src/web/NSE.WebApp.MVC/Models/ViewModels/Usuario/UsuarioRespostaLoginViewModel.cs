using NSE.WebApp.MVC.Models.ViewModels;
using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models.ViewModels.Usuario
{
    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
        public ErrorResponseResultViewModel ResponseResult { get; set; }
    }

    public class UsuarioTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaimViewModel> Claims { get; set; }
    }

    public class UsuarioClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
