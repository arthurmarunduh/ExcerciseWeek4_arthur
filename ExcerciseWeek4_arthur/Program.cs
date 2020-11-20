using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseWeek4_arthur
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Masukan nama : ");
            string name = (Console.ReadLine());
            Console.Write("Masukan Password : ");
            string password = (Console.ReadLine());
            Console.WriteLine("halo " + name);
            string mySalt = hashing.getRandamSalt();
            string myHash = hashing.HashPassword(password, mySalt);
            Console.WriteLine("Ini password anda setelah di hasing : " + myHash);
            bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, myHash);
            if (doesPasswordMatch == true)
            {
                Console.WriteLine("password sudah cocok");
            }
            else
            {
                Console.WriteLine("password belum cocok");

            }
        }
    }
    public class hashing
    {
        public static string getRandamSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
        public static string HashPassword(string password,string hashSalt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, hashSalt);
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
