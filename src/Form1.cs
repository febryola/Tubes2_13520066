using Microsoft.WindowsAPICodePack.Dialogs;

namespace src
{
    public partial class Form1 : Form
    {
        private Graph graf;
        //create a viewer object 
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        //create a graph object 
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

        public Form1()
        {
            InitializeComponent();
            this.graf = new Graph(null,null);
            this.graf.onfilefound += filefound;
            bgworker.DoWork += backgroundWorker1_DoWork;

        }
        
        private void filefound(string path)
        {
            
            listBox1.BeginInvoke((Action)delegate ()
            {
                listBox1.Items.Add(path);
            });
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

        private void labelOutput_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.graf.File = textBoxFilename.Text;
            this.graf.Dir = textBoxDir.Text;
            bgworker.RunWorkerAsync();
            //ubah sesuai bfs dfs (buat testing doang)
            string x = "Result of BFS";
            string y = "Result of DFS";
            if (radioButtonBFS.Checked)
            {
                textBox1.Text = x;
            }
            else
            {
                textBox1.Text = y;
            }
        }

        private void textBoxDir_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelTreeBox_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void radioButtonBFS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelOutput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            graf.search();
        }
    }
}
