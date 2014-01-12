using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesteP3Image.Models;
using Publico.Models;

namespace Publico.Models
{
    public class FormularioModel
    {
        [Display(Name = "Categoria")]
        public virtual Categorias Categoria { get; set; }

        [Display(Name = "Subcategoria")]
        public virtual SubCategorias Subcategoria { get; set; }

        [Display(Name = "Campos")]
        public virtual List<Campos> Campos { get; set; }

        public virtual bool TemRegistros { get; set; }
    }
}