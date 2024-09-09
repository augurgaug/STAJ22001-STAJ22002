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
            // return await _context.Finances.ToListAsync();

            return await _context.Finances
                       .Include(f => f.Cari) 
                       .ToListAsync();
        }


        public async Task<Finance?> GetFinanceById(int id)
        {
            return await _context.Finances
                                  .Include(f => f.Cari)

                                 .FirstOrDefaultAsync(f => f.id == id);
        }




        public async Task<int> GetFinancesCount()
        {
            return await _context.Finances.CountAsync();
        }

        public async Task<int> GetFinancesNOCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Nakit Ödeme");
        }

        public async Task<int> GetFinancesNTCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Nakit Tahsilat");
        }

        public async Task<int> GetFinancesGiHCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Giden Havale");
        }

        public async Task<int> GetFinancesGeHCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Gelen Havale");
        }

        public async Task<int> GetFinancesKKCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Kredi Kartý Ýle Ödeme");
        }

        public async Task<int> GetFinancesPTCount()
        {
            return await _context.Finances.CountAsync(f => f.odeme_tipi == "Pos Tahsilat");
        }

    }
}