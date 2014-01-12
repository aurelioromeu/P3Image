using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TesteP3Image.Models
{
    public class Campos
    {
        [Display(Name = "Id")]
        public virtual int CampoId { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Required]
        [Display(Name = "Subcategoria")]
        public virtual int SubCategoriaId { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public virtual int Tipo { get; set; }

        [Display(Name = "Tipo")]
        public virtual string TipoTxt { get; set; }

        [Required]
        [Display(Name = "Lista")]
        public virtual string Lista { get; set; }

        [Required]
        [Display(Name = "Ordem")]
        public virtual int Ordem { get; set; }

        [Display(Name = "Subcategoria")]
        public virtual SubCategorias SubCategoria { get; set; }

        public virtual List<SelectListItem> TipoItens { get; set; } // dropdown

    }

    public class SubCatCampos
    {
        public List<Campos> listaCampos { get; set; }
        public SubCategorias SubCategoria { get; set; }
    }

    public enum TiposEnum
    {
        TextBox = 1,
        TextArea = 2,
        Checkbox = 3,
        Select = 4
    }
}