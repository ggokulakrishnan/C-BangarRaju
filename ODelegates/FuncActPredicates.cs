using System;

namespace PP.BangarRaju
{
    //23. now lets delete all the three delegates and make use of generic delegates

    /*
    //10. we have defined three delegates and using the three delegates, we need to call three methods

    public delegate double Delegate1(int x, float y, double z);

    public delegate void Delegate2(int x, float y, double z);

    public delegate bool Delegate3(string str);
    */

    public class FuncActPredicates
    {
        //01. Func, Action and Predicates

        //02. Here we will see about Generic Predefined delgates

        //03. three predefined delegates are available for us
        //  a. func
        //  b. action 
        //  c. predicate

        //04. these delegates are defined in base class libraries

        //05. lets create a method AddNums1

        public static double AddNums1(int x, float y, double z)
        {
            return x + y + z;
        }

        //06. create a void method (non value returning method)
        public static void AddNums2(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);
        }

        //07. create an another method which takes string as parameter and checks values and returns boolean
        // if length is greater than 5 then true else false
        public static bool CheckLength(string str)
        {
            if (str.Length > 5)
                return true;
            else
                return false;
        }

        //08. lets call these three methods by using the delegates

        //09. to do that we need to define three delegates, lets do that in the namespace

        //11. lets create the main method()

        public void ODelegateMain()
        {
            //12. lets call the first method 'AddNums1' using delegate
            //Delegate1 objAddNum1 = new Delegate1(AddNums1);            

            //13. or we can directly bind the delegate
            //Delegate1 objAddNum1 = AddNums1;

            //24. now we can see the error near to Delegate1, remove the Delegate1 and use func delegate
            //  for Func delegate there are 17 overloads, we can choose what to pass
            //  first is Func<out TResult>: we have a method that does not take any value but going to return a value
            //  similarly Func<in T1, out TResult>: a method with one input and one output
            //  same way Func<in T1, in T2, out TResult>: a method with two input and one output
            //  similar way we will have method which will take 16 input and 1 output so total 17

            // to our requirement the 4th overload matches: 3 input and 1 output
            // and for T1, T2 and T3, we can tell what type of value we want to pass as output now
            // Func <int, float, double, double>: this exactly matches with our method
            //  first three are input and the last one is output
            //Func<int, float, double, double> objAddNum1 = new Func<int, float, double, double>(AddNums1);

            // or in a simplified form we can write as
            Func<int, float, double, double> objAddNum1 = AddNums1;


            //14. pass 1 integer, 1 float and 1 double value
            double result = objAddNum1.Invoke(100, 34.5f, 193.465);
            Console.WriteLine(result);

            //25. when our method is not returning any value, then we can use an action delegate
            //  in action delegate we have input and output parameter, where the output parameter is void (all are inputs only)
            //  for the method AddNum2 we can can not use Func delegate as this method has a return type as void, so we 
            //      should use action
            //  this action delegate has 16 inputs because there is no output
            //  Action<in T1>: method with 1 input parameter and no output/return value
            //  Action<in T1, in T2>: method with 2 input parameter and no output/return value
            //  smilarly we can have till 16 parameters, Action<in T1, in T2,.. in T16>: method with 16 input parameter and no output 
            //  because it it predefined as void

            //15. similarly invoke the second method using delegate2
            //Delegate2 objAddNum2 = AddNums2;

            //26. for the method AddNums2() lets apply the Action delegate, like Func<> delegate there is no need to pass the 
            //  fourth parameter here, because there is no output parameter
            Action <int, float, double> objAddNum2 = AddNums2;

            objAddNum2.Invoke(100, 34.5f, 193.465);

            //16. invoke the third method using delegate3
            //*Delegate3 objCheckLength = CheckLength;

            //27. when do we use the predicate, when the method return type is boolen, then only we can use the predicate delegate
            //  for the method CheckLenght, we can use prediate delegate
            //  for predicate delegates there are no overloads here, only single return type
            //  Predicate<in T>: the input type is string and no need to tell the output type, it is predefined and the type is
            //      boolean
            //  Predicate delgate can take only a single paramter and the return type is fixed that is bool
            //*Predicate<string> objCheckLength = CheckLength;

            //28. when we run this we will get the same output

            //29. with out defining the delegates we can make use of the three predefined delegates

            //30. in place of a predicate delegate a func delegate an full fill the requirement
            //*Func<string, bool> objCheckLength = CheckLength;

            //31. in case of bool return type with one input parameter it is recommended to use the perdicate delegate
            Predicate<string> objCheckLength = CheckLength;

            bool status = objCheckLength.Invoke("Hello");
            Console.WriteLine(status);

            //17. lets run the program (we have three methods and to call the three methods we have three delegates)
            /* OP:
             *  327.96500000000003
             *  327.96500000000003
             *  False
             */

            //18. to invoke each method, we defined n number of delegates in the previous classes
            //  actually defining the delegates is not mandatory here because there are three generic delegates that are 
            //  avaiable for us
            //  (a) func delegate
            //  (b) action delegate
            //  (c) predicate delegate

            //19. so when to use a func delegate:
            //  it is used, when a method is going to return a value (for a value returning method we will use func delegate)
            //  eg: here AddNums1() method can use func delegate as it is returning a value (double)

            //20. so when to use action delegate:
            //  for a non value returing method we will use an action delegate
            //  eg: here AddNums2() method can use action delegate as this method will not return a value (it is of void type)

            //21. so when to use predicate delegate:
            //  we will use the predicate delegate when we want the return type as boolean
            //  eg: here CheckLength() method can use predicate delegate as this method will return a boolean

            //22. now lets see how to use them

            //32. the code can be further simplified by writign anonymonous method in place of a named function
            Func<int, float, double, double> objAddNumA = (x, y, z) =>
            {
                return x + y + z;
            };
            double resultA = objAddNumA.Invoke(100, 34.5f, 193.465);
            Console.WriteLine(resultA);


            Action<int, float, double> objAddNumB = (x, y, z) =>
            {
                Console.WriteLine(x + y + z);
            };
            objAddNumB.Invoke(100, 34.5f, 193.465);


            Predicate<string> objCheckLengthA = (str) =>
            {
                if (str.Length > 5)
                    return true;
                else
                    return false;
            };
            bool statusA = objCheckLengthA.Invoke("Hello");         
            Console.WriteLine(status);

            //33. now all the defined above can be deleted
            //  we are directly going to use the anonymous methods and lamda operator

            //34. now we can again simplify the code by removing the curly braces and remove return for single statement

            Func<int, float, double, double> objAddNumAA = (x, y, z) =>  x + y + z;            
            double resultAA = objAddNumAA.Invoke(100, 34.5f, 193.465);
            Console.WriteLine(resultAA);

            Action<int, float, double> objAddNumBB = (x, y, z) => Console.WriteLine(x + y + z);
            objAddNumBB.Invoke(100, 34.5f, 193.465);

            Predicate<string> objCheckLengthAA = (str) => (str.Length > 5) ? true : false;            
            bool statusAA = objCheckLengthAA.Invoke("Hello");
            Console.WriteLine(statusAA);
        }
    }
}
