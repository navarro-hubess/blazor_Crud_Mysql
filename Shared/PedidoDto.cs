using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blazor_mysql2.Shared
{
    public class PedidoDto
    {
        public string CategoriaId { get; set; }

        public string ProdutoId { get; set; }

        public int Quantidade { get; set; }
    }
}    