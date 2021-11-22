using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSI_X_Desktop.forms.HelpingClass
{
    public partial class DBTest : Form
    {
        public DBTest()
        {
            InitializeComponent();
        }

        public void AddLine(string txt, bool withDataTime=true, bool separate=true) 
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { _addLine(txt, withDataTime, separate); });
            else
                _addLine(txt, withDataTime, separate);
        }
        private void _addLine(string txt, bool withDataTime, bool separate)
        {
            if (withDataTime) listBox1.Items.Add("   >>>" + DateTime.Now.ToString());
            listBox1.Items.Add(txt);
            if (separate) listBox1.Items.Add(String.Empty);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
    }
}
