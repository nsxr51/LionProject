using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.Configurator
{
    public class ProjectList
    {
        public List<SwVersion> SwVersions;

        public List<KeyValuePair<string, string>> Extensions
        {
            get
            {
                List<KeyValuePair<string, string>> t = new List<KeyValuePair<string, string>>();
                for(int i=0;i<Extension.Count;i++)
                {
                    t.Insert(i, new KeyValuePair<string, string>("name", Extension[i]));
                }
                return t;
            }
        }

        private List<string> Extension;
        public ProjectList(string path)
        {
            SwVersions=new List<SwVersion>();
            Extension = new List<string>();
            CollectSwVersion(path);
        }

        private void CollectSwVersion(string path)
        {
            foreach (var projdirectory in Directory.GetDirectories(path))
            {
                string projname = Path.GetFileName(projdirectory);
                foreach (var versiondirectory in Directory.GetDirectories(projdirectory))
                {
                    string version = Path.GetFileName(versiondirectory);
                    string date = (Directory.GetCreationTime(versiondirectory)).ToString();
                    SwVersions.Add(new SwVersion(projname, version, date));
                    foreach (var file in Directory.GetFiles(versiondirectory))
                    {
                        AddExtenionToList(Path.GetExtension(file));
                    }
                }
            }
        }

        private void AddExtenionToList(string ext)
        {
            if (!Extension.Contains(ext))
            {
                Extension.Add(ext);
            }
        }
    }

    public class SwVersion
    {
        public string ProjectName;
        public string ProjecVersion;
        public string ProjectDateModified;

       public SwVersion(string projectName, string projectVersion, string dateModified)
        {
            ProjectName = projectName;
            ProjecVersion = projectVersion;
            ProjectDateModified = dateModified;
        }
    }
}
