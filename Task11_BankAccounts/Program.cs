using System;

namespace Task11_BankAccounts
{
    /// <summary>
    /// Базовый класс Банковский счёт
    /// </summary>
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance >= 0 ? initialBalance : 0;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма пополнения должна быть больше 0.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Счет {AccountNumber}: пополнено на {amount:C}. Баланс: {Balance:C}");
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма снятия должна быть положительной.");
                return false;
            }

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Счет {AccountNumber}: снято {amount:C}. Баланс: {Balance:C}");
                return true;
            }

            Console.WriteLine($"Счет {AccountNumber}: недостаточно средств. Баланс: {Balance:C}, запрос: {amount:C}");
            return false;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Счёт: {AccountNumber} | Баланс: {Balance:C}");
        }
    }

    /// <summary>
    /// Сберегательный счет с начислением процентов и неснижаемым остатком
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; } // Например, 0.08m для 8%
        public decimal MinimumBalance { get; set; }

        public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate, decimal minBalance = 1000m) 
            : base(accountNumber, initialBalance)
        {
            InterestRate = interestRate;
            MinimumBalance = minBalance;
        }

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate;
            Balance += interest;
            Console.WriteLine($"На сберегательный счет {AccountNumber} начислены проценты (+{InterestRate:P}): +{interest:C}. Новый баланс: {Balance:C}");
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;
            if (Balance - amount < MinimumBalance)
            {
                Console.WriteLine($"Ошибка снятия! Неснижаемый остаток {MinimumBalance:C}. Доступно для снятия: {(Balance - MinimumBalance):C}");
                return false;
            }
            return base.Withdraw(amount);
        }
    }

    /// <summary>
    /// Кредитный счет с кредитным лимитом и овердрафтом
    /// </summary>
    public class CreditAccount : BankAccount
    {
        public decimal CreditLimit { get; set; }

        public CreditAccount(string accountNumber, decimal initialBalance, decimal creditLimit) 
            : base(accountNumber, initialBalance)
        {
            CreditLimit = creditLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;

            // Доступно: баланс + кредитный лимит
            if (Balance - amount >= -CreditLimit)
            {
                Balance -= amount;
                Console.WriteLine($"Кредитный счет {AccountNumber}: снято {amount:C}. Баланс: {Balance:C} (Лимит: {CreditLimit:C})");
                return true;
            }

            Console.WriteLine($"Превышен кредитный лимит! Доступно всего: {(Balance + CreditLimit):C}, запрос: {amount:C}");
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 11. Банковские счета ===\n");

            SavingsAccount savings = new SavingsAccount("SAV-101", 10000m, 0.075m, 2000m);
            CreditAccount credit = new CreditAccount("CRD-505", 1500m, 20000m);

            Console.WriteLine("--- Сберегательный счет ---");
            savings.DisplayInfo();
            savings.Deposit(5000m);
            savings.ApplyInterest();
            savings.Withdraw(12000m); // Попытка превысить неснижаемый остаток
            savings.Withdraw(3000m);

            Console.WriteLine("\n--- Кредитный счет ---");
            credit.DisplayInfo();
            credit.Withdraw(5000m);  // Уход в минус (в кредит)
            credit.Withdraw(16000m); // Попытка превысить кредитный лимит
            credit.Deposit(10000m);

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}