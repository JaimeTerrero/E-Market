using EMarket.Core.Application.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.ViewModels.Articles
{
    public class SaveArticleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del anuncio")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la descripción del anuncio")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe colocar el precio del anuncio")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la categoría del anuncio")]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}
