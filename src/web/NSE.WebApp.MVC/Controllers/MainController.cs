using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
    public abstract class MainController : Controller
    {
        protected bool ResponsePossuiErros(ErrorResponseResultViewModel resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                AdicionarErros(resposta.Errors.Mensagens);

                return true;
            }

            return false;
        }

        private void AdicionarErros(List<string> erros)
        {
            foreach (var mensagem in erros)
                ModelState.AddModelError(string.Empty, mensagem);
        }
    }
}
