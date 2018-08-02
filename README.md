# LevelUpChallenge

## Running the Project
1. Clone the repository
2. Open the sln file with Visual Studio
3. Run the project

## Summary
I implemented two solutions each with their pros and cons. 

### Solution 1
The first solution uses an abstract class to track all instances created of the child classes. To track additional classes, simply have the class inherit from the abstract Countable class. No additional code needs to be added to the class for this solution to work. The downside is that this class is no longer able to inherit from other classes as it's single inheritance is used by the Countable class.

#### Pros:
1. Additional classes can be tracked by inheriting from the Countable class.
2. No code needs to be added to these classes for the solution to work.

#### Cons:
1. The newly tracked classes cannot inherit from any other classes as they need to inherit from the Countable class.


### Solution 2
The second solution works around the inheritance limitation of the first solution by using a factory pattern. To track additional classes, each class must implement the ICountable interface and be instantiated through the CountableInstanceFactory. Since the class is now tracked through an interface, the class can inherit from other classes if desired.

#### Pros:
1. The newly tracked classes are not restricted from future inheritance.

#### Cons:
1. The ICountable interface, and by extention the IDisposable interface, must be implemented by each class being tracked. (It is worth noting that this restriction only applies due to the requirement of tracking disposed instances. If this were not a requirement then no additional code would be needed by newly tracked classes.)
2. The tracked classes must be instantiated by the CountableInstanceFactory.