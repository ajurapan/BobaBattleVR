# BobaBattleVR
A classic bubble shooter game (Puzzle Bobble/Bust-A-Move) remake for VR

There are three main objects in the game: Slingshot, colored ball and a colorful wall of balls. 
Basic game mechanics:
The slingshot is used to shoot a colored ball to the wall of balls, when the colored ball collided with one of the balls in the wall of balls, if they share the same color and are connected then all the balls with the same colored will pop, otherwise the colored ball will stick to the ball it collided. 


## Getting Started

* Download or clone this repository
* Have your HTC Vive set up
* I am using Unity 2018.1.0f2


### Running the game

* Open the game using Unity
* Make sure SteamVR asset is imported and the cameraRig is not missing, to add the SteamVR CameraRig back, import SteamVR asset and in Unity go to "Project" tab -> "Assets" -> "SteamVR" -> "Prefabs" -> drag CameraRig to "Hierarchy" 
* I only put the pickup script on right hand so make sure you are using right controller to pick up the ball using trigger

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details   

## Acknowledgments

* First implementation: Slingshot
** Learning from Fused VR: https://www.youtube.com/watch?v=W0nnDBRC74M

* Ball pick up and drop from: https://learn.vrdev.school/p/vive-developer-mini
