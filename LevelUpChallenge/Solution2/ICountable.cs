using System;

namespace LevelUpChallenge.Solution2
{
    public interface ICountable : IDisposable
    {
        bool IsDisposed { get; }
    }
}
