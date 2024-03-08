// See https://aka.ms/new-console-template for more information
using Bogus;
using SandBox.Bogus.Menu;

// Create a Faker instance for generating fake data
var faker = new Faker();

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

HashSet<string> uniquePaths = new();
paths.ForEach(x => {

    foreach (var item in x.Split('/'))
    {
        uniquePaths.Add(item);

    }
});

Console.WriteLine(String.Join(' ', uniquePaths));

// Generate a list of root-level menu items
var menuItems = new List<MenuItem>();
for (int i = 0; i < 10; i++)
{
    var menuItem = new MenuItem
    {
        Name = faker.PickRandom(uniquePaths.ToArray()),
        SubMenu = GenerateSubMenu(faker, faker.Random.Int(0, 3), uniquePaths) // Adjust the depth of nesting as needed
    };

    menuItems.Add(menuItem);
}

// Print the generated menu structure
PrintMenu(menuItems, 0);
Console.ReadLine();

static List<MenuItem> GenerateSubMenu(Faker faker, int depth, HashSet<string> uniquePaths, int maxDepth = 2)
{
    if (depth >= maxDepth)
    {
        return null;
    }

    var subMenu = new List<MenuItem>();
    for (int i = 0; i < faker.Random.Int(0, 3); i++)
    {
        var menuItem = new MenuItem
        {
            Name = faker.PickRandom(uniquePaths.ToArray()),
            SubMenu = GenerateSubMenu(faker, depth + 1, uniquePaths, maxDepth)
        };

        subMenu.Add(menuItem);
    }

    return subMenu.Count > 0 ? subMenu : null;
}

// Recursive method to print the menu structure
static void PrintMenu(List<MenuItem> menuItems, int indent)
{
    foreach (var menuItem in menuItems)
    {
        Console.WriteLine(new string(' ', indent * 2) + menuItem.Name);
        if (menuItem.SubMenu != null)
        {
            PrintMenu(menuItem.SubMenu, indent + 1);
        }
    }
}