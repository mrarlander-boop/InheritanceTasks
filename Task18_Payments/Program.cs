using System;
using System.Collections.Generic;

namespace Task18_Payments
{
    /// <summary>
    /// Базовый класс Платеж
    /// </summary>
    public class Payment
    {
        public string TransactionId { get; }
        public DateTime Date { get; }

        public Payment()
        {
            TransactionId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Date = DateTime.Now;
        }

        public virtual void Pay(double amount)
        {
            Console.WriteLine($"[Транзакция #{TransactionId} от {Date:g}] Базовый платеж на сумму {amount:F2} руб.");
        }
    }

    /// <summary>
    /// Оплата наличными (расчет сдачи)
    /// </summary>
    public class CashPayment : Payment
    {
        public double CashGiven { get; set; }

        public CashPayment(double cashGiven)
        {
            CashGiven = cashGiven;
        }

        public override void Pay(double amount)
        {
            Console.WriteLine($"[Оплата наличными #{TransactionId}]");
            Console.WriteLine($"К оплате: {amount:F2} руб. | Внесено покупателем: {CashGiven:F2} руб.");
            if (CashGiven >= amount)
            {
                double change = CashGiven - amount;
                Console.WriteLine($"Успешно! Сдача: {change:F2} руб. Кассовый чек напечатан.");
            }
            else
            {
                Console.WriteLine($"Ошибка! Недостаточно наличных: не хватает {(amount - CashGiven):F2} руб.");
            }
        }
    }

    /// <summary>
    /// Оплата банковской картой
    /// </summary>
    public class CardPayment : Payment
    {
        public string CardNumber { get; set; }
        public double BankCommissionPercent { get; set; } = 0.015; // 1.5%

        public CardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        private string GetMaskedCard()
        {
            if (CardNumber.Length >= 4)
                return "**** **** **** " + CardNumber.Substring(CardNumber.Length - 4);
            return CardNumber;
        }

        public override void Pay(double amount)
        {
            double commission = amount * BankCommissionPercent;
            double total = amount + commission;

            Console.WriteLine($"[Оплата картой {GetMaskedCard()} #{TransactionId}]");
            Console.WriteLine($"Сумма: {amount:F2} руб. + Комиссия банка ({BankCommissionPercent:P1}): {commission:F2} руб.");
            Console.WriteLine($"Итого списано с карты: {total:F2} руб. Оплата успешно авторизована.");
        }
    }

    /// <summary>
    /// Онлайн-платеж (СБП, электронный кошелек)
    /// </summary>
    public class OnlinePayment : Payment
    {
        public string PaymentGateway { get; set; }
        public string UserEmail { get; set; }

        public OnlinePayment(string gateway, string userEmail)
        {
            PaymentGateway = gateway;
            UserEmail = userEmail;
        }

        public override void Pay(double amount)
        {
            Console.WriteLine($"[Онлайн-платеж через {PaymentGateway} #{TransactionId}]");
            Console.WriteLine($"Сумма: {amount:F2} руб. Оплата проведена по QR-коду / СБП без комиссии.");
            Console.WriteLine($"Электронный фискальный чек отправлен на email: {UserEmail}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Задание 18. Платежи (CashPayment, CardPayment, OnlinePayment) ===\n");

            List<Payment> payments = new List<Payment>
            {
                new CashPayment(2000.00),
                new CardPayment("2200123456789876"),
                new OnlinePayment("СБП (Система быстрых платежей)", "customer@gmail.com")
            };

            double orderAmount = 1450.00;

            foreach (var p in payments)
            {
                p.Pay(orderAmount);
                Console.WriteLine(new string('-', 55));
            }

            Console.WriteLine("\nЗавершено успешно. Нажмите Enter...");
        }
    }
}