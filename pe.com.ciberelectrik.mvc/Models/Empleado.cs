using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codemp")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomemp")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apepemp")]
        [Display(Name = "A.Paterno")]
        public string apellidopaterno { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apememp")]
        [Display(Name = "A. Materno")]
        public string apellidomaterno { get; set; }

        [Required]
        [StringLength(20)]
        [Column("docemp")]
        [Display(Name = "Num. Documento")]
        public string numerodocumento { get; set; }

        [Required]
        [StringLength(100)]
        [Column("diremp")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [StringLength(7)]
        [Column("telemp")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [StringLength(9)]
        [Column("celemp")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required]
        [StringLength(60)]
        [Column("coremp")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [StringLength(20)]
        [Column("usuemp")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [StringLength(20)]
        [Column("claemp")]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Column("estemp")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        // ==========================
        //        RELACIONES
        // ==========================

        // Distrito
        [Required]
        [Column("coddis")]
        public int coddis { get; set; }

        [ForeignKey("coddis")]
        [Display(Name = "Distrito")]
        public virtual Distrito distrito { get; set; }

        // Rol
        [Required]
        [Column("codrol")]
        public int codrol { get; set; }

        [ForeignKey("codrol")]
        [Display(Name = "Rol")]
        public virtual Rol rol { get; set; }

        // Tipo Documento
        [Required]
        [Column("codtipd")]
        public int codtipd { get; set; }

        [ForeignKey("codtipd")]
        [Display(Name = "T. Documento")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        // Sexo
        [Required]
        [Column("codsex")]
        public int codsex { get; set; }

        [ForeignKey("codsex")]
        [Display(Name = "Sexo")]
        public virtual Sexo sexo { get; set; }
    }
}