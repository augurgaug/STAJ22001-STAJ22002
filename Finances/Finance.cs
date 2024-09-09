using MyApi.Caris;

namespace MyApi.Finances
{
    public class Finance
    {
        public int id { get; set; }
        public int? cari_id { get; set; }
        public string? odeme_tipi { get; set; }
        public decimal? miktar { get; set; }
        public string? aciklama { get; set; }
        public DateTime? tarih { get; set; }

        public Cari? Cari { get; set; }

    }
}
