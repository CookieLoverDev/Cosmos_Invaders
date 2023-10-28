# Cosmos_Invaders
This is my second project in Unity and trying out myself in Game Development
It is a recreation of absolute banger of a game "Space Invaders"

![alt text](https://i.postimg.cc/KjVs2sP5/image.png)

It was done in pretty messy way and it could have been done better, for example with the usage of Interfaces.
All of the sprites and background music was taken from royalty free sources.
The sound effects was generated in BFXR

All the scripts can be found in the scripts folder, however the codes are not commented with explanations yet.
Here are some basic informaton how everything works:
All enemies are generated through loop from a prefab and placed in a list.
Their movement is implemented through the looping thru the list and moveming them all togehter.
When they reach triggers placed on right and left, it changes the boolean "moveRight" to the opposite and enemies move down and start moving to the opposite direction, they were moving.
Their attack is implemented through the loop, code chooses random 5 enemies, that will shoot and it creates a bullet, that moves toward the player.
Other explanations will be written in the code comments pretty soon