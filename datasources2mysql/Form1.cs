using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace datasources2mysql
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            txtPath.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlgOpenFile = new OpenFileDialog();
            FolderBrowserDialog dlgOpenPath = new FolderBrowserDialog();
            //string path = "";
            //dlgOpenPath.ShowDialog();
            //dlgOpenFile.ShowDialog();
            if (dlgOpenPath.ShowDialog() == DialogResult.OK)
            {
                if (getPathInfo(dlgOpenPath.SelectedPath) == true)
                {
                    //path = dlgOpenPath.SelectedPath;
                    lbStatusRep.Text = "已获取数据源";
                    txtPath.Text = dlgOpenPath.SelectedPath;
                    txtPath.ReadOnly = true;
                }
                else if (getPathInfo(dlgOpenPath.SelectedPath) == false)
                {
                    MessageBox.Show("当前路径不包含数据源数据，请重新选择");
                }
            }
            
        }

        private bool getPathInfo(string path)
        {
            //throw new NotImplementedException();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@path);
                FileInfo[] filesContain =  dir.GetFiles();

                foreach (var i in filesContain)
                {
                    if(i.ToString() == "123.txt")
                    {
                        return true;
                    }
                }
                //if (dirContain.Contains("123.txt"))
                //{
                //    return true;
                //}
            }
            catch
            {
                //MessageBox.Show("当前路径不存在");
            }
            finally
            {

            }
            return false;

        }

    }
}
