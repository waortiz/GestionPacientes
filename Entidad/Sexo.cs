using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Sexo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public short IdSexo { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
