using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class SavedConnectionsSelectionDisplay : UserControl
    {
        private ConnectionInfo selectedConnection;
        public event Action<ConnectionInfo> ConnectionSelected;

        public SavedConnectionsSelectionDisplay()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            ReloadConnections();
        }

        private void connectionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItems = connectionsListView.SelectedItems;
            bool hasSelected = selectedItems.Count > 0;
            if (hasSelected)
            {
                string selectedConName = connectionsListView.SelectedItems[0].Text;
                selectedConnection = ConnectionsDAL.GetConnectionByName(selectedConName);
                ConnectionSelected?.Invoke(selectedConnection);
            }
            UpdateButtons(hasSelected);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DialogResult result = new ConnectionEditForm().ShowDialog();
            if (result == DialogResult.OK) ReloadConnections();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            DialogResult result = new ConnectionEditForm(selectedConnection).ShowDialog();
            if (result == DialogResult.OK) ReloadConnections();
            ConnectionSelected?.Invoke(selectedConnection);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (ConnectionsDAL.RemoveConnection(selectedConnection))
            {
                selectedConnection = null;
                ReloadConnections();
                ConnectionSelected?.Invoke(null);
            }
        }

        private void ReloadConnections()
        {
            IReadOnlyList<ConnectionInfo> connections = ConnectionsDAL.GetConnections();
            connectionsListView.Clear();
            if (connections.Count > 0)
            {
                foreach (ConnectionInfo conn in connections)
                {
                    connectionsListView.Items.Add(conn.ConnectionName);
                }
            }
            else
            {
                connectionsListView.Items.Add("No saved connections");
            }
            UpdateButtons(false);
            connectionsListView.Enabled = connections.Count > 0;
        }

        private void UpdateButtons(bool enabled)
        {
            editButton.Enabled = enabled;
            deleteButton.Enabled = enabled;
        }
    }
}
