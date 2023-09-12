# Project Icarus

## Abstract
Project "Icarus" aspires to educate the youth on the journey that touched the Sun by Parker Solar Probe. The historical mission that sent a solar probe, made by man, closer to the Sun than anything before. It achieves this by means of a videogame experience, that includes multiple segments of the mission, and makes it an immersive and interactive experience to learn and be fascinated by the milestone mission, via means of Virtual Reality, Computer Simulation and Augmented Reality. We propose the current prototype game 'Icarus', an immersive N-Body Simulator and VideoGame, that we developed to manifest that aspiration, with further future improvements to create our vision of space education.

## Installation
Work in Progress...
From the builds folder, download the latest setup.exe file. Run the setup and install the game and play!

## Feedback
You can send us feedback in this email address: irfannafizislive@gmail.com
We love hearing from people!

## Project Summary
Parker Solar Probe was the first human made object to “touch” the sun. Parker Solar Probe is one of the greatest scientific landmarks of history. After the moon landing in 1969, touching the sun was the most revolutionary achievement of NASA.  It opened many doors about the mysteries of the sun’s atmosphere such as, why is the corona much hotter than the Sun's surface? The Solar Probe has collected and is still collecting enormous amounts of useful data about the sun and its surroundings. 

It is impossible for any human being to get anywhere close to the sun. So, our project is to develop an experience of Parker Solar Probe’s journey towards the sun. Anyone can experience the journey from the beginning to the end without actually being in the space craft. The user will be enlightened with a variety of information about the whole journey.

- Rocket Launching:  The rocket engine will fire up and the rocket will start to leave the earth.

- Trajectory Setting: The trajectory of the solar probe has to be set by the user by changing the initial velocity vector.

- Venus Flyby: To leverage the gravitational pull of Venus, Parker Solar Probe will fly near Venus so that the trajectory around the sun will be changed in order to get closer to the Sun.

- Death Plunge: At the end of the journey The Solar Probe will plunge into the Sun. It will keep moving towards the sun until it is fully destroyed.

## How we addressed this challenge
To enlighten the young audiences about Parker Solar Probe’s mission - “On the Way to Sun”, we developed a mixed reality video game, where the user can experience the whole journey from earth to the solar atmosphere. This experience includes various information about the Solar Probe, Sun’s atmosphere, etc. Finally, we incorporated Virtual Reality into this experience to make it more immersive and realistic. 

## Github Repo
The repo contains the total project files for the Icarus Project, based on Unity version 2021.3.
- Scenes folder contains all the specific scenes we used in our project.
- The build settings are updated with our latest version we used to create the 30 second pitch video.
 
## How We Developed This Project
###Tools That We Used
- Unity
- Blender
- ShaderGraph
- ShaderScript
- Visual Studio Code Editor
- C# programming language
- Adobe Photoshop
- Canva
- DaVinci Resolve 18
- Audacity

## Development Process
At first we designed the game from a high-level overview. We planned the sequence of the game levels such as  Rocket Launching, Trajectory Setting, Venus Flyby, Death Plunge etc. Then we added details to our levels.

### Rocket Launching: 
In this level, we created a 3D model of Delta 4 Rocket in Blender and Import this model in Unity. To fire up the rocket we used Unity’s Particle System to simulate the smoke and fire. Then we used Unity’s Physics System to animate the acceleration of the rocket.
### Trajectory Setting:
After the rocket leaving the Earth, the user has to set the trajectory of the Solar Probe. We used the model of the solar probe provided on the NASA website. In C# language we scripted the process of trajectory traversing of Parker Solar Probe. In the scripting process we developed an N-body Simulator from scratch which allows the solar probe to perfectly traverse the trajectory according to the laws of gravitation.
### Venus Flyby:
The 3D model of Venus is obtained from NASA provided data. We used our previously developed N-body Simulator to simulate the process of Venus Flyby.
### Death Plunge:
After Venus flyby Parker Solar Probe will eventually be directed towards the sun. The part by part destruction of the solar probe is also scripted in C# language.
### Added a fully voiced virtual assistant that instructs and guides the player experience. 


## How We Used Space Agency Data in This Project
### Usage of 3D models
We used NASA provided 3d models in our game. First of all, we imported the Parker Solar Probe model in our Trajectory Setting stage, Venus Flyby stage, and in the Death Plunge stage. In the death plunge stage, we successfully simulated the destruction of the solar probe model. We also used the model of the Sun and Venus which were also provided by NASA.
### Usage of Numerical/Text Data
We used data from various sources to present information about Rocket, Parker Solar Probe, the Layers of Sun’s atmosphere etc. These information pop up when the user faces toward the corresponding object. They help the user to learn a lot about the whole mission. 

## NASA Data We Used
### NASA OpenSource Data
- Sun 3D Model: https://solarsystem.nasa.gov/resources/2352/sun-3d-model/
- Venus 3D Model: https://solarsystem.nasa.gov/resources/2343/venus-3d-model/
- Parker Solar Probe FlyBy Video: NASA/APL/NRL
- Parker Solar Probe Sun Atmosphere Captures: NASA/APL/NRL
- Parker Solar Probe 3D Model: https://solarsystem.nasa.gov/resources/2356/parker-solar-probe-3d-model/
- PSP Orbital Trajectory
- Live Orbital View
### Unity Documentation
https://docs.unity3d.com/Manual/index.html
### Blender Documentation
https://docs.blender.org/
### Research Sources:
https://solarsystem.nasa.gov/
https://www.nasa.gov/
https://www.planetary.org/ 


