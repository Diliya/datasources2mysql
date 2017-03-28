﻿using System;
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

            SetEnable(true);

        }
        List<DualString> listSources = new List<DualString>();
        List<DualString> listContract = new List<DualString>();
        TreeNode treeDir = new TreeNode();
        private void SetEnable(bool p)
        {
            //throw new NotImplementedException();
            if (p)
            {
                dateStart.Enabled = false;
                dateStop.Enabled = false;
                btnStartEx.Enabled = false;
                label4.Visible = false;
                label5.Visible = false;
                cmbSources.Visible = false;
                cmbContract.Visible = false;
                btnOpenPath.Enabled = true;
                listSources.Clear();
                //cmbSources.Items.Clear();
                cmbSources.DataSource = null;
                cmbContract.DataSource = null;
                listContract.Clear();
                //cmbContract.Items.Clear();
            }
            else
            {
                //txtPath.ReadOnly = true;
                dateStart.Enabled = true;
                dateStop.Enabled = true;
                btnStartEx.Enabled = true;
                label4.Visible = true;
                label5.Visible = true;
                cmbSources.Visible = true;
                cmbContract.Visible = true;
                btnOpenPath.Enabled = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dlgOpenPath = new FolderBrowserDialog();

            if (dlgOpenPath.ShowDialog() == DialogResult.OK)
            {
                DataSource.path = dlgOpenPath.SelectedPath;

                //MessageBox.Show(dlgOpenPath.SelectedPath);
                bool tag = getPathInfo(dlgOpenPath.SelectedPath);
                if (tag)
                {
                    //path = dlgOpenPath.SelectedPath;
                    lbStatusRep.Text = "已获取数据源";
                    txtPath.Text = dlgOpenPath.SelectedPath;
                    cmbSources.DataSource = listSources;
                    cmbSources.DisplayMember = "listShow";
                    cmbSources.ValueMember = "listValue";
                    cmbSources.Text = cmbContract.Items[0].ToString();

                    SetEnable(false);
                }
                else
                {
                    //switch (tag)
                    //{
                    //    case 1:
                    MessageBox.Show("当前路径不包含任何数据源数据，请重新选择");
                    //        break;
                    //    case 2:
                    //        MessageBox.Show("");
                    //        break;
                    //    default:
                    //        break;
                    //}


                }
            }

        }

        private bool getPathInfo(string path)
        {
            //throw new NotImplementedException();
            try
            {
                //存储目录结构信息，用于接下来判断目录是否符合合规
                DirectoryInfo dir = new DirectoryInfo(@path);
                //FileInfo[] filesContain =  dir.GetFiles();
                DirectoryInfo[] dirsContain = dir.GetDirectories();
                foreach (var i in dirsContain)
                {
                    //int t = 0;
                    string s = DataSource.ReturnSource(i);
                    if (s != null)
                    {

                        DirectoryInfo dirContarct = new DirectoryInfo(path + "\\" + i.ToString());
                        //FileInfo[] filesContain = dir.GetFiles();
                        DirectoryInfo[] ctContain = dirContarct.GetDirectories();
                        int t = 0;
                        foreach (var i0 in ctContain)
                        {
                            
                            string s0 = DataSource.ReturnContract(i0);
                            if (s0 != null)
                            {
                                //listContract = DataSource.Add(s0, cmbSources.SelectedValue.ToString() + "\\" + s0, listContract);
                                t++;
                            }
                            
                        }

                        if (t > 0)
                        {
                            listSources = DataSource.Add(s, path + "\\" + i.ToString(), listSources);
                        }
                    }

                }
                //存储目录结构信息，用于接下来判断目录是否符合合规

                //cmbContract.DataSource = listContract;
                //cmbContract.DisplayMember = "listShow";
                //cmbContract.ValueMember = "listValue";
                //cmbContract.Text = cmbContract.Items[0].ToString();
                //判断目录结构是否合规
                if (listSources.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //foreach (var i in filesContain)
                //{
                //    if(i.ToString() == "123.txt")
                //    {
                //        return true;
                //    }
                //}
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
                //listSources.Clear();
            }
            return false;

        }

        private void btnStartEx_Click(object sender, EventArgs e)
        {
            DateTime dtStart = dateStart.Value;
            DateTime dtStop = dateStop.Value;
            if (isDataContain(dtStart, dtStop, cmbSources.SelectedValue) == false)
            {
                MessageBox.Show("当前数据源不包含指定日期范围的数据或包含不全，请检查日期或者数据源数据");
            }
            else
            {
                StartExchage();
            }
            //MessageBox.Show(cmbSources.SelectedItem.ToString());
        }

        private void StartExchage()
        {
            //throw new NotImplementedException();
            DirectoryInfo dir = new DirectoryInfo(cmbContract.SelectedValue.ToString());
            
            DirectoryInfo[] dirsYear = dir.GetDirectories();

            foreach (var i in dirsYear)
            {
                DirectoryInfo dirYear = new DirectoryInfo(cmbContract.SelectedValue.ToString()+"\\"+i.ToString());
                DirectoryInfo[] dirsMonth = dirYear.GetDirectories();
                foreach (var m in dirsMonth)
                {
                    FileInfo[] filesContain = m.GetFiles();
                    int n = 0;
                    foreach (FileInfo f in filesContain)
                    {
                        if (n == 0)
                        {
                            string file = @cmbContract.SelectedValue.ToString() + "\\" + i.ToString() + "\\" + m.ToString() + "\\" + f.ToString();
                            FileStream fs = File.OpenRead(file);
                            StreamReader sr = new StreamReader(fs, Encoding.Default);
                            string line = sr.ReadLine();
                            n++;
                        }
                        else if(n>0)
                        {
                            string file = @cmbContract.SelectedValue.ToString() + "\\" + i.ToString() + "\\" + m.ToString() + "\\" + f.ToString();
                            FileStream fs = File.OpenRead(file);
                            StreamReader sr = new StreamReader(fs, Encoding.Default);
                            string line = sr.ReadLine();
                        }

                    }
                }
            }
        }

        private bool isDataContain(DateTime dtStart, DateTime dtStop, object p)
        {
            //throw new NotImplementedException();
            //判断目录下文件所涵盖的时间段是否覆盖了要读取的时间范围，暂时未实现
            DirectoryInfo dir = new DirectoryInfo(p.ToString());
            //FileInfo[] filesContain = dir.GetFiles();
            DirectoryInfo[] dirsContain = dir.GetDirectories();
            foreach (var i in dirsContain)
            {
                //MessageBox.Show(i.ToString());
            }
            //return false;//实现了再启用
            return true;
        }

        //private void cmbSources_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (cmbSources.Visible)
        //    {
        //        try
        //        {
        //            foreach (string i in listSources)
        //                cmbSources.Items.Add(i);
        //            cmbSources.Text = cmbSources.Items[0].ToString();
        //            //btnOpenPath.Enabled = false;
        //        }
        //        catch
        //        {
        //            MessageBox.Show("所选目录不包含数据源");
        //            SetEnable(true);
        //        }
        //        finally
        //        {
        //            //listSources.Clear();
        //        }
        //    }
        //}

        private void btnRenew_Click(object sender, EventArgs e)
        {
            SetEnable(true);
        }

        private void cmbSources_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                listContract.Clear();
                cmbContract.DataSource = null;
                DirectoryInfo dir = new DirectoryInfo(cmbSources.SelectedValue.ToString());
                //FileInfo[] filesContain = dir.GetFiles();
                DirectoryInfo[] dirsContain = dir.GetDirectories();

                foreach (var i in dirsContain)
                {
                    string s = DataSource.ReturnContract(i);
                    if (s != null)
                    {
                        listContract = DataSource.Add(s, cmbSources.SelectedValue.ToString() + "\\" + s, listContract);
                    }
                }
                cmbContract.DataSource = listContract;
                cmbContract.DisplayMember = "listShow";
                cmbContract.ValueMember = "listValue";
                cmbContract.Text = cmbContract.Items[0].ToString();
                if (listContract.Count <= 0)
                {
                    MessageBox.Show("当前数据源不包含任何合约数据，请检查！");
                }
            }
            catch
            {
                //MessageBox.Show("当前数据源不包含任何合约数据，请检查！");
            }
        }





    }
}