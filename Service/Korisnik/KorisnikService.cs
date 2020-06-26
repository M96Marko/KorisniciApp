using Dal;
using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Service
{
    public class KorisnikService : IKorisnikService
    {
        KorisniciContext context;

        public KorisnikService()
        {
            context = new KorisniciContext();
        }

        public KorisnikDto Create()
        {
            var dto = new KorisnikDto()
            {
                Id = GetNextId(),
                Ime = string.Empty,
                Prezime = string.Empty,
                Adresa = string.Empty,
                BrojMobitela = string.Empty,
                MjestoId = 0,
                Email = string.Empty,
                Spol = char.MinValue
            };

            return dto;
        }

        public List<KorisnikDto> GetAllKorisnici()
        {
            var dataQuery = context.tblKorisnik.AsNoTracking()
               .Select(x => new KorisnikDto()
               {
                   Id = x.Id,
                   Ime = x.Ime,
                   Prezime = x.Prezime,
                   Adresa = x.Adresa,
                   BrojMobitela = x.BrojMobitela,
                   MjestoId = x.MjestoId,
                   MjestoLookup = new MjestoDto()
                   {
                       Id = x.Mjesto.Id,
                       Naziv = x.Mjesto.Naziv
                   },
                   Email = x.Email,
                   Spol = x.Spol
               });

            return dataQuery.ToList();
        }

        public KorisnikDto GetById(long id)
        {
            var dataQuery = context.tblKorisnik.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new KorisnikDto()
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Adresa = x.Adresa,
                    BrojMobitela = x.BrojMobitela,
                    MjestoId = x.MjestoId,
                    MjestoLookup = new MjestoDto()
                    {
                        Id = x.Mjesto.Id,
                        Naziv = x.Mjesto.Naziv
                    },
                    Email = x.Email,
                    Spol = x.Spol
                });

            return dataQuery.SingleOrDefault();
        }

        public KorisnikDto Save(KorisnikDto korisnik)
        {
            tblKorisnik dbKorisnik = new tblKorisnik(); ;

            try
            {
                dbKorisnik = context.tblKorisnik.Find(korisnik.Id);

                if (dbKorisnik != null)
                {
                    KorisnikMapper.Map(korisnik, dbKorisnik);
                    //context.Entry(dbKorisnik).State = EntityState.Modified;
                }
                else
                {
                    dbKorisnik = new tblKorisnik();
                    KorisnikMapper.Map(korisnik, dbKorisnik);
                    context.tblKorisnik.Add(dbKorisnik);
                }
                
                context.SaveChanges();

                context.Dispose();

                var newKorisnikDto = KorisnikMapper.Map(dbKorisnik);

                return newKorisnikDto;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var deleteEntity = context.tblKorisnik.Find(id);

                context.tblKorisnik.Remove(deleteEntity);
                context.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }
        }

        private long GetNextId()
        {
            var nextId = context.tblKorisnik.AsNoTracking().Max(x => (long?)x.Id);
            return nextId != null ? nextId.Value + 1 : 1;
        }
    }
}
