namespace LevelUpChallenge.Solution2.Countable
{
    public class CountableClass1 : ICountable
    {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}
