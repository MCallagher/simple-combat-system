
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public abstract class Action
    {
        protected ActionType actionType;
        protected ActionMode actionMode;
        protected List<object> actionParams;

        public Action(ActionType actionType, ActionMode actionMode, List<object> actionParams)
        {
            this.actionType = actionType;
            this.actionMode = actionMode;
            this.actionParams = actionParams;
        }

        public ActionType GetActionType()
        {
            return actionType;
        }

        public ActionMode GetMode()
        {
            return actionMode;
        }

        public List<object> GetParams()
        {
            return actionParams;
        }

        public abstract void Perform();
    }
}
