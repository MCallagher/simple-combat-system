
![Engine: Unity 6](https://img.shields.io/badge/Engine-Unity%206-000000)
![Version: 1.0.0](https://img.shields.io/badge/Version-1.0.0-green)

# Simple Combat System for Unity
A lightweight, extensible, and highly customizable turn‑based combat system designed for Unity projects.
This library provides a clean architecture built around three core pillars—Entities, Actions, and Rules—plus a set of shared Commons utilities such as Health management.

Its goal is to offer a flexible foundation that teams can adapt to different game mechanics without rewriting core combat logic.

## Features
- Modular architecture
- Fully customizable actions, rules, and entities
- Clear separation between what an action is, who performs it, and whether it is allowed
- Extensible rule validation system with detailed violation reporting
- Flexible health model supporting multiple health pools (e.g., HP, armor, magical armor)
- Designed for team‑based, turn‑based combat (but flexible and generic)

## Architecture Overview
The system is structured around three main pillars:
1. Entities: represents the actors in combat, Fighters and Teams
2. Actions: represent what entities can do and apply their effects directly to entities
3. Rules: define whether an action is valid

Shared utilities, currently includes:
- Health: a dictionary‑based health model with arithmetic operators and comparison logic

## Customization Summary

| Area     | What You Can Customize                               |
| -------- | ---------------------------------------------------- |
| Actions  | Types, modes, execution                              | 
| Entities | Property interfaces, fighter/team interfaces, status | 
| Rules    | Rule classes, violation classes                      |
| Health   | Operators logic                                      |

## Getting Started

1. Clone the repository
2. Import the library into your Unity project
3. Implement your own fighters, teams, actions, and rules
4. Integrate the system into your turn‑based loop

## Documentation
More information can be found [here](/docs/index.md)

Repository setup with [unity-upm-package-template](https://github.com/MCallagher/unity-upm-package-template)
