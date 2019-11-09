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

        public String GetOs()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }

        public String GetName(String mac)
        {
            //вернуть имя компа
            return System.Environment.MachineName;
        }

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

        public Hardware GetCpu()
        {
            Hardware cpu;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                foreach (PropertyData property in mObject.Properties)
                {
                    if (property.Name == "Name")
                    {
                        cpu = new Hardware();
                        cpu.Model = property.Value.ToString();
                        cpu.Type = HardwareType.CPU;
                        return cpu;
                    }
                }
            }
            throw new Exception("CPU Search Error!");
        }

        public Hardware GetMotherboard()
        {
            Hardware mb;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                mb = new Hardware();
                mb.Model = mObject.Properties["Manufacturer"].Value.ToString() + " " + mObject.Properties["Product"].Value.ToString();
                mb.Type = HardwareType.Motherboard;
                return mb;
            }
            throw new Exception("Motherboard Search Error!");
        }

        public List<Hardware> GetHdds()
        {
            List<Hardware> hdd = new List<Hardware>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                if (mObject.Properties["InterfaceType"].Value.ToString() != "USB")
                {
                    Hardware _hdd = new Hardware();
                    _hdd.Model = mObject.Properties["Caption"].Value.ToString();
                    _hdd.Type = HardwareType.HDD;
                    String size = mObject.Properties["Size"].Value.ToString();
                    long size_b = Int64.Parse(size) / (1024 * 1024 * 1024);
                    _hdd.Memory = (int)size_b;
                    hdd.Add(_hdd);
                }
            }
            return hdd;
        }

        public List<Hardware> GetRams()
        {
            List<Hardware> ram = new List<Hardware>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                Hardware _ram = new Hardware();
                _ram.Model = mObject.Properties["Manufacturer"].Value.ToString() + " " + mObject.Properties["PartNumber"].Value.ToString();
                String size = mObject.Properties["Capacity"].Value.ToString();
                long size_b = Int64.Parse(size) / (1024*1024*1024);
                _ram.Type = HardwareType.RAM;
                _ram.Memory = (int)size_b;
                ram.Add(_ram);
            }
            return ram;
        }

        public Hardware GetSoundboard()
        {
            Hardware sb;
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                sb = new Hardware();
                sb.Model = mObject.Properties["Caption"].Value.ToString();
                sb.Type = HardwareType.Soundcard;
                return sb;
            }
            throw new Exception("Soundboard Search Error!");
        }

        public List<Hardware> GetGpus()
        {
            List<Hardware> gpu = new List<Hardware>();
            ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            ManagementObjectCollection objCollection = mSearchObj.Get();
            foreach (ManagementObject mObject in objCollection)
            {
                Hardware _gpu = new Hardware();
                _gpu.Model = mObject.Properties["Name"].Value.ToString();
                _gpu.Type = HardwareType.GPU;
                gpu.Add(_gpu);
            }
            return gpu;
        }

        public List<Software> GetSoftwareCollection()
        {
            List<Software> view = new List<Software>();
            String parameter = "DisplayName";
            String parameterLoc = "InstallLocation";

            string displayName;
            string installLocation;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    installLocation = subkey.GetValue(parameterLoc) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(new Software { Name = displayName, ExePath = !string.IsNullOrEmpty(installLocation) ? installLocation + "\\" + displayName + ".exe" : "" });
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
                    installLocation = subkey.GetValue(parameterLoc) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(new Software { Name = displayName, ExePath = !string.IsNullOrEmpty(installLocation) ? installLocation + "\\" + displayName + ".exe" : "" });
                }
            }

            using (var localMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                var key = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false);
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    installLocation = subkey.GetValue(parameterLoc) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(new Software { Name = displayName, ExePath = !string.IsNullOrEmpty(installLocation) ? installLocation + "\\" + displayName + ".exe" : "" });
                }
            }

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue(parameter) as string;
                    installLocation = subkey.GetValue(parameterLoc) as string;
                    if (string.IsNullOrEmpty(displayName))
                        continue;

                    view.Add(new Software { Name = displayName, ExePath = !string.IsNullOrEmpty(installLocation) ? installLocation + "\\" + displayName + ".exe" : "" });
                }
            }

            //List<Software> distinct = view.Distinct().ToList();
            var DistinctItems = view.GroupBy(x => x.Name).Select(y => y.First());
            List<Software> distinct = new List<Software>();
            foreach (var item in DistinctItems)
            {
                distinct.Add(item);
            }
            return distinct;
        }
    }
}
