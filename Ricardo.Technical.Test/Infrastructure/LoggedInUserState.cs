using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Ricardo.Technical.Test.Infrastructure
{
	public class LoggedInUserState
	{
		public string Username { get; protected set; } = string.Empty;
		public event Action UsernameChanged;
		public void SetLoggedInUser(string username)
		{
			this.Username = username;
			NotifyStateChanged();
		}
		private void NotifyStateChanged() => UsernameChanged?.Invoke();
	}
}
