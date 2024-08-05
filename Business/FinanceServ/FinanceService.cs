using MyApi.Data;
using MyApi.Finances;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Business.FinanceServ
{
    public class FinanceService
    {
        private readonly MyDbContext _context;

        public FinanceService(MyDbContext context)
        {
            _context = context;
        }


        public async Task<Finance?> AddFinance(Finance finance)
        {
            
            _context.Finances.Add(finance);
            await _context.SaveChangesAsync();
            return finance;
        }



        public async Task<List<Finance>> GetFinances()
        {
            return await _context.Finances.ToListAsync();
        }


        public async Task<Finance?> GetFinanceById(int id)
        {
            return await _context.Finances
                                 .FirstOrDefaultAsync(f => f.id == id);
        }

    }
}