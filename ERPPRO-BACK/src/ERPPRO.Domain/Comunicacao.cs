using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain

namespace ERPPRO.Domain
{
    public class Comunicacao
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Setor { get; set; }
        public string Mensagem { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}