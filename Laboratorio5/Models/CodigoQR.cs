using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio5.Models
{
    public class CodigoQR
    {

        [Required(ErrorMessage ="El texto es requerido")]
        public string Texto { get; set; }

        public string Codigo { get; set; }
    }
}