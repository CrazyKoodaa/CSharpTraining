using System;

// head first 439

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
             * list<T> => T is just a letter to represent all other declarations Types like int, shoes, or whatever. Therefore its generic
             * list.add to add
             * list.remove to remove
             * list.removeat to remove item at index 
             * list.contains() to find an item in list
             * list.contains().IndexOf() to get the index of the found list
             * list.count counts the items in a list
             * list[3] access the item at index 3
             * foreach list is possible
             * All generic collections impleent the generic ICollection<T> interface
             * The <T> i a generic class r interace definition is replaced with a type when you instantiate it.
             *                      
             * Collection initializers let you specify the contents of a List<T> or other collection when you create it, using angle brackets with a comma-separated list of objects.
             * A collection initializer makes your code more compact by letting you combine list creation with addning an inital set of items
             * The List.Sort method sorts the contents of the collection, changing the order of the items it contains
             * The ICoparable<T> interface contains a single method, CompareTo, which List.Sort uses to determine the order of objects to sort.
             * The Sort method has an overload that takes an IComparer<T> object, which it will then use for sorting
             * IComparable.CompareTo and IComparer.Compare both compare pairs of objects, returning -1 if the first object is less than the second, 1 if the first is greater than the second or 0 if they're equal
             * Every Object has a ToString method that converts it to a string. The ToString method is called any time you use string interpolation or concatenation
             * The default ToString method is inherited from Object. It returns the fully qualified class name, or the namespace followed by a period followed by the class name.
             * Override the ToString method to get interpolation, concatenation and many other operations to use a custom string
             *                      
             *                      
             *                      
             */
        }
    }
}
