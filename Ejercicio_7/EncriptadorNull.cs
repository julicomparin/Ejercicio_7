using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    public sealed class EncriptadorNull : Encriptador
    {
        public EncriptadorNull() : base("Null")
        {
        }

        public override string Encriptar(string pCadena)
        {
            return pCadena;
        }

        public override string Desencriptar(string pCadena)
        {
            return pCadena;
        }

    }
}
