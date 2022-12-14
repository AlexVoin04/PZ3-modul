using ConsoleApp1.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Helper db2 = new Helper();
                RestaurantEntities db = Helper.GetContext();
                Console.WriteLine("Добавление сотрудника и создание учетной записи\n");
                Console.Write("Введите имя сотрудника: ");
                string name = Console.ReadLine();
                Console.Write("Введите фамилию сотрудника: ");
                string surname = Console.ReadLine();
                Console.Write("Введите отчество сотрудника: ");
                string patronymic = Console.ReadLine();
                Console.Write("Введите дату рождения сотрудника: ");
                string born = Console.ReadLine();
                Console.Write("Введите номер телефона сотрудника: ");
                string tel = Console.ReadLine();
                Console.Write("Введите серию паспорта сотрудника: ");
                string passpseries = Console.ReadLine();
                Console.Write("Введите номер паспорта сотрудника: ");
                string passpnumber = Console.ReadLine();

                Console.WriteLine("\nДолжности:");
                var posts = db.Posts;
                foreach (Posts post in posts)
                    Console.WriteLine($"{post.ID}: {post.Post}");
                Console.Write("\nВведите номер должности сотрудника: ");
                int postid = int.Parse(Console.ReadLine());

                Console.Write("Введите логин сотрудника: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль сотрудника: ");
                string password = Console.ReadLine();

                int lastpost = db2.GetLastIDPost();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname)
                    || string.IsNullOrEmpty(born) || string.IsNullOrEmpty(tel)
                    || string.IsNullOrEmpty(passpseries) || string.IsNullOrEmpty(passpnumber)
                    || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Не все нужные данные введены");
                }
                else if (int.TryParse(name, out int n) || int.TryParse(surname, out int s)
                    || int.TryParse(login, out int l))
                {
                    Console.WriteLine("Неправильно введены данные");
                }
                else if (DateTime.TryParseExact(born, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt)
                    && int.TryParse(passpseries, out int ps) && int.TryParse(passpnumber, out int pn) && passpseries.Length == 4 
                    && passpnumber.Length == 6 && postid > 0 && postid<lastpost)
                {
                    Hash hash = new Hash();
                    Console.WriteLine($"Хешированный пароль пользователя: {hash.sha256_hash(password)}");
                    hash.sha256_hash(password);
                    int employeeid = db2.GetLastIDEmployee();
                    int infoid = db2.GetLastIDInfo();
                    int authid = db2.GetLastIDAuth();
                    EmployeeInformation employeeInformation = new EmployeeInformation { ID = infoid, Tel = tel, Born = dt, PasspSeries = passpseries, PasspNumber = passpnumber, AuthorizationID = authid, PostsID = postid };
                    Employees employees = new Employees { ID = employeeid, Name = name, Surname = surname, Patronymic = patronymic };
                    Authorization authorization = new Authorization { ID = authid, Login = login, Password = hash.sha256_hash(password) };
                    db2.CreateEmployees(employees, employeeInformation, authorization);
                    Console.WriteLine("Учетная запись добавлена");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Неправильный ввод даты");
                }
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так ...");
            }
            
        }
    }
}
