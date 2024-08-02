namespace MyApi.Finances
{
    public class Finance
    {
        public int FinanceId { get; set; }
        public int? CariId { get; set; }
        public string? OdemeTipi { get; set; }
        public float? Miktar { get; set; }
        public string? Aciklama { get; set; }
        public string? Tarih { get; set; }

    }
}
