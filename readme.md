# Toy Robot challenge

This application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are no
other obstructions on the table surface. The robot is free to roam around the surface of the table.
This is a console application that can read in commands of the following form -<br />
PLACE X,Y,F <br />
MOVE <br />
LEFT <br />
RIGHT <br />
REPORT <br />
PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)
can be considered to be the SOUTH WEST most corner. MOVE will move the toy robot one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the 
robot. REPORT will announce the X,Y and F of the robot.

Inputs should be provided from standard input. 

## Example inputs and output:

PLACE 0,0,NORTH<br />
MOVE<br />
REPORT<br />
Output: 0,1,NORTH<br />

PLACE 0,0,NORTH<br />
LEFT<br />
REPORT<br />
Output: 0,0,WEST<br />

PLACE 1,2,EAST<br />
MOVE<br />
MOVE<br />
LEFT<br />
MOVE<br />
REPORT<br />
Output: 3,3,NORTH

## Requirements

Requires Visual Studio Code or Visual Studio.<br />
Requires .NET 7<br />

## Usage

In command line navigate to ToyRobot/ToyRobot, type 'dotnet run' and start typing commands e.g. 'place 0,0,north', 'report'<br />
To run tests navigate to ToyRobot/Test and type 'dotnet test'



