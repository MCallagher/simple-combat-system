# Combat Rules for v0.2.1

## Basic mechanics

| Type | Description |
| ---- | ----------- |
| Participants | The combat involves two teams with one or many fighters each. |
| Turns | The fight has a team-level turn-based mechanic: a team act, then the other team act. |
| Victory | The victory contidition is the death of all the fighters of a team. |

## Entities abilities

| Entity | Ability | Rules |
| ------ | ------- | ----- |
| Fighter | A fighter can attack another fighter | Only one attack per turn, cannot attack dead fighters, cannot attack if dead, cannot attack fighter in the same team |
| Team | A team can take the initiative and start the fight | Only in the first turn of the fight |
| Team | A team can pass turn | |
| Fighter | A fighter can rest | The team must have at least another fighter that is active (not dead nor resting), only one fighter can rest per turn per team |
