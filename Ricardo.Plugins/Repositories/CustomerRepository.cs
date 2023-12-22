using Ricardo.Models;
using Ricardo.Plugins.Repositories.Interfaces;

namespace Ricardo.Services.Repositories
{
    public class CustomerRepository : ICustomerRepository
	{
		private readonly List<Customer> _customers = new();

		public CustomerRepository()
		{
			//Data seeding
			_customers.Add(new Customer(BankAccount.Open(200), "test", "1234", "Jeremy Irons"));
		}

		public Customer? FindCustomerByUsernameAndPassword(string username, string password)
		{
			var Customer = new Customer(null, "", "", "");
			foreach (var customer in _customers)
			{
				bool found = false;
				if (customer.Username == username)
				{
					if (customer.Password == password)
					{
						found = true;
					}
					else
					{
						found = false;
					}
				}

				if (found == true)
				{
					Customer = customer;
				}
			}

			if (Customer == null)
			{
				return new Customer(null, "", "", "");
			}
			else
			{
				return Customer;
			}
		}

	}
}
