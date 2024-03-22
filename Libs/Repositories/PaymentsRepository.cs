using Libs.EF;
using Libs.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IpaymentsRepository : IRepository<Payments>
    {
        Task insertPayment(Payments payments);
        Payments GetPayment(int PaymentId);
    }
    public class PaymentsRepository : RepositoryBase<Payments>, IpaymentsRepository
    {
        public PaymentsRepository(ModelFlightContext dbContext) : base(dbContext)
        {
        }
        public async Task insertPayment(Payments payments)
        {
            await _dbContext.Payments.AddAsync(payments);
        }
        public Payments GetPayment(int PaymentId)
        {
            return _dbContext.Payments.FirstOrDefault(m => m.PaymentID == PaymentId);
        }
    }
}
