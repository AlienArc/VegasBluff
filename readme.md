#Bluff - Community Extensions for Sony Vegas Pro

##Overview

An Open Source project to help make you look like you know what you are doing in ***Sony Vegas Pro***. Developed using **Vegas'** extension model, it takes you a step beyond what can easily be done inside a standard script. Developed initially to help create some custom video effects for internal and personal video projects. We thought it would be useful to other content producers out there and would like to see it improved by the community.

**Requires** Sony Vegas Pro. Official release is compiled against the Vegas Pro 8 dll and functionality should be compatible from 8.0 - 13.0. All testing was done against Sony Vegas Pro 12.

##Getting it

To install the extension just download the current [release](https://github.com/AlienArc/VegasBluff/releases/latest "latest release") then follow these simple steps:

1. Extract the contents of the archive
2. Place the dll in one of the following locations:
 * *MyDocuments*\Vegas Application Extensions\  
 * *AppData*\Sony\Vegas Pro\Application Extensions\ 
 * *ProgramData*\Sony\Vegas Pro\Application Extensions\ 
3. Look for the new "Bluff" menu under Tools->Extensions

We hope to have an official installer soon.

##Developer

The project should be easy to build. After pulling the latest source you can go to the solution directory and run the following command:

> msbuild .\VegasTools.sln /p:Platform="Any CPU"

By default the solution will look for the DLL from either Sony Vegas Pro 13 or 12 (in that order). It has not been tested against v13, but should work.

The project has post-build commands to copy the plugin dll to the current user's documents folder under the "Vegas Application Extensions" folder (Vegas scans this folder on startup).

If you are going to add new features the most convenient way to work with Vegas that I have found is to go to the Debug tab of the project properties and set the Start Action to "Start external program" and put in the path to Vegas. This allows you to hit run and have Vegas start with your plugin loaded and the ability to break and debug through your changes.

##Current Commands

###Track Motion

####Create Video Wall

Creates a "wall" of video tracks using track motion. Does flyover zooming in and out between tracks. Useful to show lots of individual clips with quick highlights.

####Track Along Bezier (beta - only in debug builds)

Creates a path that moves along a Bezier line.

###Events

####Arrange Events By Created Timestamp (new)

Positions events in relative time to each other on the timeline, leaving gaps. Useful when you have small clips that have matching (or near matching) timestamps to get them lined up, or at least close to where they should be.

####Order Events by Name and In Time

Orders the events in a track based on the name of the source media and then the starting offset of the current event based on the source media. Does not change the source track of an event, just the starting time. Grouped events all get the same start time (will change to keep relative time position in the future).

####Randomize Events

Randomizes selected events position in the timeline. Does not change the source track of an event.

###Region and Markers

####Convert Markers to Regions

Iterates through markers and creates a region between every two markers.

####Reorder Markers and Regions

Reorders the markers (and now regions) in the project to be sequential. The default behavior is to renumber the markers and regions at the same time in sequential time order. If the CTRL key is held when execution the command then it will order all markers first, then it will order all regions.

####Split Region

Splits the region under the timeline position into two regions at the current position.
