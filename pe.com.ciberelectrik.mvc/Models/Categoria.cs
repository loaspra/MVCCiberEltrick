using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codcat")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nomcat")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estcat")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}