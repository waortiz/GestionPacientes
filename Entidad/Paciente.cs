using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        [Key]
        public long IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroDocumento { get; set; }
        public short IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public short IdSexo { get; set; }
        public virtual Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Observaciones { get; set; }
        public bool EsCotizante { get; set; }
    }
}
