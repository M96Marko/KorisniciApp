using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KorisniciApp.Controllers
{
    [ApiController]
    [Route("korisnici")]
    public class KorisnikController : Controller
    {
        KorisnikService korisnikService = new KorisnikService();
        MjestoService mjestoService = new MjestoService();

        [HttpGet]
        [Route("create")]
        public KorisnikDto Create()
        {
            return korisnikService.Create();
        }

        [HttpGet]
        public List<KorisnikDto> GetAllKorisnici()
        {
            return korisnikService.GetAllKorisnici();
        }

        [HttpGet]
        [Route("getAllMjesta")]
        public List<MjestoDto> GetAllMjesta()
        {
            return mjestoService.GetAllMjesta();
        }

        [HttpGet]
        [Route("id/{id}")]
        public KorisnikDto GetKorisnikById([FromRoute] long id)
        {
            return korisnikService.GetById(id);
        }

        [HttpPost]
        [Route("save")]
        public KorisnikDto SaveKorisnik([FromBody] KorisnikDto dto)
        {
            return korisnikService.Save(dto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteKorisnik([FromRoute] long id)
        {
            return korisnikService.Delete(id);
        }
    }
}