# game-with-adaptive-npc-behavior
**Cardbox Trap** is a 3D maze game developed in Unity including AI Technologies as a part of an academic project for the course **Advanced Game Development**.

## Game Overview
- Game scene represents a maze
- Movement controls: → (right), ← (left), ↑ (forwards), ↓ (backwards)
- There is a time countdown (3 min)
- There are 11 enemies (NPCs), a succesful attack by an enemy has a time penalty
- The goal is to find the way out within the time limit 

## AI Technologies
### NPC behavior
- An NPC moves with NavMesh
- If player gets inside NPC's field of view chasing mode is activated
- If there is a collision with the player the attack is succesful and it costs 15 sec from the player's remaining time
- After a succesful attack the NPC gets vanished
- If the player gets out of NPC's field of view, the NPC stops chasing and returns to its initial position

### Level Adaptation
- If player finds the way out within the first minute, maze changes a bit and a new way out must be found
- A form of Dynamic Difficulty Adjustment - DDA

## Tech Stack
- **Engine:** Unity
- **Language:** C#

## How to Run
- Open the Project in Unity 6
- The *Library* folder has been deleted to reduce the project size, so you need to select the *MenuScene* from the *Scenes* folder.
- Press Run to start 
