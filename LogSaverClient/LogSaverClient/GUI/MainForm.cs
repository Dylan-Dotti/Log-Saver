using System;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class MainForm : Form
    {
        private ConnectionMenu connectionMenu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // initialize connection menu
            connectionMenu = new ConnectionMenu();
            connectionMenu.Dock = DockStyle.Fill;
            connectionMenu.ConnectionMade += OnConnectionMade;
            Controls.Add(connectionMenu);
        }

        private void OnConnectionMade(LSClient client)
        {
            new ConnectedClientForm(client).ShowDialog(this);
            client.Close();
        }
    }
}
