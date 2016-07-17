namespace SR.Core.Context
{
    public abstract class ContextSingleton<T> where T : class
    {
        protected static T Instance { get; private set; }

        protected ContextSingleton()
        {
            lock (_lock)
            {
                if (Instance == null)
                {
                    Instance = this as T;
                }
            }
        }

        private readonly object _lock = true;
    }
}
