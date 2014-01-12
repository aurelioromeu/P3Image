using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace TesteP3Image.Models
{
    public class SubCategorias
    {
        [Display(Name = "Id")]
        public virtual int SubCategoriaId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public virtual int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public virtual Categorias Categoria { get; set; }

    }
}