using System;
using BookingHotelApp.Models;
using BookingHotelApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingHotelApp.DataAccess;

namespace BookingHotelApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Registration.EnterLogin(user);
            Registration.EnterPassword(user);
            Registration.ConfirmPassword(user);
            Registration.EnterEmail(user);
            Registration.EnterPhoneNumber(user);

            string adoptedCode = Registration.VerificationAccount(user);

            System.Console.WriteLine("\nМы отправили на указанный Вами номер код верификации, введите его ниже...");

            while (true)
            {
                System.Console.Write("\nКод подтверждения: ");
                string verificationCode = System.Console.ReadLine();
                if (verificationCode == adoptedCode)
                {
                    System.Console.Clear();
                    System.Console.WriteLine("Поздравляем! Вы успешно прошли регистрацию");
                    break;
                }
                else
                {
                    System.Console.WriteLine("Неверный код верификации, нажмите Enter чтобы ввести заново...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Registration.Show(user, 5, Registration.GiveMeStars(user), Registration.GiveMeStars(user));
                }
            }
            var dataService = new AccountsTableDataService();
            dataService.AddUser(user);
            System.Console.ReadLine();
        }
    }
}
