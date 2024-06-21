using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class TareasController : ApiController
    {
        //private TareasEntities dbContext = new TareasEntities();
        private TareasEntities dbContext = new TareasEntities();

        [Authorize]
        [HttpGet]
        public IEnumerable<Tarea> Get()
        {
            using (TareasEntities tareasEntities = new TareasEntities())
            {
                return tareasEntities.Tareas.ToList();
            }
        }

        [Authorize]
        [HttpGet]
        public Tarea Get(int id)
        {
            using (TareasEntities tareasEntities = new TareasEntities())
            {
                return tareasEntities.Tareas.FirstOrDefault(e => e.ID == id);
            }
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AgregarTarea([FromBody] Tarea tareas)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new TareasEntities())
                {
                    dbContext.Tareas.Add(tareas);
                    dbContext.SaveChanges();
                    return Ok(tareas);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult ActualizarTarea(int id, [FromBody] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new TareasEntities())
                {
                    var tareaExiste = dbContext.Tareas.Any(t => t.ID == id);

                    if (tareaExiste)
                    {
                        dbContext.Entry(tarea).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        return Ok(new { mensaje = "Tarea actualizada exitosamente", tarea });
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, new { mensaje = "Tarea no encontrada" });
                    }
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, new { mensaje = "Datos inválidos" });
            }
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult EliminarTarea(int id)
        {
            using (var dbContext = new TareasEntities())
            {
                var tarea = dbContext.Tareas.Find(id);

                if (tarea != null)
                {
                    dbContext.Tareas.Remove(tarea);
                    dbContext.SaveChanges();
                    return Ok(new { mensaje = "Tarea eliminada exitosamente", tarea });
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, new { mensaje = "Tarea no encontrada" });
                }
            }
        }
    }
}
