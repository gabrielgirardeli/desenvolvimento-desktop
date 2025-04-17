using MultApps.Models.Entities.Abstract;
using MultApps.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.Entities
{
     public class  Usuario : EntidadesBase
    {
        
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public  DateTime DataUltimoAcesso { get; set; }


    }
}
