using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotelApp.Models;

namespace BookingHotelApp.Services.Abstract
{
    public class Security
    {
        #region Вывод на консоль
        public static void Show(User user, int numb, string stars = "", string stars2 = "")
        {
            for (int i = 0; i < numb; i++)
            {
                switch (i + 1)
                {
                    case 1: Console.Write("Login: " + user.Login); break;
                    case 2: Console.Write("\nPassword: " + stars); break;
                    case 3: Console.Write("\nConfirm Password: " + stars2); break;
                    case 4: Console.Write("\nEmail: " + user.Email); break;
                    case 5: Console.Write("\nPhone number (+XYYYZZZZZZZ): " + user.PhoneNumber); break;
                }
            }
        }
        #endregion

        #region Скрытие пароля
        public static string HideCharacter()
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);
                Console.Write("*");
                code += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter);

            //Console.WriteLine("\n" + code);
            return code;
        }
        #endregion

        #region Звездочки
        public static string GiveMeStars(User user)
        {
            char[] symbols = new char[user.Password.Length];

            for (int i = 0; i < user.Password.Length; i++)
            {
                symbols[i] = '*';
            }
            string str = new string(symbols);
            return str;
        }
        #endregion
    }
}
