
## Creator Notes

1. Why my Player wouldn't fall when going off the map:
    - Turn off "is Kinamatic" 
2. When creating a Player
    - Don't forget the Ridgid body components
    - Add the PlayerController Script by dragging it onto the GameComponent
3. Camera Controller
    - I remember that you don't add the main camera onto the Player
    - Instead you add the CameraController script to the main camera
    - There is an initalized GameComponent variabel in the script we wrote, so you need to drag and drop the PlayerComponent to that box in the Unity Editor 
    - You also need to rotate the camera down in the Unity Editor (recommended 30-45 degrees) to see the player
4. Needed to connect the chest lid ato the body
   - Used "Rigid Body" - needed for both the lid and main body
   - Also need Fixed Joint - needed only for the body; drag and dropped the lid game component onto the body
   - Duplicated 2 more times and created an empty game component as a folder for the chests
   - Had to unselect "Is Kinematic" for all of them
   - Had to put player in the prefabs folder so you don't move a chest lid instead of the main character
   - Still only grab from the main body of chest because you amde the lid a child of the body for organization purposes
5. Tokens/Collect
    - You need to add colliers to your collectable tokens (chest, energyBars/apples)
    - Added a box collier to the chest
    - Added a sphere collier to the apples/energyBars
    - selected "isTrigger for both"
    - added a "OnTriggerEnter" method to PlayerController because they will react to the player and be deactiviated/disappear with the play touches them
6. Sound effects scripting
    - you add an "AudioSource (name)" cariable to the PlayerController script in the "OnTriggerEnter" method
    - you do "(name).Play();" line before deactivating the gameObject
7. Sound Effect gameObjects
    - make an empty gameObj for soundsto act as a folder
    - make a child gameObj for teh coinCollected sound
    - add the "Audio Source" component to the object
    - drag and drop a sound into the "audioClip" box
    - uncheck the "play on awake" box on audio source component (will play sound on game start)
    - nice wav cutter: https://products.aspose.app/audio/cutter/wav
    - nice wav converter: https://4kdownload.to/en1/youtube-wav-downloader
