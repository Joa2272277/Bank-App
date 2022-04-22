using System;

namespace ConsoleApp6
{
    public class Account
    {
        private static int CurrentId { get; set; } = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string PIN { get; set; }

        public Account()
        {
            var random = new Random();
            Id = CurrentId;
            CurrentId++;
            Balance = 0;
            AccountNumber = Id.ToString() + random.Next(10000-99000);

        }

        public Account(string name, string surname, DateTime dateOfBirth, string pin)
        {
            var random = new Random();
            Id = CurrentId;
            CurrentId++;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Balance = 0;
            AccountNumber = Id.ToString() + random.Next(10000, 99000);
            PIN = pin;
        }

        ~Account()
        {
            Console.WriteLine("Wywolanie destrutora. Usuwanie uzytkowanika " + Name + Id);
        }

        public string Introduce() 
        {
            return $"My name is {Name}, my surname is " + Surname + ", " 
            + "my age is " + (DateTime.Now.Year - DateOfBirth.Year) + " moje Id to " + Id + " stan konta to " + Balance + " mój numer konta to " + AccountNumber; 
        }

        public void DepositMoney()
        {
            Console.WriteLine("Podaj kwote do wpłacenia ");
            Balance += Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Nowy stan konta {Balance}");
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("Podaj kwote do wypłacenia ");
            var valueToWithdraw = Int32.Parse(Console.ReadLine());
            if (valueToWithdraw > Balance)
            {
                Console.WriteLine("Nie mozesz wyplacic kwoty ");
                return;
            }
            Balance -= valueToWithdraw;
            Console.WriteLine($"Nowy stan konta {Balance}");
        }

        public static Account CreateAccount()
        {
            Console.WriteLine("Podaj Imie");
            var name = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko ");
            var surname = Console.ReadLine();
            Console.WriteLine("Podaj date urodzenia ");
            var dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            var PIN = string.Empty;
            var IsValid = false;
            while (!IsValid)
            {
                Console.WriteLine("Podaj PIN");
                PIN = Console.ReadLine();
                IsValid = VerifyPIN(PIN);
            }

            var account = new Account(name, surname, dateOfBirth, PIN);
            return account;
        }
        
        static bool VerifyPIN(string pin)
        {
            if (pin.Length != 4)
            {
                Console.WriteLine("Błędny PIN: Podaj PIN który ma 4 cyfry ");
                return false;
            }
            foreach (var znak in pin)
            {
                if (!char.IsDigit(znak))
                {
                    Console.WriteLine("Błędny PIN: Podaj PIN który zawiera tylko cyfry ");
                    return false;
                }
            }
            return true;
        }
    }
}



   