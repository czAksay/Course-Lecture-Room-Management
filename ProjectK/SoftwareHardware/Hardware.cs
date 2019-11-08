using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK
{
    public enum HardwareType { CPU, RAM, GPU, HDD, Soundboard, Motherboard};
    public class Hardware
    {
        public String Model { get; set; }
        public int Memory { get; set; }
        public Hardware() { }
        public HardwareType Type { get; set; }
    }
}
