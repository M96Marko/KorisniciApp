using Dal;

namespace Dto
{
    public class MjestoMapper
    {
        public MjestoDto Map(MjestoDto dto, tblMjesto db)
        {
            dto = new MjestoDto();

            dto.Id = db.Id;
            dto.Naziv = db.Naziv;

            return dto;
        }

        public tblMjesto Map(tblMjesto db, MjestoDto dto)
        {
            db = new tblMjesto();

            db.Id = dto.Id;
            db.Naziv = dto.Naziv;

            return db;
        }
    }
}
