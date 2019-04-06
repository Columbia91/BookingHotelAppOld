using System;
using System.Collections.Generic;
using BookingHotelApp.Models;
using System.Data.SqlClient;

namespace BookingHotelApp.DataAccess
{
    public class AccountsTableDataService
    {
        private static readonly string _connectionString;
        static AccountsTableDataService()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADILET\Source\Repos\BookingHotelApp2\BookingHotelApp.DataAccess\Database.mdf;Integrated Security=True";
        }

        #region Получить коллекцию всех пользователей
        public List<User> GetAllUsers()
        {
            var data = new List<User>(); //буферный список пользователей

            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM Accounts";

                    var sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        int id = (int)sqlDataReader["Id"];
                        string login = sqlDataReader["Login"].ToString();
                        string password = sqlDataReader["Password"].ToString();
                        string email = sqlDataReader["Email"].ToString();
                        string phoneNumber = sqlDataReader["PhoneNumber"].ToString();

                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Password = password,
                            Email = email,
                            PhoneNumber = phoneNumber
                        });
                    }
                    sqlDataReader.Close();
                }
                catch (SqlException exception)
                {
                    //TODO обработка ошибки
                    throw;
                }
                catch (Exception exception)
                {
                    //TODO обработка ошибки
                    throw;
                }
            }
            return data;
        }
        #endregion

        #region Добавление пользователя в базу данных
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"INSERT into Accounts values ('{user.Login}','{user.Password}','{user.Email}','{user.PhoneNumber}')";
                    //command.CommandText = $"INSERT into Accounts " +
                    //$"Select {user.Login},{user.Password},{user.Email},{user.PhoneNumber}";
                    var affectedRows = command.ExecuteNonQuery(); //число строк которые подвергнуты каким либо изменениям 

                    if (affectedRows < 1)
                    {
                        throw new Exception("Вставка не была произведена");
                    }
                }
                catch (SqlException exception)
                {
                    //TODO обработка ошибки
                    Console.WriteLine(exception.Message);
                    //throw;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    //TODO обработка ошибки
                    //throw;
                }
            }
        }
        #endregion

        #region Удаление пользователя по ID
        public void DeleteUserById(int id)
        {

        }
        #endregion

        #region Изменение таблицы
        public void UpdateUser(User user)
        {

        }
        #endregion

        #region Проверка на доступность введенных данных
        public static bool CheckForAvailability(string property, object data)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"Select * from Accounts where {property} = '{data}'";

                    if(command.ExecuteScalar() == null)
                        return false;
                }
                catch (SqlException exception)
                {
                    Console.WriteLine(exception.Message);
                    //TODO обработка ошибки
                    //throw;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    //TODO обработка ошибки
                    //throw;
                    Console.ReadLine();
                }
            }
            return true;
        }
        #endregion
    }
}
