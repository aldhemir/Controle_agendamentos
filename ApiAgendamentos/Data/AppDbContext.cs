#nullable enable

using Microsoft.EntityFrameworkCore;
using ApiAgendamentos.Models;
using System;

namespace ApiAgendamentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para a tabela Agendamentos
        public DbSet<Agendamento>? Agendamentos { get; set; }

        // DbSet para a tabela Usuarios
        public DbSet<Usuario>? Usuarios { get; set; }

        // Configuração dos mapeamentos das tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela Agendamentos
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.Id); // Define a chave primária
                entity.Property(e => e.NomeCliente).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Servico).HasMaxLength(150).IsRequired();
                entity.Property(e => e.DataHora).IsRequired();
                entity.Property(e => e.Observacoes).HasMaxLength(500);
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.DataAtualizacao).IsRequired(false); // Permite nulo
            });

            // Configuração da tabela Usuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id); // Define a chave primária
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired().IsUnicode(false);
                entity.Property(e => e.Senha).HasMaxLength(250).IsRequired();
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.DataAtualizacao).IsRequired(false); // Permite nulo
            });

            base.OnModelCreating(modelBuilder);
        }

        // Sobrescrever o método SaveChanges para auditoria automática
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                // Auditoria para as entidades Agendamento e Usuario
                if (entry.Entity is Agendamento agendamento)
                {
                    if (entry.State == EntityState.Added)
                    {
                        agendamento.DataCriacao = DateTime.UtcNow;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        agendamento.DataAtualizacao = DateTime.UtcNow;
                    }
                }

                if (entry.Entity is Usuario usuario)
                {
                    if (entry.State == EntityState.Added)
                    {
                        usuario.DataCriacao = DateTime.UtcNow;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        usuario.DataAtualizacao = DateTime.UtcNow;
                    }

                    // Criptografar a senha antes de salvar no banco
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        usuario.Senha = CriptografarSenha(usuario.Senha);
                    }
                }
            }

            return base.SaveChanges();
        }

        // Função para criptografar a senha (exemplo usando SHA256)
        private string CriptografarSenha(string senha)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
