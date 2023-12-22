namespace Ricardo.Technical.Test.Infrastructure
{
	public class SignInOutState
	{
		public bool IsSignedIn { get; private set; }
		public event Action OnChange;

		public void SetIsSignedIn(bool isSignedIn)
		{
			IsSignedIn = isSignedIn;
			NotifyStateChanged();
		}
		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}
