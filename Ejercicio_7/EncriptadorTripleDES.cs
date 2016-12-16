using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.IO;


namespace Ejercicio_7
{
    // CLASE QUE FORMA PARTE DEL EJERICIO 5
    public class EncriptadorTripleDES : Encriptador
    {
        //clave de seguridad para cifrar el texto es escencial!!!!
        private const string CLAVE = "Claveeeee";

        public EncriptadorTripleDES() : base("TripleDES")
        {
        }

        //Encriptador
        public override string Encriptar(string pCadena)
        {
            // Obtiene los bytes de la cadena de entrada.
            byte[] byteCadena = UTF8Encoding.UTF8.GetBytes(pCadena); //toEncryptedArray

            // Inicializa una nueva instancia de la clase MD5CryptoServiceProvider.
            MD5CryptoServiceProvider instMD5CryptoService = new MD5CryptoServiceProvider();

            // Obtiene los bytes de la clave de seguridad y pasa a calcular el valor de Hash correspondientes.
            byte[] claveByteArray = instMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(CLAVE));

            // Libera memoria utilizada por la clase Hash.
            instMD5CryptoService.Clear();

            // Inicializa una nueva instancia de la clase TripleDESCryptoServiceProvider.
            var instTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            // Asigna la clave de seguridad al Proveedor de Servicios TripleDES.
            instTripleDESCryptoService.Key = claveByteArray;

            // Especifica el Modo de cifrado que se usara (ECB)
            instTripleDESCryptoService.Mode = CipherMode.ECB;

            // Especifica el Modo de relleno (PKCS7) si no se añade ningún byte adicional.
            instTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            // Crea un objeto descifrador simetrico.
            var objetoDescifrador = instTripleDESCryptoService.CreateEncryptor();

            // Transformar la matriz de bytes a la matriz resultante, que es la que se devolvera.
            byte[] ultimoArray = objetoDescifrador.TransformFinalBlock(byteCadena, 0, byteCadena.Length);

            // Liberar la memoria ocupada por el Proveedor de Servicio TripleDES para el cifrado.
            instTripleDESCryptoService.Clear();

            // Convierte y devuelve los datos/byte cifrado en formato de cadena.
            return Convert.ToBase64String(ultimoArray, 0, ultimoArray.Length);
        }


        // Desencriptador
        public override string Desencriptar(string pCadena)
        {
            // Obtiene los bytes de la cadena.
            byte[] byteCadena = Convert.FromBase64String(pCadena);

            // Inicializa una nueva instancia de la clase MD5CryptoServiceProvider.
            MD5CryptoServiceProvider instMD5CryptoService = new MD5CryptoServiceProvider();

            // Obtiene los bytes de la clave de seguridad y pasa a calcular el valor de Hash correspondientes.
            byte[] claveByteArray = instMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(CLAVE));

            // Libera memoria utilizada por la clase Hash.
            instMD5CryptoService.Clear();

            // Inicializa una nueva instancia de la clase TripleDESCryptoServiceProvider.
            var instTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            // Asigna la clave de seguridad al Proveedor de Servicios TripleDES.
            instTripleDESCryptoService.Key = claveByteArray;

            // Especifica el Modo de cifrado que se usara (ECB)
            instTripleDESCryptoService.Mode = CipherMode.ECB;

            // Especifica el Modo de relleno (PKCS7) si no se añade ningún byte adicional.
            instTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            // Crea un objeto desifrador simetrico.
            var objetoDescifrador = instTripleDESCryptoService.CreateDecryptor();

            // Transformar la matriz de bytes a la matriz resultante, que es la que se devolvera.
            byte[] ultimoArray = objetoDescifrador.TransformFinalBlock(byteCadena, 0, byteCadena.Length);

            // Liberar la memoria ocupada por el Proveedor de Servicio TripleDES para el cifrado.       
            instTripleDESCryptoService.Clear();

            // Convierte y devuelve los datos/descifrado de bytes en formato de cadena.
            return UTF8Encoding.UTF8.GetString(ultimoArray);
        }
    }
}
