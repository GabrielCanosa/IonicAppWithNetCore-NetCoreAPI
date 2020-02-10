using ApiNoticias.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoticias.Services
{
    public class NoticiaService
    {
        private readonly NoticiasDBContext _noticiasDBContext;
        public NoticiaService(NoticiasDBContext noticiasDBContext)
        {
            _noticiasDBContext = noticiasDBContext;
        }

        public List<Noticia> ObtenerNoticias()
        {
            return _noticiasDBContext.Noticia.Include(x => x.Autor).ToList();
        }

        public Boolean AgregarNoticia(Noticia noticia)
        {
            try
            {
                _noticiasDBContext.Noticia.Add(noticia);
                _noticiasDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }

            return true;
        }

        public Boolean EditarNoticia(Noticia noticia)
        {
            try
            {
                Noticia noticiaModificar = _noticiasDBContext.Noticia.Where(x => x.NoticiaID == noticia.NoticiaID).FirstOrDefault();

                noticiaModificar.Titulo = noticia.Titulo;
                noticiaModificar.Descripcion = noticia.Descripcion;
                noticiaModificar.Contenido = noticia.Contenido;
                noticiaModificar.Fecha = noticia.Fecha;
                noticiaModificar.AutorID = noticia.AutorID;

                _noticiasDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }

            return true;
        }

        public Boolean EliminarNoticia(int noticiaID)
        {
            try
            {
                Noticia noticia = _noticiasDBContext.Noticia.Where(x => x.NoticiaID == noticiaID).FirstOrDefault();
                _noticiasDBContext.Noticia.Remove(noticia);
                _noticiasDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }

            return true;
        }

        public List<Autor> ObtenerAutores()
        {
            return _noticiasDBContext.Autor.ToList();
        }
    }
}
