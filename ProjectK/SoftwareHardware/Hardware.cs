using System;

namespace ProjectK
{
    public enum HardwareType { CPU, RAM, GPU, HDD, Soundcard, Motherboard};
    public class Hardware
    {
        public String Model { get; set; }
        public int Memory { get; set; }
        public Hardware() { }
        public HardwareType Type { get; set; }
    }
}
