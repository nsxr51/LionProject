using System;
using System.IO;
using Lion.Transport;
using Lion.Configurator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLionUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Transport tr = new Transport("c:\\test", "\\\\TC34079NB9\\c$\\test3","TC34033","Elbit-12");
            tr.StartCopy();
        }

        [TestMethod]
        public void TestMethod2()
        {
            Configurator cr = new Configurator();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Configurator cr = new Configurator();
            cr.PcsList.AddPc("tc34051", "user1", "password1");
            cr.PcsList.AddPc("tc34052", "user2", "password2");
            cr.PcsList.AddPc("tc34053", "user3", "password3");
            cr.PcsList.AddPc("tc34054", "user4", "password4");
            cr.PcsList.AddPc("tc34055", "user5", "password5");
            cr.PcsList.AddPc("tc34056", "user6", "password6");
            cr.PcsList.AddPc("tc34057", "user7", "password7");
            string t = cr.PcsList.GetXmlFile();
            cr.PcsList.LoadFromXmlFile(File.ReadAllText(@"C:\Users\tc34905\Desktop\pclist.xml"));
        }
    }
}
