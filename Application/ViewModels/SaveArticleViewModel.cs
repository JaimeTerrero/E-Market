using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveArticleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del anuncio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar la descripción del anuncio")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Debe colocar el precio del anuncio")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Debe colocar la imagen del anuncio")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Debe colocar la categoría del anuncio")]
        public int CategoryId { get; set; }
    }
}
