namespace Dal
{
    public class tblKorisnik
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojMobitela { get; set; }
        public int MjestoId { get; set; }
        public string Email { get; set; }
        public char Spol { get; set; }

        public virtual tblMjesto Mjesto { get; set; }
    }
}
