using SandBox.MenuBuild;

namespace MenuBuild // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> paths = new List<string> {
            "Pages/AllPages",
            "Pages/Documents/Documents",
            "Pages/Documents/SimpleDocument",
            "Pages/Settings/Download",
            "Pages/Settings/Settings",
            "LDPAnonymous",
            "LDPAppendPrepend",
            "LDPLayoutTemplate",
            "LDPLayoutTemplate1",
            "LDPTemplatedColumnTest",
        };

            //MenuItem menu = MenuBuilder.BuildMenu(paths);
            MenuTrie menuTrie = MenuBuilder.BuildMenuTrie(paths);

            menuTrie.Print();
        }

    }
}

