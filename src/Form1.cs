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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.graf = new Graph(null, null);
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
                resultBox.Text = x;
            }
            else
            {
                resultBox.Text = y;
            }
            if (listBox1.Items.Count == 0)
            {
                pathBox.Text = "File tidak ditemukan";
            }

            drawGraph(this.graf);

        }

        private void drawGraph(Graph graf)
        {
            //TEST nampilin graph, nanti diganti sama graph yang dari graf hasil DFS/BFS
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;


            // Bind graph to viewer engine
            viewer.Graph = graph;
            // Bind viewer engine to the panelGraph
            panelGraph.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraph.Controls.Add(viewer);
            panelGraph.ResumeLayout();
        }

        private void labelOutput_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDir_TextChanged(object sender, EventArgs e)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void labelPathFile_Click(object sender, EventArgs e)
        {

        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
