# CritterEscape AR Version
## Prerequisites

### Hardware
- **PC VR setup (via Meta Quest Link)**  
  For detailed requirements, please refer to:  https://www.meta.com/help/quest/140991407990979/
    - **2 PCs**
    - **Compatible Link cables**
    - **2 Meta Quest 3 headsets with controllers**
- **Stable Wi-Fi network** (Required for multiplayer)

### Software
- **Unity 2022.3.62f1** (Recommeneded. Newer Unity Editor versions may introduce compatibility issues and require manual fixes.)
- **Meta Horizon Link**
- **Blender**  (If Blender is not installed, some 3D models may lose their meshes.)


## Installation Instructions
> This section assumes you are running the **prebuilt executable** version.

1. Go to: [Builds](/CritterEscape-AR/Builds)
2. Copy the .apk file to the headset via USB
3. Use the Mobile VR Station application to install the .apk file, please refer to https://www.youtube.com/watch?v=60_YqA-AmGk

## In-Game Setup

- **Spatial Anchors**
    - Both players use **pinch gestures** to place two spatial anchors at the **same physical location**
    - Use the Right Hand Pinch Pose (pinch the right thumb and right index finger together).
    - Create two anchors, as shown in the image below. 
> Explanations:
> The first anchor represents the (0, 0) coordinates for the x and z axes.
> The first and second anchors together ensure consistent rotation
> throughout the game.

<p align="center">
  <img src="../Images/Anchor.png" width="50%" />
</p


- **Network Connection**
  - Ensure both devices are connected to the **same local network (LAN)**
  - One player presses the **Create Room**button on the panel 
  - The other player will **automatically join** the room once it is created


## Interaction Guide

<p align="center">
  <img src="../Images/Controllers.png" width="50%" />
</p

- Movement
    - Physical movement

- Object Interaction
    - **Grip Buttons (L5 / R5)** Grab and manipulate objects

- UI & Precision Actions
    - **Triggers (L6 / R6)** Interact with 3D UI elements, Perform precise actions (pinch gesture)
