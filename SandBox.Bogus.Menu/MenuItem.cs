using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Bogus.Menu
{
    public class MenuItem
    {
        public string Name { get; set; }
        public List<MenuItem> SubMenu { get; set; }
    }

}
