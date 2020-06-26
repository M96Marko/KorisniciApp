using Dto;
using System.Collections.Generic;

namespace Service
{
    public interface IKorisnikService
    {
        KorisnikDto Create();
        List<KorisnikDto> GetAllKorisnici();
        KorisnikDto GetById(long id);
        KorisnikDto Save(KorisnikDto korisnik);
        bool Delete(long id);
    }
}
