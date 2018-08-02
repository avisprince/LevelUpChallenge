using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelUpChallenge.Solution2
{
    public class CountableInstanceFactory
    {
        private static Dictionary<string, List<ICountable>> CreatedInstancesCount = new Dictionary<string, List<ICountable>>();

        public ICountable Create(Type className)
        {
            try
            {
                var instance = (ICountable)Activator.CreateInstance(className);
                this.IncrementCreatedInstanceCount(instance);

                return instance;
            }
            catch (Exception e)
            {
                return null;
            }
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

        private void IncrementCreatedInstanceCount(ICountable instance)
        {
            var className = instance.GetType().Name;

            if (!CreatedInstancesCount.ContainsKey(className))
            {
                CreatedInstancesCount.Add(className, new List<ICountable>());
            }

            CreatedInstancesCount[className].Add(instance);
        }
    }
}
