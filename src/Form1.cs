using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;

namespace src
{
    public partial class Form1 : Form
    {
        private Graph graf;
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();

        public Form1()
        {
            InitializeComponent();
            this.graf = new Graph("", "");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.graf = new Graph("", "");
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
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
                        visitedFolderSingle(resultpath);

                    }
                    else
                    {
                        string s = notFound;
                        this.richTextBox1.AppendText(s);
                    }
                    
                }
                else
                {
                    List<string> resultpaths = bfs.multipleSearchBFS(textBoxDir.Text, textBoxFilename.Text);
                    if (resultpaths.Count == 0)
                    {
                        string s = notFound;
                        this.richTextBox1.AppendText(s);
                    }
                    else if (resultpaths.Count == 1)
                    {
                        foreach (string path in resultpaths)
                        {
                            visitedFolderSingle(path);
                        }
                    }
                    else
                    {
                        foreach (string path in resultpaths)
                        {
                            visitedFolderMultiple(path);
                        }
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
                    if(resultpath != this.graf.Dir)
                    {
                        visitedFolderSingle(resultpath);

                    }
                    else
                    {
                        string s = notFound;
                        this.richTextBox1.AppendText(s);
                    }
                    
                }
                else
                {
                    List<string> resultpaths = dfs.multipleSearchDFS(textBoxDir.Text, textBoxFilename.Text);
                    if (resultpaths.Count == 0)
                    {
                        string s = notFound;
                        this.richTextBox1.AppendText(s);
                    }
                    else if (resultpaths.Count == 1)
                    {
                        foreach (string path in resultpaths)
                        {
                            visitedFolderSingle(path);
                        }
                    }
                    else
                    {
                        foreach (string path in resultpaths)
                        {
                            visitedFolderMultiple(path);
                        }
                    }
                   
                }

            }
            DateTime dt = DateTime.Now;
            drawGraph(this.graf);
            TimeSpan ts = DateTime.Now - dt;
            string waktu = ts.TotalSeconds.ToString();
            label1.Text = waktu + " Second";

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
                    Microsoft.Msagl.Drawing.Node pr = graph.FindNode(parent);
                    if (!String.Equals(parent, this.graf.Dir))
                    {
                        pr.LabelText = new DirectoryInfo(parent).Name;
                    }
                    else
                    {
                        pr.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        pr.Label.FontColor = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    graph.FindNode(child).LabelText = new DirectoryInfo(child).Name;

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
                    ch.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    ch.Label.FontColor = Microsoft.Msagl.Drawing.Color.Red;
                    newVisited.Add(Tuple.Create(parent, child));

                }
                // hasil
                else
                {
                    Microsoft.Msagl.Drawing.Node ch = graph.FindNode(child);
                    Microsoft.Msagl.Drawing.Node pr = graph.FindNode(parent);
                    Microsoft.Msagl.Drawing.Node root = graph.FindNode(this.graf.Dir);

                    root.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                    root.Label.FontColor = Microsoft.Msagl.Drawing.Color.Blue;
                    while (ch != root)
                    {
                        foreach (Microsoft.Msagl.Drawing.Edge e in ch.InEdges)
                        {
                            e.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            ch.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                            ch.Label.FontColor = Microsoft.Msagl.Drawing.Color.Blue;
                            ch = e.SourceNode;
                        }
                    }
                }

                bindGraph(graph);
                wait(trackBarDelay.Value);
            }
        }

        private void bindGraph(Microsoft.Msagl.Drawing.Graph graph)
        {
            viewer.Graph = graph;
            panelGraph.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraph.Controls.Add(viewer);
            panelGraph.ResumeLayout();
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

        public void visitedFolderSingle(string folder)
        {
            LinkLabel link = new LinkLabel();
            link.Text = folder;
            link.AutoSize = true;
            this.richTextBox1.Controls.Add(link);
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            link.LinkClicked += Link_LinkClicked1;
        }

        public void visitedFolderMultiple(string folder)
        {
            LinkLabel link = new LinkLabel();
            link.Text = folder;
            link.AutoSize = true;
            this.richTextBox1.Controls.Add(link);
            this.richTextBox1.AppendText("\n");
            int index = richTextBox1.Text.Length;
            Point position = richTextBox1.GetPositionFromCharIndex(index);
            link.Location = position;
            this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;
            link.LinkClicked += Link_LinkClicked1;
            this.richTextBox1.ScrollToCaret();
        }

        private void Link_LinkClicked1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (radioButtonBFS.Checked)
            {
                Graph.BFS bfs = new Graph.BFS(this.graf);
                if (!checkBoxAllOcc.Checked)
                {
                    string resultpath = bfs.singleSearchBFS(this.graf.Dir, this.graf.File);
                    if (resultpath != this.graf.Dir)
                    {
                        string folder = Path.GetDirectoryName(resultpath);
                        System.Diagnostics.Process.Start("explorer.exe", folder);

                    }
                }
                else
                {
                    List<string> resultpaths = bfs.multipleSearchBFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach (string path in resultpaths)
                    {
                        string folder = Path.GetDirectoryName(path);
                        System.Diagnostics.Process.Start("explorer.exe", folder);
                    }
                   
                }
            }
            else if (radioButtonDFS.Checked)
            {
                Graph.DFS dfs = new Graph.DFS(this.graf);
                if (!checkBoxAllOcc.Checked)
                {
                    string resultpath = dfs.singleSearchDFS(this.graf.Dir, this.graf.File);
                    if (resultpath != this.graf.Dir)
                    {
                        string folder = Path.GetDirectoryName(resultpath);
                        System.Diagnostics.Process.Start("explorer.exe", folder);

                    }
                }
                else
                {
                    List<string> resultpaths = dfs.multipleSearchDFS(textBoxDir.Text, textBoxFilename.Text);
                    foreach (string path in resultpaths)
                    {
                        string folder = Path.GetDirectoryName(path);
                        System.Diagnostics.Process.Start("explorer.exe", folder);
                    }
                }
            }
        }
    }
}
