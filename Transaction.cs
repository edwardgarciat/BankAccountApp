using System;
namespace BankAccount
{
    public class Transaction
    {

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }


    }
}


//This does not have any responsability but it nees a few properites.