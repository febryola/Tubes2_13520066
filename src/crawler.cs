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
        private int totalNodes;
        private int totalEdges;
        private string file;
        private string dir;
        // graph modeled as adjacency list
        // key : vertices, value : neighbors
        private Dictionary<string, HashSet<string>> AdjacencyList = new Dictionary<string, HashSet<string>>();

        public event filefound onfilefound;
        //constructor
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

        private void scanning(string directory, string lastVertex)
        {
            string[] files = Directory.GetFiles(directory);
            string[] dirs = Directory.GetDirectories(directory);

            List<string> allfiles = new List<string>();
            allfiles.AddRange(files);
            allfiles.AddRange(dirs);

            foreach (string s in allfiles)
            {
                string _s = s;
                _s = _s.Replace(directory, "");
                _s = _s.Replace("\\", "");
                string _file = this.file.ToLower();
                this.addVertex(_s);
                this.addEdge(Tuple.Create(lastVertex,_s));
                if (Directory.Exists(s) && s != "." && s != "..")
                {
                    scanning(s,_s);
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
            scanning(this.dir,this.dir);
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
                
            }

            public BFS(string root, string file)
            {
                this.totalEdges = 0;
                this.totalNodes = 0;
                this.dir = root;
                this.file = file;
                this.AdjacencyList = new Dictionary<string, HashSet<string>>();
                this.addVertex(dir);
            }

            public void addKeyPath(string key, string path)
            {
                this.predPath[key] = path;
            }
            public Queue<string> searchQueue = new Queue<string>();
            public HashSet<string> visited = new HashSet<string>();
            public HashSet<string> visitedVertex = new HashSet<string>();
            public Dictionary<string, string> predPath = new Dictionary<string, string>();
            public Dictionary<string, string> predVertex = new Dictionary<string, string>();
            public HashSet<string> returnVertex = new HashSet<string>();
            public HashSet<HashSet<string>> returnMultipleVertex = new HashSet<HashSet<string>>();
            public void getPath(string root, string file)
            {

                while (!String.Equals(root, file))
                {
                    string _vertex = file.Replace(predPath[file], "");
                    _vertex = _vertex.Replace("\\", "");
                    returnVertex.Add(_vertex);
                    file = (predPath[file]);
                }
                returnVertex.Add(root);

            }

            public void getMultiplePath(string root, string file)
            {
                HashSet<string> path = new HashSet<string>();
                while (!String.Equals(root, file))
                {
                    string _vertex = file.Replace(predPath[file], "");
                    _vertex = _vertex.Replace("\\", "");
                    path.Add(_vertex);
                    file = (predPath[file]);
                }
                path.Add(root);
                returnMultipleVertex.Add(path);
            }

            public string singleSearchBFS(string directory, string file)
            {
                //string target masih harus dipisah dari dir root

                addKeyPath(directory, "");
                string returnPath = directory;
                string lastVertex= directory;
                this.file = file;

                //first iteration
                searchQueue.Enqueue(directory);

                while(searchQueue.Count != 0)
                {
                    string vertex = searchQueue.Dequeue();
                    string _vertex = " ";
                    if (string.Equals(vertex, directory))
                    {
                        _vertex = directory;
                    } else
                    {
                        _vertex = vertex.Replace(predPath[vertex], "");
                        _vertex = _vertex.Replace("\\", "");
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s,vertex);
                        string _s = s;
                        _s = _s.Replace(vertex, "");
                        _s = _s.Replace("\\", "");
                        predVertex.Add(_s, _vertex);
                        if (!visited.Contains(s))
                        {
                            visited.Add(s);
                            visitedVertex.Add(_s);
                            
                            this.addVertex(_s);
                            if (string.Equals(vertex, directory))
                            {
                                this.addEdge(Tuple.Create(vertex, _s));
                            }
                            else
                            {
                                this.addEdge(Tuple.Create(_vertex, _s));
                            }
                            
                            totalEdges++; totalNodes++;
                            
                            if (Directory.Exists(s) && s != "." && s != "..")
                            {
                                searchQueue.Enqueue(s);
                            }
                            if (_s.Contains(file))
                            {
                                this.getPath(directory, s);
                                return s;
                            
                            }
                        }
                        else { continue; }
                        
                    }
                    
                }

                return returnPath;
            }


            public List<string> multipleSearchBFS(string directory, string file)
            {
                //string target masih harus dipisah dari dir root

                addKeyPath(directory, "");
                List<string> returnPath = new List<string>();
                this.file = file;

                //first iteration
                searchQueue.Enqueue(directory);

                while (searchQueue.Count != 0)
                {
                    string vertex = searchQueue.Dequeue();
                    string _vertex = " ";
                    if (string.Equals(vertex, directory))
                    {
                        _vertex = directory;
                    }
                    else
                    {
                        _vertex = vertex.Replace(predPath[vertex], "");
                        _vertex = _vertex.Replace("\\", "");
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s, vertex);
                        string _s = s;
                        _s = _s.Replace(vertex, "");
                        _s = _s.Replace("\\", "");
                        predVertex.Add(_s, _vertex);
                        if (!visited.Contains(s))
                        {
                            visited.Add(s);
                            visitedVertex.Add(_s);
                            this.addVertex(_s);
                            if (string.Equals(vertex, directory))
                            {
                                this.addEdge(Tuple.Create(vertex, _s));
                            }
                            else
                            {
                                this.addEdge(Tuple.Create(_vertex, _s));
                            }

                            totalEdges++; totalNodes++;

                            if (Directory.Exists(s) && s != "." && s != "..")
                            {
                                searchQueue.Enqueue(s);
                            }
                            if (_s.Contains(file))
                            {
                                this.getMultiplePath(directory, s);
                                returnPath.Add(s);

                            }
                        }
                        else { continue; }

                    }

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
            }

            public DFS(string root, string file)
            {
                this.totalEdges = 0;
                this.totalNodes = 0;
                this.dir = root;
                this.file = file;
                this.AdjacencyList = new Dictionary<string, HashSet<string>>();
                this.addVertex(dir);
            }

            public void addKeyPath(string key, string path)
            {
                this.predPath[key] = path;
            }

            public Stack<string> searchStack = new Stack<string>();
            public HashSet<string> visited = new HashSet<string>();
            public HashSet<string> visitedVertex = new HashSet<string>();
            public Dictionary<string, string> predPath = new Dictionary<string, string>();
            public Dictionary<string, string> predVertex = new Dictionary<string, string>();
            public HashSet<string> returnVertex = new HashSet<string>();
            public HashSet<HashSet<string>> returnMultipleVertex = new HashSet<HashSet<string>>();
            public void getPath(string root ,string file)
            {

                while(!String.Equals(root, file)){
                    string _vertex = file.Replace(predPath[file], "");
                    _vertex = _vertex.Replace("\\", "");
                    returnVertex.Add(_vertex);
                    file = (predPath[file]);
                }
                returnVertex.Add(root);
                
            }

            public void getMultiplePath(string root, string file)
            {
                HashSet<string> path = new HashSet<string>();
                while (!String.Equals(root, file))
                {
                    string _vertex = file.Replace(predPath[file], "");
                    _vertex = _vertex.Replace("\\", "");
                    path.Add(_vertex);
                    file = (predPath[file]);
                }
                path.Add(root);
                returnMultipleVertex.Add(path);
            }

            public string singleSearchDFS(string directory, string file)
            {
                //string target masih harus dipisah dari dir root
                addKeyPath(directory, "");
                string returnPath = directory;
                string lastVertex = directory;
                this.file = file;
               

                //first iteration
                searchStack.Push(directory);

                while (searchStack.Count != 0)
                {
                    string vertex = searchStack.Pop();
                    string _vertex = " ";
                    if (string.Equals(vertex, directory))
                    {
                        _vertex = directory;
                    }
                    else
                    {
                        _vertex = vertex.Replace(predPath[vertex], "");
                        _vertex = _vertex.Replace("\\", "");
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    visited.Add(vertex);
                    visitedVertex.Add(_vertex);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s, vertex);
                        string _s = s;
                        _s = _s.Replace(vertex, "");
                        _s = _s.Replace("\\", "");
                        predVertex.Add(_s, _vertex);
                        if (!visited.Contains(s))
                        {
                            

                            this.addVertex(_s);
                            if (string.Equals(vertex, directory))
                            {
                                this.addEdge(Tuple.Create(vertex, _s));
                            }
                            else
                            {
                                this.addEdge(Tuple.Create(_vertex, _s));
                            }

                            totalEdges++; totalNodes++;

                            if (Directory.Exists(s) && s != "." && s != "..")
                            {
                                searchStack.Push(s);
                            } else if (!Directory.Exists(s))
                            {
                                visited.Add(s);
                                visitedVertex.Add(_s);
                            }

                            if (_s.Contains(file))
                            {
                                this.getPath(directory, s);
                                return s;

                            }
                        }
                        else { continue; }

                    }
                }
                return returnPath;
            }

            public List<string> multipleSearchDFS(string directory, string file)
            {
                //string target masih harus dipisah dari dir root
                addKeyPath(directory, "");
                List<string> returnPath = new List<string>();
                this.file = file;


                //first iteration
                searchStack.Push(directory);

                while (searchStack.Count != 0)
                {
                    string vertex = searchStack.Pop();
                    string _vertex = " ";
                    if (string.Equals(vertex, directory))
                    {
                        _vertex = directory;
                    }
                    else
                    {
                        _vertex = vertex.Replace(predPath[vertex], "");
                        _vertex = _vertex.Replace("\\", "");
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    visited.Add(vertex);
                    visitedVertex.Add(_vertex);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s, vertex);
                        string _s = s;
                        _s = _s.Replace(vertex, "");
                        _s = _s.Replace("\\", "");
                        predVertex.Add(_s, _vertex);
                        if (!visited.Contains(s))
                        {


                            this.addVertex(_s);
                            if (string.Equals(vertex, directory))
                            {
                                this.addEdge(Tuple.Create(vertex, _s));
                            }
                            else
                            {
                                this.addEdge(Tuple.Create(_vertex, _s));
                            }

                            totalEdges++; totalNodes++;

                            if (Directory.Exists(s) && s != "." && s != "..")
                            {
                                searchStack.Push(s);
                            }
                            else if (!Directory.Exists(s))
                            {
                                visited.Add(s);
                                visitedVertex.Add(_s);
                            }

                            if (_s.Contains(file))
                            {
                                this.getMultiplePath(directory, s);
                                returnPath.Add(s);

                            }
                        }
                        else { continue; }
                    }
                }
                return returnPath;
            }
        }
    }
}