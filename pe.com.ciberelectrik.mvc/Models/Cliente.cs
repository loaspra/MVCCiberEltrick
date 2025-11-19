using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codcli")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomcli")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apepcli")]
        [Display(Name = "Apellido Paterno")]
        public string apellidopaterno { get; set; }

        [Required]
        [StringLength(60)]
        [Column("apemcli")]
        [Display(Name = "Apellido Materno")]
        public string apellidomaterno { get; set; }

        [Required]
        [StringLength(20)]
        [Column("doccli")]
        [Display(Name = "Documento")]
        public string numerodocumento { get; set; }

        [StringLength(100)]
        [Column("dircli")]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [StringLength(7)]
        [Column("telcli")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [StringLength(9)]
        [Column("celcli")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [StringLength(60)]
        [Column("corcli")]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [Column("estcli")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        // ==========================
        //        RELACIONES
        // ==========================

        // Distrito
        [Required]
        [Column("coddis")]
        [Display(Name = "Distrito")]
        public int coddis { get; set; }

        [ForeignKey("coddis")]
        public virtual Distrito distrito { get; set; }

        // Tipo Documento
        [Required]
        [Column("codtipd")]
        [Display(Name = "Tipo Documento")]
        public int codtipd { get; set; }

        [ForeignKey("codtipd")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        // Sexo
        [Required]
        [Column("codsex")]
        [Display(Name = "Sexo")]
        public int codsex { get; set; }

        [ForeignKey("codsex")]
        public virtual Sexo sexo { get; set; }
    }
}
