using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using DefaultProperties;

namespace SpriteSheetEditor
{
    public enum ColorSetMode
    {
        ColorSetMode_Main,
        ColorSetMode_Vice
    };
    public partial class frmSelectReplaceColor : Form
    {
        public Color SelectedColor;
        public Form m_parentForm;
        private ColorSetMode m_colorsetmode;
        //private PJLControls.CustomColorPicker customColorPicker;
        public frmSelectReplaceColor(Color initialColor , Form _parentForm, ColorSetMode _colormode_)
        {
            InitializeComponent();
            m_parentForm = _parentForm;
            customColorPicker.Color = initialColor;
            m_colorsetmode = _colormode_;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            switch (m_colorsetmode)
            { 
                case ColorSetMode.ColorSetMode_Main:
                    ((frmMain)m_parentForm).shiftedColor = customColorPicker.Color;
                    break;
                case ColorSetMode.ColorSetMode_Vice:
                    ((frmMain)m_parentForm).shiftedColorVice = customColorPicker.Color;
                    break;
            }
            DialogResult = DialogResult.OK;
            ((frmMain)m_parentForm).setColorShifting();
            ((frmMain)m_parentForm).storeColorToImgInfo();
            Close();
        }
        private void colorPanel_ColorChanged(object sender, PJLControls.ColorChangedEventArgs e)
        {
            SetControlColor(labelWeb, customColorPicker.Color);
        }
        private void frmSelectReplaceColor_Load(object sender, EventArgs e)
        {
            SetControlColor(labelWeb,customColorPicker.Color);//底下顯示顏色
        }
        private void SetControlColor(Control ctrl, Color c)
        {
            ctrl.BackColor = c;
            string s = string.Format("{0}, {1:X}", c.Name, c.ToArgb());
            ctrl.Text = s;
            ctrl.ForeColor = (c.GetBrightness() < 0.3) ? (Color.White) : (Color.Black);

        }
    }
}
