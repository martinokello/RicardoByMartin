using Microsoft.AspNetCore.Components;
using Ricardo.Plugins.Utility;
using Ricardo.Technical.Test.Infrastructure;
using Ricardo.Technical.Test.Utility;
using Blazored.LocalStorage;
using Ricardo.Models;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class UserWidget : IDisposable
	{
		[Inject] public LoggedInUserState? loggedInUserState { get; set; } = default!; 
		[Parameter] public bool IsSignedIn { get; set; }
		[Inject] private SignInOutState signInOutState { get; set; } = default!;
		[Inject]
		private ILocalStorageService ProtectedLocalStorage { get; set; } = default!;
		[Inject] private Navigation NavManager { get; set; } = default!;
		[Inject] private SessionManager SessionManager { get; set; } = default!;

		protected override void OnInitialized()
		{
			SessionManager.OnSignIn += StateHasChanged;
			
			base.OnInitialized();
		}
		public void NavigateToSignIn()
		{
			NavManager.NavigateTo("/signin");
		}
		public async Task  NavigateToSignOut()
		{
			await ProtectedLocalStorage.SetItemAsync<string>("LoggedInUser", null);
			SessionManager.SignedOut(SessionManager.Customer);

			signInOutState.SetIsSignedIn(false);
			IsSignedIn = false;
			NavManager.NavigateTo("/");
		}
		public void Dispose()
		{
			SessionManager.OnSignIn -= StateHasChanged;
			SessionManager.OnSignOut-= StateHasChanged;
		}

	}
}
