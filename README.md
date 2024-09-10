Basically what the description says. It's a controller that allows walking based on keyboard and mouse inputs.
It's based on CharacterController, so everything past inputs and directions is handled by Unity.
In order for it to work properly create a hierarchy like in the image:

![image](https://github.com/user-attachments/assets/ff317a27-8153-4148-95ae-b895cb9cef08)

then attach PlayerController and CharacterController to Player Controller game object and CameraController to Main Camera game object.
Don't forget to tag Player Controller as "Player" in Inspector.
