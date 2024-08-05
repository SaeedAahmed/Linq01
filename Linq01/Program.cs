using Linq01.Demo;
using Linq01.Task;
using static Linq01.ListGenerator;
namespace Linq01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implicittly Type local variable
            /// var Data = "Saeed";
            /// Compiler will detect the DataType of variable based on its intial value at compilition time
            /// Must be initialized
            /// Can't be initialized with null
            /// After intitialization , U can't change variable datatype

            /// dynamic Data02 = "Ahmed";
            /// Clr will detect the datatype of based its last assigned value at runtime
            /// Not must be initialized
            /// Can't be initialized with null
            /// After intitialization , U can change variable datatype
            #endregion

            #region Extension Method
            //int x = 123456;
            //int y = IntExtensions.Reverse(x);
            //y = x.Reverse(); // Syntax Sugar
            //Console.WriteLine(y); 
            #endregion

            #region AnonymousType
            //Employee E01 = new Employee() { Id=10 , Name="Saeed" , Salary=9_0000};

            //var E01 = new { Id = 10, Name = "Saeed", Salary = 9_0000 };
            //Console.WriteLine(E01.GetType().Name); // AnonymousType0`3
            //Console.WriteLine(E01);
            //// The object that will be created anonymousType is a immutable object[can't change]

            ////To modify an object, you'll go ahead and create a new object, which will store the value in the old object, and then modify it [Like a string]
            ////var E02 = new { E01.Id, E01.Name, Salary = 4_0000 };
            ////var E02 = E01 with { Salary = 4_0000 }; // C# 10.0 Feature

            //var E02 = new { Id = 20, Name = "Ahmed", Salary = 3_0000 };
            /// The same AnonymousType as long as :
            /// 1. the same properties name [Case Sensitive]
            /// 2. The same properties order
            /// 3. The same properties datatype


            #endregion

            #region LINQ
            // LINQ Stands for Language-Integrated Query
            // LINQ : +40 Extension Methods [For the classes that implement Built-in interface 'IEnumerable']
            //      : named as [LINQ Operators] exsited at class 'Enumerable'
            //      : Categorized into 13 categories

            // U can use LINQ operators against the Data[Stored in Sequence] , despite data store[Sql server, MYSql , oracle]
            // Sequence : the object from any class to implement the built-in interface 'IEnumerable'
            // 1. Local Sequence [static data or from XML] L2Object , L2xml
            // 2. Remote Sequence [from database] : L2EF
            //List<int> list = new List<int>() { 1, 2 , 3, 4, 5} ; // Local Sequence
            //List<int> OddNumbers = list.Where((N) => N % 2 == 1).ToList();
            //foreach(int odd in OddNumbers)
            //{
            //    Console.WriteLine(odd);
            //} 
            #endregion

            #region LINQ Syntax

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5 }; // Local Sequence

            /// 1. Fluent Syntax
            /// 1.1 Call 'LINQ operator' as static Method through class "Enumerable"
            ///var oddNUmbers = Enumerable.Where(list, (N) => N % 2 == 0);
            ///
            /// 1.2 Call 'LINQ operator' as Extension Method 
            ///oddNUmbers = list.Where((N) => N % 2 == 0);

            /// 2. Query Syntax [Query Expression] : like sql server style
            /// Start with from , Introducing rang variable (N) : Represents each element at sequence
            /// End with select or group by

            //var oddNUmbers = from N in list
            //                 where N % 2 == 0
            //                 select N;
            //foreach (var n in oddNUmbers)
            //{
            //    Console.WriteLine(n);
            //}
            #endregion

            #region LINQ Execution Ways
            /// 1. Differed Execution
            ///List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            ///var oddNumbers = numbers.Where((N) => N % 2 == 0);
            ///numbers.AddRange(new int[] { 6, 7, 8, 9, 10 });
            ///foreach (int n in oddNumbers)
            ///{
            ///    Console.WriteLine(n);
            ///}

            /// 2. Immediate Execution [Element operators , casting operators , Aggregate operators]
            ///List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            ///var oddNumbers = numbers.Where((N) => N % 2 == 0).ToList();
            ///numbers.AddRange(new int[] { 6, 7, 8, 9, 10 });
            ///foreach (int n in oddNumbers)
            ///{
            ///    Console.WriteLine(n);
            ///}
            #endregion

            #region Test Data Setup
            //Console.WriteLine(ProductsList[0]);
            //Console.WriteLine(CustomersList[0]); 
            #endregion

            #region Filteration - Where
            ////Fluent Syntax
            //var res = ProductsList.Where((P) => P.UnitsInStock == 0);
            ////Query Syntax
            //res = from P in ProductsList
            //      where P.UnitsInStock == 0
            //      select P;


            ///indexed Where
            /// Valid only at fluent Syntax, Can't products that are out of stock
            //var res = ProductsList.Where((P, I) => I < 10 && P.UnitsInStock == 0);

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Transformation  Operators - select / selectMany
            ///select
            /// Fluent Syntax
            ///var res = ProductsList.Select((P) => P.ProductName);
            ///Quary Syntax
            ///res = from P in ProductsList
            ///      select P.ProductName;

            ///selectMany
            /// Fluent Syntax
            ///var res = CustomersList.SelectMany((C) => C.Orders);
            /// Quary Syntax
            ///res = from C in CustomersList
            ///      from o in C.Orders
            ///      select o;
            ///foreach (var item in res)
            ///{
            ///    Console.WriteLine(item);
            ///}
            /***********************************************/

            //var res = ProductsList.Select(P => new { P.ProductID, P.ProductName });

            //var res = from P in ProductsList
            //      select new
            //      {
            //          id = P.ProductID,
            //          name = P.ProductName,
            //      };
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            /************************************************/

            //var discountList = ProductsList.Where(P => P.UnitsInStock > 0)
            //                               .Select(P => new
            //                               {
            //                                   Id = P.ProductID,
            //                                   Name = P.ProductName,
            //                                   NewPrice = P.UnitPrice - (P.UnitPrice * 0.1m)

            //                               });

            //discountList = from P in ProductsList
            //               where P.UnitsInStock > 0
            //               select new
            //               {
            //                   Id = P.ProductID,
            //                   Name = P.ProductName,
            //                   NewPrice = P.UnitPrice - (P.UnitPrice * 0.1m)
            //               };


            //foreach (var discount in discountList) 
            //{
            //    Console.WriteLine(discount);
            //}
            #endregion

            #region Order Operators
            //var res = ProductsList.OrderBy(P => P.UnitPrice);

            //res = from P in ProductsList
            //      orderby P.UnitPrice descending
            //      select P;

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            /// ThenBy
            ///var res = ProductsList.OrderBy(P => P.UnitPrice).ThenBy(P => P.UnitsInStock);
            ///res = from P in ProductsList
            ///      orderby P.UnitPrice , P.UnitsInStock
            ///      select P;
            ///foreach (var item in res)
            ///{
            ///    Console.WriteLine(item);
            ///}

            #endregion

            #region Assignment
            #region LINQ - Restriction Operators

            #region 1. Find all products that are out of stock.

            //var res = ProductsList.Where((p) => p.UnitsInStock == 0);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 2. Find all products that are in stock and cost more than 3.00 per unit.

            //var res = ProductsList.Where(P => P.UnitsInStock != 0 && P.UnitPrice > 3);
            // foreach (var item in res)
            // {
            //     Console.WriteLine(item);
            // }

            #endregion

            #region 3. Returns digits whose name is shorter than their value.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight","nine" };
            //var res = Arr.Where((d, i) => d.Length < i);
            //foreach (var d in res)
            //{
            //    Console.WriteLine(d);
            //}

            #endregion

            #endregion

            #region LINQ - Ordering Operators

            #region 1. Sort a list of products by name

            //var sortedProd = ProductsList.OrderBy(P => P.ProductName);
            //foreach(var item in sortedProd)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.

            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var SortArr = Arr.OrderBy(e => e, new CaseInSenestive());
            //foreach (var item in SortArr) 
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.

            //var sortedProdDec = ProductsList.OrderByDescending(P => P.UnitPrice);
            //foreach (var item in sortedProdDec) 
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region 4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var sortArr = Arr.OrderBy(D => D.Length).ThenBy(D => D);
            //foreach (var item in sortArr)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region 5. Sort first by word length and then by a case-insensitive sort of the words in an array.

            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var sortWords = words.OrderBy(W => W.Length).ThenBy(W => W, new CaseInSenestive());
            //foreach (var word in sortWords)
            //{
            //    Console.WriteLine(word);
            //}

            #endregion

            #region 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.

            //var sortProducts = ProductsList.OrderByDescending(P => P.Category).ThenByDescending(P => P.UnitPrice);
            //foreach (var product in sortProducts)
            //{
            //    Console.WriteLine(product);
            //}

            #endregion

            #region 7. Sort first by word length and then by a case-insensitive descending sort of the words in an array.

            //string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var SortWords = Arr.OrderBy(W => W.Length).ThenByDescending(W => W, new CaseInSenestive());
            //foreach(var words in SortWords)
            //{
            //    Console.WriteLine(words);
            //}

            #endregion

            #region 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var SortArr = Arr.Reverse().Where(Index => Index[1] == 'i');
            //foreach (var Index in SortArr)
            //{
            //    Console.WriteLine(Index);
            //}    

            #endregion

            #endregion
            #endregion
        }
    }
}
