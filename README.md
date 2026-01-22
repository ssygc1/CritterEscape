<div align="center">
<h1>CritterEscape 🦊🐰 </h1>
<h3> Differential Effects of Virtual and Augmented Reality on Social Presence and Engagement in Collaborative Gaming for Unfamiliar Users [<a href="https://ieeevr.org/2026/">IEEE-VR 2026</a>] </h3>

Lijie Zheng*, Guoyueyang Cheng*, Shaoteng Ke, Jiachen Yuan, Yuchen FAN, Boon Giin Lee, Matthew Pike, Alejandro Guerra-Manzanares

<p align='center'>
  <b>
    <a href="https://0">Paper</a>
    |
    <a href="https://github.com/ssygc1/CritterEscape">Code</a> 
  </b>
</p> 
</div>

## 📷 Introduction
<!-- <div align="center">
    <a href="https://ieeexplore.ieee.org/document/10494181" target="_blank">
    <img src="https://img.shields.io/badge/ieee-%2300629B.svg?&style=for-the-badge&logo=ieee&logoColor=white"></a>
    <a href="https://arxiv.org/abs/2402.07677" target="_blank">
    <img src="https://img.shields.io/badge/arxiv-%23B31B1B.svg?&style=for-the-badge&logo=arxiv&logoColor=white" alt="Paper arXiv"></a>
</div> -->
<img width="1207" height="515" alt="Experiment" src="https://github.com/user-attachments/assets/bbb2f76f-0357-43e8-89ce-1aef42bac04c" />

This paper introduces CritterEscape, an immersive collaborative puzzle game with asymmetric roles in both VR and AR. This project builds upon the foundational research presented in our paper: [Exploring Asymmetric Collaboration in VR vs. AR: A Study of Immersive Puzzle Game Design](https://ieeexplore.ieee.org/document/10937399). This study expanded the design that enables a direct comparison of how VR and AR modalities affect user experience and cooperative behavior, allowing for systematic observation of how each medium’s characteristics modulate social interaction under consistent task conditions. Specifically, we investigate how immersive VR and AR environments influence social presence, task engagement, and collaborative dynamicsin a cooperative puzzle game setting, focusing particularly on interactions between unfamiliar participants.

## 🎮 Game Overview
**Critter Escape: VR Adventure** is a virtual reality educational game where two players cooperate to solve a set of problems and escape from a dungeon-like environment.  
Players are initialized as **Zeke (fox)** and **Yuki (rabbit)**, and can start together from the Lobby scene.

<p align="center">
  <img src="Images/VROverview.png" alt="VR Overview" width="48%"/>
  <img src="Images/MROverview.png" alt="AR Overview" width="48%"/>
</p>

<p align="center">
  <b>Left:</b> VR Overview &nbsp;&nbsp; | &nbsp;&nbsp; <b>Right:</b> AR Overview
</p>

## 🧩 Mini-Games & Collaboration Mechanics
This game includes three collaborative mini-games used in the VR/AR comparison study:

- **Mini-Game 1: Animal Identification Puzzle**  
  Informational asymmetry: each player sees clues needed by the other.
- **Mini-Game 2: Potion Brewing Puzzle**  
  Positional asymmetry: players are constrained to different locations/roles to proceed.
- **Mini-Game 3: Shape Alignment Puzzle**  
  Visual asymmetry: each player sees unique parts of the solution and must communicate.
  
## ✅ Requirements
### Hardware
- **2× Meta Quest 3 headsets + controllers** (multiplayer co-located setup)
- **2× Windows 10/11 PCs** with **RTX 2050 GPU or above**
- **2× USB 3.0+ cables** (PC ↔ headset)
- **Stable Wi-Fi network** (multiplayer required)

### Software
- Oculus PC app / Quest Link or any **OpenXR-compatible** platform
  - Meta tutorial: https://www.meta.com/help/quest/articles/headsets-and-accessories/oculus-rift-s/install-app-for-link/

## 🚀 Quick Start (Run the Build)
Detailed User Manual: [User Manual](Documents/User%20Manual.pdf)
> This section assumes you are running the **prebuilt executable** version.

1. Download and extract the compressed package (e.g., `GRPSoftware.Team16.zip`).
2. Go to: `/GRPSoftware.Team16/Builds`
3. Connect each Quest 3 to a PC via Oculus / OpenXR platform, and enable **Quest Link** in the headset.
4. Launch `STEM Game.exe` on **both PCs**.
5. After launching, players will be initialized as **Zeke (fox)** and **Yuki (rabbit)** in the Lobby.
6. When both players are in the Lobby, either player can point at **Start** and press **Trigger** to begin.

**Important note:**  
To restart the game, ensure **all running instances are fully closed**, otherwise the server may prevent a new instance from joining the same room.


  

## 🌟 Citation
If you are interested in our work, please consider giving a 🌟 and citing our work below.

```bibtex
@misc{critterescape_vrar_ieeevr2026_tbd,
  title        = {Differential Effects of Virtual and Augmented Reality on Social Presence and Engagement in Collaborative Gaming for Unfamiliar Users},
  author       = {TBD},
  howpublished = {Manuscript prepared for IEEE VR 2026},
  note         = {Submission ID: 1813. Final bibliographic details TBD.},
  year         = {2026}
}
```

## 💡Acknowledgment
Thanks to previous open-sourced repo: 
