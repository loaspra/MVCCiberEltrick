using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codmar")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nommar")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estmar")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}