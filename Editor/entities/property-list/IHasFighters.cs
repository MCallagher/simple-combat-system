
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public interface IHasFighters
    {
        void AddFighter(IFighter fighter);
        void RemoveFighter(string name);
        IFighter GetFighter(string name);
        List<IFighter> GetFighters();
    }
}
