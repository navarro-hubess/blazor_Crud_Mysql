using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class UserDetails
    {
        public int UserDetailsId { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
