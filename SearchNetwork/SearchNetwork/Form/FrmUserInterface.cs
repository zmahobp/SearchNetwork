using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using DMV_API;

namespace SearchNetwork
{
    public partial class FrmUserInterface : Form
    {
        //Form delegates
        public delegate void AddItem(NetworkDevice networkDevice);
        public AddItem ItemAdd;

        public delegate void EndSearch();
        public EndSearch SearchEnd;

        //Host on Form
        Host host = new Host();
        public FrmUserInterface()
        {
            InitializeComponent();
        }

        private void FrmUserInterface_Load(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            progressBar.Visible = false;
            btnClear.Enabled = false;
            lvResults
            .GetType()
            .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(lvResults, true, null);

            host.ResultReady += form_ResultReady;
            ItemAdd = new AddItem(AddResult);

            host.EndSearch += form_EndSearch;
            SearchEnd = new EndSearch(EndSearchPopup);
        }

        private void tBx2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxParameter.Text))
            {
                btnSearch.Enabled = false;
                return;
            }
            btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            progressBar.Value = 1;
            btnClear.Enabled = false;
            lblWarning.Text = "";
            lvResults.Items.Clear();
            string parameterName;
            string group="";
            if (!String.IsNullOrWhiteSpace(tbxParameter.Text))
            {
                parameterName = tbxParameter.Text;

                if (!String.IsNullOrWhiteSpace(tbxGroup.Text))
                    group = tbxGroup.Text;

                progressBar.Visible = true;
                Application.DoEvents();
                progressBar.Maximum = host.Search(parameterName, group) + 1;
            }
            else
            {
                lblWarning.ForeColor = Color.Red;
                lblWarning.Text = "Enter valid parameter name.";
            }
        }

        //methods subscribed to Device class events
        private void form_ResultReady(NetworkDevice networkDevice)
        {
            this.Invoke(this.ItemAdd, networkDevice);
            Console.WriteLine(networkDevice.ToString());
        }

        private void form_EndSearch()
        {
            this.Invoke(this.SearchEnd);
        }

        //Form delegate methods responding to Device events
        private void AddResult(NetworkDevice networkDevice)
        {
            var listItem = new ListViewItem(networkDevice.HostName);
            listItem.UseItemStyleForSubItems = false;

            listItem.SubItems.Add(networkDevice.MacAddress);
            var status = listItem.SubItems.Add(networkDevice.Status.ToString());
            var value = listItem.SubItems.Add(networkDevice.ParameterValue ?? "not available");

            switch (networkDevice.Status)
            {
                case NetworkDevice.EStatus.Connected_Found:
                    SetSubitemColor(status, value, Color.Green);
                    break;
                case NetworkDevice.EStatus.Connected_NotFound:
                    SetSubitemColor(status, value, Color.Orange);
                    break;
                case NetworkDevice.EStatus.NotConnected:
                case NetworkDevice.EStatus.Error:
                    SetSubitemColor(status, value, Color.Red);
                    break;
            }
            progressBar.Value++;
            lvResults.Items.Add(listItem);
            lvResults.EnsureVisible(lvResults.Items.Count -1 );
        }

        private void SetSubitemColor(ListViewItem.ListViewSubItem status, ListViewItem.ListViewSubItem value, Color color)
        {
            status.ForeColor = value.ForeColor = color;
        }

        private void EndSearchPopup()
        {    
            MessageBox.Show("Search finished!", "Searching", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Visible = false;
            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvResults.Items.Clear();
        }
    }
}
