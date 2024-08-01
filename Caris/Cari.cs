namespace MyApi.Caris
{ 
    public class Cari
    {
        public int? CariId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? TelNo { get; set; }

        public string? Ulke { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Mahalle { get; set; }
        public string? Sokak { get; set; }
        public string? BinaNo { get; set; } 
        public string? DaireNo { get; set; }

        public string? Banka { get; set; }
        public string? Iban { get; set; }
        public int? Alacak { get; set; } = 0;
        public int? Borc { get; set; } = 0;
        public string? Tarih { get; set; }
        public string? OdemeTipi { get; set; }
        public int? Miktar { get; set; }
        public string? Aciklama { get; set; }
    }
}
