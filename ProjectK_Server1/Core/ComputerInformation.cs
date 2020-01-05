using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Management;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using ProjectK.SoftwareHardware;

namespace ProjectK_Server1
{
    public class ComputerInformation
    {
        String fileText = "";
        static String cpuzFolder = "hardwarescan\\";
        static String cpuzName = "cpuz32.exe";
        static String outFileName = "report";
        static String outFileExt = ".txt";
        static String CpuzPath { get { return cpuzFolder + cpuzName; } }
        static String OutFilePath { get { return cpuzFolder + outFileName + outFileExt; } }
        public ComputerInformation() { }

        public String GetOs()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }

        public String GetName()
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

        private String GetSerialHash(String deviceId)
        {
            String serialHash;
            if (String.IsNullOrEmpty(deviceId))
            {
                deviceId = "nullValue";
            }
            serialHash = DataManager.getHashSha256(GetName()+deviceId);
            return serialHash;
        }

        private bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public void ScanFromCpuZ()
        {
            //удаляем файл если он есть
            if (File.Exists(OutFilePath))
                File.Delete(OutFilePath);
            //проверяем наличие программы - если нет делаем исключение
            if (!File.Exists(CpuzPath))
                throw new Exception("Cannot start hardware scan! No detecting tool!");
            //запускаем в сайлент режиме
            Process.Start(CpuzPath, $"-txt={outFileName}");

            int i = 0;
            //ждем пока файл не создастся
            while (!File.Exists(OutFilePath) || IsFileLocked(new FileInfo(OutFilePath)))
            {
                Thread.Sleep(100);
                i++;
                if (i >= 200)
                    throw new Exception("Hardware scan timeout error!");
            }

            //считываем файл - удаляем файл - закрываем поток
            StreamReader sr = new StreamReader(OutFilePath);
            String temp = sr.ReadToEnd().Replace("\n\t", "");
            temp = temp.Replace("\r\n", "\n");
            temp = temp.Replace("\r", "\n");
            temp = temp.Replace('\t', ' ');
            fileText = temp;
            sr.Close();
            File.Delete(OutFilePath);
        }

