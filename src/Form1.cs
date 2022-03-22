using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;

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
            string notFound = "File tidak ditemukan";

            if (radioButtonBFS.Checked)
            {
                resultBox.Text = "Result of BFS";
                Graph.BFS bfs = new Graph.BFS(this.graf);
                if (!checkBoxAllOcc.Checked)
                {
                    string resultpath = bfs.singleSearchBFS(this.graf.Dir, this.graf.File);
                    if(resultpath != this.graf.Dir)
                    {
                        LinkLabel link = new LinkLabel();
                        link.Text = resultpath;
                        link.AutoSize = true;
                        this.richTextBox1.Controls.Add(link);
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;

                    }
                    else
                    {
                        LinkLabel s = new LinkLabel();
                        s.Text = notFound;
                        s.AutoSize = true;
                        this.richTextBox1.Controls.Add(s);
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                    }
                    
                }
                else
                {
                    List<string> resultpaths = bfs.multipleSearchBFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach (string path in resultpaths)
                    {
                        LinkLabel link = new LinkLabel();
                        link.Text = path;
                        link.AutoSize = true;
                        this.richTextBox1.Controls.Add(link);
                        this.richTextBox1.AppendText("\n");
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                    }
                }

            }
            else if (radioButtonDFS.Checked)
            {
                resultBox.Text = "Result of DFS";
                Graph.DFS dfs = new Graph.DFS(this.graf);
                if (!checkBoxAllOcc.Checked)
                {
                    string resultpath = dfs.singleSearchDFS(this.graf.Dir, this.graf.File);
                    if (resultpath != this.graf.Dir)
                    {
                        LinkLabel link = new LinkLabel();
                        link.Text = resultpath;
                        link.AutoSize = true;
                        this.richTextBox1.Controls.Add(link);
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                    }
                    else
                    {
                        LinkLabel s = new LinkLabel();
                        s.Text = notFound;
                        s.AutoSize = true;
                        this.richTextBox1.Controls.Add(s);
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                    }
                }
                else
                {
                    List<string> resultpaths = dfs.multipleSearchDFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach (string path in resultpaths)
                    {
                        LinkLabel link = new LinkLabel();
                        link.Text = path;
                        link.AutoSize = true;
                        this.richTextBox1.Controls.Add(link);
                        this.richTextBox1.AppendText("\n");
                        this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                    }
                }

            }
            drawGraph(this.graf);

        }

        private void drawGraph(Graph graf)
        {
            List<Tuple<string, string>> newAdjlist= new List<Tuple<string, string>>();
            List<Tuple<string, string>> newVisited = new List<Tuple<string, string>>();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            List<Tuple<string, string>> ParentAndChildren = graf.getParentAndChildren();
            foreach (Tuple<string, string> parentChild in ParentAndChildren)
            {
                string parent = parentChild.Item1;
                string child = parentChild.Item2;
                // membangkitkan
                if (!newAdjlist.Contains(Tuple.Create(parent, child)))
                {
                    graph.AddEdge(parent, child);
                    newAdjlist.Add(Tuple.Create(parent, child));
                }
                // memeriksa
                else if (!newVisited.Contains(Tuple.Create(parent, child)))
                {
                    Microsoft.Msagl.Drawing.Node ch = graph.FindNode(child);
                    foreach (Microsoft.Msagl.Drawing.Edge e in ch.InEdges)
                    {
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    newVisited.Add(Tuple.Create(parent, child));

                }
                // hasil
                else
                {
                    Microsoft.Msagl.Drawing.Node ch = graph.FindNode(child);
                    Microsoft.Msagl.Drawing.Node root = graph.FindNode(parent);

                    while (ch != root)
                    {
                        foreach (Microsoft.Msagl.Drawing.Edge e in ch.InEdges)
                        {
                            e.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            ch = e.SourceNode;
                        }
                    }

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

            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

    }
}
