using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniRx.Async;

namespace ActionSequence
{
    public class AsyncActionSequenceService : IDisposable
    {
        private readonly HashSet<ConditionsHolder> _conditions = new();
        
        public void Dispose()
        {
            foreach (var condition in _conditions)
            {
                condition.Tcs.TrySetCanceled();
            }
            
            _conditions.Clear();
        }
        
        public UniTask ActionCompleted(string key)
        {
            foreach (var condition in _conditions)
            {
                if (condition.Key == key)
                    return condition.Tcs.Task;
            }
            
            return UniTask.CompletedTask;
        }

        public void AddCondition(string key)
        {
            _conditions.Add(new ConditionsHolder
            {
                Tcs = new UniTaskCompletionSource(),
                Key = key,
            });
        }

        public void MarkAsCompleted(string key)
        {
            foreach (var condition in _conditions)
            {
                if (condition.Key == key)
                    condition.Tcs.TrySetResult();
            }
        }

        class ConditionsHolder
        {
            public UniTaskCompletionSource Tcs;
            public string Key;
        }
    }
}