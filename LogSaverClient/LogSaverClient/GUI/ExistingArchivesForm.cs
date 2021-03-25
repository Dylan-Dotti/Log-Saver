using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient.GUI
{
    public partial class ExistingArchivesForm : Form
    {
        public ExistingArchivesForm(ServerInfoMessage serverInfo)
        {
            InitializeComponent();
            double availableGb = Math.Round(
                serverInfo.AvailableCapacityInBytes / Math.Pow(1024, 3), 1);
            double totalGb = Math.Round(
                serverInfo.TotalCapacityInBytes / Math.Pow(1024, 3), 1);
            availableMemLabel.Text = availableGb.ToString();
            totalMemLabel.Text = totalGb.ToString();
        }
    }
}
