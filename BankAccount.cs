
using System.Collections.Generic;
using System;
namespace BankAccount
{
    public class BankAccount
    {

        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        //public decimal Balance { get; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        //TWO CONSTRUCTOR AND THE ADITIONAL FIELD
        //This implementation calls MakeDeposit only if the initial balance is greater than 0.
        //Now that the BankAccount class has a read-only field for the minimum balance, the final change is to change the hard code 0 to minimumBalance in the MakeWithdrawal method:
        private readonly decimal minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }



        //public BankAccount(string name, decimal initialBalance)
        //{
        //    this.Owner = name;
        //    MakeDeposit(initialBalance, DateTime.Now, "initial balance");  //The constructor should add the initial trans  //this.Balance = initialBalance;

        //    //To assign the account number
        //    this.Number = accountNumberSeed.ToString();
        //    accountNumberSeed++;
        //}

        private List<Transaction> allTransactions = new List<Transaction>();



        // Here, the MakeDeposit method throws an exception if the amount of the deposit is not greater than 0
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);


        }


        //The MakeWithdrawal method throws an exception if the withdrawal amount is not greater than 0, or if applying the withdrawal results in a negative balance. 
        //public void MakeWithdrawal(decimal amount, DateTime date, string note)
        //{


        //    if (amount <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        //    }
        //    if (Balance - amount < minimumBalance)// 0 changed to minimun balance
        //    {
        //        throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        //    }
        //    var withdrawal = new Transaction(-amount, date, note);
        //    allTransactions.Add(withdrawal);


        //}

        //The last feature to add enables the LineOfCreditAccount to charge a fee for going over the credit limit instead of refusing the transaction.
        //NEW MAKE WITHDRAW MWETHOD
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }




        //GetAccountHistory method that creates a string for the transaction history.

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }


        public virtual void PerformMonthEndTransactions() { }

    }


   





}



//Creating a new object of the bank Accouint mean defining a constructor use to initialize objects of the class
//Constructor arer call when you create an object new
//The number is private which means it can be only access inside the BankAccount class
//It is also STATIC WHICH MEANS ITS SHARE BY ALL BANK ACCOUNT OBJECTS
//Virtuel is specify in BankAccount class for the derive class overide behavior (overwritting the base implementation)


//This code fails because the BankAccount assumes that the initial balance must be greater than 0. Another assumption baked into the BankAccount class is that the balance can't go negative. Instead, any withdrawal that overdraws the account is rejected. Both of those assumptions need to change
//Let's start by adding a second constructor that includes an optional minimumBalance parameter. This new constructor does all the actions done by the existing constructor. Also, it sets the minimum balance property. You could copy the body of the existing constructor. but that means two locations to change in the future. Instead, you can use constructor chaining to have one constructor call another. 