using System.ComponentModel.DataAnnotations;

namespace ManageProducts.Models.Dto
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder de 500 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio base es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio base debe ser mayor que 0.")]
        public decimal BasePrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio con descuento debe ser mayor que 0.")]
        public decimal? DiscountedPrice { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria")]
        public string ImageUrl { get; set; }
    }
}
