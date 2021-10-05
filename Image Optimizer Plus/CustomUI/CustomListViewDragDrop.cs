using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomUI.Controls;
using CustomUI.Forms;


namespace Image_Optimizer_Plus
{
    public class CustomListViewDragDrop : CustomListView
    {
        private SizeF stringSizeF;

        public CustomListViewDragDrop() : base()
        {
            stringText = "Drag and drop images here";
            stringFont = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            UpdateUI();
        }

        private String stringText;

        [Category("Appearance")]
        [Description("Determines the text.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public String StringText
        {
            get { return stringText; }
            set
            {
                stringText = value;
                UpdateUI();
            }
        }

        private Font stringFont;

        [Category("Appearance")]
        [Description("Determines the font.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font StringFont
        {
            get { return stringFont; }
            set
            {
                stringFont = value;
                UpdateUI();
            }
        }


        public void UpdateUI()
        {
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                stringSizeF = g.MeasureString(stringText, stringFont);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (Items.Count == 0)
            {
                g.DrawString(stringText, stringFont, new SolidBrush(CustomUI.Config.Colors.Instance.LightText), new PointF((Width / 2) - (stringSizeF.Width / 2.0f), (Height / 2) - (stringSizeF.Height / 2.0f)));
            }
        }
    }
}
