/*
            8
         /     \
        3       10
     /     \       \
    1       6      14
          /   \    /
         4     7  13

 */
// See https://aka.ms/new-console-template for more information
using Recursive.Console;

Console.WriteLine("Hello, World!");

var rootNode = new Node(8);

AddNode(rootNode, 3);
AddNode(rootNode, 10);
AddNode(rootNode, 1);
AddNode(rootNode, 6);
AddNode(rootNode, 14);
AddNode(rootNode, 4);
AddNode(rootNode, 13);
AddNode(rootNode, 7);
Traverse(rootNode);

Console.ReadLine();
//rootNode.LeftNode = new Node(3);
//rootNode.RightNode = new Node(10);

void Traverse(Node rootNode) {
    if (rootNode is null)
    {
        return;
    }
    Traverse(rootNode.LeftNode);
    Console.WriteLine($"Sayı = {rootNode.Val}");
    Traverse(rootNode.RightNode);
}
void AddNode(Node rootNode, int val)
{
    if (val < rootNode.Val)
    {
        if (rootNode.LeftNode is null)
        {
            rootNode.LeftNode = new Node(val);
            return;
        }
        else
        {
            AddNode(rootNode.LeftNode, val);
        }
    }
    else
    {
        if (rootNode.RightNode is null)
        {
            rootNode.RightNode = new Node(val);
            return;
        }
        else
        {
            AddNode(rootNode.RightNode, val);
        }
    }
}