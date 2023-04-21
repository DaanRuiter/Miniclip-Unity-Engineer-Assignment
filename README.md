# Miniclip-Unity-Engineer-Assignment
## Wack-A-Mole

### About
This project serves as an assessment of my capabilities for the Unity Engineer position at Gamebasics/Miniclip.

The focus for this project was on the code structure and principles while the presentation was kept very simple.

The project contains a playable android build at **Builds/WackAMole.apk**.

### Structure
The main entry point for this project is the Main class, where a game instance can be passed along with its dependencies.
This is done from the WackAMoleSceneWrapper which passes the game instance and some scene references. This means the core structure, apart from some standard UI and factory implementations, does not require Unity to function and could be called from different engines/frameworks.
Calling the Init method on Main will initialize the games loop and state.
The code is split into three parts: 
- The core part which supports an abstract implementation of a small where the player can achieve a score.
- The common part that contains standard/common implementations of the core's interfaces that can be used by any game's implementation.
- The Wack-A-Mole part that contains all the games specific implementations and logic.
This means that you could, with little effort, create a new type of game in this structure and get it working by only having to worry about this game's specific implementations.

### Improvements
I would make the following improvements to this project if I had more time.

- Scores split per game implementation.
    - Currently the scores are stored using the key Highscores. if you would include the current game's name in this key you could store the scores for each game independently.
- Prefab collection
    - Currently prefabs are loaded by their resource path and are mostly hardcored. Creating a scriptable asset allows you to store prefab paths in text form or even allow you to directly link prefabs themselves.
- Editable Game config
    - The game has a config class containing a number of tweakable gameplay settings. Adding an in-game editor for these settings allows you to tweak and experiment with the values easily. 

### Known issues
- Some of the UI does not scale well with smaller screen sizes.
- When wacking a mole that is still in it's appearing animation can result in a small animation jump.
- The scoreboard does not initially focus on the top scores.