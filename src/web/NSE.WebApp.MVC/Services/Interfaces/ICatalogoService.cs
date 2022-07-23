using NSE.WebApp.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
