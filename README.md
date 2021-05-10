# ToyRobotSim (Toy Robot Simulator)
A collection of C# (c-sharp) sample projects to simulate a toy robot which is able to move within a virtual board.

_Test Case: The toy robot is permitted to move one unit at a time, in a specific cardinal direction, within the boundaries of a 5 unit (X-axis) by 5 unit (Y-axis) board._

### Tech stack:

- ToyRobotSimLib
  _A c# class library project built off .net 5,0, which contains the "business logic" required to facilitate the test case requirements._
- ToyRobotSim
  _A C# console application built off .net 5.0 that references the ToyRobotSimLib class library as it's BLL (Business Logic Layer), servicing as a simple UI (user interface) within the windows desktop environment/space._
- ToyRobotSimBlazor
  _A C# server-side blazor web application built off .net 5.0, that references the ToyRobotSimLib class library as it's BLL (Business Logic Layer), serving as a simple UI (User Interface) within the Web/online space._
- ToyRobotSim.Tests
  _A XUnit C# based project built off .net 5.0 containing various unit tests. This ensures better code coverage and early identification of any breaking code changes._

### Deployments:

- This application is currently deployed via Github Actions, to an Azure App Service, which can be viewed at : [orilon.azurewebsites.net](https://orilon.azurewebsites.net)

Software Development Principles applied:

- **S**ingle Responsibility
  _Summary: A class should do one thing - the thing it should be responsible for._
- **O**pen-Closed
  _Summary: A class should be open for extension but/and closed to modifications._
- **I**nterface Segregation
  _Summary: keeping things separated, by means of interfaces (aka; more interfaces are better than one monster interface)._
- **D**ependency Inversion
  _Summary: Classes should depend upon interfaces or abstract classes instead of concrete implementations of classes (and/or functions)._

-----

## Project/Challenge Criteria:

### Requirements

The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
There are no other obstructions on the table surface.
The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

### Specification Details

Create an application that can read in commands of the following form:

PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
The origin (0,0) can be considered to be the SOUTH WEST most corner.
The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command.
The application should discard all commands in the sequence until a valid PLACE command has been executed.

MOVE will move the toy robot one unit forward in the direction it is currently facing.

LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.
Input can be from a file, or from standard input, as the developer chooses.
Provide test data to exercise the application.

### Constraints

The toy robot must not fall off the table during movement - this also includes the initial placement of the toy robot.
Any move that would cause the robot to fall must be ignored.

#### Example Input and Output

If using stdout:

```
a)PLACE 0,0,NORTH
MOVE
REPORT
Output: 0,1,NORTH 
```

```
b)PLACE 0,0,NORTH
LEFT
REPORT
Output: 0,0,WEST 
```

```
c)PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
Output: 3,3,NORTH
```

-----

Test Cases:

Test Case #1:

```
PLACE 1,1,North
MOVE
MOVE
RIGHT
MOVE
RIGHT
MOVE
REPORT
Output: 2,2,south
```

Test Case #2:

```
PLACE 0,0,East
MOVE
MOVE
RIGHT
MOVE
MOVE
LEFT
LEFT
MOVE
MOVE
MOVE
MOVE
RIGHT
MOVE
REPORT
Output: 3,4,east
```

Test Case #3:

```
PLACE 4,2,East
MOVE
LEFT
MOVE
MOVE
RIGHT
MOVE
LEFT
MOVE
MOVE
RIGHT
MOVE
RIGHT
MOVE
MOVE
RIGHT
MOVE
REPORT
Output: 3,2,west
```

_NOTE: These tests are also included in the Simulator tests, covered in the ToyRobotSim.Tests (XUnit) project_

------

### Disclaimer(s):

- The R2D2 images were sourced from the [Hum3D store](https://hum3d.com/360-view/?id=185036), and are used purely for educational purposes only, to make it easier to identify the direction of the robot (well that's the hope). _Chris Visser at no time claims ownership of these images used in any way whatsoever._
- A fair amount of coffee was consumed during the making of these applications, but no keyboards or mice where harmed during this process.

-----

