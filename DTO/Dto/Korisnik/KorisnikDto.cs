namespace Dto
{
    public class KorisnikDto
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojMobitela { get; set; }
        public int MjestoId { get; set; }
        public MjestoDto MjestoLookup { get; set; }
        public string Email { get; set; }
        public char Spol { get; set; }
    }
}
