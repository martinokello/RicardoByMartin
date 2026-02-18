using Ricardo.Plugins.BankAccount.Interfaces;
using Ricardo.Technical.Test.Errors;

namespace Ricardo.Plugins.BankAccount
{
	public class BankAccount:IBankAccountServices
	{
		public int Money { get; set; } 

		public BankAccount()
		{
		}

		public bool CanWithdraw(int amount)
		{
			return Money >= amount;
		}

		public void Withdraw(int amount)
		{
			Money -= amount;
		}

		public static BankAccount Open(int money)
		{
			if(money >= 1)
			{
                var bankAccount = new BankAccount();
				bankAccount.Money = money;
				return bankAccount;
            }
			throw new InsufficientFundsException("Cannot open a bank account with less than £1.");
		}
	}
}
