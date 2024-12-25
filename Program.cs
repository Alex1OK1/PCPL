using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Part2
{
    [AttributeUsage((AttributeTargets.Method))]
    public class OpenMethod : System.Attribute
    {

    }

    [AttributeUsage((AttributeTargets.Property))]
    public class OpenProperty : System.Attribute
    {

    }

    [AttributeUsage((AttributeTargets.Constructor))]
    public class OpenConstructor : System.Attribute
    {

    }
    public class ReflectClass
    {
        [OpenConstructor]
        private ReflectClass() 
        {

        }

        public ReflectClass(string name)
        {
            Name = name;
        }

        [OpenProperty]
        private string Name { get; }
        public int count { get; set; }

        private int Sum(int a, int b)
        {
            return a + b;
        }

        [OpenMethod]
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodReflectInfo<T>(T obj) where T : class
        {
            Type type = typeof(T);

            #region Constructor info
            Console.WriteLine("Список конструкторов класса {0}\n", obj.ToString());
            foreach (ConstructorInfo ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                string modificator = "";

                if (ctor.IsPublic)
                    modificator += "public";
                else if (ctor.IsPrivate)
                    modificator += "private";
                else if (ctor.IsAssembly)
                    modificator += "internal";
                else if (ctor.IsFamily)
                    modificator += "protected";
                else if (ctor.IsFamilyAndAssembly)
                    modificator += "private protected";
                else if (ctor.IsFamilyOrAssembly)
                    modificator += "protected internal";
                Console.Write($"{modificator} {type.Name}(");

                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("\n");
            #endregion

            #region Methods info
            Console.WriteLine("Список методов класса {0}\n", obj.ToString());
            foreach(MethodInfo mth in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic 
                | BindingFlags.Public | BindingFlags.Static).Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
            {
                string modificator = "";

                if (mth.IsPublic)
                    modificator += "public";
                else if (mth.IsPrivate)
                    modificator += "private";
                else if (mth.IsFamily)
                    modificator += "protected";

                if (mth.IsStatic)
                    modificator += " static";
                else if (mth.IsAbstract)
                    modificator += " abstract";
                else if (mth.IsVirtual)
                    modificator += " virtual";

                Console.Write($"{modificator} {mth.ReturnType.Name} {mth.Name}(");

                ParameterInfo[] parameters = mth.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("\n");
            #endregion

            #region Properties info
            Console.WriteLine("Список свойств класса {0}\n", obj.ToString());
            foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.Write($"{prop.Name} Can read: {prop.CanRead} Can write: {prop.CanWrite}");
                Console.Write("\n");
            }
            #endregion
        }

        public static void MethodReflectInfoToOpenAttributes<T>(T obj) where T : class
        {
            Type type = typeof(T);

            #region Constructor info
            Console.WriteLine("Список конструкторов класса {0}\n", obj.ToString());
            foreach (ConstructorInfo ctor in type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic 
                | BindingFlags.Public).Where(p => p.GetCustomAttributes<OpenConstructor>().Any()))
            {
                string modificator = "";

                if (ctor.IsPublic)
                    modificator += "public";
                else if (ctor.IsPrivate)
                    modificator += "private";
                else if (ctor.IsAssembly)
                    modificator += "internal";
                else if (ctor.IsFamily)
                    modificator += "protected";
                else if (ctor.IsFamilyAndAssembly)
                    modificator += "private protected";
                else if (ctor.IsFamilyOrAssembly)
                    modificator += "protected internal";
                Console.Write($"{modificator} {type.Name}(");

                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("\n");
            #endregion

            #region Methods info
            Console.WriteLine("Список методов класса {0}\n", obj.ToString());
            foreach (MethodInfo mth in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic 
                | BindingFlags.Public | BindingFlags.Static).Where(m => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_") 
                && m.GetCustomAttributes<OpenMethod>().Any()))
            {
                string modificator = "";

                if (mth.IsPublic)
                    modificator += "public";
                else if (mth.IsPrivate)
                    modificator += "private";
                else if (mth.IsFamily)
                    modificator += "protected";

                if (mth.IsStatic)
                    modificator += " static";
                else if (mth.IsAbstract)
                    modificator += " abstract";
                else if (mth.IsVirtual)
                    modificator += " virtual";

                Console.Write($"{modificator} {mth.ReturnType.Name} {mth.Name}(");

                ParameterInfo[] parameters = mth.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("\n");
            #endregion

            #region Properties info
            Console.WriteLine("Список свойств класса {0}\n", obj.ToString());
            foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic 
                | BindingFlags.Instance).Where(p => p.GetCustomAttributes<OpenProperty>().Any()))
            {
                Console.Write($"{prop.Name} Can read: {prop.CanRead} Can write: {prop.CanWrite}");
                Console.Write("\n");
            }
            #endregion
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ReflectClass reflectClass = new ReflectClass("TestClass");

            ReflectClass.MethodReflectInfo<ReflectClass>(reflectClass);
            Console.WriteLine("\n\n\n");

            ReflectClass.MethodReflectInfoToOpenAttributes<ReflectClass>(reflectClass);
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Результат вызова метода PrintMessage с помощью рефлексии:\n");
            MethodInfo classMethod = typeof(ReflectClass).GetMethod("PrintMessage");
            object classValue = classMethod.Invoke(reflectClass, new object[] { "Hellow World!" });

            Console.ReadLine();
        }
    }
}
