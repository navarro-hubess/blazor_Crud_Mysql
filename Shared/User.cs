using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace blazor_mysql2.Shared
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres")]
        public string Password { get; set; }

        [Required]
        [CompareProperty("Password", ErrorMessage = "a senha deve ser a mesma")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Aceitar os termos é obrigatório")]
        public bool AcceptTerms { get; set; }
    }
}
