using Dal;

namespace Dto
{
    public static class KorisnikMapper
    {
        public static KorisnikDto Map(tblKorisnik db, KorisnikDto dto = null)
        {
            dto = new KorisnikDto();

            dto.Id = db.Id;
            dto.Ime = db.Ime;
            dto.Prezime = db.Prezime;
            dto.Adresa = db.Adresa;
            dto.BrojMobitela = db.BrojMobitela;
            dto.MjestoId = db.MjestoId;
            dto.Email = db.Email;
            dto.Spol = db.Spol;

            return dto;
        }

        public static tblKorisnik Map(KorisnikDto dto, tblKorisnik db = null)
        {
            db.Id = dto.Id;
            db.Ime = dto.Ime;
            db.Prezime = dto.Prezime;
            db.Adresa = dto.Adresa;
            db.BrojMobitela = dto.BrojMobitela;
            db.MjestoId = dto.MjestoId;
            db.Email = dto.Email;
            db.Spol = dto.Spol;

            return db;
        }
    }
}
