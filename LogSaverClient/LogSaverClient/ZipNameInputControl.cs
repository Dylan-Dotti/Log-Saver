using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class ZipNameInputControl : UserControl
    {
        public event Action<string> InputTextChanged;

        public string InputText => zipNameInput.Text;

        private int lastLength = 0;
        private readonly char[] invalidChars = new char[]
        {
            '/', '\\', ':', '*', '?', '"', '<', '>', '|'
        };

        public ZipNameInputControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            zipNameInput.Clear();
        }

        private void zipNameInput_TextChanged(object sender, EventArgs e)
        {
            // filter invalid input
            string input = zipNameInput.Text;
            if (input.Length > 0)
            {
                if (string.IsNullOrWhiteSpace(input)) 
                { 
                    input = "";
                }
                else if (Math.Abs(input.Length - lastLength) > 1)
                {
                    if (invalidChars.Any(c => input.Contains(c)))
                    {
                        input = "";
                        ShowErrorTooltip();
                    }
                }
                else
                {
                    int invalidIndex = input.IndexOfAny(invalidChars);
                    if (invalidIndex != -1)
                    {
                        input = input.Remove(invalidIndex, 1);
                        zipNameInput.Text = input;
                        zipNameInput.Select(invalidIndex, 0);
                        ShowErrorTooltip();
                    }
                }
            }
            input = input.TrimStart();
            lastLength = input.Length;
            zipNameInput.Text = input;
            InputTextChanged?.Invoke(input);
        }

        private void ShowErrorTooltip()
        {
            int x = zipNameInput.Size.Width / 4;
            int y = zipNameInput.Size.Height + 5;
            errorTooltip.Show("File name can't contain these characters: \n" +
                string.Join("   ", invalidChars), zipNameInput, x, y, 4000);
        }
    }
}
