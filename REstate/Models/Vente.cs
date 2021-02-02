using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Models
{
    public class Vente
    {
        public Guid ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string IdenCard { get; set; }
        public string Adress { get; set; }
        public string NumeroDeTlf { get; set; }
        public DateTime DateAchat { get; set; }
        public Guid PropertyID { get; set; }
        public Property Property { get; set; }
    }
}
