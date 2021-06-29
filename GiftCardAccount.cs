using System;
namespace BankAccount
{

    public class GiftCardAccount : BankAccount
    {
        //BASE CONSTRUCTOR
        //public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
        //{


        //}

        //MODIFY CONSTRUCTOR
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
            => _monthlyDeposit = monthlyDeposit;




        //The constructor provides a default value for the monthlyDeposit value so callers can omit a 0 for no monthly deposit.

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }




    }


}

//derive class each class share behavior from base class
//The override applies the monthly deposit set in the constructor. Add the following code to the Main method to test these changes for the GiftCardAccount and the InterestEarningAccount: