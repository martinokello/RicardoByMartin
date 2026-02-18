using Ricardo.Models;
using Ricardo.Plugins.Repositories.Interfaces;
using Ricardo.Plugins.Services.Interfaces;
using Ricardo.Plugins.Utility;

namespace Ricardo.Plugins.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly SessionManager _sessionManager;

        public CustomerService(ICustomerRepository repository, SessionManager sessionManager)
        {
            _repository = repository;
            _sessionManager = sessionManager;
        }

        public Customer? SignIn(string username, string password)
        {
            var customer = _repository.FindCustomerByUsernameAndPassword(username, password);
            if (customer != default!)
            {
                _sessionManager.SignedIn(customer);
            }
            return customer;
        }

		public void SignOut(string username, string password) => _sessionManager.SignedOut(new Customer(account: new Models.BankAccount(0)
				, username: username, password: string.Empty, name: string.Empty));
	}
}
