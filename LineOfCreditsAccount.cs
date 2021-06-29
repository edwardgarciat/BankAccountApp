using System;
namespace BankAccount
{
    public class LineOfCreditsAccount : BankAccount
    {

        //public LineOfCreditsAccount(string name, decimal initialBalance) : base(name, initialBalance)
        //{


        //}

        //NEW CONSTRUCTOR
        //After extending the BankAccount class, you can modify the LineOfCreditAccount constructor to call the new base constructor, as shown in the follo
        //wing code:
        //Notice that the LineOfCreditAccount constructor changes the sign of the creditLimit parameter so it matches the meaning of the minimumBalance parameter.
        public LineOfCreditsAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }


        //The code negates the balance to compute a positive interest charge that is withdrawn from the account:


        //Add the following implementation in the LineOfCreditAccount to charge a fee when the withdrawal limit is exceeded:

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;




        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }


    }
}
