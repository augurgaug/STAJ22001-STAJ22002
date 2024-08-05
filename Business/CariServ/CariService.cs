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
            var existingCari = await _context.Caris.FirstOrDefaultAsync(u => u.name == cari.name && u.last_name == cari.last_name);
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
            var cari = await _context.Caris.FirstOrDefaultAsync(c => c.id == id);
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

            cari.name = updatedCari.name;
            cari.last_name = updatedCari.last_name;
            cari.email = updatedCari.email;
            cari.tel_no = updatedCari.tel_no;
            cari.ulke = updatedCari.ulke;
            cari.il = updatedCari.il;
            cari.ilce = updatedCari.ilce;
            cari.mahalle = updatedCari.mahalle;
            cari.sokak = updatedCari.sokak;
            cari.bina_no = updatedCari.bina_no;
            cari.daire_no = updatedCari.daire_no;
            cari.banka = updatedCari.banka;
            cari.iban = updatedCari.iban;


            _context.Caris.Update(cari);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCarii(int id, Cari updatedCarii)
        {
            var cari = await _context.Caris.FindAsync(id);
            if (cari == null)
            {
                return false;
            }


            cari.borc = updatedCarii.borc;
            cari.alacak = updatedCarii.alacak;


            _context.Caris.Update(cari);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}