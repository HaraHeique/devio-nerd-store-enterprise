﻿using NSE.Core.Data;

namespace NSE.Pedidos.Domain.Vouchers.Interfaces
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher?> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);
    }
}
