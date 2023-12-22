using Blazored.LocalStorage;
using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.UseCases.CustomerOrderHistoryUseCase
{
    public class CustomerOrderHistoryUseCase
    {
		private ILocalStorageService _localStorage;

		public CustomerOrderHistoryUseCase(ILocalStorageService localStorage) {
            _localStorage = localStorage;
        }
        public async Task<List<OrderItem>> GetCustomerOrderHistory(Customer customer)
        {
			
			var history =await _localStorage.GetItemAsync<List<OrderItem>>($"Customer_{customer.Username}") ?? new List<OrderItem>();
            return history;
        }
    }
}
