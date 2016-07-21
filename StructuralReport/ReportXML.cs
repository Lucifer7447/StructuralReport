using System;
using System.Xml;
using System.Collections;
using System.Windows.Forms;

namespace StructuralReport
{ 
        public class ReportXML
        {
            //private:
            string fileName;
            XmlDocument reportxml = new XmlDocument();//初始化一个xml实例
            ArrayList reportlists = new ArrayList();
        
            
            public ReportXML()
	        {
                fileName = "C:\\Users\\chaos\\OneDrive\\结构化报告\\SR.XML";
            }
            public ReportXML(string filename)
            {
                fileName = filename;
            }

            public Boolean Initialize()
            {
                try
                {
                    reportxml.Load(fileName);//导入指定xml文件
                    XmlNode root = reportxml.SelectSingleNode("/StructuralReports");//指定一个节点
                    XmlNodeList reportlists = root.ChildNodes;//获取节点下所有直接子节点
                                                              //XmlNodeList nodelist = xml.SelectNodes("/Root/News");//获取同名同级节点集合string id=node.Attributes["id"].Value;//获取指定节点的指定属性值
                                                              //string content = node.InnerText;//获取指定节点中的文本
                                                              //root.HasChildNodes;//判断该节点下是否有子节点

                    foreach (XmlNode report in reportlists)
                    {
                        XmlElement reportname = (XmlElement)report;
                        this.reportlists.Add(reportname.GetAttribute("name"));

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "错误");

                    throw;
                }

                return true;

            }
            
            public ArrayList GetReportLists()
            {
                return this.reportlists;
            }

        }
}