﻿using System;

namespace CoreProject.Core.Entity
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } 
    }
}
