namespace LevelUpChallenge.Solution2.Countable
{
    public class CountableClass2 : ICountable
    {
        public bool IsDisposed { get; private set; } = false;

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}
