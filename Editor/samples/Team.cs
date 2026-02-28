
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class Team : ITeam
    {
        protected string name;
        protected Dictionary<string, IFighter> fighters;
        protected HashSet<TeamStatus> statuses;

        public Team(string name)
        {
            this.name = name;
            fighters = new();
            statuses = new();
        }

        public Team(string name, List<IFighter> fighters) : this(name)
        {
            foreach (IFighter fighter in fighters)
            {
                AddFighter(fighter);
            }
        }

        // IHasName
        public string GetName()
        {
            return name;
        }

        // IHasFighters
        public void AddFighter(IFighter fighter)
        {
            fighter.SetTeam(this);
            fighters.Add(fighter.GetName(), fighter);
        }

        public void RemoveFighter(string name)
        {
            fighters[name].ResetTeam();
            fighters.Remove(name);
        }

        public IFighter GetFighter(string name)
        {
            return fighters[name];
        }

        public List<IFighter> GetFighters()
        {
            return new(fighters.Values);
        }

        // IHasStatus
        public void AddStatus(TeamStatus status)
        {
            statuses.Add(status);
        }

        public bool HasStatus(TeamStatus status)
        {
            return statuses.Contains(status);
        }

        public void RemoveStatus(TeamStatus status)
        {
            statuses.Remove(status);
        }
    }
}
