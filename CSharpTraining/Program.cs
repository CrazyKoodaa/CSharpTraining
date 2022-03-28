using System;

namespace CSharpTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /* Bullet Points
             * 
             * - A subclass can override members it inherits, replacing them with new methods or properties with the same names
             * - To override a method or property, add the virtual leayword to the base class, then add the override keyword to the member with the same name in the subclass
             * - The protected keyword is an access modifiert that makes a member public only to its subclasses, but private to every other class
             * - When a subclass overrides a method in its base class, the more specific version defined in the sbclass is always calles - even of the base class is calling it
             * - If a subclass jist adds a method with the same name as a method in its base class, it only hides the base class method instead of overrideing it. Use the new keyword when you're hiding methods
             * - A subclass can access its base class using the base keyword. When a base class has a constructor, your subclass needs to use the base keyword to call it.
             * - A subclass and base class can have different constructors. The subclass can choose what vales to pass to the base class constructor.
             * - Abstract classes are intentionally incomplete classes that cannot be instantiated.
             * - Adding the abstract keywrd to a method or property and leacing out the body makes it abstract. Any concrete subclass of the abstract class must implement it.
             * 
             * Albedo is a physics term that means the color that's reflected by an object. Unity can use texture maps for the albedo in a material
             * A prefab is a GameObject that you can instantiate in your scene. YOu can turn any GameObject into a prefab
             * The Instantiate method creates a new instance of a GameObject. The Destroy methid destroys it. Instances are created and destroyed at the end of the update loop.
             * The Invoke Repeating method calls another method in the script over and over again.
             * Unity call every GameObjects Update method before each frame. That's called the update loop
             * When you add a Rigidbody component ot a GameObject, Unity's physics engine makes it act like a real, solid, physical object.
             * The Rigitbody component lets you turn gravity on or off for a GameObject
             *              
             * An interface defines methods and properties that a class must implement.
             * By default, all interface members are public and abstract (so the public and abstract keyords are typically left off each member)#
             * Interaces are really useful because they let unrelated classes do the same job.
             * The is keyword returns true if an object matches the a type.  
             * 
             * To remember how interfaces work:
             * you extend a class, but implement an interface. Extending somehing means taking what's already there and stretching it out (in this case,
             * by adding behavior). Implementing means putting an agreement into effect - you've agreed to add all the interface members (and the compiler
             * hlds you to that agreement).
             * 
             * $"bla \n {test}" = bla NewLine 29
             * @"bla \n {test} 
             * bla2"            = bla \n {test}
             *                    bla2
             *                    
             * you can also combine $@"...." like this
             *       
        }
    }
}
