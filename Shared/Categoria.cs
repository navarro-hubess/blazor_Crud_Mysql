using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blazor_mysql2.Shared
{
    public class Categoria
    {
        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}    