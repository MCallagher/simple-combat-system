
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public interface IHasStatus<T>
    {
        bool HasStatus(T status);
        void AddStatus(T status);
        void RemoveStatus(T status);
        List<T> GetStatuses();
    }
}
