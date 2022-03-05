using Microsoft.WindowsAPICodePack.Dialogs;

namespace src
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog openFolder = new CommonOpenFileDialog();
            openFolder.IsFolderPicker = true;
            if (openFolder.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxDir.Text = openFolder.FileName;
            }
        }
    }
}