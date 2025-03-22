Climb to the Star


1. Introduction

Climb to the Star is a 2D platformer game in which players will jump across different layers of clouds to conquer the distant star peak. The game requires dexterity, patience and precise timing skills.

2. Story

In a world where stars are not only lights in the sky but also sources of endless power, there exists a legend of the Royal Star - a star that can grant its owner ultimate power.
Our protagonist was once a Star Knight, a mighty warrior tasked with protecting this star. But due to a treacherous plot, he was defeated and thrown into the deepest abyss of the world. With no title, no weapons, only determination, he began his journey to conquer the sky, leaping step by step into the clouds, passing through ancient ruins. His goal was not only to regain his honor, but also to return to the place where he was born.
Do you have the strength to climb to the top of the sky and take back what is yours?

3. Gameplay

●  	Jumping mechanism: Characters can hold down the jump key to accumulate power to jump higher.
●  	Scoring system:
○  	Each successful jump: +1 point.
●  	Your Majesty:
○  	The clouds gradually faded and disappeared.
○  	The angle of the wind blowing the character.
○  	Moving object.
○  	Clouds move sideways/in and out.
○  	The clouds jumped high.
●  	End: When the character reaches the top of the cloud, the victory screen/cutscene appears.

4. Environment & Level Design

The game consists of 4 levels:
●  	Ruins of Eden- Basic level, everything is normal.
●  	Howling Peak- Wind obstructs, moving objects, characters will be pushed by the wind.
●  	The Frozen Land- The ground is slippery, the character will slide continuously.
●  	The Chaos Sky- Clouds move continuously, the character will fall if standing on them for too long.

5. Background Music & Sound

●  	Each floor has its own unique background music.
●  	Sounds of jumping, crashing, snapping, etc.
●  	Character animation: Stand still, move, exert force, jump, fall, pile up dirt, tumble.

6. Technology & Tools

●  	Engine: Unity
●  	Language: C#
●  	Develop: Visual Studio
●  	Sound: NoCopyright, Youtube, Asset Store.

7. Challenges & Development Directions

●  	Hard:
○  	Build smooth jumping mechanics.
○  	Bite by difficulty.
○  	More levels need new ideas
○  	Graphics and background music must be of good quality.
●  	Future Development:
○  	Add speedrun mode.
○  	Increase interaction with the environment.
○  	Leaderboard system.
○  	Expand the plot.
 
 
8. UI & Mechanics and Levels

1 : Menu Interface

![image](https://github.com/user-attachments/assets/0a1c3afa-8352-416d-a6f4-d491a8afb83c)

- Includes Play, Score, Exit and Guide buttons

●  	Press the Play button to enter the game screen.
●  	Score will help store scores
●  	The Exit button will exit the game.
●  	The Tutorial button will guide new players.

2: Game interface

- Act 1: Ruins of Paradise

![image](https://github.com/user-attachments/assets/7b369322-d9eb-49eb-b711-ae44a049450c)

- Mechanics of stage 1: Simple, basic without any difficulty

●  	There are butterflies flying, crickets chirping, flowers, trees, decorated houses…
●  	Camera effects by screen, background sound by screen.



- Act 2: The Windy Peak

![image](https://github.com/user-attachments/assets/bee9abd4-612a-4ecd-91ea-b974dd2e3be3)


- Mechanics of stage 2: More difficult, there will be continuous winds blowing from left to right, from right to left causing the player to be pushed away.

●  	There is a wind effect, objects floating down
●  	Camera effects by screen, background sound by screen

- Act 3: The Frozen Land

![image](https://github.com/user-attachments/assets/8cfaec89-2a82-4a6b-a8db-1c11a84fd61e)

- Stage 3 Mechanism: Objects will be slippery, causing the character to slip when in contact, requiring the player to move continuously.

●  	Entities have slippery properties.
●  	Has snow falling effect from top to bottom
●  	Camera effects by screen, background sound by screen.
 
- Act 4: The Chaos Sky

![image](https://github.com/user-attachments/assets/6692f9a4-bebe-42a4-9f03-092fbf19d4b8)

- Stage 4 Mechanics: The clouds will move from left to right continuously and will disappear after a while if there is contact with the player.
●  	The entity moves and disappears after a while if there is player contact.
●  	Camera effects by screen, background sound by screen.
●  	If the player climbs to the highest cloud and jumps, the ending cutscene will appear.
 
- Act 5: CutScene ends.

![image](https://github.com/user-attachments/assets/6c1204fc-a121-4612-87bd-3a691c9a6530)

-  Mechanism: After completing, the player will be taken to the ending Scene.

●  	1 minute video explaining more about the plot
●  	There is a Skip button, when pressed it will return to the Menu page.
●  	After the video ends, the player will automatically return to the Menu page.
 
- About Character / Character.
- The character has 6 separate animations:

●  	Stationary
●  	Move
●  	Exercise
●  	Jump up
●  	Jump down (landing)
●  	Fall/face down.
 
- The character has 3 sound effects:

●  	On the move
●  	When jumping up (after exhausting energy)
●  	When landing
 
- The camera frame is designed separately for each map so that other structures are not exposed, increasing the player experience.
- The background music sounds different in each level.
- Automatically save player position when player exits.
- Automatically save player's score.
 

