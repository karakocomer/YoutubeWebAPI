using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace YoutubeWebAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument xDoc = new XmlDocument();
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string url =string.Format("https://www.youtube.com/feeds/videos.xml?channel_id=UCEuOwB9vSL1oPKGNdONB4ig",textBox1.Text);
            WebClient wc = new WebClient();
            //wc.Encoding = Encoding.Default;
            string XmlData = wc.DownloadString(url);
            xDoc.LoadXml(XmlData);
            XmlNodeList entries = xDoc.DocumentElement.GetElementsByTagName("entry");
            foreach (XmlNode item in entries)
            {
                string title = item.ChildNodes[3].InnerText;
                string urll = item.ChildNodes[4].Attributes["href"].InnerText;


                if (!string.IsNullOrEmpty(title) && title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = title;
                    lvi.SubItems.Add(urll);
                    listView1.Items.Add(lvi);
                }
               
            }



        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                string link = listView1.SelectedItems[0].SubItems[1].Text;
                //tıkladığımda linki acmaı için bir komut
                System.Diagnostics.Process.Start(link);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string url = string.Format("https://www.youtube.com/feeds/videos.xml?channel_id=UCEuOwB9vSL1oPKGNdONB4ig");
            WebClient wc = new WebClient();
            //wc.Encoding = Encoding.Default;
            string XmlData = wc.DownloadString(url);
            xDoc.LoadXml(XmlData);
            XmlNodeList entries = xDoc.DocumentElement.GetElementsByTagName("entry");
            foreach (XmlNode item in entries)
            {
                string title = item.ChildNodes[3].InnerText;
                string urll = item.ChildNodes[4].Attributes["href"].InnerText;


                if (!string.IsNullOrEmpty(title) && title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = title;
                    lvi.SubItems.Add(urll);
                    listView1.Items.Add(lvi);
                }

            }
        }
    }
}
