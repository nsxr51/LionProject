using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.Configurator
{
    public class Configurator
    {
        public ProjectList ProjectsList;
        public PcList PcsList ;
        private static Configurator _instatnse;
        public static Configurator Instanse
        {
            get
            {
                if (_instatnse == null)
                {
                    _instatnse=new Configurator();
                }
                return _instatnse;
            }
        }

        private Configurator()
        {
            ProjectsList = new ProjectList("c:\\test");
            PcsList = new PcList();
        }
    }
}
