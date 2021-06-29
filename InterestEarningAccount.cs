using System;
namespace BankAccount
{

    public class InterestEarningAccount : BankAccount
    {

        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {


        }





        //The code negates the balance to compute a positive interest charge that is withdrawn from the account:
        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }





     

    }



}

//You could modify its implementation without affecting any of the code that used the BankAccount class
//However, each account type does different tasks. You use polymorphism to implement this code. Create a single virtual method in the BankAccount class:

