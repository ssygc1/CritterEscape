# Critter Escape: VR Adventure 🦊🐰
A two-player co-located collaborative escape-room game designed for immersive learning and research on social presence and engagement in **Virtual Reality (VR)** and **Augmented Reality (AR)**.

> This repository contains the project assets and/or builds for **Critter Escape: VR Adventure**, a multiplayer VR educational game featuring STEM-themed mini-games and asymmetric collaboration mechanics.

---

## ✨ Highlights
- **Two-player co-located collaboration** (unfamiliar pairs supported)
- **Escape-room gameplay** with multiple STEM-flavored puzzles (e.g., biology, arithmetic, geometry)
- **Asymmetric task design** to encourage communication and interdependence (informational / positional / visual asymmetry)
- Designed for **comfortable experience** and beginner-friendly interaction

---

## 🎮 Game Overview
**Critter Escape: VR Adventure** is a virtual reality educational game where two players cooperate to solve a set of problems and escape from a dungeon-like environment.  
Players are initialized as **Zeke (fox)** and **Yuki (rabbit)**, and can start together from the Lobby scene.

<p align="center">
  <img src="./VROverview.png" alt="VR Overview" width="48%"/>
  <img src="./MROverview.png" alt="AR Overview" width="48%"/>
</p>

<p align="center">
  <b>Left:</b> VR Overview &nbsp;&nbsp; | &nbsp;&nbsp; <b>Right:</b> AR Overview
</p>

---


## 🧪 Research Context (IEEE VR 2026 Accepted)
This project was used in a between-subjects study comparing **VR vs. AR** for **unfamiliar pairs** collaborating in an escape-room game.  
The VR and AR versions share identical task goals and game logic; key differences include:
- **VR**: stationary experience, controller-based locomotion
- **AR**: requires **physical movement** between rooms
- Teammate representation differs between modalities (VR: avatar only; AR: real body + avatar overlay)

**Main findings (high level):**
- VR pairs reported stronger **immersion** and **flow**
- AR pairs showed greater **contextual awareness** and **behavioral coordination**
- Cybersickness profiles differed across conditions

📄 Paper (IEEE VR 2026 manuscript): Differential Effects of Virtual and Augmented Reality on Social Presence and Engagement in Collaborative Gaming for Unfamiliar Users (Submission ID: 1813; bibliographic details TBD)
> If you use this project in academic work, please cite the paper (BibTeX below).

---

## ✅ Requirements

### Hardware
- **2× Meta Quest 3 headsets + controllers** (multiplayer co-located setup)
- **2× Windows 10/11 PCs** with **RTX 2050 GPU or above**
- **2× USB 3.0+ cables** (PC ↔ headset)
- **Stable Wi-Fi network** (multiplayer required)

### Software
- Oculus PC app / Quest Link or any **OpenXR-compatible** platform
  - Meta tutorial: https://www.meta.com/help/quest/articles/headsets-and-accessories/oculus-rift-s/install-app-for-link/

---

## 🚀 Quick Start (Run the Build)
> This section assumes you are running the **prebuilt executable** version.

1. Download and extract the compressed package (e.g., `GRPSoftware.Team16.zip`).
2. Go to: `/GRPSoftware.Team16/Builds`
3. Connect each Quest 3 to a PC via Oculus / OpenXR platform, and enable **Quest Link** in the headset.
4. Launch `STEM Game.exe` on **both PCs**.
5. After launching, players will be initialized as **Zeke (fox)** and **Yuki (rabbit)** in the Lobby.
6. When both players are in the Lobby, either player can point at **Start** and press **Trigger** to begin.

**Important note:**  
To restart the game, ensure **all running instances are fully closed**, otherwise the server may prevent a new instance from joining the same room.

---

## 🎛 Controller Guide (Meta Quest)
- **Move**: Left thumbstick
- **Look / Aim**: Right thumbstick
- **Grab / Interact**: Grip buttons
- **UI actions / Pinch-like interactions**: Triggers

---

## 🧩 Mini-Games & Collaboration Mechanics
This game includes three collaborative mini-games used in the VR/AR comparison study:

- **Mini-Game 1: Animal Identification Puzzle**  
  Informational asymmetry: each player sees clues needed by the other.
- **Mini-Game 2: Potion Brewing Puzzle**  
  Positional asymmetry: players are constrained to different locations/roles to proceed.
- **Mini-Game 3: Shape Alignment Puzzle**  
  Visual asymmetry: each player sees unique parts of the solution and must communicate.


---

## 📦 What’s in This Repository?
- `Builds/` (Windows executable build)
- `Assets/` (Unity project assets)
- `Docs/` (user manual, figures, etc.)


---

## 📝 Citation

This repository is associated with a manuscript prepared for **IEEE VR 2026**. Final bibliographic details (e.g., proceedings info, DOI, page numbers) are **TBD**.

```bibtex
@misc{critterescape_vrar_ieeevr2026_tbd,
  title        = {Differential Effects of Virtual and Augmented Reality on Social Presence and Engagement in Collaborative Gaming for Unfamiliar Users},
  author       = {TBD},
  howpublished = {Manuscript prepared for IEEE VR 2026},
  note         = {Submission ID: 1813. Final bibliographic details TBD.},
  year         = {2026}
}
