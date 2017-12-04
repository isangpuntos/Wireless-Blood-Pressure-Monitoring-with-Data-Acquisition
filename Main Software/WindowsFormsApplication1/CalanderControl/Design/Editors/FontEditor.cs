using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CalanderControl.Design.Editors
{
    public class FontEditor : UITypeEditor
    {
        private readonly ImageIndexUI lbx = new ImageIndexUI();

        private static void Draw(Graphics g, FontFamily fontFamily, Rectangle bounds)
        {
            Font font = GetFont(fontFamily, bounds.Height);
            try
            {
                g.DrawString("ab", font, SystemBrushes.ActiveCaptionText, bounds);
            }
            finally
            {
                font.Dispose();
            }
        }

        private static Font GetFont(FontFamily fontFamily, int height)
        {
            FontStyle style = FontStyle.Regular;
            if (fontFamily.IsStyleAvailable(FontStyle.Regular))
            {
                style = FontStyle.Regular;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Italic))
            {
                style = FontStyle.Italic;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Bold))
            {
                style = FontStyle.Bold;
            }
            else if (fontFamily.IsStyleAvailable(FontStyle.Italic | FontStyle.Bold))
            {
                style = FontStyle.Italic | FontStyle.Bold;
            }
            return new Font(fontFamily, (float) (height/1.3), style, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <returns>
        /// true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"/> is implemented; otherwise, false.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param>
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"/>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"/> that indicates what to paint and where to paint it. </param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            var name = e.Value as string;
            if (!string.IsNullOrEmpty(name))
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                try
                {
                    var fontFamily = new FontFamily(name);
                    Draw(e.Graphics, fontFamily, e.Bounds);
                }
                catch
                {
                }
                e.Graphics.DrawLine(SystemPens.WindowFrame, e.Bounds.Right, e.Bounds.Y, e.Bounds.Right, e.Bounds.Bottom);
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                var edSvc = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                if (edSvc == null)
                {
                    return value;
                }
                lbx.Items.Clear();
                TypeConverter.StandardValuesCollection values =
                    context.PropertyDescriptor.Converter.GetStandardValues(context);
                foreach (object v in values)
                {
                    lbx.Items.Add(v);
                    if (v.Equals(value))
                        lbx.SelectedItem = v;
                }
                lbx.SelectedIndexChanged += delegate { edSvc.CloseDropDown(); };
                edSvc.DropDownControl(lbx);
                value = lbx.SelectedItem;
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        #region Nested type: ImageIndexUI

        private class ImageIndexUI : ListBox
        {
            public ImageIndexUI()
            {
                ItemHeight = 20;
                Height = 20*10;
                DrawMode = DrawMode.OwnerDrawFixed;
                Dock = DockStyle.Fill;
                BorderStyle = BorderStyle.None;
            }

            protected override void OnDrawItem(DrawItemEventArgs die)
            {
                base.OnDrawItem(die);
                if (die.Index != -1)
                {
                    string s = Items[die.Index].ToString();
                    Brush brush = new SolidBrush(die.ForeColor);
                    die.DrawBackground();
                    die.Graphics.FillRectangle(SystemBrushes.ActiveCaption,
                                               new Rectangle(die.Bounds.X + 1, die.Bounds.Y + 1, 34, 18));
                    try
                    {
                        var fontFamily = new FontFamily(s);
                        Font font = GetFont(fontFamily, die.Bounds.Height);
                        try
                        {
                            die.Graphics.DrawString("ab", font, SystemBrushes.ActiveCaptionText, die.Bounds.X,
                                                    die.Bounds.Y);
                        }
                        finally
                        {
                            font.Dispose();
                        }
                    }
                    catch
                    {
                    }
                    die.Graphics.DrawString(s, die.Font, brush, die.Bounds.X + 36,
                                            die.Bounds.Y + ((die.Bounds.Height - die.Font.Height)/2));

                    brush.Dispose();
                }
            }

            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (((keyData & Keys.KeyCode) == Keys.Return) && ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
                {
                    OnClick(EventArgs.Empty);
                    return true;
                }
                return base.ProcessDialogKey(keyData);
            }
        }

        #endregion
    }
}