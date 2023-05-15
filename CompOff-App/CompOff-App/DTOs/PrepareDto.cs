using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.DTOs
{
    public class PrepareDto
    {
        public JobDto serviceTask { get; set; }
        public WifiDto wifi { get; set; }
    }
}
