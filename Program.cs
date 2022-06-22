using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    internal class Program
    {

        public delegate int MyHandler(int i);
        static void Main(string[] args)
        {
            var lesson = new Lesson("Programming in C#");

            lesson.Started += Lesson_Started;

            lesson.Started += (sender, date) =>
            {
                //Console.WriteLine(sender);
                //Console.WriteLine(date);
            };

            lesson.Start();

            var list = new List<int>();

            for (int i = 0; i <= 100; i++)
            {
                list.Add(i);
            }

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            var aggregatedList = list.Aggregate((x, y) => x + y);
            Console.WriteLine(list);
            Console.WriteLine(aggregatedList);

            var result1 = Agr(list, delegate (int i)
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            });

            var result2 = Agr(list, Method);

            var result3 = Agr(list, x => x * x * x * x);

            Console.WriteLine("Result1 :" + result1);
            Console.WriteLine("Result2 :" + result2);
            Console.WriteLine("Result3 :" + result3);


            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyHandler handler = delegate (int i)
                {
                    var r = i * i;
                    //Console.WriteLine(r);
                    return r;
                };

                handler += Method;

                //Console.WriteLine(handler(result));

                //MyHandler lambdaHandler = (i) =>  i * i;

                MyHandler lambdaHandler = (i) =>
                {
                    var r = i * i;
                    return r;
                };

                //Console.WriteLine(lambdaHandler(result));

                Console.ReadLine();
            }   
        }

        protected static int Agr(List<int> list, MyHandler handler)
        {
            int result = 0;

            foreach(var item in list)
            {
                result += handler(item);
            }

            return result;
        }
        private static void Lesson_Started(object sender, DateTime e)
        {
        }

        public static int Method(int i)
        {
            return i * i * i;
        }
    }
}
