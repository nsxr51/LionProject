using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace Lion.Transport
{
    public class Transport
    {
        public string PathFrom;
        public string PathTo;
        public string UserName;
        public string Password;

        public Transport(string pathForm, string pathTo, string userName, string password)
        {
            PathFrom = pathForm;
            PathTo = pathTo;
            UserName = userName;
            Password = password;
        }

        public bool StartCopy()
        {
            if(SaveACopyfileToServer(PathFrom, PathTo)==0)
                return true;
            return false;
        }

        public int SaveACopyfileToServer(string filePath, string savePath)
        {
            try
            {
                var directory = savePath;
                var username = "loginusername";
                var password = "loginpassword";
                var filenameToSave = "";
                int result = 0;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var command = "NET USE " + directory + " /delete";
                ExecuteCommand(command, 5000);

                command = "NET USE " + directory + " /user:" + username + " " + password;
                ExecuteCommand(command, 5000);

                command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";

                result = ExecuteCommand(command, 900000);


                command = "NET USE " + directory + " /delete";
                ExecuteCommand(command, 5000);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public  int ExecuteCommand(string command, int timeout)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = "C:\\",
            };

            var process = Process.Start(processInfo);
            process.WaitForExit(timeout);
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        } 
    }
}
