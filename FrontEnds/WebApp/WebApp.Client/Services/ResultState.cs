namespace WebApp.Client.Services
{
    public class ResultState
    {
        public int? Result { get; private set; }

        // Evento que notifica cambios; pueden usar Action, EventHandler, o IObservable según preferencia
        public event Action? OnChange;

        public void SetResult(int result)
        {
            Result = result;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