        public Hardware GetCpu()
        {
            Hardware cpu = new Hardware();
            if (string.IsNullOrEmpty(fileText))
            {
                throw new Exception("Unable to find CPU model");
            }
            Regex regex = new Regex(@"Processors Information.*?Specification(.*?)\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //Match match = regex.Match(text);
            if (regex.Matches(fileText).Count == 0)
                throw new Exception("Unable to find CPU model");
            cpu.Model = DataManager.RemoveSpaces(regex.Match(fileText).Groups[1].Value);
            cpu.Type = HardwareType.CPU;
            return cpu;
        }

        public Hardware GetMotherboard()
        {
            Hardware mb = new Hardware();
            if (string.IsNullOrEmpty(fileText))
                throw new Exception("Unable to find Motherboard model");
            Regex regex = new Regex(@"Baseboard.*?vendor(.*?)\nmodel(.*?)\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            if (regex.Matches(fileText).Count == 0)
                throw new Exception("Unable to find CPU model");
            mb.Model = DataManager.RemoveSpaces(regex.Match(fileText).Groups[1].Value) + " " + DataManager.RemoveSpaces(regex.Match(fileText).Groups[2].Value);
            mb.Type = HardwareType.Motherboard;
            return mb;
        }

        public List<Hardware> GetHdds()
        {
            List<Hardware> hdd = new List<Hardware>();
            if (string.IsNullOrEmpty(fileText))
                throw new Exception("Unable to find HDD model");
            Regex regex = new Regex(@"Drive [0,100].*?Name(.*?)\n.*?Capacity (.*?)[G.\n]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            foreach(Match match in regex.Matches(fileText))
            {
                Hardware _hdd = new Hardware();
                _hdd.Type = HardwareType.HDD;
                _hdd.Model = DataManager.RemoveSpaces(match.Groups[1].Value);
                _hdd.Memory = Int32.Parse(DataManager.RemoveSpaces(match.Groups[2].Value));
                hdd.Add(_hdd);
            }
            return hdd;
        }

        public List<Hardware> GetRams()
        {
            List<Hardware> ram = new List<Hardware>();
            if (string.IsNullOrEmpty(fileText))
                throw new Exception("Unable to find RAM model");
            Regex regex = new Regex(@"DIMM #.*?manufacturer\(id\)(.*?)[\n(].*?Size(.*?)[M\n].*?Part number(.*?)\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in regex.Matches(fileText))
            {
                Hardware _ram = new Hardware();
                _ram.Type = HardwareType.RAM;
                _ram.Model = DataManager.RemoveSpaces(match.Groups[1].Value) + " " + DataManager.RemoveSpaces(match.Groups[3].Value);
                _ram.Memory = Int32.Parse(DataManager.RemoveSpaces(match.Groups[2].Value)) / 1024;
                ram.Add(_ram);
            }
            return ram;
        }

        public List<Hardware> GetGpus()
        {
            List<Hardware> gpu = new List<Hardware>();
            if (string.IsNullOrEmpty(fileText))
                throw new Exception("Unable to find GPU model");
            Regex regex = new Regex(@"Display adapter [0,100].*?Name(.*?)\n", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in regex.Matches(fileText))
            {
                Hardware _gpu = new Hardware();
                _gpu.Type = HardwareType.GPU;
                _gpu.Model = DataManager.RemoveSpaces(match.Groups[1].Value);
                gpu.Add(_gpu);
            }
            return gpu;
        }



        //public Hardware GetCpu()
        //{
        //    Hardware cpu;
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        foreach (PropertyData property in mObject.Properties)
        //        {
        //            cpu = new Hardware();
        //            cpu.Model = mObject.Properties["Name"].Value.ToString();
        //            cpu.Type = HardwareType.CPU;
        //            return cpu;
        //        }
        //    }
        //    throw new Exception("CPU Search Error!");
        //}

        //public Hardware GetMotherboard()
        //{
        //    Hardware mb;
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    String manufact, product;
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        mb = new Hardware();
        //        manufact = mObject.Properties["Manufacturer"].Value == null ? "" : mObject.Properties["Manufacturer"].Value.ToString();
        //        product = mObject.Properties["Product"].Value == null ? "" : mObject.Properties["Product"].Value.ToString();
        //        mb.Model = manufact + " " + product;
        //        mb.Type = HardwareType.Motherboard;
        //        return mb;
        //    }
        //    throw new Exception("Motherboard Search Error!");
        //}

        //public List<Hardware> GetHdds()
        //{
        //    List<Hardware> hdd = new List<Hardware>();
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        if (mObject.Properties["InterfaceType"].Value.ToString() != "USB")
        //        {
        //            Hardware _hdd = new Hardware();
        //            _hdd.Model = mObject.Properties["Caption"].Value.ToString();
        //            _hdd.Type = HardwareType.HDD;
        //            String size = mObject.Properties["Size"].Value.ToString();
        //            long size_b = Int64.Parse(size) / (1024 * 1024 * 1024);
        //            _hdd.Memory = (int)size_b;
        //            hdd.Add(_hdd);
        //        }
        //    }
        //    return hdd;
        //}

        //public List<Hardware> GetRams()
        //{
        //    List<Hardware> ram = new List<Hardware>();
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        Hardware _ram = new Hardware();
        //        _ram.Model = mObject.Properties["Manufacturer"].Value.ToString() + " " + mObject.Properties["PartNumber"].Value.ToString();
        //        String size = mObject.Properties["Capacity"].Value.ToString();
        //        long size_b = Int64.Parse(size) / (1024*1024*1024);
        //        _ram.Type = HardwareType.RAM;
        //        _ram.Memory = (int)size_b;
        //        ram.Add(_ram);
        //    }
        //    return ram;
        //}

        //public Hardware GetSoundboard()
        //{
        //    Hardware sb;
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        sb = new Hardware();
        //        sb.Model = mObject.Properties["Caption"].Value.ToString();
        //        sb.Type = HardwareType.Soundcard;
        //        return sb;
        //    }
        //    throw new Exception("Soundboard Search Error!");
        //}

        //public List<Hardware> GetGpus()
        //{
        //    List<Hardware> gpu = new List<Hardware>();
        //    ManagementObjectSearcher mSearchObj = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
        //    ManagementObjectCollection objCollection = mSearchObj.Get();
        //    foreach (ManagementObject mObject in objCollection)
        //    {
        //        Hardware _gpu = new Hardware();
        //        _gpu.Model = mObject.Properties["Name"].Value.ToString();
        //        _gpu.Type = HardwareType.GPU;
        //        gpu.Add(_gpu);
        //    }
        //    return gpu;
        //}

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
