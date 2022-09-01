using Microsoft.AspNetCore.Mvc;
using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.API.Application.Queries.Interfaces;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Pedidos.API.Controllers
{
    public class VoucherController : MainController
    {
        private readonly IVoucherQueries _voucherQueries;

        public VoucherController(IVoucherQueries voucherQueries)
        {
            _voucherQueries = voucherQueries;
        }

        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return NotFound();

            var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

            return voucher is null ? NotFound() : CustomResponse(voucher);
        }
    }
}
