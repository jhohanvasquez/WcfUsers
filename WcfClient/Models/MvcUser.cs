using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfClient.Models
{
    public class MvcUser
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Sexo { get; set; }
    }
}