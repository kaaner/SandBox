using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.MenuBuild
{
    public class MenuItem
    {
        public string Name { get; set; }
        public HashSet<MenuItem> Childs { get; set; }
    }

    public class MenuBuilder
    {
        public static MenuTrie BuildMenuTrie(List<string> paths)
        {
            MenuTrie menuTrie = new();
            foreach (var path in paths)
            {
                menuTrie.Add(path);
            }
            return menuTrie;
        }
        public static MenuItem BuildMenu(IEnumerable<string> paths)
        {
            var root = new MenuItem { Name = "Root", Childs = new HashSet<MenuItem>() };

            foreach (var path in paths)
            {
                AddPathToMenu(root, path.Split('/'));
            }

            return root;
        }

        private static void AddPathToMenu(MenuItem parent, IEnumerable<string> pathSegments)
        {
            foreach (var segment in pathSegments)
            {
                var child = FindChildByName(parent, segment) ?? CreateAndAddChild(parent, segment);
                parent = child;
            }
        }

        private static MenuItem FindChildByName(MenuItem parent, string name)
        {
            return parent.Childs?.FirstOrDefault(c => c.Name == name);
        }

        private static MenuItem CreateAndAddChild(MenuItem parent, string name)
        {
            var child = new MenuItem { Name = name, Childs = new HashSet<MenuItem>() };
            parent.Childs ??= new HashSet<MenuItem>();
            parent.Childs.Add(child);
            return child;
        }


    }
}
