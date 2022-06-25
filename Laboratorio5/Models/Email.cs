using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio5.Models
{
    public class Email
    {
        public Email()
        {
        }


        [Required(ErrorMessage ="El email es requerido")]
        public string EmailDestino { get; set; }
        public string Asunto { get; set; }

        public string Contenido { get; set; }

    }
}