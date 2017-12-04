using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CalanderControl.Design.Attributes;

namespace CalanderControl.Design.Editors
{
    public class RangeEditor : UITypeEditor
    {
        private int defaultValue = 128;
        private int max = 255;
        private int min;

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService;
            OpacityEditorUI editor;

            if (context != null && context.Instance != null && provider != null)
            {
                editorService = (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService));
                SetMinMaxValue(context);
                if (!(value is int && (int) value >= min && (int) value <= max))
                {
                    value = defaultValue;
                }
                if (editorService != null)
                {
                    var currentValue = (int) value;
                    editor = new OpacityEditorUI(currentValue, min, max);
                    editor.Dock = DockStyle.Fill;
                    editorService.DropDownControl(editor);
                    value = editor.GetValue();
                }
            }

            return value;
        }

        private void SetMinMaxValue(ITypeDescriptorContext context)
        {
            var attribute = context.PropertyDescriptor.Attributes[typeof (MinMaxAttribute)] as MinMaxAttribute;
            if (attribute != null)
            {
                min = attribute.MinValue;
                max = attribute.MaxValue;
            }
            if (max <= min)
            {
                min = 0;
                max = 100;
                defaultValue = 0;
            }
            var defaultVal =
                context.PropertyDescriptor.Attributes[typeof (DefaultValueAttribute)] as DefaultValueAttribute;
            if (defaultVal != null && defaultVal.Value is int)
            {
                defaultValue = (int) defaultVal.Value;
            }
            else
            {
                if (defaultValue > max)
                {
                    defaultValue = max;
                }
                if (defaultValue < min)
                {
                    defaultValue = min;
                }
            }
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region Nested type: OpacityEditorUI

        [ToolboxItem(false)]
        private class OpacityEditorUI : UserControl
        {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private IContainer components = null;

            private int currentValue;
            private TrackBar trkMain;

            protected internal OpacityEditorUI(int currentValue, int min, int max)
            {
                InitializeComponent();
                this.currentValue = currentValue;
                trkMain.Minimum = min;
                trkMain.Maximum = max;
                trkMain.Value = currentValue;
                trkMain.TickFrequency = (max - min)/10;
            }

            public object GetValue()
            {
                return currentValue;
            }

            private void trkMain_ValueChanged(object sender, EventArgs e)
            {
                currentValue = trkMain.Value;
            }

            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Component Designer generated code

            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new Container();
                this.trkMain = new System.Windows.Forms.TrackBar();
                ((System.ComponentModel.ISupportInitialize) (this.trkMain)).BeginInit();
                this.SuspendLayout();
                // 
                // trkMain
                // 
                this.trkMain.AutoSize = false;
                this.trkMain.Dock = System.Windows.Forms.DockStyle.Fill;
                this.trkMain.Location = new System.Drawing.Point(0, 0);
                this.trkMain.Name = "trkMain";
                this.trkMain.RightToLeftLayout = true;
                this.trkMain.Size = new System.Drawing.Size(150, 37);
                this.trkMain.TabIndex = 0;
                this.trkMain.TickFrequency = 16;
                this.trkMain.ValueChanged += new System.EventHandler(this.trkMain_ValueChanged);
                // 
                // OpacityEditorUI
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.White;
                this.Controls.Add(this.trkMain);
                this.Name = "OpacityEditorUI";
                this.Size = new System.Drawing.Size(150, 37);
                ((System.ComponentModel.ISupportInitialize) (this.trkMain)).EndInit();
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
}