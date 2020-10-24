using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class DetalhePedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProductId { get; set; }
        public Product Produto { get; set; }
        public int Quantidade { get; set; }

    }
}