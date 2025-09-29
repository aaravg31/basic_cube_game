# COSC 519 (J) – Lab 1  
**Project Title:** Basic Cube Game – Interactive Unity Game  

---

## 🎮 Project Description  
This project is a Unity-based interactive game developed for **COSC 519 (J) Lab 1**.  
The player controls a cube in a darkened environment, collecting coins, leaving behind glowing orb trails, and experiencing visual and audio feedback that enhances immersion.  

The goal was to implement **at least 5 interactive elements** in the scene while building familiarity with Unity, C#, and game mechanics.  

---

## ✨ Interactive Elements  

1. **Player Movement (Keyboard Input)**  
   - The cube can be moved using **WASD** or **arrow keys**.  
   - This provides direct control and forms the foundation of the game interaction.  

2. **Coin Collection (Trigger Interaction + Physics)**  
   - Coins are spawned randomly on the ground.  
   - When the player collides with a coin, it is destroyed, the score increases, and a **coin collection sound** plays.  

3. **Score UI (UI Interaction)**  
   - A dynamic UI element displays the player’s **current score**.  
   - A **high score** system is also implemented, persisting across play sessions.  

4. **Glowing Orb Trail (Visual + Time-based Animation)**  
   - As the cube moves, it leaves behind glowing spheres.  
   - The spheres gradually change color from **cyan → blue → purple**, fade out over ~5 seconds, and disappear.  
   - This creates a “shifting wave” trail effect.  

5. **Background Music (Audio Interaction)**  
   - A looping background track plays during gameplay, setting the atmosphere.  
   - Audio settings are configured for looping and balanced with sound effects.  

---

## 🔹 Additional Features  
- **Laser Borders:** Imported laser prefabs are positioned along the floor edges to visually indicate danger zones.  
- **Game Over Mechanic:** If the player falls below the ground plane, the game ends and restarts.  
- **Dark Aesthetic:** Background, ground, and materials are styled with a moody color scheme to enhance immersion.  

---

## 📂 Repository Contents  
- `Assets/` → Unity project assets, scripts, prefabs, and materials.  
- `lab1_video.mov` → Short demo video of the game.  
- `README.md` → This documentation file.  

---

<h2>🎥 Demo Video</h2>
<a href="https://youtu.be/K5CQvbQmYfg" target="_blank">
  <img src="https://img.youtube.com/vi/K5CQvbQmYfg/hqdefault.jpg" alt="Demo video thumbnail" />
</a>
<p><strong>Local copy:</strong> <code>lab1_video.mov</code> (included in this repo)</p>


---

## 🚀 How to Play  
1. Clone this repository.  
2. Open the project in Unity (URP recommended).  
3. Press **Play** in the editor.  
4. Move with **WASD/Arrow Keys**, collect coins, and enjoy the interactive elements.  

---

## 👤 Author  
Aarav Gosalia  
University of British Columbia – Okanagan 
