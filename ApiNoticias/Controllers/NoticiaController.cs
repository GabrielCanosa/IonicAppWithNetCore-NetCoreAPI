using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoticias.Models;
using ApiNoticias.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("ObtenerNoticias")]
        public IActionResult OtenerNoticias()
        {
            return Ok(_noticiaService.ObtenerNoticias());
        }

        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar([FromBody] Noticia noticia)
        {
            if (_noticiaService.AgregarNoticia(noticia))
                return Ok();
            else
                return BadRequest();
            
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Noticia noticia)
        {
            if (_noticiaService.EditarNoticia(noticia))
                return Ok();
            else
                return BadRequest();

        }

        [HttpDelete]
        [Route("Eliminar/{noticiaID}")]
        public IActionResult Eliminar(int noticiaID)
        {
            if (_noticiaService.EliminarNoticia(noticiaID))
                return Ok();
            else
                return BadRequest();

        }

        [HttpGet]
        [Route("ObtenerAutores")]
        public IActionResult ObtenerAutores()
        {
            return Ok(_noticiaService.ObtenerAutores());
        }

    }
}