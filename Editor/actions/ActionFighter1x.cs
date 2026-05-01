
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public abstract class ActionFighter1x : Action
    {
        public IFighter fighter1 { get; }
        public ActionFighter1x(ActionType actionType, List<object> actionParams) : base(actionType, ActionMode.Fighter1x, actionParams)
        {
            fighter1 = (IFighter)actionParams[0];
        }
    }
}
