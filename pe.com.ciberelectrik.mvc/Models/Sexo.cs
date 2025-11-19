using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("sexo")]
    public class Sexo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codsex")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(20)]
        [Column("nomsex")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estsex")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}