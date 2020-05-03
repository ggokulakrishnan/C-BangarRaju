//Rama
using System;

namespace PP.BangarRaju
{
    //09. lets define the delegate inside the namespace
    //since all the class are under same namespace 'PP.BangarRaju', we can access the same delegate here in this class also
    //public delegate string GreetingsDelegate(string name);

    //10. or if needed we can define the delegate with a new name (but not required)
    //public delegate string GreetingDelegate(string name);

    public class LamdaExp
    {
        //01. in previous session, we saw an ananymonous method means a method with out a method body which can be bound directly to 
        //  a delegate and can be called

        //02. first the named method was created, then the named method was binded with a delegate

        //03. afterwards the named method was changed to an anonymonous method and then it was invoked in the process

        //04. anonymonous method, the advantage is lesser typing work, due to no need to use private|public, static, 
        //      return type or the fn name

        //05. we directly use it with delegate keywork and directly we use it

        //06. (imp) lamda express is a short hand for writing the anonymonous methods

        //07. lamba express was still introduced to simplify the process of anonymonous method

        //08. lets use the same code that we have used in previous Anonymonous method class

        //11. create the method (Greetings)

        //15. comment the below method, as we have written it as an anonymonous method
        //////public static string Greetings(string name)
        //////{
        //////    return "Hello " + name + ", very good morning";
        //////}

        //12. create the main method, instinciate the delegate and then invoke the delegate by passing an argument
        //13. run it and we get the output as: Hello Raju, very good morning
        public void NDelegateMain()
        {
            //14. now lets convert it as anonymonous method and comment or remove the method (Greetings)
            //GreetingsDelegate objGreetingsDelegate = new GreetingsDelegate(Greetings);

            //////GreetingsDelegate objGreetingsDelegate = delegate (string name) {

            //////    return "Hello " + name + ", very good morning";
            //////};

            //15. now if we try to run the program, we will get the same output
            //OP: Hello Raju, very good morning

            //16. here we just need to tell the parameter along with type of prameter to the Delegate and all 
            //  the above we have seen in previous class

            //17. no need to tell the return type, because the 'GreetingsDeledate' is very much clear that it returns a string
            //  public delegate string GreetingsDelegate(string name);

            //18. here a doubt arises, since delegate know the return type no need to tell the return type but delegate also knows the 
            //  parameter then why need to tell the delegate again all these things when it knows

            //19. ananymonous method it self is telling (typing lesser code) but we need to type delegate and parameter type

            //20. in c# 2.0 anonymonous method was introduced in the above format of writing the code

            //21. here a doubt arises, since delegate know the return type no need to tell the return type but delegate also knows the 
            //  parameter then why need to tell the delegate again all these things when it knows

            //22. hence in c# 3.0, they introduced a concept call lamda expressions, with lamda expressions the code can be written in a\
            //  much simplified way

            //23. lamda express is a short hand for writing anonymonous methods

            //24. with lamda express, there is no need type the delegate keyword and write the parameter type also

            //25. straight away we are provided with one operator called lambda operator =>

            //26. lets modify the above anonymonous call (in line: 48) to lambda expression

            //28. this is still the simiplified version of anonymonous method

            //29. in lambda expression we can also tell the parameter type as (string) it works, but still it is not required
            //  because delegate already knows the parameter type it is going to take
            //GreetingsDelegate objGreetingsDelegate = (string name) =>

            //30. to understand lambda expression we need to first understand anonymous method, the anonymonous methods are 
            //  simplified with the concept of lambda expressions
            
            GreetingsDelegate objGreetingsDelegate = (name) =>
            {
                return "Hello " + name + ", very good morning";
            };

            //27. for comparision with anonymonous method
            /*
            GreetingsDelegate objGreetingsDelegate = delegate (string name)
            {
                return "Hello " + name + ", very good morning";
            };
            */

            string returnVal = objGreetingsDelegate.Invoke("Raju");

            Console.WriteLine(returnVal);
        }
    }
}
