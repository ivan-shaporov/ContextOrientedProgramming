using System.Collections.Generic;

namespace ContextOrientedProgramming
{
    /// <summary>
    /// Class emulating compiler generated scope management.
    /// </summary>
    class Context
    {
        private Context Parent;
        private HashSet<string> External = new HashSet<string>();
        private readonly Dictionary<string, object> Values = new Dictionary<string, object>();

        public Context Subset(params string[] names) => new Context { Parent = this, External = new HashSet<string>(names) };

        public T Get<T>(string n) => External.Contains(n) ? Parent.Get<T>(n) : (T)(Values[n]);

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <typeparam name="T">Variable type.</typeparam>
        /// <param name="n">Variable name.</param>
        /// <param name="v">Assigned value.</param>
        public void Set<T>(string n, T v)
        {
            if (External.Contains(n))
            {
                Parent.Set(n, v);
            }
            else
            {
                Values[n] = v;
            }
        }
    }
}
