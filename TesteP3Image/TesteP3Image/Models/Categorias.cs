using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteP3Image.Models
{
    public class Categorias
    {

        [Display(Name = "Id")]
        public virtual int CategoriaId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }
        
    }
}