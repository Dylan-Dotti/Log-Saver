using System;
using System.Linq;
using System.Windows.Forms;

namespace LogSaverClient
{
    public partial class FileNameInputControl : UserControl
    {
        public event Action<string> InputTextChanged;

        public override string Text 
        {
            get => fileNameInput.Text;
            set => fileNameInput.Text = value;
        }

        private int lastLength = 0;
        private readonly char[] invalidChars = new char[]
        {
            '/', '\\', ':', '*', '?', '"', '<', '>', '|'
        };

        public FileNameInputControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            fileNameInput.Clear();
        }

        private void fileNameInput_TextChanged(object sender, EventArgs e)
        {
            // filter invalid input
            string input = fileNameInput.Text;
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
                        fileNameInput.Text = input;
                        fileNameInput.Select(invalidIndex, 0);
                        ShowErrorTooltip();
                    }
                }
            }
            input = input.TrimStart();
            lastLength = input.Length;
            fileNameInput.Text = input;
            InputTextChanged?.Invoke(input);
        }

        private void ShowErrorTooltip()
        {
            int x = fileNameInput.Size.Width / 4;
            int y = fileNameInput.Size.Height + 5;
            errorTooltip.Show("File name can't contain these characters: \n" +
                string.Join("   ", invalidChars), fileNameInput, x, y, 4000);
        }
    }
}
