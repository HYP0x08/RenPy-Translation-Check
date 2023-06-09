using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ren_Py
{

    class CtlZooming : Attribute //属性类，用于帮助控制窗体缩放
    {
        #region 私有成员变量
        public float X { get; set; }
        public float Y { get; set; }
        #endregion

        #region 关于控件缩放的一些函数
        public void SetXY(float width, float height) //设置x y的值
        {
            X = width;
            Y = height;
        }
        public void InitTag(Control ctls) //设置标签值
        {
            //遍历窗体中的控件
            foreach (Control ctl in ctls.Controls)
            {
                ctl.Tag = ctl.Width + ":" + ctl.Height + ":" + ctl.Left + ":" + ctl.Top + ":" + ctl.Font.Size; //标签
                if (ctl.Controls.Count > 0) //递归问题，层序分析
                    InitTag(ctl);
            }
        }
        public void Resize(float zoomX, float zoomY, Control ctls) //窗体大小改变时的回调函数的辅助函数
        {
            foreach (Control ctl in ctls.Controls)
            {
                if (null != ctl.Tag)
                {
                    string[] myTag = ctl.Tag.ToString().Split(new char[] { ':' }); //获取控件的Tag属性值
                    float carry = Convert.ToSingle(myTag[0]) * zoomX;
                    ctl.Width = (int)carry; //设置宽度
                    carry = Convert.ToSingle(myTag[1]) * zoomY;
                    ctl.Height = (int)(carry);//设置高度
                    carry = Convert.ToSingle(myTag[2]) * zoomX;
                    ctl.Left = (int)(carry); //设置左边距
                    carry = Convert.ToSingle(myTag[3]) * zoomY;
                    ctl.Top = (int)(carry); //设置上边距
                    float currentSize = Convert.ToSingle(myTag[4]) * zoomY;
                    ctl.Font = new Font(ctl.Font.Name, currentSize, ctl.Font.Style, ctl.Font.Unit); //设置字号
                    if (ctl.Controls.Count > 0)
                    {
                        Resize(zoomX, zoomY, ctl);
                    }
                }
            }
        }
        #endregion
    }
}
