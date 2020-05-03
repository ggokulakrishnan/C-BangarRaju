//Sri Rama Jeyam
using System;

namespace PP.BangarRaju
{
    public class DelegatesP1
    {
        //12. define the delegate under the namespace
        public delegate void AddNumberDelegate(int dataA, int dataB);

        public delegate string SayHelloDelegate(string name);

        //13. it is also possible to define the delegate inside the class, then it becomes a nested type
        //      that is a type inside a type, but generally not advised. its good to put it under namespace

        //01.
        /* Standard Definition about Delegate is: Its a type safe function pointer
         *  (imp) Delegate is going to hold reference of a method and going to call the method for execution
         *  
         *  In C# we can call the methods in two ways:
         *      (a) By using instance of class and then calling the method with <instanceName>.<methodName> (in case of normal/non static method)
         *      (b) By using name of the class and then with method name <className>.<methodName> (if it is a static method)

                (c) By using a Delegate, using Delegate we can call a method
        */

        //02. lets create a new class and create few methods
        class LearnDelegates
        {
            //03. Create the first method
            public void AddNumber(int a, int b)
            {
                Console.WriteLine(a + b);
            }

            //04. Create the second method as a static method (inside a non static class)
            public static string SayHello(string name)
            {
                return "Hello " + name;
            }

            //05. to call these two methods the first approach is to create instance of the class
        }

