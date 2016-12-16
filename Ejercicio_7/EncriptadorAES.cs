using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Ejercicio_7
{
    public class EncriptadorAES : Encriptador
    {
        private Rijndael iRijndael;
        private byte[] iKey;
        private byte[] iIVector;

        public EncriptadorAES() : base("AES")
        {
            // Crear una instancia del algoritmo de Rijndael
            this.iRijndael = Rijndael.Create();
            int keySize = 32;
            int ivSize = 16;
            Array.Resize(ref this.iKey, keySize);
            Array.Resize(ref this.iIVector, ivSize);

        }

        public override string Encriptar(string pCadena)
        {

            // Establecer un flujo en memoria para el cifrado
            MemoryStream memoryStream = new MemoryStream();

            // Crear un flujo de cifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream, iRijndael.CreateEncryptor(iKey, iIVector), CryptoStreamMode.Write);

            // Obtener la representación en bytes de la información a cifrar
            byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(pCadena);

            // Cifrar los datos enviándolos al flujo de cifrado
            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Obtener los datos datos cifrados como un arreglo de bytes
            byte[] cipherMessageBytes = memoryStream.ToArray();

            // Cerrar los flujos utilizados
            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos cifrados
            return Convert.ToBase64String(cipherMessageBytes);
        }

        public override string Desencriptar(string pCadena)
        {
            // Obtener la representación en bytes del texto cifrado
            byte[] cipherTextBytes = Convert.FromBase64String(pCadena);

            // Crear un arreglo de bytes para almacenar los datos descifrados
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Crear una instancia del algoritmo de Rijndael
            //Rijndael RijndaelAlg = Rijndael.Create();

            // Crear un flujo en memoria con la representación de bytes de la información cifrada
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Crear un flujo de descifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream, iRijndael.CreateDecryptor(iKey, iIVector), CryptoStreamMode.Read);

            // Obtener los datos descifrados obteniéndolos del flujo de descifrado
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Cerrar los flujos utilizados
            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos descifrados
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
