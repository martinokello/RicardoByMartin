using Ricardo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ricardo.Plugins.Utility
{
    public class SessionManager
    {
		public Customer Customer { get; private set; } = null!;

        public event Action? OnSignIn;
		public event Action? OnSignOut;
		public void SignedIn(Customer customer)
        {
            Customer = customer;
			NotifySignedIn();
        }
		public void SignedOut(Customer customer)
		{
			Customer = null;
			NotifyLoggedOut();
		}

		public void NotifySignedIn() => OnSignIn?.Invoke();
		public void NotifyLoggedOut() => OnSignOut?.Invoke();
	}
}
