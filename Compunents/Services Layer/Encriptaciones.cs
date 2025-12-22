using System;
using System.Security.Cryptography;

namespace Services_Layer
{
    public static class Encriptaciones
    {
        // Configuración PBKDF2
        private const int SaltSize = 16;    // 128 bits
        private const int KeySize = 32;     // 256 bits
        private const int Iterations = 100_000;

        // Hashea una contraseña y devuelve hash+salt en Base64
        public static string HashPassword(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                // Generar salt seguro
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                // Derivar clave con PBKDF2
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    var key = pbkdf2.GetBytes(KeySize);

                    // Guardar juntos: Iteraciones | Salt | Hash
                    var result = new byte[4 + SaltSize + KeySize];
                    Buffer.BlockCopy(BitConverter.GetBytes(Iterations), 0, result, 0, 4);
                    Buffer.BlockCopy(salt, 0, result, 4, SaltSize);
                    Buffer.BlockCopy(key, 0, result, 4 + SaltSize, KeySize);

                    return Convert.ToBase64String(result);
                }
            }
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }

        // Verifica si la contraseña ingresada coincide con el hash guardado
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var decoded = Convert.FromBase64String(hashedPassword);

            var iterations = BitConverter.ToInt32(decoded, 0);
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(decoded, 4, salt, 0, SaltSize);

            var storedKey = new byte[KeySize];
            Buffer.BlockCopy(decoded, 4 + SaltSize, storedKey, 0, KeySize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                var key = pbkdf2.GetBytes(KeySize);
                return FixedTimeEquals(key, storedKey);
            }
        }
    }
}
