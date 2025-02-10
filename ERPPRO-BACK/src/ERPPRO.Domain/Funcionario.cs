using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain

namespace ERPPRO.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string? Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Setor { get; set; }
        public string Cargo { get; set; }
        public string Salario { get; set; }
        public string DataAdimissao { get; set; }
        public string? DataDemissao { get; set; }
        public string HorarioEntrada { get; set; }
        public string HorarioSaida { get; set; }
    }
}