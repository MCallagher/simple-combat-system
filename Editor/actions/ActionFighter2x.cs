
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public abstract class ActionFighter2x : Action
    {
        public IFighter fighter1 { get; }
        public IFighter fighter2 { get; }
        public ActionFighter2x(ActionType actionType, List<object> actionParams) : base(actionType, ActionMode.Fighter2x, actionParams)
        {
            fighter1 = (IFighter)actionParams[0];
            fighter2 = (IFighter)actionParams[1];
        }
    }
}
