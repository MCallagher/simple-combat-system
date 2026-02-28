# Intro
This repository aim to build a simple, extensible, and customizable combat system.
The features were designed for a team, turn-based combat.

## Architecture
There are 3 pillars that compose the fundaments of the architecture:
- Entities: the entities that interact in the fight
- Actions: the actions that the entities can performs
- Rules: the rules that the action need to satisfy to be performed
Other than this, there are other elements that are not strictly specific to these pillars and falls in the generic area of "commons", e.g. the health.

The combat system lies heavily on this pillars: its tasks are limited to checking the validity on the actions using the rules and to apply their effects on the entities.

![High-level architecture](img/ark-overall.png)

More details can be found in the following sections:
- Pillars
    - [Entities](pillars/entities.md)
    - [Actions](pillars/actions.md)
    - [Rules](pillars/rules.md)
- Commons
    - [Health](commons/health.md)
