namespace MyApi.Caris
{
    public class Cari
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? tel_no { get; set; }

        public string? ulke { get; set; }
        public string? il { get; set; }
        public string? ilce { get; set; }
        public string? mahalle { get; set; }
        public string? sokak { get; set; }
        public string? bina_no { get; set; }
        public string? daire_no { get; set; }

        public string? banka { get; set; }
        public string? iban { get; set; }
        public decimal? alacak { get; set; } = 0;
        public decimal? borc { get; set; } = 0;
      
    }
}