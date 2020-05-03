//Sri Ram Jey Ram Jeya Jaya Ram
using System;

namespace PP.BangarRaju
{
    //10. (step 1) define the delegate
    //  the return type and the parameters of the methods should exactly match with the return type and parametes of the delegate
    //  the next step (step 2) is instanciation of the delegate, to do that create the instance of the delegate
    public delegate void RectangleDelegate(double Width, double Height);

    //24. define the delegate for the method with return type
    public delegate double RectangleDoubleDelegate(double Width, double Height);

    public class DelegatesP2
    {
        //Multicast Delegates
        //-------------------
        //01. Delegate: it is a type safe function pointer, using which we can call a method

        //(a) in c# we can call a method in two different way, for a non static method, we can call using instance of class
        // and name of the class if it is a static method
        // this is the approach we have been following for accessing the method (static or non static methods)

        //(b). the second approach is, calling the method by using a delegate
        // using delegates we can call static and non static methods also

        //there are three steps involved in calling a method using delegate
        //Step 1: defining delegate
        //Step 2: instanciating delegate
        //Step 3: calling the delgate

        //in previous class KDelegates, we seen how to bind method with a delegate and how to call the delegate

        //02. lets start multicast delegates
        //a delegate is going to hold reference of method (previous class example)
        //in MCD (multicast Delegate) a delegate will be holding the reference of more than one method, which can be called with the help of a delegate

        //03. in a class if we have multiple methods with same signature, we can call all those methods using the same delegate

        //06. create a main method, inside create object of Rectangle class 
        //07. call the methods of the class: GetArea and GetRectangle
        public void LDelegateMain()
        {
            Rectangle objRectangle = new Rectangle();
            objRectangle.GetArea(12.34, 56.78);
            objRectangle.GetPerimeter(12.34, 56.78);

            //08. lets check the output           

            /*  Hello World!
                700.6652
                138.24
             */

            //09. this is the normal way of calling, now I want to call the methods using a delegate
            //  to call the methods we do not require two delegates, because both the methods are having the
            //  same return type and the parameters are similar
            //  to do that lets first define a delegate

            //11. the next step (step 2) is instanciation of the delegate, to do that create the instance of the delegate
            //RectangleDelegate objRectangleDelegate = new RectangleDelegate(objRectangle.GetArea);

            //14. there is another way to perform instanciation of delegate
            RectangleDelegate objRectangleDelegate = objRectangle.GetArea;

            //15. now we need to call the second method, using the same deligate and same values, we can perform the binding like this
            objRectangleDelegate += new RectangleDelegate(objRectangle.GetPerimeter);
            //objRectangleDelegate += objRectangle.GetPerimeter;

            //16. run the program
            /*
             * Hello World!
             *   700.6652
             *   138.24
             *   700.6652   <=
             *   138.24     <=
             */

            //17. one single delegate call will invoke both the methods

            //12. (step 3) invoke the delegate
            //objRectangleDelegate(12.34, 56.78); (or)
            objRectangleDelegate.Invoke(12.34, 56.78);

            //13. the op is: 
            //      Hello World!
            //      700.6652
            //      138.24
            //      700.6652 <=

            //18. we can see that there is no need for us to call the delgate twice, calling the delegate once invoke both the methods

            //19. now if we want to find area and perimeter of different rectangle just pass different values
            Console.WriteLine();
            objRectangleDelegate(42.89, 98.52);

            //20. the op is: 
            //Hello World!
            //Area of rectangle is: 700.6652
            //Perimeter of rectangle is: 138.24
            //Area of rectangle is: 700.6652
            //Perimeter of rectangle is: 138.24

            //Area of rectangle is: 4225.5228
            //Perimeter of rectangle is: 282.82

            //21. now the delegate (objRectangleDelegate) is holding the reference of two methods
            //  both the methods are binded to this delegate and we can make a single call to execute both the delegate

            //21. the methods that we used are void types, suppose we have value returning methods
            //  then we will get the result of the last method only

            //22. expl: on calling delegate the first method (area) gets executes and the value comes the second method (perimeter)
            //  get executed and the values comes, the second output will overwrite the values of the first output

            //23. create two new methods with return type as double

            //25. creating the instance of the delegate (step: 2) instanciating the delegate
            //RectangleDoubleDelegate objRectangleDoubleDelegate = new RectangleDoubleDelegate(objRectangle.GetNewArea);
            RectangleDoubleDelegate objRectangleDoubleDelegate = objRectangle.GetNewArea;

            //26. bind the delegate with GetNewPerimeter method
            //objRectangleDoubleDelegate += new RectangleDoubleDelegate(objRectangle.GetNewPerimeter);
            objRectangleDoubleDelegate += objRectangle.GetNewPerimeter;

            //27. when we invoke the delegate, it returns the value. then how to capture
            //  first the GetNewArea method will be invoked and value will be stored in result and 
            //  then the second method GetNewPerimeter will be invoke and value will be stored in result, thus the value is overwritten
            //  the problem is it will display the result of the last method only. result of GetNewArea will not be displayed

            //28. so when ever you use multicast delegate the return type of the methods are void, else the values will be over written
            
            //29. even if output parameters are used, then only the return from first method output parameter will be over written by the 
            //  second method output parameter
            double result = objRectangleDoubleDelegate.Invoke(12.22, 15.45);

            //30. multicast delegate means the delegate is going to hold the reference of more than one methods (this eg. two methods reference is holded)

            Console.ReadLine();
        }
    }

    //04. lets create a new class called Rectangle
    //05. in the class lets define two methods
    //  (a) GetArea
    //  (b) GetPerimeter
    class Rectangle
    {
        //area of rectangle: height * width
        public void GetArea(double Width, double Height)
        {
            Console.WriteLine("Area of rectangle is: " + Height * Width);
        }

        //perimeter of a rectangle: 2 * (width + height)
        public void GetPerimeter(double Width, double Height)
        {
            Console.WriteLine("Perimeter of rectangle is: " + 2 * (Width + Height));
        }

        //23. create two new methods with return type as double
        public double GetNewArea(double Width, double Height)
        {
            return Height * Width;
        }

        public double GetNewPerimeter(double Width, double Height)
        {
            return (2 * (Width + Height));
        }
    }
}
