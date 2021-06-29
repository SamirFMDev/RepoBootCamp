using System;

namespace Anonymous
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Anonymous anonymous = new Anonymous();
            dynamic anonymousDynamicData = anonymous.getData();
            Console.WriteLine(string.Format("{0} {1}", anonymousDynamicData.Name, anonymousDynamicData.EmailID));

            object anonymousData = anonymous.getData();
            var obj = toGeneric(anonymousData, new { Name = "", EmailID = "" }); 
            Console.WriteLine(string.Format("{0} {1}", obj.Name, obj.EmailID));
            
        }
        public static T toGeneric<T>(object obj, T type)
        {
            return (T)obj;
        }
    }
}
