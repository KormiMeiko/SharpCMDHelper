using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
//SharpCmdHelper By KormiMeiko(kormimeiko@gmail.com)
namespace SharpCmdHelper
{

    public class CmdHelper
    {
        public static string ExeCommand(string commandText)
        {
            return ExeCommand(new string[] { commandText });
        }
        public static string ExeCommand(string[] commandTexts)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string strOutput = null;
            try
            {
                p.Start();
                foreach (string item in commandTexts)
                {
                    p.StandardInput.WriteLine(item);
                }
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();
                //strOutput = Encoding.UTF8.GetString(Encoding.Default.GetBytes(strOutput));
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }
        public static bool StartApp(string appName)
        {
            return StartApp(appName, ProcessWindowStyle.Hidden);
        }
        public static bool StartApp(string appName, ProcessWindowStyle style)
        {
            return StartApp(appName, null, style);
        }
        public static bool StartApp(string appName, string arguments)
        {
            return StartApp(appName, arguments, ProcessWindowStyle.Hidden);
        }
        public static bool StartApp(string appName, string arguments, ProcessWindowStyle style)
        {
            bool blnRst = false;
            Process p = new Process();
            p.StartInfo.FileName = appName;
            p.StartInfo.WindowStyle = style;
            p.StartInfo.Arguments = arguments;
            try
            {
                p.Start();
                p.WaitForExit();
                p.Close();
                blnRst = true;
            }
            catch
            {
            }
            return blnRst;
        }

    }

}