using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDemoTest.Config
{
    public class AppConfig
    {
        public  string PlatformName { get; set; } = string.Empty;
        public  string DeviceName { get; set; } = string.Empty;
        public  string PlatformVersion { get; set; } = string.Empty;
        public  string AppPackage { get; set; } = string.Empty;
        public  string AppActivity { get; set; } = string.Empty;
        public  string AutomationName { get; set; } = string.Empty;
        public  bool NoReset { get; set; } = false;
        public  string App { get; set; } = string.Empty;
        public  string Username { get; set; } = string.Empty;
        public  string Password { get; set; } = string.Empty;
    }
}