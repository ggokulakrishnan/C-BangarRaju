//Rama Rama
using System;

namespace PP.BangarRaju
{
    //05. lets define the delegate inside the namespace
    public delegate string GreetingsDelegate(string name);

    //06. the next step is to create instance of the delegate inside the main method

    public class AnonymousMthd
    {
        //01. Part 3 of delegates (Anonymonous Methods)
        
        //02. previous section we saw how to buind a method with delegate 
        //        we create instance of delegate and while creating the instance we pass the method as parameter to 
        //        that delegate (for binding)
        
        //03. (imp) ananymonous method is also related to delegate, with our binding a named method to a 
        //        delegate, we can bind an unnamed code block to the delegate
        
        //04. now we need to call the method using delegate (like how we have seen in part1 and part2 of delegates)
        //defined delegate
        //instanciate the delegate
        //invoke the delegate

        //////public static string Greetings(string name) {
        //////    return "Hello " + name + ", very good morning";
        //////}


        public void MDelegateMain()
        {
            //07. create instance of the delegate here
            //////GreetingsDelegate objGreetingDelegate = new GreetingsDelegate(Greetings);

            //11. instead of that we can simplify the process
            //  at the time of creating an instance of delegate, we can use the word as delegate followed by parameter type and name
            //      followed by method body in open and close { }
            //  which means there is no need to have the Greetings method sparately, 
            //  the Greetings method is created at the time of creating the instance of the delegate
            //  the output is the same

            GreetingsDelegate objGreetingDelegate = delegate (string name2)
            {
                return "Hello " + name2 + ", very good morning";
            };

            //12. now we can remove the Greetings() method and run the program, we will get the same output

            //13. the below part is called anonymonous method, a method with out a name. what it contains is only a body

            //14. the method is defined using the delegate keyword
            /*
            delegate (string name2)
            {
                return "Hello " + name2 + ", very good morning";
            };
             */

            //15. the advantage is less typing (no need to specify the modified, method name return type)
            //  ananymonous methods are not often suggested

            //16. if the method is going to have less volumes of code, then it is recommedned to go with anonymonous method
            //  for huge volumnes of code anonymonus methods are not recommeded

            //17. for a small logic with few lines of code we can write an unnamed code and directly bind it with the 
            //  anonymonous method

            //18. now the question is how does it understand the return type, the GreetingsDelegate() declared in line; #7 
            //  already knows that the return type is string

            //19. there is no where to go and check the logic of the method, the logic is defined in the place where the 
            //  binding is created            

            //08.now invoke the delegate (a) either using .invoke method or(b) call directly
            //      the reference method accepts string as value and returns a string as output
            string hello = objGreetingDelegate("scott");

            Console.WriteLine(hello);

            //09. lets run the program, the method is invoked with the help of delegate
            //OP: 
            //   Hello scott!!!, very good morning

            //10. this is what we have learned in the previous sessions with the help of a delegate, how to invoke a method
            //  on a high level what we have done is, 
            //  (a) we have writted a method
            //  (b) binding the method with delegate

           

        }
    }
}
