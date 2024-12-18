# Unity week 2: Formal elements

A project with step-by-step scenes illustrating some of the formal elements of game development in Unity, including: 

* Prefabs for instantiating new objects;
* Colliders for triggering outcomes of actions;
* Coroutines for setting time-based rules.

Text explanations are available 
[here](https://github.com/gamedev-at-ariel/gamedev-5782) in folder 04.

## Cloning
To clone the project, you may need to install git lfs first (if it is not already installed):

    git lfs install 

To clone faster, you can limit the depth to 1 like this:

    git clone --depth=1 https://github.com/<repository-name>.git

When you first open this project, you may not see the text in the score field.
This is because `TextMeshPro` is not in the project.
The Unity Editor should hopefully prompt you to import TextMeshPro;
once you do this, re-open the scenes, and you should be able to see the texts.



## Credits

Programming:
* Maoz Grossman
* Erel Segal-Halevi

Online courses:
* [The Ultimate Guide to Game Development with Unity 2019](https://www.udemy.com/the-ultimate-guide-to-game-development-with-unity/), by Jonathan Weinberger

Graphics:
* [Matt Whitehead](https://ccsearch.creativecommons.org/photos/7fd4a37b-8d1a-4d4c-80a2-4ca4a3839941)
* [Kenney's space kit](https://kenney.nl/assets/space-kit)
* [Ductman's 2D Animated Spacehips](https://assetstore.unity.com/packages/2d/characters/2d-animated-spaceships-96852)
* [Franc from the Noun Project](https://commons.wikimedia.org/w/index.php?curid=64661575)
* [Greek-arrow-animated.gif by Andrikkos is licensed under CC BY-SA 3.0](https://search.creativecommons.org/photos/2db102af-80d0-4ec8-9171-1ac77d2565ce)


* ## Recent Updates and Changes

### 1. Weapon System
A combo-based weapon system has been implemented. Each weapon now supports:
- Unique combos for activation.
- Distinct behaviors such as **lasers** (move forward) or **bombs** (stay stationary).
- Adjustable properties like size, speed, and points to add upon hitting a target.

This system demonstrates my understanding of Unity components like `Rigidbody` for movement and `ScoreAdder` for score tracking.

### 2. Advanced Enemy Behaviors
Added **new enemy types** with creative effects:
- Enemies move dynamically in the space (based on `Coroutines` and smooth animations).
- When destroyed, enemies disappear with a fade-out or explosion effect, showcasing both animation and scripting creativity.

These additions align with the objectives of the second assignment, but also reflect my creative interpretation and personal coding style.


eran david tzarum