# 8-bit-game
KTU projektas
# The Game

Team members:
```
 MATAS PAGALYS
 MARTYNAS BINISEVIČIUS
 MARTYNAS RIMKEVIČIUS
 TOMAS JANKAUSKAS
```

# Technical Task


  Our team decided to create an 8-bit style game. We will develop a platform game using the c# programming language and the Unity game engine, which has a variety of tools that help us create 2D or 3D games. The style of the game is similar to classic games like "Mario", "Hollow knights", "Gris", "Celeste", etc. The goal of our game is to collect all the special objects to unlock the passage to the new level.

The player will be able to control the main character, who will be able to move freely across the map. The levels will have obstacles of varying difficulty that the player will have to overcome by using the level layout. The player will be greeted by moving dangerous objects that will take the life of the protagonist and the level will have to be repeated. There may also be platforms that can disappear after a second or two, or platforms that need to be activated in order to be able to climb up them and reach the desired destination, or even moving platforms. The player will also be able to collect useful objects such as a shield that saves them from injury and so on.

All in all, this will be an 8bit adventure platform game where collecting special objects will allow you to move to the next level
   
# Architektūra

![image](https://github.com/MartynasBinis/8-bit-game/assets/104345266/775bf682-330f-4e60-97c6-b9929fce27dc)

# Testing

| Description of test  | Expected results  |  Actual results |
|---|---|---|
|  PLayer basic movement script  | The character can wiggle from side to side and can jump  |  the character can move through the level normally and can jump |
| Wall jumping  |  PLayer is able to smoothly jump from wall to wall | Player is able to jump from wall to wall but it's easy to fall off and doesnt have a good grip on the wall   |
| Player has a health and can lose it |  When player touches the spike trap it loses hp and when dies gets game over menu |  Player loses hp and gets game over menu when dies but if player has less then 0hp game bugs out |
| Player is on moving platforms  | PLayer is able to stay still on platform and ride a long side with a platform, and reach end point of a platform where its going  | Player is able to stay still and reach other side but it takes properties from moving platform when staying on it  |
| Moving enemy | When player touches the enemy it takes damage  | Player takes damage but also player can push enemy away  |
| Knockback from a trap  | It should spring back a player when touched  | Knocback doesnt work at all and sometimes it bugs out a game  |
| Gravity potion  | When player picks up a potion player is able to manipulate gravity by activating pressing G and controlling it by W and S  | Player can control gravity but player is able to use gravity everywhere and can abuse the level  |
| Coin collect  | When collected all coins player advances to another lever  | After collecting  5 coins player moves to level 2  |
|  Pushable object |  When player pushes the rock on the red trigger, trigger should become green and door which was closed should open up for player  | Rocked pushed on trigger it turns green and door which was closed opens up for advancing and also when player manipulates gravity object also gets affected  |
|  Telport player  | Player is able to use teleporter and teleport to a other teleporter wto which is linked to  | PLayer is able to freely walk through teleports at will at anytime  |
| Shooting trap  | Player should see a trap shooting arrows and should be able to take damage from them  | Player is able to get damage from the trap and is able see them but arrows innteract with other invisible objects which stop arrows from travelling  |
|  Dissapearing platform |  PLayer is able to see platforms which dissapear after few seconds and appear back also can jump on them | Player indeed can jump on them and platforms dissapear and come back for player to jump on  |
|  Gravity zone |  Player is now able to use gravity in specific zones indicated by icon | player only can use powers in special zones  |
| Launch pad  | Player is able to use launch pad which can lift player up and go down  |  Player walking on the launch pad it lifts player up and while pressing S keyword it goes down the stream of wind |

# User documentation

  Once the game is started, you will be taken to the main menu where you can choose to play the game, adjust the sound, start and quit a game you have played in the past. Once in the game, the character is controlled with the WASD keys. A, D to walk sideways W and S will be used to change gravity and SPACE will make the character jump. The player's goal is to collect coins on the level to move to the next level.

