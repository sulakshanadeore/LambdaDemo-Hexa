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
        //ParitalClassMethodsAndDynamic();

        //TupleWorking();

        (int, string) person = (1, "Hari");
        Console.WriteLine(person.Item1);
        Console.WriteLine(person.Item2);

        (int, string, string, float, double) data = (11, "Jack", "Mumbai", 344.33f, 3435.234d);
        Console.WriteLine(data);

        (int Catid, string CatName, string Description, float AvgPrice, double TotalPrice) Catdata = (Catid: 11, CatName: "Beverages", Description: "All Beverages", AvgPrice: 344.33f, TotalPrice: 3435.234d);
       
        Console.WriteLine("===================Using Methods with Value Tupe==========================");

        (int Bookid, string BookName, float BookPrice) bdata = (Bookid:11,BookName:"Learn DesignPattern",BookPrice:1400);

        Books newbookData=new  Books();
        newbookData.AssignBookData(bdata);
        (int Bookid, string BookName, float BookPrice) bookData = newbookData.DisplayBookData();
        Console.WriteLine(bookData.Bookid);
        Console.WriteLine(bookData.BookName);
        Console.WriteLine(bookData.BookPrice);




    }

    private static void TupleWorking()
    {
        //Tuple means Row. A row can store a single value or multiple values
        Tuple<int> tuple = Tuple.Create(10);
        Console.WriteLine(tuple.Item1);

        Tuple<Employee> emp = Tuple.Create(new Employee { Empid = 1, Ename = "Suraj", Email = "suraj@gmail.com" });
        Console.WriteLine(emp.Item1.Empid);
        Console.WriteLine(emp.Item1.Ename);
        Console.WriteLine(emp.Item1.Email);
        Console.WriteLine("========================");
        var empdata = Tuple.Create(new Employee { Empid = 2, Ename = "Hemant", Email = "hemant@gmail.com" });

        Console.WriteLine(empdata.Item1.Empid);
        Console.WriteLine(empdata.Item1.Ename);
        Console.WriteLine(empdata.Item1.Email);

        Console.WriteLine("================================");
        var somedata = Tuple.Create<int, int, int, int, int, int, int, Tuple<double, double>>(1, 2, 3, 4, 5, 6, 7, Tuple.Create(12.3445d, 22343.324d));
        Console.WriteLine(somedata.Item1);
        Console.WriteLine(somedata.Item2);
        Console.WriteLine(somedata.Item3);
        Console.WriteLine(somedata.Item4);
        Console.WriteLine(somedata.Item5);
        Console.WriteLine(somedata.Item6);
        Console.WriteLine(somedata.Item7);
        Console.WriteLine(somedata.Rest.Item1.Item1);
        Console.WriteLine(somedata.Rest.Item1.Item2);
        Console.WriteLine("-------------------Using Tuple in a method parameter--------------------");
        Books b = new Books();
        Tuple<int, string, float> tuple2 = Tuple.Create<int, string, float>(11, "Learn C#", 1000.00f);
        b.SetBookData(tuple2);

        Tuple<int, string, float> tuple3 = b.GetBookData();
        Console.WriteLine(tuple3.Item1);
        Console.WriteLine(tuple3.Item2);
        Console.WriteLine(tuple3.Item3);


        //Console.WriteLine(b.Bookid);
        //Console.WriteLine(b.BookName);
        //Console.WriteLine(b.Price);
    }

    private static void ParitalClassMethodsAndDynamic()
    {
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

        dynamic ans = method1(k);
        Console.WriteLine(ans);


        Employee emp = new Employee();
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