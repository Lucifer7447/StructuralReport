using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StructuralReport
{
    public partial class MainForm : Form
    {
        public string TransLabelName(string name)
        {
            //name.Remove('\"');
            name.Replace("\"", "");
            return "@lbl" + name.Replace(' ', '_');

        }
        public string TransTextboxName(string name)
        {
            //name.Remove('\"');
            name.Replace("\"", "");
            return "@txtbox" + name.Replace(' ', '_');

        }
        public string TransComboboxName(string name)
        {
            //name.Remove('\"');
            name.Replace("\"", "");
            return "@combobox" + name.Replace(' ', '_');

        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.reportLists = new ReportXML();
            reportLists.Initialize();
            this.templatelistBox.Items.AddRange(reportLists.GetReportLists().ToArray());
        }

        private void templatelistBox_SelectedValueChanged(object sender, EventArgs e)
        {
            XmlNodeList reportContent;

            this.textBox1.Text = "";
            this.panel1.Controls.Clear();
            int x=10, y=10,padX=10,padY=15;
            try
            {
                reportContent = this.reportLists.GetSelectReport(templatelistBox.SelectedItem.ToString());
                foreach (XmlNode reportitemnode in reportContent)
                {
                    XmlElement reportitem = (XmlElement)reportitemnode;
                    //this.textBox1.AppendText(reportitem.Name.ToString()+ System.Environment.NewLine);

                    switch (reportitem.Name.ToString())
                    {
                        default:
                            MessageBox.Show("XML文件中有不支持的标签", "错误");
                            break;

                        case "label":
                            Label lbl = new Label();
                            string lblName = reportitem.InnerText;
                            lbl.AutoSize = true;
                            lbl.Name = TransLabelName(lblName);
                            lbl.Text = lblName;
                            lbl.Top = y;
                            this.panel1.Controls.Add(lbl);
                            y = y + lbl.Height + padY;
                            break;
                        case "input":
                            Label lblinputName = new Label();
                            TextBox inputContent = new TextBox();
                            string sInputName = reportitem.GetAttribute("name").ToString();
                            string sInputValue = reportitem.GetAttribute("value").ToString();
                            lblinputName.AutoSize = true;
                            lblinputName.Name = TransLabelName(sInputName);
                            lblinputName.Text = sInputName;
                            lblinputName.Top = y;
                            this.panel1.Controls.Add(lblinputName);
                            inputContent.Name = TransTextboxName(sInputName);
                            inputContent.Text = sInputValue;
                            //inputContent.Top = y;
                            inputContent.Top = lblinputName.Bottom -inputContent.Height;
                            inputContent.Left = x + lblinputName.Width + padX;
                            inputContent.Multiline = false;
                            
                            this.panel1.Controls.Add(inputContent);
                            y = y + lblinputName.Height + padY;
                            break;
                        case "textarea":
                            Label lbltextName = new Label();
                            TextBox textContent = new TextBox();
                            string stextName = reportitem.GetAttribute("name").ToString();
                            string stextValue =reportitem.InnerText.ToString();
                            
                            lbltextName.AutoSize = true;
                            lbltextName.Name = TransLabelName(stextName);
                            lbltextName.Text = stextName;
                            lbltextName.Top = y;
                            this.panel1.Controls.Add(lbltextName);
                            textContent.Name = TransTextboxName(stextName);
                            textContent.Text = stextValue;
                            //inputContent.Top = y;
                            textContent.Top = y;
                            textContent.Left = x + lbltextName.Width + padX;
                            textContent.Height = 4 * lbltextName.Height;
                            textContent.Width = 2 * lbltextName.Width;
                            textContent.Multiline = true;
                            textContent.ScrollBars = ScrollBars.Both;

                            this.panel1.Controls.Add(textContent);
                            y = y + textContent.Height + padY;
                            break;
                        case "select":
                            Label lblcomboName = new Label();
                            ComboBox comboContent = new ComboBox();
                            XmlNodeList OptionContent;
                            string scomboName = reportitem.GetAttribute("name").ToString();
                            
                            lblcomboName.AutoSize = true;
                            lblcomboName.Name = TransLabelName(scomboName);
                            lblcomboName.Text = scomboName;
                            lblcomboName.Top = y;
                            this.panel1.Controls.Add(lblcomboName);

                            comboContent.Name = TransComboboxName(scomboName);
                            OptionContent = reportitemnode.ChildNodes;
                            comboContent.Top = y;
                            comboContent.Left = x + lblcomboName.Width + padX;

                            foreach (XmlNode comboboxitemnode in OptionContent)
                            {
                                comboContent.Items.Add(comboboxitemnode.InnerText.ToString());
                            }

                            this.panel1.Controls.Add(comboContent);
                            y = y + padY + comboContent.Height;
                            break;

                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString(), "错误");
                throw;
            }
            

     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlNodeList reportContent;
            String sContent="";
        
            try
            {
                reportContent = this.reportLists.GetSelectReport(templatelistBox.SelectedItem.ToString());
                foreach (XmlNode reportitemnode in reportContent)
                {
                    XmlElement reportitem = (XmlElement)reportitemnode;
                    switch (reportitem.Name.ToString())
                    {
                        case "label":
                            sContent=sContent+ reportitem.InnerText+ System.Environment.NewLine;
                            break;
                        case "input":
                            string sInputName = reportitem.GetAttribute("name").ToString();
                            sContent = sContent + sInputName + "       ";
                            TextBox tb= panel1.Controls.Find(TransTextboxName(sInputName),true)[0] as TextBox;
                            sContent = sContent + tb.Text+ System.Environment.NewLine;

                            break;
                        case "textarea":
                         
                            string stextName = reportitem.GetAttribute("name").ToString();
                            sContent = sContent + stextName + System.Environment.NewLine;
                            TextBox tb2 = panel1.Controls.Find(TransTextboxName(stextName), true)[0] as TextBox;
                            //sContent=sContent+tb2.Text+ System.Environment.NewLine
                            foreach (string s1 in tb2.Lines)
                            {
                                sContent = sContent + " ".PadLeft(stextName.Length+4) + s1 + System.Environment.NewLine;
                            }
                            break;
                        case "select":

                            string scomboName = reportitem.GetAttribute("name").ToString();
                            sContent=sContent+ scomboName + "       ";
                    
                            ComboBox cb= panel1.Controls.Find(TransComboboxName(scomboName), true)[0] as ComboBox;
                            sContent=sContent+cb.Text+ System.Environment.NewLine;
                            break;
                    }
                }
                textBox1.Text = sContent;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString(), "错误");
                throw;
            }
        }
    }
}
