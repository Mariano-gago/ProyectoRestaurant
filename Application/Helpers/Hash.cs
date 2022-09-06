using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class Hash
    {

        /* Primera calse convierte la clave en base de datos en un arreglo de bites y hashea la clave
         * Segunda clase, convierte la clave ingresada en un arreglo de bites y la compara con la de la base de datos */
        public static string Hashing(string password)
        {
            byte[] salt;
            byte[] buffer;

            if(password == null)
            {
                throw new ArgumentNullException();
            }

            //Config de hashing, como argumento se coloca la clave, la cantidad de caracteres y la cantidad de veces que itera
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes( password, 16, 1000))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(32);
            }

            // Formando la clave, une la Salt y el buffer. Buffer tiene la clave y Salt el texto aleatorio para recuperar la clave
            byte[] dst = new byte[49];
            Buffer.BlockCopy(salt, 0, dst, 1, 16);
            Buffer.BlockCopy(buffer, 0, dst, 17, 32);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            

            // validaciones
            if (hashedPassword == null)
            {
                return false;
            }
            if(password == null)
            {
                throw new ArgumentNullException();
            }

            //validaciones
            byte[] src = Convert.FromBase64String(hashedPassword);

            if((src.Length !=49) || src[0] !=0)
            {
                return false;
            }

            byte[] dst = new byte[16];
            Buffer.BlockCopy(src, 1, dst, 0, 16);


            byte[] buffer3 = new byte[32];
            Buffer.BlockCopy(src, 17, buffer3, 0, 32);





            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 1000))
            {

                buffer4 = bytes.GetBytes(32);
            }

            //Verifica la contraseña ingresda con la de la base de datos
            return buffer3.SequenceEqual(buffer4);
            
        }

    }
}
