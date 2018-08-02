using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelUpChallenge.Solution1
{
    public abstract class Countable : IDisposable
    {
        private static Dictionary<string, List<Countable>> CreatedInstancesCount = new Dictionary<string, List<Countable>>();

        public bool IsDisposed { get; private set; } = false;

        public Countable()
        {
            this.IncrementCreatedInstanceCount();
        }

        public static string PrintInstancesCount()
        {
            if (!CreatedInstancesCount.Keys.Any())
            {
                return "There have been no classes instantiated";
            }

            var sb = new StringBuilder();

            foreach (var instance in CreatedInstancesCount)
            {
                sb.AppendLine($"{instance.Key}: Instances created: {instance.Value.Count}. Instances still alive: {instance.Value.Count - instance.Value.Where(i => i.IsDisposed).ToList().Count}");
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            this.IsDisposed = true;
        }

        private void IncrementCreatedInstanceCount()
        {
            var className = this.GetType().Name;

            if (!CreatedInstancesCount.ContainsKey(className))
            {
                CreatedInstancesCount.Add(className, new List<Countable>());
            }

            CreatedInstancesCount[className].Add(this);
        }
    }
}
