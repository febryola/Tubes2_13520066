using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Microsoft.Msagl.Drawing;

namespace src
{
    delegate void filefound(string path);
    internal class Graph
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int totalNodes; // jumlah nodes
        private int totalEdges; // jumlah edges
        private string file;
        private string dir;
        // graph modeled as adjaceny list
        // key sebagai vertices, value sebagai neighbors
        private Dictionary<string, HashSet<string>> AdjacencyList = new Dictionary<string, HashSet<string>>();

        public event filefound onfilefound;
        // Constructor
        public Graph()
        {
            this.totalEdges = 0;
            this.totalNodes = 0;
        }

        public Graph(string dir, string file)
        {
            this.file = file;
            this.dir = dir;
            this.totalEdges = 0;
            this.totalNodes = 0;
            this.AdjacencyList = new Dictionary<string, HashSet<string>>();
            this.addVertex(dir);

        }

        private void scanning(string directory)
        {
            string[] files = Directory.GetFiles( directory );
            string[] dirs = Directory.GetDirectories( directory );

            List<string> allfiles = new List<string>();
            allfiles.AddRange(files);
            allfiles.AddRange(dirs);

            foreach (string s in allfiles){
                string _s = s.ToLower();
                string _file = this.file.ToLower();
                this.addVertex(s);
                this.addEdge(Tuple.Create(directory,s));
                if (Directory.Exists(s) && s != "." && s != "..")
                {
                    scanning(s);
                    totalEdges++;
                }
                if (_s.Contains(_file))
                {
                    onfilefound(s);
                    totalNodes++;
                }
            }

        }

        public void addVertex(string vertex)
        {
            this.AdjacencyList[vertex] = new HashSet<string>();
        }

        public void addEdge(Tuple<string, string> edge)
        {
             if(this.AdjacencyList.ContainsKey(edge.Item1) && this.AdjacencyList.ContainsKey(edge.Item2))
            {
                this.AdjacencyList[edge.Item1].Add(edge.Item2);
                this.AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
        public void search()
        {
            scanning(this.dir);
        }
        //getter buat dapetin jumlah edges (garis cabang)
        public int getEdges()
        {
            return this.totalEdges;
        }

        //getter buat dapetin jumlah simpul
        public int getNodes()
        {
            return this.totalNodes;
        }

        public string File
        {
            set
            {
                this.file = value;
            }
            get
            {
                return this.file;
            }

        }

        public string Dir
        {
            set
            {
                this.dir = value;
            }
            get
            {
                return this.dir;
            }

        }

        public class BFS : Graph
        {
            public BFS(Graph graf)
            {
                this.AdjacencyList = graf.AdjacencyList;
                this.totalEdges = graf.totalEdges;
                this.totalNodes = graf.totalNodes;
                this.dir = graf.dir;
                this.file = graf.file;
                this.search();
            }

            public string singleSearchBFS(string root, string target)
            {
                //string target masih harus dipisah dari dir root
                Queue<string> searchQueue = new Queue<string>();
                HashSet<string> visited = new HashSet<string>();
                string returnPath = " ";

                //first iteration
                searchQueue.Enqueue(root);

                while(searchQueue.Count != 0)
                {
                    string vertex = searchQueue.Dequeue();
                    if (vertex == target)
                    {
                        returnPath = vertex;
                        break;
                    }
                    else if (!visited.Contains(vertex))
                    {
                        visited.Add(vertex);
                        foreach (string neighbor in this.AdjacencyList[vertex])
                            if (!visited.Contains(neighbor))
                            {
                                searchQueue.Enqueue(neighbor);
                            }
                    } else { continue; }
                }

                return returnPath;
            }
        }

        public class DFS : Graph
        {
            public DFS(Graph graf)
            {
                this.AdjacencyList = graf.AdjacencyList;
                this.totalEdges = graf.totalEdges;
                this.totalNodes = graf.totalNodes;
                this.dir = graf.dir;
                this.file = graf.file;
                this.search();
            }

            public string singleSearchDFS(string root, string target)
            {
                //string target masih harus dipisah dari dir root
                Stack<string> searchStack = new Stack<string>();
                HashSet<string> visited = new HashSet<string>();
                string returnPath = " ";

                //first iteration
                searchStack.Push(root);

                while (searchStack.Count != 0)
                {
                    string vertex = searchStack.Pop();
                    if (vertex == target)
                    {
                        returnPath = vertex;
                        break;
                    }
                    else if (!visited.Contains(vertex))
                    {
                        visited.Add(vertex);
                        foreach (string neighbor in this.AdjacencyList[vertex])
                            if (!visited.Contains(neighbor))
                            {
                                searchStack.Push(neighbor);
                            }
                    }
                    else { continue; }
                }

                return returnPath;
            }
        }
    }
}
