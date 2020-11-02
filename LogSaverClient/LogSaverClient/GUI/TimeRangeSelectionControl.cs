using System;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class TimeRangeSelectionControl : UserControl
    {
        public TimeRangeSelectionControl()
        {
            InitializeComponent();
        }

        public TimeRange GetTimeRange()
        {
            if (radioButton1.Checked)
            {
                DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                return new TimeRange(fiveYearsAgo, DateTime.Now);
            }
            else if (radioButton2.Checked)
            {
                DateTime to = fromNowToDate.Value.Date
                    .AddHours(fromNowToTime.Value.Hour).AddMinutes(fromNowToTime.Value.Minute);
                return new TimeRange(to, DateTime.Now);
            }
            else if (radioButton3.Checked)
            {
                DateTime from = fromDate.Value.Date
                    .AddHours(fromTime.Value.Hour).AddMinutes(fromTime.Value.Minute);
                DateTime to = toDate.Value.Date
                    .AddHours(toTime.Value.Hour).AddMinutes(toTime.Value.Minute);
                return new TimeRange(from, to);

            }
            throw new Exception("No buttons checked");
        }

        private void OnRadioSelectionChanged(object sender, EventArgs e)
        {
            allRangesLabel.Enabled = radioButton1.Checked;

            fromNowToLabel.Enabled = radioButton2.Checked;
            fromNowToDate.Enabled = radioButton2.Checked;
            fromNowToTime.Enabled = radioButton2.Checked;

            fromLabel.Enabled = radioButton3.Checked;
            fromDate.Enabled = radioButton3.Checked;
            fromTime.Enabled = radioButton3.Checked;
            toLabel.Enabled = radioButton3.Checked;
            toDate.Enabled = radioButton3.Checked;
            toTime.Enabled = radioButton3.Checked;
        }
    }
}
