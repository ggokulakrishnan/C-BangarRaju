//Sri Rama Jeyam
using System;

namespace PP.BangarRaju
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!! from Program.cs, Main() method");

            #region "Delegates Part #01"

            //DelegatesP1 objDelegates = new DelegatesP1();
            //objDelegates.KDelegateMain();

            #endregion

            #region "Delegates Part #02 (Multicase Delegates)"

            //DelegatesP2 objLDelegates = new DelegatesP2();
            //objLDelegates.LDelegateMain();

            #endregion

            #region "Delegates Part #03 (Anonymonous Methods)"

            //AnonymousMthd objMDelegates = new AnonymousMthd();
            //objMDelegates.MDelegateMain();

            #endregion
             
            #region "Delegates Part #04 (Lambda Expressions)"

            //LamdaExp objNDelegates = new LamdaExp();
            //objNDelegates.NDelegateMain();

            #endregion

            #region "Delegates Part #05 (Func, Action and Predicates)"

            FuncActPredicates objOCDelegates = new FuncActPredicates();
            objOCDelegates.ODelegateMain();

            #endregion

            Console.ReadLine();
        }
    }
}
