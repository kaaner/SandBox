using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive.Console
{
    public class Node
    {
        public Node(int val)
        {
            Val = val;
        }
        public int Val { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }
}
