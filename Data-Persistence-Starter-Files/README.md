## Data Persistence – Breakout Clone

This project is part of the **Unity Junior Programmer Pathway**.

---

### **Exercise Overview**

In this challenge, you’ll implement data persistence to keep information consistent between scenes and game sessions.
• Between scenes: Store and display the player’s name entered in the Start Menu across scenes.
• Between sessions: Save and load the high score and player name so they persist after closing and reopening the game.

The goal is to build a menu for name entry, display the score and player name in the main game, and ensure high scores are saved across play sessions.

---

### **Core Features / Outcome**

- Persistent save system for player name and best score
- Menu screen for entering player name and viewing high score
- Data reset button to clear save data and update UI immediately (press R on gameover)
- Persistent `GameManager` using `DontDestroyOnLoad(gameObject)`
- `OnDataReset` event for clean, event-driven UI updates
- Enum-based `GameState` system for cleaner game logic
- JSON save file stored in `Application.persistentDataPath`
- Works across multiple scenes (Menu → Game → Menu)

---

### **Future Ideas (from the lesson)**

- Create a separate High Score scene that displays the high score.
- Display multiple high scores instead of just one.
- Create a Settings scene that allows users to configure gameplay, and use that information between sessions.

---

### **Unity Learn Pathway**

**[Unity Junior Programmer Pathway – 5 Data Persistence in Unity - Submission: Data persistence in a new repo](https://learn.unity.com/pathway/junior-programmer/unit/manage-scene-flow-and-data/tutorial/submission-data-persistence-in-a-new-repo?version=6.0)**
