using ConsoleApp6;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Account> Accounts { get; set; }

        static void Main(string[] args)
        {
            Accounts = new List<Account>();

            string opcja;
            do
            {
                Console.WriteLine("Wybierz opcje: 0 - zakoncz program, 1 - Utworz konto, 2 - wyplac pieniadze, 3 - wpłać pieniądze, 4 - usuń konto");
                opcja = Console.ReadLine();

                if (opcja == "1")
                {
                    var account = Account.CreateAccount();
                    Accounts.Add(account);
                    Console.WriteLine("Uzytkownicy na liscie to: ");
                    foreach (var user in Accounts)
                    {
                        Console.WriteLine(user.Introduce());
                    }
                }
                if (opcja == "2")
                {
                    Console.WriteLine("Podaj swoje ID");
                    var id = Int32.Parse(Console.ReadLine());
                    var user = Accounts.FirstOrDefault(x => x.Id == id);
                    if (user == null)
                    {
                        Console.WriteLine("Uzytkownik o takim ID nie istnieje ");
                        return;
                    }
                    user.WithdrawMoney();
                }
                if (opcja == "3")
                {
                    Console.WriteLine("Podaj swoje ID");
                    var id = Int32.Parse(Console.ReadLine());
                    var user = Accounts.FirstOrDefault(x => x.Id == id);
                    if (user == null)
                    {
                        Console.WriteLine("Uzytkownik o takim ID nie istnieje ");
                        return;
                    }
                    user.DepositMoney();
                }
                if (opcja == "4")
                {
                    Console.WriteLine("podaj Id uzytkowanika do usuniecia: ");
                    var doUsuniecia = Convert.ToInt32(Console.ReadLine());

                    DeleteAccount(doUsuniecia);
                }

            }
            while (opcja != "0");
        }

        static void DeleteAccount(int id)
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
                if (Accounts[i].Id == id)
                {
                    Accounts.RemoveAt(i);
                    Console.WriteLine("usunieto uzytkownika o Id " + id);
                    return;
                }
            }
        }
    }
}