namespace SandBox.MenuBuild
{
    public class MenuTrie
    {
        public bool IsEndOfPath { get; set; }
        public Dictionary<string, MenuTrie> Children { get; set; } = new();
        public void Add(string path)
        {
            MenuTrie current = this;
            foreach (var segment in path.Split('/'))
            {
                if (!current.Children.TryGetValue(segment, out var child))
                {
                    child = new MenuTrie();
                    current.Children.Add(segment, child);
                }

                current = child;
            }

            current.IsEndOfPath = true;
        }

        public bool Contains(string path)
        {
            MenuTrie current = this;
            foreach (var segment in path.Split('/'))
            {
                if (current.Children.TryGetValue(segment, out current))
                    return false;

            }

            return current.IsEndOfPath;
        }
        public void Print(int space = 0) => Print(this, space);

        public void Print(MenuTrie trie, int space = 0)
        {
            trie ??= this;
            static void PrintSingleNode(string segment, int space = 0, bool isEndOfPath = false)
            {
                if (space > 0)
                    Console.Write(new string(' ', space));

                Console.ForegroundColor = space == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine($"-> {segment}{(isEndOfPath ? "(*)" : "")}");
            }

            foreach (var entry in trie.Children)
            {
                PrintSingleNode(entry.Key, space, entry.Value.IsEndOfPath);
                Print(entry.Value, space + 3);
            }
        }
    }
}
