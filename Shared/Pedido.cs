using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public User Usuario { get; set; }
        public DateTime DataPedido { get; set; }
        public List<DetalhePedido> DetalhePedidos { get; set; }

    }
}