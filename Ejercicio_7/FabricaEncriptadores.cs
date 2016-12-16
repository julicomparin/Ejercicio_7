using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    class FabricaEncriptadores
    {
        private static readonly Object cSynch = new Object();
        private static FabricaEncriptadores cInstancia;
        IDictionary<string, IEncriptador> iEncriptadores = new Dictionary<string, IEncriptador>();


        //constructor
        private FabricaEncriptadores()
        {
            this.iEncriptadores["CESAR"] = new EncriptadorCesar(3);
            this.iEncriptadores["AES"] = new EncriptadorAES();

            // CLASE QUE FORMA PARTE DEL EJERICIO 5
            this.iEncriptadores["TRIPLEDES"] = new EncriptadorTripleDES();
        }

        public static FabricaEncriptadores Instancia
        {
            get
            {
                if (cInstancia == null)
                {
                    lock (cSynch)
                    {
                        if (cInstancia == null)
                        {
                            cInstancia = new FabricaEncriptadores();
                        }
                    }
                }
                return cInstancia;
            }
        }

        public IEncriptador GetEncriptador(string pNombre)
        {
            IEncriptador mResultado = new EncriptadorNull();
            if (this.iEncriptadores.ContainsKey(pNombre)) //asegurarse que el encriptador exista en el diccionario
            {
                mResultado = this.iEncriptadores[pNombre];
            }

            return mResultado;
        }

    }
}