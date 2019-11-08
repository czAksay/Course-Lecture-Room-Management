using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Management;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

namespace ProjectK
{
    class ComputerInformation
    {
        public ComputerInformation() { }

        public String GetIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public string GetMACAddress()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMOS.Get();
            string macAddress = String.Empty;
            foreach (ManagementObject objMO in objMOC)
            {
                object tempMacAddrObj = objMO["MacAddress"];

                if (tempMacAddrObj == null) //Skip objects without a MACAddress
                {
                    continue;
                }
                if (macAddress == String.Empty) // only return MAC Address from first card that has a MAC Address
                {
                    macAddress = tempMacAddrObj.ToString();
                }
                objMO.Dispose();
            }
            //macAddress = macAddress.Replace(":", "");
            return macAddress;
        }

        public CPU GetCpu()
        {
            CPU cpu;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                foreach (PropertyData property in mObject.Properties)
                {
                    if (property.Name == "Name")
                    {
                        cpu = new CPU();
                        cpu.Model = property.Value.ToString();
                        return cpu;
                    }
                }
            }
            throw new Exception("CPU Search Error!");
        }

        public Motherboard GetMotherboard()
        {
            Motherboard mb;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                mb = new Motherboard();
                mb.Model = mObject.Properties["Manufacturer"].Value.ToString() + " " + mObject.Properties["Product"].Value.ToString();
                return mb;
            }
            throw new Exception("Motherboard Search Error!");
        }

        public List<HDD> GetHdds()
        {
            List<HDD> hdd = new List<HDD>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                if (mObject.Properties["InterfaceType"].Value.ToString() != "USB")
                {
                    HDD _hdd = new HDD();
                    _hdd.Model = mObject.Properties["Caption"].Value.ToString();
                    String size = mObject.Properties["Size"].Value.ToString();
                    long size_b = Int64.Parse(size) / (1024 * 1024 * 1024);
                    _hdd.Memory = (int)size_b;
                    hdd.Add(_hdd);
                }
            }
            return hdd;
        }

        public List<RAM> GetRams()
        {
            List<RAM> ram = new List<RAM>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                RAM _ram = new RAM();
                _ram.Model = mObject.Properties["Manufacturer"].Value.ToString() + " " + mObject.Properties["PartNumber"].Value.ToString();
                String size = mObject.Properties["Capacity"].Value.ToString();
                long size_b = Int64.Parse(size) / (1024*1024*1024);
                _ram.Memory = (int)size_b;
                ram.Add(_ram);
            }
            return ram;
        }

        public Soundboard GetSoundboard()
        {
            Soundboard sb;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                sb = new Soundboard();
                sb.Model = mObject.Properties["Caption"].Value.ToString();
                return sb;
            }
            throw new Exception("Soundboard Search Error!");
        }

        public List<GPU> GetGpus()
        {
            List<GPU> gpu = new List<GPU>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                GPU _gpu = new GPU();
                _gpu.Model = mObject.Properties["Name"].Value.ToString();
                gpu.Add(_gpu);
            }
            return gpu;
        }

        //public PowerSupply GetPowerSupply()
        //{
        //    PowerSupply ps;
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        foreach (PropertyData property in mObject.Properties)
        //        {
        //            if (property.Name == "ProductName")
        //            {
        //                ps = new PowerSupply();
        //                ps.Model = property.Value.ToString();
        //                return ps;
        //            }
        //        }
        //    }
        //    throw new Exception("Soundboard Search Error!");
        //}

        public List<String> GetSoftwareCollection()
        {
            List<string> view = new List<string>();
            String parameter = "DisplayName";

            string displayName;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(displayName);
                }
            }

            //using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
            using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(displayName);
                }
            }

            using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(displayName);
                }
            }

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(displayName);
                }
            }

            List<string> distinct = view.Distinct().ToList();
            return distinct;
        }
    }
}
