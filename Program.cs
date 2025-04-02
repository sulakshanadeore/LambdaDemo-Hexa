using LambdaDemo;
using LibraryForLambda;

internal class Program
{

    private static void Main(string[] args)
    {
        // =>  Lambda/GoesTo
        //SimpleLambdaWorkingWithDelegates();

        //Total number of Parameters in Action Lambda is 17, all are input parameters 
        //Action lambda--- Action is a delegate , no need to declare a delegate
        //WorkWithActionFuncAndPredicateLambda();
        int i = 100;
        var j = 89.45f;//float
        //ERROR    j  = 232.34234d;
        //Disadvantage of var datatype---- > it CANT CHANGE THE TYPE OF DATA IT CAN HOLD, ONCE DECLARED AS FLOAT ALWAYS REMAINS A FLOAT
        //var is not allowed in the method parameters nor in the return type of method
        dynamic k = 56.63f;
        k = "Ramesh";
       // k = 'C';
       // k = true;
        //Advantge of dynamic datatype---- > it CAN CHANGE THE TYPE OF DATA IT CAN HOLD, ONCE DECLARED AS FLOAT IT  CAN CHANGE ANY TIME AND ANY NUMBER OF TIMES
        //dynamic is allowed in the parameters as well as in the return type of the method.

        dynamic ans=method1(k);
        Console.WriteLine(ans);


        Employee emp=new Employee();
        emp.InsertData(emp);
        emp.CalculateSalary();








    }


    public static dynamic method1(dynamic d1)
    {
        dynamic d2;
        d2 = "HEllo " + d1;
        return d2;
    
    
    }

    private static void WorkWithActionFuncAndPredicateLambda()
    {
        Action<string, string> checkUserNameAndPassword = (username, password) =>
        {
            if (username != null && password != null)
            {
                if (username == "Anuradha" && password == "Anu@123")
                {
                    Console.WriteLine("Valid User.... We are shortly redirecting you to the Inbox");

                }
                else
                {
                    Console.WriteLine("InValid Username and password...Pls check");
                }

            }

        };

        checkUserNameAndPassword("Anuradha", "Anu@123");
        Console.WriteLine("----------------------------------------");
        checkUserNameAndPassword("Anuprita", "Anu@132");

        Console.WriteLine("*************Function Lamdba*****************");

        //Total number of Parameters in Func Lambda is 17, 16 is input parameters and last the output parameter
        Func<string, string, char> FunctionToCheckUSerNameAndPassword = (username, password) =>
        {

            char ValidOrInValid = 'I';
            if (username != null && password != null)
            {
                if (username == "Anuradha" && password == "Anu@123")
                {
                    ValidOrInValid = 'V';

                }


            }
            return ValidOrInValid;
        };



        char output = FunctionToCheckUSerNameAndPassword("Anuradha", "Anu@123");
        Console.WriteLine(output);
        Console.WriteLine("----------------------------------------");
        output = FunctionToCheckUSerNameAndPassword("Anuprita", "Anu@132");
        Console.WriteLine(output);



        Console.WriteLine("****************************************");
        //Predicate Lambda---- return type is always bool and it takes only one input  parameter
        Predicate<string> CheckWhetherStringHasVowel = (p) =>
        {
            if (p.Contains('a') || p.Contains('e') || p.Contains('i') || p.Contains('o') || p.Contains('u'))
            {

                return true;
            }
            else
            {

                return false;

            }

        };

        bool result = CheckWhetherStringHasVowel("Rajesh");
        Console.WriteLine(result);
        Console.WriteLine("------------------");
        result = CheckWhetherStringHasVowel("Hmmmmmm");
        Console.WriteLine(result);
    }

    private static void SimpleLambdaWorkingWithDelegates()
    {
        Add del = (i, j) =>
        {
            return i + j;
        };

        int addans = del(10, 20);
        Console.WriteLine(addans);


        Greet g = (s) =>
        {

            if (s != null)
                Console.WriteLine("Hello " + s);
        };

        g("Raj");

        PrintHelloWorld p = () =>
        {
            return "Hello World";

        };

        string output = p();
        Console.WriteLine(output);
    }
}