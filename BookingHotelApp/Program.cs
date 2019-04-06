using BookingHotelApp.Models;
using BookingHotelApp.Services;
using BookingHotelApp.DataAccess;

namespace BookingHotelApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            var dataService = new AccountsTableDataService();

            Registration.SignUp(user, dataService);
            Authorization.SignIn(user);
            
            System.Console.ReadLine();
        }
    }
}
