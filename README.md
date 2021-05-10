# ToyRobotSim (Toy Robot Simulator)
A collection of C# (c-sharp) sample projects to simulate a toy robot which is able to move within a virtual board.
_Test Case: The toy robot is permitted to move one unit at a time, in a specific cardinal direction, within the boundaries of a 5 unit (X-axis) by 5 unit (Y-axis) board._

Tech stack:

- ToyRobotSimLib
  _A c# class library project built off .net 5,0, which contains the "business logic" required to facilitate the test case requirements._
- ToyRobotSim
  _A console application that references the ToyRobotSimLib class library as it's BLL (Business Logic Layer), servicing as a simple UI (user interface) within the windows desktop environment/space._
- ToyRobotSimBlazor
  _A server-side blazor web application, that references the ToyRobotSimLib class library as it's BLL (Business Logic Layer), serving as a simple UI (User Interface) within the Web/online space._
- ToyRobotSim.Tests
  _A XUnit based project containing various unit tests. This ensures better code coverage and early identification of any breaking code changes._

Deployments:

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

Disclaimer(s):

- The R2D2 images were sourced from the [Hum3D store](https://hum3d.com/360-view/?id=185036), and are used purely for educational purposes only, to make it easier to identify the direction of the robot (well that's the hope). _Chris Visser at no time claims ownership of these images used in any way whatsoever._
- A fair amount of coffee was consumed during the making of these applications, but no keyboards or mice where harmed during this process.

