using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Management;
using System.Management.Instrumentation;
using System.Globalization;
namespace WindowsFormsApplication31
{
    public partial class Form3 : Form
    {
        const uint Wm_SETTEXT = 0x0C;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam,
        [MarshalAs(UnmanagedType.LPStr)]string IParam);
        List<Process> Processes = new List<Process>();
        int Counter = 0;

      
        public Form3()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
        }
       

        void LoadAvailableAssemblies()
        {
            string except = new FileInfo(Application.ExecutablePath).Name;
            except = except.Substring(0, except.IndexOf("."));
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");
            foreach(var file in files)
            {
                string fileName = new FileInfo(file).Name;
                if(fileName.IndexOf(except)==-1)
                {
                    AvailableAssemblies.Items.Add(fileName);
                }
            }
        }
        void RunProcess(string AssamblyName)
        {
            
            Process proc = Process.Start(AssamblyName);
            Processes.Add(proc);
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
            {
                MessageBox.Show(proc.ProcessName + "действительно дочерний процусс текущего процесса!");
                proc.EnableRaisingEvents = true;
                proc.Exited += proc_Exited;
                SetChildWindowText(proc.MainWindowHandle, "child process #" + (++Counter));
                if (!StartedAssemblies.Items.Contains(proc.ProcessName)) 
                {
                    StartedAssemblies.Items.Add(proc.ProcessName);
                    AvailableAssemblies.Items.Remove(AvailableAssemblies.SelectedItem);
                }
                 
            } 
            
        }
        void SetChildWindowText(IntPtr Handle,string text)
        {
            SendMessage(Handle, Wm_SETTEXT, 0, text);
        }
        int GetParentProcessId(int id)
        {
            int parentid = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + id.ToString()))
            {
                obj.Get();
                parentid = Convert.ToInt32(obj["ParentProcessId"]);

            }
            return parentid;
        }
        void proc_Exited(object sender,EventArgs e)
        {
            Process proc = sender as Process;
            StartedAssemblies.Items.Remove(proc.ProcessName);
            AvailableAssemblies.Items.Add(proc.ProcessName);
            Processes.Remove(proc);
            Counter--;
            int index = 0;
            foreach(var p in Processes)
            {
                SetChildWindowText(p.MainWindowHandle, "child process #" + index);
            }
        }
        delegate void ProcessDelegate(Process proc);
        void ExecuteOnProcessesByName(string ProcessName,ProcessDelegate func)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach(var process in processes)
            {
                if(Process.GetCurrentProcess().Id==GetParentProcessId(process.Id))
                {
                    func(process);
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            RunProcess(AvailableAssemblies.SelectedItem.ToString());
        }
        void Kill(Process proc)
        {
            proc.Kill();
        }

        private void Stop_buton_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), Kill);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }
        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), CloseMainWindow);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }
        void Refresh(Process proc)
        {
            proc.Refresh();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(),Refresh);

        }

        private void AvailableAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AvailableAssemblies.SelectedItems.Count==0)
            {
                Start.Enabled = false;
            }
            else
            {
                Start.Enabled = true;
            }
        }

   
        private void MainWindow_formClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var proc in Processes)
            {
                proc.Kill();
            }
        }

        private void Runcalc_Click(object sender, EventArgs e)
        {
            RunProcess("calc.exe");
        }
    }
}
