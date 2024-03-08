// See https://aka.ms/new-console-template for more information

/*
 *            6
 *     2   B-----E    9
 *      /  |   / |  \
 *    A    |5 /3 |1   C
 *      \  | /   |  / 
 *     8   D-----F    3
 *            2
 */
using SandBox.Dijkstra;

Console.WriteLine("Hello, World!");

var nodes = new Dictionary<string, Node>()
{
    ["A"] = new Node("A"),
    ["B"] = new Node("B"),
    ["C"] = new Node("C"),
    ["D"] = new Node("D"),
    ["E"] = new Node("E"),
    ["F"] = new Node("F")
};

nodes["A"].AddEdge(nodes["B"], 2).AddEdge(nodes["D"], 8);
nodes["B"].AddEdge(nodes["A"], 2).AddEdge(nodes["D"], 5).AddEdge(nodes["E"], 6);
nodes["C"].AddEdge(nodes["E"], 9).AddEdge(nodes["F"], 3);
nodes["D"].AddEdge(nodes["A"], 8).AddEdge(nodes["B"], 5).AddEdge(nodes["E"], 3).AddEdge(nodes["F"], 2);
nodes["E"].AddEdge(nodes["B"], 6).AddEdge(nodes["D"], 3).AddEdge(nodes["F"], 1).AddEdge(nodes["C"], 9);
nodes["F"].AddEdge(nodes["C"], 3).AddEdge(nodes["D"], 2).AddEdge(nodes["E"], 1);

var finalNode = nodes["C"];

var distances = nodes.ToDictionary(x => x.Value, kvp => (int?)int.MaxValue);
var parents = new Dictionary<Node, Node>();
var undiscoveredNodes = new HashSet<Node>(nodes.Values);

distances[nodes["A"]] = 0;

while (undiscoveredNodes.Count > 0)
{
    var current = undiscoveredNodes.MinBy(node => distances[node]);
    undiscoveredNodes.Remove(current);

    if (current == finalNode)
        break;

    foreach (var (adjacent, distance) in current.Edges)
    {
        var subDistance = distances[current] + distance;

        if (subDistance < distances[adjacent])
        {
            distances[adjacent] = subDistance;
            parents[adjacent] = current;
        }
    }
}

// Traversing the path

var pathNodes =  new List<Node>();
var currentNode = finalNode;

while (currentNode != null)
{
    pathNodes.Insert(0, currentNode);
    currentNode = parents.TryGetValue(currentNode, out var parentNode) ? parentNode : null;
}

Console.WriteLine(string.Join(" -> ", pathNodes.Select(i => i.Name)));
Console.WriteLine("Total Distance: {0}", distances[finalNode]);

Console.ReadLine();