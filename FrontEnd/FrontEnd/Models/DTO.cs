using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class DTO
    {
        public class Tarea
        {
            public int ID { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha_Creacion { get; set; }
            public DateTime Fecha_Vencimiento { get; set; }
            public bool Completada { get; set; }
        }

       
    }
}