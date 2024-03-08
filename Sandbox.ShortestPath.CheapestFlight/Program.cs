// See https://aka.ms/new-console-template for more information
using SandBox.ShortestPath.CheapestFlight;
using System.Security.Cryptography;

int[][] flights = {
            new int[] {0,1,100},
            new int[] {1,2,100},
            new int[] {2,0,100},
            new int[] {1,3,600},
            new int[] {2,3,200}
        };


int source = 0;
int destination = 3;
int maxStops = 1;

int result = FindCheapestPrice(source, destination, maxStops, flights);

Console.WriteLine("Cheapest price from source {0} to destination {1} with at most {2} stops: {3}",
    source, destination, maxStops, result);
static int FindCheapestPrice(int src, int dst, int k, int[][] flights)
{
    int n = flights.Length;

    // Step 1: Initialize the distance array
    int[] distance = new int[n];
    Array.Fill(distance, int.MaxValue);
    distance[src] = 0;

    // Step 2: Relax edges repeatedly with a limit on stops
    for (int i = 0; i <= k; i++)
    {
        int[] temp = (int[])distance.Clone();

        foreach (var flight in flights)
        {
            int u = flight[0];
            int v = flight[1];
            int w = flight[2];

            if (distance[u] != int.MaxValue && distance[u] + w < temp[v])
            {
                temp[v] = distance[u] + w;
            }
        }

        distance = temp;
    }

    // Step 3: Check for the minimum cost to the destination
    return distance[dst] == int.MaxValue ? -1 : distance[dst];
}

static Dictionary<int, int> BellmanFordAlgorithm(Dictionary<int, Dictionary<int, int>> graph, int source, int destination, int maxStops)
{
    int vertexCount = graph.Count;
    Dictionary<int, int> distances = new Dictionary<int, int>();
    Dictionary<int, int> stops = new Dictionary<int, int>();

    // Step 1: Initialization
    foreach (var vertex in graph.Keys)
    {
        distances[vertex] = int.MaxValue;
        stops[vertex] = 0;
    }
    distances[source] = 0;

    // Step 2: Relax edges repeatedly with a limit on stops
    for (int i = 0; i < maxStops; i++)
    {
        foreach (var u in graph.Keys)
        {
            foreach (var v in graph[u].Keys)
            {
                int weight = graph[u][v];
                if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                    stops[v] = i + 1;
                }
            }
        }
    }

    // Step 3: Check for negative weight cycles
    foreach (var u in graph.Keys)
    {
        foreach (var v in graph[u].Keys)
        {
            int weight = graph[u][v];
            if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
            {
                throw new InvalidOperationException("Graph contains a negative weight cycle");
            }
        }
    }

    // Check if destination is reachable with the specified number of stops
    if (stops[destination] <= maxStops)
    {
        return distances;
    }
    else
    {
        throw new InvalidOperationException("Destination is not reachable with the specified number of stops");
    }
}