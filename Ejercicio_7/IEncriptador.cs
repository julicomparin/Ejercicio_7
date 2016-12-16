using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    interface IEncriptador
    {
        string Encriptar(string pCadena);

        string Desencriptar(string pCadena);
    }
}
