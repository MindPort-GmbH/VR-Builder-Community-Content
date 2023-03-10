# Condition Template by MindPort

This is a non-functional, commented example condition that can be used as a base to create your own custom conditions.

Note that this condition is not visible in the step inspector menu. That is because it does not have a corresponding menu item class.
To make your own condition visible in the menu, create a class overriding `MenuItem<ICondition>` in a subfolder of the `Editor` folder.
This should return a default instance of the condition.