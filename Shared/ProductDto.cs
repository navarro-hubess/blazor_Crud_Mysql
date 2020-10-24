using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class ProductDto
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public Decimal Preco { get; set; }

        public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public List<DetalhePedido> DetalhePedidos { get; set; }

    }
}