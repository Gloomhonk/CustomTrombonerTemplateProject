# Custom Tromboner Template Project
A helper Unity Project for creating custom characters for [Trombone Champ](https://store.steampowered.com/app/1059990/Trombone_Champ/). This project contains:
- Example scenes replicating the lighting and camera setup of the base game.
- Prefabs showing example characters and animation setups.
- Helper scripts for testing your character in the Unity editor.

This readme will cover the basic steps for setting up a custom character, if you have any specific questions then feel free to join the [Trombone Champ Modding discord](https://discord.gg/KVzKRsbetJ).

 **Contents**
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Creating Your First Character](#first-character)
- [Animating Your Character](#animating-character)
- [Adding A Trombone](#adding-trombone)
- [Going Further](#going-further)
- [Attribution](#attribution)

<a id="prerequisites"></a>
## Prerequisites
You'll need the following:
- The [TootTallyCustomTromboner](https://trombone-champ.thunderstore.io/package/TootTally/TootTallyCustomTromboner/) mod, plus any dependencies.
- Unity version `2019.4.40f1`. It's highly recommended that you use [Unity Hub](https://unity.com/download) to install  and manage your Unity versions.
- The assets you wish to use for your character (e.g. a rigged 3d model, collection of images to use for sprites, etc).

<a id="getting-started"></a>
## Getting Started
1. Download the latest version of this project.
2. Open the project using Unity Hub.
3. In Unity, navigate to Scenes and open `HumanoidExampleScene`. This scene contains the game-accurate lighting and camera setup, plus an example character prefab. 
4. If you press Play, you should see the example character animate. Clicking the play area should also trigger the toot animations and effects.

    ![HumanoidPlayMode](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/eca9cf8f-5e6e-417a-b304-68fd5f4e6cee)


<a id="first-character"></a>
## Creating Your First Character
The details of creating a character depend on what assets you use, but these basic steps should be the same for any character:
1. Import your assets into the project: 
    * If importing a 3D model, make sure it is in a supported format (Unity supports .fbx, .dae (Collada), .3ds, .dxf, and .obj).
2. In the scene hierarchy: create a root object called `Puppet` that is a child of the `PlaceCharacterInHere` object, and add any assets inside this object.
    * If you're using a 3D model, you can alternatively drag that from the project explorer onto `PlaceCharacterInHere` and rename the root to `Puppet`.

    ![CreateRootObject](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/06891f8f-9148-499d-92d0-6d78948e067a)
3. Position your character so they are visible in the Game view.
    * By default the character will appear on the right side of the screen, but this is dependent on the model used (e.g. it may contain position offsets).
    * Do not edit the positions of `PlaceCharacterInHere` or `Puppet`, if you do then the in-game position will not match the editor. If you need to make position edits then do so on child objects.
4. Add an Animator component to the `Puppet` object:
    * For now don't worry about the animations themselves, just create a new blank Animator from scratch or copy one of the included example Animators.

    ![AddAnimator](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/d7a4331b-b8ad-42d5-9466-a8311c64755e)

This is the minimum setup required, at this stage your character won't move but it will be ready to export and use in the game.

### Building The Assetbundle
Custom tromboners are essentially Unity Assetbundles with a custom postfix (`.boner`). To build the Assetbundle:

1. Create a prefab of the character:
    * An easy way to do this is drag your `Puppet` object from the scene hierarchy to the project explorer.
2. Select the prefab in the project explorer and assign to an Assetbundle using the bottom-right Assetbundle panel.
    * The first drop-down box is the bundle name, if you haven't created an Assetbundle here before then add a new name.
    * The second drop-down box is the file postfix, this must be called `boner`.

    ![AssetBundlePanel](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/fbbd2dc0-6b22-4595-98a6-05837ecce387)
3. Open **Window -> Assetbundle Browser**
4. Choose a path for where the asset bundle file is saved. 
5. Press **Build**, you should see a new file in specified path called `your_bundle_name.boner`.

    ![BuildAssetBundle](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/3da93458-376d-4611-8774-535a7555240f)
    ![AssetBundleResult](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/1af94433-e788-45b0-a1f2-92357dc4f3f1)

### Testing Your Character

1. Copy and paste your new character file into your **Bepinex/CustomTromboners** folder.
    * If you use r2modman to install mods it will be in your r2modman profiles folder, if you manually installed the mods it will be in your TromboneChamp Steam folder.
    * If the folder doesn't exist then make sure to run the game once with the **TootTallyCustomTromboner** mod installed, this will automatically create the folder.
2. Launch the game and select **Mod Settings** on the main menu.
3. Select **Custom Tromboner**.
4. You should be able to select your character from the dropdown box.
5. Play any chart (or go into Free Improvisation mode) to see your character in action.

<a id="animating-character"></a>
## Animating Your Character

Fully breaking down how to create animations from scratch is out of the scope of this readme, but it's recommended you look into the following topics:
- The Unity Animator:
    - Creating States within the Animator and linking them together with Transitions.
    - Using Parameters to control transitions and the animations themselves.
    - Creating Blend Trees and using Parameters to blend between multiple animations.
    - Using Layers to control different parts of a character independently.
- Animation clips:
    - Creating new clips and assigning them to States in the Animator.
    - Adding keyframes to the clip to control your character.
    - Modifying Curves to control how your keyframes blend and get the desired movement.
    - Importing clips from external applications (if you wish to create animations in a different app e.g. Blender).
- (For 3D models) Character rigs:
    - A lot of 3D models online will come with a usable skeleton. If it doesn't then you will need to rig the character yourself, either manually using programs such as [Blender](https://www.blender.org/), or via an automated process such as [Mixamo](https://www.mixamo.com/#/).
- For 2D animating:
    - Creating Sprite objects.
    - Creating multiple sprites from a single spritesheet image.
    - Using animation clips to switch sprites.

### Humanoid Example

It's recommended to check out the Humanoid example included in the project. The prefab contains a rigged 3D model with animations replicating the base game movement (including tooting, sliding trombone, out of breath reactions, and particle effects). Copying the Animator from this example can be a good starting point, but you will still need to replace the animation clips themselves.

![HumanoidAnimator](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/147159b8-1591-4253-aebc-98cc6391cac0)

The Humanoid Animator is broken down into these layers:
- **Root layer**: controls the slow, constant side-to-side rotation of the character.
- **Body layer**: controls the character dancing loop, this is set up to match the current song tempo and switch to an out of breath animation when appropriate.
- **HoldTrombone layer**: controls the arms, up/down spine movement and the trombone slide. This layer uses a Blend Tree to move based on the player's cursor position, and like the Body layer it will switch to an out of breath variation when appropriate.
- **PlayTrombone layer**: controls the trombone vibration and particle effects. These are switched on/off depending on if the player is tooting, idle, or out of breath.

### Animator Parameters
The **TootTallyCustomTromboner** mod will send events to your Animator using the following parameter names. Make sure your Animator contains these parameters if you want to make use of them:

![AnimatorParameters](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/57dd2fc3-6ee3-4bb6-8f92-b19c908c11a6)

- `Tooting`: boolean that is `true` when the player is pressing a toot button, and `false` when nothing is being pressed.
- `OutOfBreath`: boolean that is `true` while the player is out of breath and cannot play, `false` during normal play.
- `AnimationSpeed`: float that can be used as a speed multiplier for animations.
    - 1.0 = default speed, higher values = faster animations.
    - The mod will set this to be equal to the current song tempo / 120bpm (e.g. a 180bpm song has an animation speed of 1.5). 
    - If you have an animation that needs to be in time with the beat, author this animation so it loops perfectly at 120bpm, then set the animation to be multiplied by this parameter.
- `PointY`: the player's cursor position. 
    - 0.5 = centre, 0.0 = bottom of screen, 1.0 = top of screen.
    - This value can be used to control Blend Trees e.g. to make the character tilt up/down, or the trombone tube move forward/back.

### Testing Animations
The `PlaceCharacterInHere` object contains a script called `TrombonerAnimTester` that can be used to test your animations in Play mode in a similar manner to how they will work in-game.

![Tester](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/97875b66-3e41-44cf-817b-eac1bfc171e2)
- Assign your Animator to the `Tromboner Animator` property.
- Start Play mode.
- Moving the mouse will update the `PointY` Animator parameter, and clicking the Game window will trigger the `Tooting` parameter.
- Changing the `Song Tempo` property will affect the `AnimationSpeed` parameter.
- Checking the `Is Out Of Breath` box will flag the `OutOfBreath` parameter.

<a id="adding-trombone"></a>
## Adding A Trombone

- The project provides an example trombone that's free to use under Creative Commons license (if you use this model then make sure to give credit). However, you are free to use any trombone model you like.
- If your character has an animation rig, then the trombone model should usually be added as a child object of the Head bone, so it follows the head if parent bones are animated (e.g. the spine).


### Trombone Particle Effects

There are two example prefabs included in the project: `SoundwaveParticles` and `SpitParticles`. These are mockups of the spit and soundwaves in the base game, and should be used as follows:
- Drag the prefabs onto your trombone, and position them so their root is near the trombone bell.
- Each prefab consists of a Particle System: 
    - by default nothing will show, you need to go into the `Emission` section of the Particle System and change `Rate Over Time` to a value other than zero.
 
    ![Particles](https://github.com/Gloomhonk/CustomTrombonerTemplateProject/assets/135999125/83081188-74de-4262-a9a6-608b59236a8b)
- You can turn these effects on/off in animations by setting `Rate Over Time` to zero when the player isn't tooting, and to the max number of particles when the player is tooting (for spit this is 20, for the soundwaves this is 10).
    - In the Humanoid example this is done in the `TromboneIdle`, `TrombonePlaying`, and `TromboneOutOfBreath` animations.

Feel free to modify these effects for your own requirements, or create entirely new ones.

<a id="going-further"></a>
## Going Further

This readme covers the standard setup of a character, but ultimately you can use any kind of model/sprites you want and animate them however you like. Anything that can be included in a Unity Assetbundle can also be part of a character, including lights, cameras, custom shaders, and sound effects. 

<a id="attribution"></a>
## Attribution

["Tenor Trombone"](https://skfb.ly/oBuZy) by Vltava is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

["Modular Humanoid Characters | Male (Free Demo)"](https://skfb.ly/oOSEM) by joaobaltieri is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).








