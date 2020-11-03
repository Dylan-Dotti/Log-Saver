using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class ConnectionEditForm : Form
    {
        public ConnectionEditForm()
        {
            InitializeComponent();
        }

        private void okTestButton_Click(object sender, EventArgs e)
        {
            var connections = ConnectionsDAL.GetConnections();
            Console.WriteLine(connections[0].ConnectionName);
        }
    }
}
