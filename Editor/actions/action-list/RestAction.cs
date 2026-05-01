
using System.Collections.Generic;

namespace SimpleCombatSystem
{
    public class RestAction : ActionFighter1x
    {
        public RestAction(List<object> actionParams) : base(ActionType.Rest, actionParams) { }

        public override void Perform()
        {
            IFighter rester = fighter1;

            // Perform action
            rester.Rest();

            // Update status
            rester.AddStatus(FighterStatus.Rested);
        }
    }
}
