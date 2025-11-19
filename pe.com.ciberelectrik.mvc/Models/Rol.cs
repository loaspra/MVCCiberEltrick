using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("rol")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codrol")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(40)]
        [Column("nomrol")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Column("estrol")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}