using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class SavedConnectionsSelectionDisplay : UserControl
    {
        public event Action<ConnectionInfo> ConnectionSelected;

        public SavedConnectionsSelectionDisplay()
        {
            InitializeComponent();
        }

        private void connectionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
             string selectedConnection = connectionsListView.SelectedItems[0].Text;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
