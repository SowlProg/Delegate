using System;


using System;
using Project.Delegate;

namespace Project.Services
{
    public class CreditCard
    {
        public string CardNumber { get; }
        public string OwnerName { get; set; }
        public DateTime ExpiryDate { get; set; }
        private int _pin;
        public decimal CreditLimit { get; set; }
        private decimal _balance;

        public event Action<decimal> MoneyDeposited;
        public event Action<decimal> MoneyWithdrawn;
        public event Action CreditUsageStarted;
        public event Action<decimal> SavingsTargetReached;
        public event Action PinChanged;

        public CreditCard(string number, string owner, DateTime expiry, int pin, decimal limit)
        {
            CardNumber = number;
            OwnerName = owner;
            ExpiryDate = expiry;
            _pin = pin;
            CreditLimit = limit;

            // Initialize events with empty delegates
            MoneyDeposited = delegate { };
            MoneyWithdrawn = delegate { };
            CreditUsageStarted = delegate { };
            SavingsTargetReached = delegate { };
            PinChanged = delegate { };
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            MoneyDeposited?.Invoke(amount);
            if (_balance >= 1000) SavingsTargetReached?.Invoke(_balance);
        }

        public bool Withdraw(decimal amount, int pin)
        {
            if (_pin != pin)
            {
                Console.WriteLine("Invalid PIN!");
                return false;
            }

            if (_balance >= amount)
            {
                _balance -= amount;
                MoneyWithdrawn?.Invoke(amount);
                return true;
            }
            else if (_balance + CreditLimit >= amount)
            {
                CreditUsageStarted?.Invoke();
                _balance -= amount;
                MoneyWithdrawn?.Invoke(amount);
                return true;
            }

            Console.WriteLine("Insufficient funds!");
            return false;
        }

        public void ChangePin(int oldPin, int newPin)
        {
            if (_pin != oldPin)
            {
                Console.WriteLine("Wrong current PIN!");
                return;
            }
            _pin = newPin;
            PinChanged?.Invoke();
        }
    }
}