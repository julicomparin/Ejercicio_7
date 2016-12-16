using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_7
{
    public class EncriptadorCesar : Encriptador
    {
        private int iDesplazamiento;
        private string iAlfabeto = "abcdefghijklmnñopqrstuvwxyz";

        public EncriptadorCesar(int pDesplazamiento) : base("César")
        {
            this.iDesplazamiento = pDesplazamiento;
        }

        public override string Encriptar(string pCadena)
        {
            string mCadenaEncriptada = "";

            for (int i = 0; i < pCadena.Length; i++)
            {
                int mPosCarater = this.PosicionEnAlfabeto(pCadena[i]);

                if (mPosCarater != -1) //existe carater
                {
                    int mPos = mPosCarater + this.iDesplazamiento;

                    while (mPos >= this.iAlfabeto.Length)
                    {
                        mPos -= this.iAlfabeto.Length;
                    }

                    mCadenaEncriptada += this.iAlfabeto[mPos];
                }
                else
                {
                    mCadenaEncriptada += pCadena[i]; //el carater no se encuentra en el albabeto. Se usa para desencriptar
                }
            }

            return mCadenaEncriptada;
        }

        public override string Desencriptar(string pCadena)
        {
            string mCadenaDesencriptada = "";

            for (int i = 0; i < pCadena.Length; i++)
            {
                int mPosCarater = this.PosicionEnAlfabeto(pCadena[i]);

                if (mPosCarater != -1) //existe carater
                {
                    int mPos = mPosCarater - this.iDesplazamiento;

                    while (mPos < 0)
                    {
                        mPos += this.iAlfabeto.Length;
                    }

                    mCadenaDesencriptada += this.iAlfabeto[mPos];
                }
                else
                {
                    mCadenaDesencriptada += pCadena[i]; //el carater no se encuentra en el albabeto. Se usa para desencriptar
                }
            }

            return mCadenaDesencriptada;
        }



        private int PosicionEnAlfabeto(char pCaracter)
        {
            for (int i = 0; i < this.iAlfabeto.Length; i++)
            {
                if (pCaracter == this.iAlfabeto[i]) return i;
            }
            return -1; //no existe posicion
        }
    }
}
