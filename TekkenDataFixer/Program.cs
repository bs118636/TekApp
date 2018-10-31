using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TekkenDataFixer.Entity;

namespace TekkenDataFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            Type[] types = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "TekkenDataFixer.Entity");

            using (var db = new TekkenModel())
            {
                try 
                {
                    foreach (Type type in types)
                    {
                        PropertyInfo prop = db.GetType().GetProperty(type.Name);
                        object table = prop.GetValue(db, null);

                        table.GetType().InvokeMember("Local", BindingFlags.GetProperty, null, table, null);

                        object result = null;
                        MethodInfo method = typeof(Enumerable).GetMethod("ToList");
                        MethodInfo generic = method.MakeGenericMethod(type);
                        result = generic.Invoke(null, new object[] { table });

                        //dynamic obj = ConvertList((List<object>)result, type);
                        
                        foreach (var item in (dynamic)result)
                        {
                            Console.Write(item);
                        }

                        var list = result as List<object>;

                        //List<type> t = new List<type>();


                        //for (int i = 0; i <= result.)

                        //dynamic q = ((IEnumerable<object>)Queryable.Where((dynamic)table, l)).ToList();
                        //bool b = table.Equals(db.AKUMA_); //returns true;

                        //string x = "";
                        //object list = Activator.CreateInstance(valueType);
                        // public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);


                        //object result = null;
                        //MethodInfo method = typeof(Enumerable).GetMethod("ToList");
                        //MethodInfo generic = method.MakeGenericMethod(type);
                        //result = generic.Invoke(table, new object[] { result });

                        //string test = "";

                        //Type valueType = typeof(Enumerable).MakeGenericType(type);
                        
                        //MethodInfo methodInfo = valueType.GetMethod("ToList").MakeGenericMethod( new System.Type[] { valueType });
                        //var toListMethod = methodInfo.MakeGenericMethod(new[] { type });

                        //result = methodInfo.Invoke(null, new object[] { list });
                        


                    }
                }
                catch (Exception e) { Display(e.Message); }
            }

            Console.ReadLine();
            

            Type valueType2 = typeof(AKUMA_);

            object val = Activator.CreateInstance(typeof(List<>).MakeGenericType(valueType2));
            Console.WriteLine(val.GetType() == typeof(List<int>)); // "True" - it worked!


            using (var db = new TekkenModel())
            {
                try
                {
                    var list = db.AKUMA_.ToList();
                }
                catch (Exception e) { Display(e.Message); }
            }


        }

        public static object ConvertList(List<object> value, Type type)
        {
            IList list = (IList)Activator.CreateInstance(type);
            foreach (var item in value)
            {
                list.Add(item);
            }
            return list;
        }

        public static void Display(string str = "")
        {
            Console.WriteLine(str);
            Console.ReadLine();
        }

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .Where(t => t.ToString().Substring(t.ToString().Length - 1) == "_")
                      .ToArray();
        }
    }
}
