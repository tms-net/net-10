using System.Collections;

namespace Homework_4
{
    class MyArray : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    static class ArrayExtensions
    {
        internal static object[] ReverseToArray(this IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {

            }

            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                { 
                }
            }
        }

        internal static int[] ReverseArray(this int[] array) 
        {
            return array[^0..];
        }
    }
}
