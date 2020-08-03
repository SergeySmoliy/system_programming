using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication30
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
             listView1.View = View.Details;
            //listView2.View = View.Details;
            timer1.Interval = 1200;       
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] mas = Process.GetProcesses();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("ProcessName");
            listView1.Columns.Add("Id");
            listView1.Columns.Add("HandleCount");
            foreach (Process pr in mas)
            {
                ListViewItem lwi = new ListViewItem(pr.ProcessName);
                lwi.SubItems.Add(pr.Id.ToString());
                ProcessThreadCollection ptc = pr.Threads;
                lwi.SubItems.Add(ptc.Count.ToString());
                lwi.SubItems.Add(pr.HandleCount.ToString());
                listView1.Items.Add(lwi);
            }
        }


    


    }
}
