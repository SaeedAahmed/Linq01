using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq01.Task
{
    internal class CaseInSenestive : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            string copyx = x.ToLower();
            string copyy = y.ToLower();
            return copyx.CompareTo(copyy);
        }
    }
}
