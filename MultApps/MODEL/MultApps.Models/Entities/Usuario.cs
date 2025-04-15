using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.Entities
{
    internal class Usuario
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string SenhaCriptografada { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public bool Ativo { get; set; }
    }
}
