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
    internal class Graph
    {
        private int totalNodes;
        private int totalEdges;
        private string file;
        private string dir;
        private Dictionary<string, HashSet<string>> AdjacencyList = new Dictionary<string, HashSet<string>>();
        private List<Tuple<string, string>> ParentAndChildren = new List<Tuple<string, string>>();
        public HashSet<string> visited = new HashSet<string>();
        public HashSet<string> visitedVertex = new HashSet<string>();
        public Dictionary<string, string> predPath = new Dictionary<string, string>();
        public Dictionary<string, string> predVertex = new Dictionary<string, string>();
        public HashSet<string> returnVertex = new HashSet<string>();
        public HashSet<HashSet<string>> returnMultipleVertex = new HashSet<HashSet<string>>();

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

        public List<Tuple<string, string>> getParentAndChildren()
        {
            return this.ParentAndChildren;
        }

        public void addVertex(string vertex)
        {
            this.AdjacencyList[vertex] = new HashSet<string>();
        }

        public void addEdge(Tuple<string, string> edge)
        {
            if (this.AdjacencyList.ContainsKey(edge.Item1) && this.AdjacencyList.ContainsKey(edge.Item2))
            {
                this.AdjacencyList[edge.Item1].Add(edge.Item2);
                this.AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
        public void getPath(string root, string file)
        {
            while (!String.Equals(root, file))
            {
                string _vertex = new DirectoryInfo(file).Name;
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
                string _vertex = new DirectoryInfo(file).Name;
                path.Add(_vertex);
                file = (predPath[file]);
            }
            path.Add(root);
            returnMultipleVertex.Add(path);
        }

        public void addKeyPath(string key, string path)
        {
            this.predPath[key] = path;
        }


        public class BFS : Graph
        {
            public Queue<string> searchQueue = new Queue<string>();

            public BFS(Graph graf)
            {
                this.AdjacencyList = graf.AdjacencyList;
                this.totalEdges = graf.totalEdges;
                this.totalNodes = graf.totalNodes;
                this.dir = graf.dir;
                this.file = graf.file;
                this.ParentAndChildren = graf.ParentAndChildren;
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

            public string singleSearchBFS(string directory, string file)
            {

                addKeyPath(directory, "");
                string returnPath = directory;
                string lastVertex = directory;
                this.file = file;
                visited.Add(directory);
                visitedVertex.Add(directory);
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
                        _vertex = new DirectoryInfo(vertex).Name;
                        visited.Add(vertex);
                        visitedVertex.Add(_vertex);
                        this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));
                        if (string.Equals(_vertex, file))
                        {
                            this.getPath(directory, vertex);
                            this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));
                            return vertex;

                        }
                    }
                    if (!Directory.Exists(vertex))
                    {
                        continue;
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s, vertex);
                        string _s = new DirectoryInfo(s).Name;

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
                            this.ParentAndChildren.Add(Tuple.Create(vertex, s));

                            totalEdges++; totalNodes++;

                            searchQueue.Enqueue(s);

                        }
                        else { continue; }

                    }

                }

                return returnPath;
            }


            public List<string> multipleSearchBFS(string directory, string file)
            {
                addKeyPath(directory, "");
                List<string> returnPath = new List<string>();
                this.file = file;
                visited.Add(directory);
                visitedVertex.Add(directory);
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
                        _vertex = new DirectoryInfo(vertex).Name;
                        visited.Add(vertex);
                        visitedVertex.Add(_vertex);
                        this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));

                        if (string.Equals(_vertex, file))
                        {
                            this.getMultiplePath(directory, vertex);
                            this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));
                            returnPath.Add(vertex);
                        }
                    }
                    if (!Directory.Exists(vertex))
                    {
                        continue;
                    }
                    string[] files = Directory.GetFiles(vertex);
                    string[] dirs = Directory.GetDirectories(vertex);
                    List<string> allfiles = new List<string>();
                    allfiles.AddRange(files);
                    allfiles.AddRange(dirs);
                    foreach (string s in allfiles)
                    {
                        predPath.Add(s, vertex);
                        string _s = new DirectoryInfo(s).Name;

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

                            this.ParentAndChildren.Add(Tuple.Create(vertex, s));

                            totalEdges++; totalNodes++;

                            searchQueue.Enqueue(s);
                        }
                        else { continue; }

                    }

                }

                return returnPath;
            }
        }

        public class DFS : Graph
        {

            public Stack<string> searchStack = new Stack<string>();

            public DFS(Graph graf)
            {
                this.AdjacencyList = graf.AdjacencyList;
                this.totalEdges = graf.totalEdges;
                this.totalNodes = graf.totalNodes;
                this.dir = graf.dir;
                this.file = graf.file;
                this.ParentAndChildren = graf.ParentAndChildren;
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


            public string singleSearchDFS(string directory, string file)
            {
                addKeyPath(directory, "");
                string returnPath = directory;
                string lastVertex = directory;
                this.file = file;
                visited.Add(directory);
                visitedVertex.Add(directory);

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
                        _vertex = new DirectoryInfo(vertex).Name;
                        visited.Add(vertex);
                        visitedVertex.Add(_vertex);
                        this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));
                        if (string.Equals(_vertex, file))
                        {
                            this.getPath(directory, vertex);
                            this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));   // ini result
                            return vertex;

                        }
                    }
                    if (!Directory.Exists(vertex))
                    {
                        continue;
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
                        string _s = new DirectoryInfo(s).Name;

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
                            this.ParentAndChildren.Add(Tuple.Create(vertex, s));

                            totalEdges++; totalNodes++;
                            
                            searchStack.Push(s);
                        }
                        else { continue; }

                    }
                }
                return returnPath;
            }

            public List<string> multipleSearchDFS(string directory, string file)
            {
                addKeyPath(directory, "");
                List<string> returnPath = new List<string>();
                this.file = file;
                visited.Add(directory);
                visitedVertex.Add(directory);

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
                        _vertex = new DirectoryInfo(vertex).Name;

                        this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));

                        if (string.Equals(_vertex, file))
                        {
                            this.getMultiplePath(directory, vertex);
                            this.ParentAndChildren.Add(Tuple.Create(predPath[vertex], vertex));   // ini result
                            returnPath.Add(vertex);
                        }
                    }
                    if (!Directory.Exists(vertex))
                    {
                        continue;
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
                        string _s = new DirectoryInfo(s).Name;

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

                            this.ParentAndChildren.Add(Tuple.Create(vertex, s));
                            
                            totalEdges++; totalNodes++;

                            searchStack.Push(s);

                        }
                        else { continue; }
                    }
                }
                return returnPath;
            }
        }
    }
}