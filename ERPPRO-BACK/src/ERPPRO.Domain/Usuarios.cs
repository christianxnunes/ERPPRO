using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain

namespace ERPPRO.Domain
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}