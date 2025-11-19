using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("tipodocumento")]
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codtipd")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(30)]
        [Column("nomtipd")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("esttipd")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}