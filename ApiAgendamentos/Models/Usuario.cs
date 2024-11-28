using System;

namespace ApiAgendamentos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        // Se os valores não podem ser nulos, use a palavra-chave 'required'
        public string Nome { get; set; } = null!; // Usando null! para evitar o erro CS8618
        public string Email { get; set; } = null!; // Usando null!
        public string Senha { get; set; } = null!; // Usando null!
        
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; } // Nullable
    }
}
