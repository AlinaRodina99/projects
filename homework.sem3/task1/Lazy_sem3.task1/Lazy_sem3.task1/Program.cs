using System;
using System.Threading;

namespace Lazy_sem3.task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lazy = LazyFactory<int>.CreateOneThreadLazy(() => 4 * 2);
            lazy.Get();
            var result = lazy.Get();
        }
    }
}
