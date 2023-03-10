# Behavior Template by MindPort

This is a non-functional, commented example behavior that can be used as a base to create your own custom behaviors.

Note that this behavior is not visible in the step inspector menu. That is because it does not have a corresponding menu item class.
To make your own behavior visible in the menu, create a class overriding `MenuItem<IBehavior>` in a subfolder of the `Editor` folder.
This should return a default instance of the behavior.