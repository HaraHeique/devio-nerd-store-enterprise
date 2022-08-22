using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public abstract class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResultViewModel resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                AdicionarErros(resposta.Errors.Mensagens.ToArray());

                return true;
            }

            return false;
        }

        protected void AdicionarErros(params string[] erros)
        {
            foreach (var mensagem in erros)
                ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida() => ModelState.ErrorCount == 0;

        protected bool OperacaoInvalida() => !OperacaoValida();
    }
}
