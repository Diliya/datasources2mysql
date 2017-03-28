using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace datasources2mysql
{
    class DataSource
    {
        public static string path;
        //金字塔
        public static readonly string weisoft = path+"\\WeiSoft";
        public static readonly DirectoryInfo dirWeiSoft = new DirectoryInfo(@weisoft);


        internal static string ReturnSource(DirectoryInfo i)
        {
            //throw new NotImplementedException();
            //获取选择目录是否包含特定子目录，并将子目录名称转换成可识别的对应平台名称
            switch(i.ToString())
            {
                case "WeiSoft":
                    return "金字塔";
                case "大智慧":
                    return "大智慧数据";
                case "通达信":
                    return "通达信数据";
                default:
                    return null;
            }
        }
        
        internal static List<DualString> Add(string s, string p, List<DualString> listSources)
        {
            //throw new NotImplementedException();
            DualString ds = new DualString();
            ds.listShow = s;
            ds.listValue = p;
            listSources.Add(ds);
            return listSources;
        }

        internal static string ReturnContract(DirectoryInfo i)
        {
            //throw new NotImplementedException();
            //throw new NotImplementedException();
            //获取选择目录是否包含特定子目录，并将子目录名称转换成可识别的对应合约名称
            switch (i.ToString())
            {
                case "IF00":
                    return "IF00";
                case "IF01":
                    return "IF01";
                default:
                    return null;
            }
        }
    }
    public class DualString
    {
        //private string listShow;
        //private string listValue;

        //public DualString(string listShow, string listValue)
        //{
        //    // TODO: Complete member initialization
        //    this.s = listShow;
        //    this.p = listValue;
        //}
        public string listShow { get; set; }
        public string listValue { get; set; }
    }
}
