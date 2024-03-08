using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.ShortestPath.CheapestFlight
{
    public class Node
    {
        public int Name { get; set; }
        public Dictionary<Node, int> Edges { get; set; }

        public Node(int name)
        {
            Name = name;
        }
        public Node(int name, Dictionary<Node, int> edges)
        {
            Edges = edges;
            Name = name;
        }

        public Node AddEdge(Node node, int distance)
        {
            Edges ??= new Dictionary<Node, int>();
            Edges.Add(node, distance);

            return this;
        }

        public override string ToString() => $"Node: {Name}, Edges: {Edges?.Count}";
    }
}
