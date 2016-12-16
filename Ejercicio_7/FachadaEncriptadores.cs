using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    class FachadaEncriptadores
    {
        private FabricaEncriptadores iFabrica;

        public FachadaEncriptadores()
        {
            this.iFabrica = FabricaEncriptadores.Instancia;
        }

        public string EncriptarMediante(string pNombre, string pCadena)
        {
            return iFabrica.GetEncriptador(pNombre).Encriptar(pCadena);
        }

        public string DesencriptarMediante(string pNombre, string pCadena)
        {
            return iFabrica.GetEncriptador(pNombre).Desencriptar(pCadena);
        }
    }
}

