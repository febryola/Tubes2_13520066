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
    }
}
