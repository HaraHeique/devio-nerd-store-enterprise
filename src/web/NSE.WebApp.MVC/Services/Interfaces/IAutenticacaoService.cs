using NSE.WebApp.MVC.Models.ViewModels.Usuario;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin);
        Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}
