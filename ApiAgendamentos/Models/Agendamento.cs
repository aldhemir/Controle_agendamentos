using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgendamentos.Models
{
    public class Agendamento
    {
        [Key]  // Explicitamente definindo a chave primária, embora EF normalmente faça isso automaticamente
        public Guid Id { get; set; }

        [Required] // Garantindo que não seja nulo
        [MaxLength(100)] // Definindo um tamanho máximo, ajuste conforme necessário
        public string NomeCliente { get; set; } = null!;

        [Required] // Garantindo que não seja nulo
        [MaxLength(100)] // Ajuste do tamanho do serviço, pode ser alterado conforme necessidade
        public string Servico { get; set; } = null!;

        [Required] // Garantindo que não seja nulo
        public DateTime DataHora { get; set; }

        [MaxLength(500)] // Ajuste do tamanho máximo para observações, se necessário
        public string Observacoes { get; set; } = null!;

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow; // Definindo valor padrão como UTC agora

        public DateTime? DataAtualizacao { get; set; } // Nullable (opcional)
    }
}
