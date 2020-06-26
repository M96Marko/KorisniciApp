using Dal;
using Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class MjestoService : IMjestoService
    {
        KorisniciContext context;

        public MjestoService()
        {
            context = new KorisniciContext();
        }

        public List<MjestoDto> GetAllMjesta()
        {
            var dataQuery = context.tblMjesto.AsNoTracking()
               .Select(x => new MjestoDto()
               {
                   Id = x.Id,
                   Naziv = x.Naziv
               });

            return dataQuery.ToList();
        }
    }
}