        public void KDelegateMain()
        {
            Console.WriteLine("Hello World :: KDelegateMain() !");

            //06. lets create an instance of the class (LearnDelegates)
            LearnDelegates objLearnDelegates = new LearnDelegates();

            //07. Call the first method (addNumber)
            objLearnDelegates.AddNumber(2, 4);

            //08. now call the second method which is a static method 
            string name = LearnDelegates.SayHello("Rama");
            Console.WriteLine(name);

            //15. creating an instance of AddNumberDelegate
            //  when instanciating the delegate we need to pass the method name as parameter to the delegate
            //  check the intellisence it will tell as, 
            //      a. a method name need to be passed
            //      b. the return type of the method is: void
            //      c. the method should take two integers as parameters
            //  intellisence: AddNumberDelegate(void (int, int) target)
            //  it is not mandatory that only AddNumber() method should be passed as parameter to this delegate
            //  any method can be passed to this delegate that has this return (void) and parameter type (taking two integers)
            //  can be passed to this delegate
            //  In the code when we type AddNumber as parameter to this delegate, there is no intellisence
            //  when there is no intellisence which means some thing is incorrect
            //  AddNumberDelegate objAddNumberDelegate = new AddNumberDelegate(AddNumber    .. no intellisence
            // reason: the method is non static method and we are creating it in static block of the delegate

            // rule: a non static member of a class can never be accessed from a static block directly
            //      this can be accessed only by using instance of the class

            // where is the non static method AddNumber(), it is inside/can be accessed from object of class LearnDelegate
            //      Object Name: objLearnDelegates

            // AddNumberDelegate(objLearnDelegates.AddNumber) => this represents: delegate holds the address of the method
            AddNumberDelegate objAddNumberDelegate = new AddNumberDelegate(objLearnDelegates.AddNumber);

            // SayHello, is a static method hence we are able to call it directly using class name
            SayHelloDelegate objSayHelloDelegate = new SayHelloDelegate(LearnDelegates.SayHello);
            // this is the second step called as instanciating the delegate

            //instanciating is the process of creating instance of the delegate, here we need to pass method name as 
            //  parameter to the delegate constructor


            //09. now lets run the program and we get the following output
            /* 
             * Hello World!
             * 6
             * Hello Rama
             */

            //10. till now we have been calling methods like this, now lets see how we can call 
            //  methods by delegates

            //11. to call a method by Delegate, we have three steps:
            //     (01) define a delegate
            //          <modifier> delegate void|type <name> ( <parameter List> )

            //          the above statement looks exactly similar to method signature, the extra word we are 
            //              using is delegate (method signature and delegate will look exactly same)

            //          if we want to call the method (addNumber) using delegate 
            //          
            //  =>      public void AddNumber(int a, int b)
            //              
            //          to the method name add the keyword delegate before return type
            //
            //  =>      public delegate void AddNumber(int a, int b)
            //
            //          method name and delegate name will not be the same hence give an appropriate 
            //              name to the delegate, which is followed by semicolon
            //
            //  =>      public delegate void AddNumberDelegate(int a, int b);
            //
            //          Summary:
            //          --------
            //  =>      (method)        public void AddNumber(int a, int b)
            //  =>      (delegate)      public delegate void AddNumberDelegate(int a, int b);
            //
            //  (a) when calling a delegate two important points to note, the return type of the delegate should 
            //      exactly match the return type of the method (here its void)
            //
            //  (b) the second is the parameters types of the delegate should exactly be the same type as parameters types of the 
            //      delegate (here method is taking two integers and delegate is also taking two integers)
            //
            //  =>      (method)        public void AddNumber(int a, int b)
            //  =>      (delegate)      public delegate void AddNumberDelegate(int x, int y);
            //
            //          the parameter name can be any thing, it does not matter. it can be a and b in method where as 
            //          x and y delegates, what matters is the type which is <int>, <int>
            //
            //  Now lets try to define delegate for the second method SayHello
            //
            //  =>      (method)        public static string SayHello(string name)
            //  =>      (delegate)      public static string SayHello(string name);
            //
            //  In delegate no need to use they keyword static (we never use static on a delegate) 
            //
            //  =>      (method)        public static string SayHello(string name)
            //  =>      (delegate)      public delegate string SayHelloDelegate(string name);
            //  =>      (delegate)      public delegate string SayHelloDelegate(string userName);
            //
            //  Here the return type of the delegate is string because the method return type is string
            //      the parameter type of the delegate is string because method parameter is also string
            //
            //  (imp) the delegate type (return and parameter types) should exactly match with method type
            //  that is the reason we say, a delegate is type safe function pointer
            //  because delegate signature is going to match with method signature 
            //
            //  delegate is a type:
            //      a class is a type (user defined type)
            //      a structure is a type (user defined type)
            //      an interface is a type (user defined type)
            //  all these are user defined types 
            //
            //  similar to (class, struct and interface) delegate is also a user defined type
            //
            //  the main difference between class and structure is: 
            //      (a) class is reference type
            //      (b) struct is value type
            //  the same way 
            //      (c) delegate is also a reference type
            //
            //  In c# types are defined under namespace, for eg. every class we define/create is under namespace
            //      this class (LearnDelegates) is under the namespace (namespace PP.BR.DP1)
            //      not only class, everything structure, interface etc will be under a namespace
            //
            //  (imp) this is because namespace is a logical container of types, that is the reason we define all the 
            //      types under a namespace
            //  Now the question is where should we define, the delegate the answer is it should be under a namespace
            //
            //  Now lets define the delegate below the namespace

            //14. the second step in delegate is
            //  (01) instanciating the delegate 
            //
            //  it is like creating an instance of delegate, because delegate is a reference type
            //  (imp) when instanciating the delegate we need to pass the method name as parameter to the delegate
            //
            //  now lets create an instance (line #57) of the AddNumberDelegate which is defined in line #7
            //
            //16. finally the third step is: call the delegate by passing required parameter values, so that 
            //      internally the method which is bound with the delegate gets executed
            //
            // we need to call the method AddNumber which we will not call it directly, we will call using delegate
            // when we call the delegate objAddNumberDelegate(.. it ask for two integer parameters
            //      objAddNumberDelegate(int dataA, int dataB)
            objAddNumberDelegate(100, 50);

            // now call the other delegate
            string returnInformation = objSayHelloDelegate("raju");
            Console.WriteLine(returnInformation);

            // what happens internally, when we call the delegate the method will get executed, (it is not delegate, 
            //  delegate is just pointer to a method)
            // when ever we call the delegate the pointer comes to method and method gets execuite 
            //
            // Calling via delegate and calling direclty will get the same output
            // Op:
            // ---
            // Hello World!
            // 6
            // Hello Rama
            // 150
            // Hello raju

            //17. the other way to call a delegate is .invoke
            //  so delegate has a method call invoke, this invoke accepts two parameters for us: (int dataA, int dataB)
            objAddNumberDelegate.Invoke(100, 50);
            objSayHelloDelegate.Invoke("bangaru");

            //we can use any of the two ways, it is the same output
            //

            /* happy learning: part2 Multicast Delegates */

            Console.ReadLine();
        }
    }
}
