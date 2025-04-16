using MultApps.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.Entities
{
     public class  Usuario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public StatusEnum Status { get; set; }
    }
}
