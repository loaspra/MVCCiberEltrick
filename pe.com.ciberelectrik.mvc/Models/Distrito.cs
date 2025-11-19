using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("distrito")]
    public class Distrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("coddis")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nomdis")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estdis")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}