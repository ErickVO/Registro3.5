using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.Entidades
{
   public class Inscripcion
    {
        public int InscripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string Comentarios { get; set; }
        public int Monto { get; set; }
        public int Balance { get; set; }

        public Inscripcion()
        {
            InscripcionId = 0;
            Fecha = DateTime.Now;
            PersonaId = 0;
            Comentarios = string.Empty;
            Monto = 0;
            Balance = 0;
        }
    }


}
