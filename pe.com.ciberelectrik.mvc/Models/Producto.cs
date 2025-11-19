using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("codpro")]
        [Display(Name = "Código")]
        public int codigo { get; set; }

        [Required]
        [StringLength(80)]
        [Column("nompro")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [StringLength(200)]
        [Column("despro")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required]
        [Column("prepro")]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal precio { get; set; }

        [Required]
        [Column("canpro")]
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Required]
        [Column("fecing")]
        [Display(Name = "Fec. Ingreso")]
        public DateTime fechaingreso { get; set; }

        [Required]
        [Column("estpro")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

        // ==========================
        //        RELACIONES
        // ==========================

        // ------- MARCA -------
        [Required]
        [Column("codmar")]
        [Display(Name = "Marca")]
        public int codmar { get; set; }

        [ForeignKey("codmar")]
        public virtual Marca marca { get; set; }

        // ------- CATEGORÍA -------
        [Required]
        [Column("codcat")]
        [Display(Name = "Categoría")]
        public int codcat { get; set; }

        [ForeignKey("codcat")]
        public virtual Categoria categoria { get; set; }
    }
}