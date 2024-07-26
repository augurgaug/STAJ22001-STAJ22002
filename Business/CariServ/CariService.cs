using MyApi.Data;
using MyApi.Caris;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Business.CariServ
{
    public class CariService
    {
        private readonly MyDbContext _context;

        public CariService(MyDbContext context)
        {
            _context = context;
        }



        public async Task<Cari?> PostCari(Cari cari)
        {
            var existingCari = await _context.Caris.FirstOrDefaultAsync(u => u.Name == cari.Name && u.LastName == cari.LastName);
            if (existingCari != null)
            {
                return null;
            }
            _context.Caris.Add(cari);
            await _context.SaveChangesAsync();
            return cari;
        }

        public async Task<Cari?> GetCari(int id)
        {
            var cari = await _context.Caris.FindAsync(id);
            return cari ?? null;
        }

        public async Task<List<Cari>> GetCaris()
        {
            return await _context.Caris.ToListAsync();
        }

        public async Task<bool> DeleteCari(int id)
        {
            var cari = await _context.Caris.FirstOrDefaultAsync(c => c.CariId == id);
            if (cari == null)
            {
                return false;
            }

            _context.Caris.Remove(cari);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCari(int id, Cari updatedCari)
        {
            var cari = await _context.Caris.FindAsync(id);
            if (cari == null)
            {
                return false;
            }

            cari.Name = updatedCari.Name;
            cari.LastName = updatedCari.LastName;
            cari.Email = updatedCari.Email;
            cari.TelNo = updatedCari.TelNo;
            cari.Ulke = updatedCari.Ulke;
            cari.Il = updatedCari.Il;
            cari.Ilce = updatedCari.Ilce;
            cari.Mahalle = updatedCari.Mahalle;
            cari.Sokak = updatedCari.Sokak;
            cari.BinaNo = updatedCari.BinaNo;
            cari.DaireNo = updatedCari.DaireNo;
            cari.Banka = updatedCari.Banka;
            cari.Iban = updatedCari.Iban;

            _context.Caris.Update(cari);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
