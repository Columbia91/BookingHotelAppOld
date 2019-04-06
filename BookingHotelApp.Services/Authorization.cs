using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotelApp.DataAccess;
using BookingHotelApp.Models;

namespace BookingHotelApp.Services
{
    public class Authorization
    {
        public static void SignIn(User user)
        {
            bool check = false;
            while (true)
            {
                Console.Clear();
                if (!check && !EnterLogin(user))
                {
                    Console.WriteLine("Пользователя с таким логином не существует, нажмите Enter чтобы ввести заново...");
                    Console.ReadLine();
                    continue;
                }
                if (check)
                {
                    Console.WriteLine($"Login: {user.Login}");
                }
                if (!EnterPassword(user))
                {
                    Console.WriteLine("Введенный Вами пароль не корректный, нажмите Enter чтобы ввести заново...");
                    Console.ReadLine();
                    check = true;
                }
                else
                {
                    Console.WriteLine("Вход выполнен!");
                    break;
                }
            }
        }

        private static bool EnterPassword(User user)
        {
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            return AccountsTableDataService.CheckForAvailability("Password", user.Password);
        }

        private static bool EnterLogin(User user)
        {
            Console.Write("Login: ");
            user.Login = Console.ReadLine();
            return AccountsTableDataService.CheckForAvailability("Login", user.Login);
        }
    }
}
