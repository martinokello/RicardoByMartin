using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Utility;
using Ricardo.Plugins.Services.Interfaces;
using Ricardo.Technical.Test.Pages.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Ricardo.Technical.Test.Infrastructure;
using Ricardo.Models;

namespace Ricardo.Technical.Test.Pages
{
	public partial class SignIn
	{
		[Inject] private LoggedInUserState LoggedInUserState{ get; set; }
		[Inject] private SignInOutState SignInOutState { get; set; }
		[Inject] private Blazored.LocalStorage.ILocalStorageService storage { get; set; } = default!;
        [Inject] private ICustomerService CustomerService { get; set; } = default!;
		[Inject] private Navigation NavManager { get; set; } = default!;
		private string _username = default!;
		private string _password = default!;

		private async Task Submit()
		{
			var signInResult = CustomerService.SignIn(_username, _password);

			await storage.SetItemAsync("LoggedInUser", _username);

			LoggedInUserState.SetLoggedInUser(_username);

			SignInOutState.SetIsSignedIn(true);

			NavManager.NavigateTo("/");

			BackToPreviousPage();
		}

		private void BackToPreviousPage()
		{
			if(NavManager.CanNavigateBack)
				NavManager.NavigateBack();
			else
				NavManager.NavigateTo("/browse");
		}

	}
}
