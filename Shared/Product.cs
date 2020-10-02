using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Descricao { get; set; }
        
        [Required]
        public Decimal Preco { get; set; }

    }
}