using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPPRO.Domain
{
    public class NivelAcesso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string bloqueios { get; set; }
        public string inicial { get; set; }
    }
}