using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EyeProtectedTemplate
{
    //https://blog.csdn.net/weixin_34268843/article/details/86156321
    public partial class Form1 : Form
    {
        //碰见问题：git 一直报错
        //          将分支推送到远程存储库时遇到错误: rejected Updates were rejected because the remote contains work that you do not have locally. This is usually caused by another repository pushing to the same ref. You may want to first integrate the remote changes before pushing again.
        //解决方法：https://www.cnblogs.com/jimaojin/p/7667830.html
        //          git pull origin master --allow-unrelated-histories
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern int SetLayeredWindowAttributes(IntPtr Handle, int crKey, byte bAlpha, int dwFlags);
        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;
        const int LWA_ALPHA = 2;
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.Silver;
            this.BackColor = Color.FromArgb(204,232,207);//https://www.cnblogs.com/wfy680/p/12001306.html
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(Handle, 0, 128, LWA_ALPHA);
        }
    }
}
