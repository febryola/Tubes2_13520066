using Microsoft.WindowsAPICodePack.Dialogs;

namespace src
{
    public partial class Form1 : Form
    {
        private Graph graf;
        Microsoft.Msagl.Drawing.Graph graph;
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();

        public Form1()
        {
            InitializeComponent();
            this.graf = new Graph(@"D:\", "RiotClientServices.exe");
            this.graf.onfilefound += filefound;
            // bgworker.DoWork += backgroundWorker1_DoWork;

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.graf = new Graph(null, null);
            this.graf.onfilefound += filefound;
            // bgworker.DoWork += backgroundWorker1_DoWork;
        }

        private void filefound(string path)
        {
            /*   
            listBox1.BeginInvoke((Action)delegate ()
            {
                listBox1.Items.Add(path);
            });
            */
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
            if (radioButtonBFS.Checked)
            {
                resultBox.Text = "Result of BFS";
                if (!checkBoxAllOcc.Checked)
                {
                    Graph.BFS bfs = new Graph.BFS(this.graf, ref graph, ref panelGraph, ref viewer);
                    string resultpath = bfs.singleSearchBFS(this.graf.Dir, this.graf.File);
                    listBox1.Items.Add(resultpath);
                }
                else
                {
                    Graph.BFS bfs = new Graph.BFS(this.graf, ref graph, ref panelGraph, ref viewer);
                    List<string> resultpaths = bfs.multipleSearchBFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach(string path in resultpaths)
                    {
                        listBox1.Items.Add(path);
                    }
                }

            }
            else if (radioButtonDFS.Checked)
            {
                if (!checkBoxAllOcc.Checked)
                {
                    resultBox.Text = "Result of DFS";
                    Graph.DFS dfs = new Graph.DFS(this.graf, ref graph, ref panelGraph, ref viewer);
                    string resultpath = dfs.singleSearchDFS(this.graf.Dir, this.graf.File);
                    listBox1.Items.Add(resultpath);
                }
                else
                {
                    Graph.BFS bfs = new Graph.BFS(this.graf, ref graph, ref panelGraph, ref viewer);
                    List<string> resultpaths = bfs.multipleSearchBFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach (string path in resultpaths)
                    {
                        listBox1.Items.Add(path);
                    }
                }
                
            }
            /*
            if (listBox1.Items.Count < 1)
            {
                pathBox.Text = "File tidak ditemukan";
            }
            */
            drawGraph(this.graf);

        }

        private void drawGraph(Graph graf)
        {
            List<Tuple<string, string>> newvisited = new List<Tuple<string, string>>();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            List<Tuple<string, string>> ParentAndChildren = graf.getParentAndChildren();
            foreach (Tuple<string, string> parentChild in ParentAndChildren)
            {
                string parent = parentChild.Item1;
                string child = parentChild.Item2;
                if (!newvisited.Contains(Tuple.Create(parent, child)))
                {
                    graph.AddEdge(parent, child);
                    newvisited.Add(Tuple.Create(parent, child));
                }
                else
                {
                    // graph.RemoveEdge(parent, child);
                    graph.AddEdge(parent, child).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;

                }

                bindGraph(graph);
                wait(1000);
            }
            

            //TEST nampilin graph, nanti diganti sama graph yang dari graf hasil DFS/BFS
            //create the graph content 
            /*graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            */
        }

        void bindGraph(Microsoft.Msagl.Drawing.Graph graph)
        {
            viewer.Graph = graph;
            // Bind viewer engine to the panel
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

        private void checkBoxAllOcc_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

    }
}
