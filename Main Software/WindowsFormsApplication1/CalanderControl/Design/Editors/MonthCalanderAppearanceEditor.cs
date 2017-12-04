using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Layout;

namespace CalanderControl.Design.Editors
{
    internal class MonthCalanderAppearanceEditor : UITypeEditor
    {
        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
        /// </summary>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param><param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services. </param><param name="value">The object to edit. </param>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            AppearanceEditor editor;

            if (context != null && context.Instance != null && provider != null)
            {
                object currentValue = value;
                if (value is string)
                {
                    var convet = new GenericConverter<MonthCalanderAppearance>();
                    currentValue = convet.ConvertTo(value, typeof (MonthCalanderAppearance));
                }
                editor = new AppearanceEditor((MonthCalanderAppearance) currentValue);
                editor.ShowDialog();
                value = editor.Value;
                if (context.Instance is MonthCalander)
                {
                    ((MonthCalander) context.Instance).Appearance.Assign(editor.Value);
                    ((MonthCalander) context.Instance).SetThemeDefaults();
                }
            }
            return value;
        }

        #region Nested type: AppearanceEditor

        internal class AppearanceEditor : Form
        {
            private readonly MonthCalanderAppearance appearance;

            /// <summary>
            /// Required designer variable.
            /// </summary>
            private readonly IContainer components;

            private Button btnCancel;
            private Button btnOK;
            private MonthCalander calPreview;
            private LinkLabel lblApply;
            private Label lblAvailableTheme;
            private Label lblCurrentStyle;
            private LinkLabel lblLoad;
            private Label lblPreview;
            private LinkLabel lblReset;
            private LinkLabel lblSave;
            private ListBox lbxTemplate;
            private PropertyGrid pgrdMain;
            private Panel pnlBottom;
            private Panel pnlLeft;
            private Panel pnlRight;
            private Panel pnlTop;

            public AppearanceEditor(MonthCalanderAppearance appearance)
            {
                this.appearance = (MonthCalanderAppearance) appearance.Clone();
                InitializeComponent();
                pgrdMain.SelectedObject = appearance;
                lbxTemplate.Items.AddRange(new object[]
                                               {
                                                   "VS2005",
                                                   "Classic",
                                                   "Blue",
                                                   "OliveGreen",
                                                   "Royale",
                                                   "Silver"
                                               });
                lbxTemplate.SelectedIndex = 0;
                calPreview.Appearance.Assign(appearance);
                calPreview.ThemeProperty.UseTheme = false;
            }

            public MonthCalanderAppearance Value
            {
                get
                {
                    return ((DialogResult == DialogResult.OK)
                                ? (MonthCalanderAppearance) pgrdMain.SelectedObject
                                : appearance);
                }
            }

            private void OnApplyClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                switch (lbxTemplate.SelectedItem.ToString())
                {
                    case "VS2005":
                        SetColors(ColorSchemeDefinition.VS2005);
                        break;
                    case "Classic":
                        SetColors(ColorSchemeDefinition.Classic);
                        break;
                    case "Blue":
                        SetColors(ColorSchemeDefinition.Blue);
                        break;
                    case "OliveGreen":
                        SetColors(ColorSchemeDefinition.OliveGreen);
                        break;
                    case "Royale":
                        SetColors(ColorSchemeDefinition.Royale);
                        break;
                    case "Silver":
                        SetColors(ColorSchemeDefinition.Silver);
                        break;
                }
                pgrdMain.Refresh();
            }

            private void SetColors(ColorSchemeDefinition schemeDefinition)
            {
                var appearance = (MonthCalanderAppearance) pgrdMain.SelectedObject;
                appearance.SelectedDateAppearance.Assign(new BorderAppearance());
                appearance.ActiveTextColor = schemeDefinition.CaptionTextColor;
                appearance.InactiveTextColor = schemeDefinition.InactiveTextColor;
                appearance.SelectedDateTextColor = schemeDefinition.DayMarker;
                appearance.TodayBorderColor = schemeDefinition.SelectedDateBorderColor;
                appearance.ButtonBackColor.Assign(new ColorPair(schemeDefinition.CaptionBackColor));
                appearance.SelectedBackColor.Assign(new ColorPair(schemeDefinition.SelectedBackColor));
                appearance.ArrowColor = schemeDefinition.ArrowColor;
                appearance.CaptionBackColor.Assign(new ColorPair(schemeDefinition.CaptionBackColor));
                appearance.CaptionTextColor = schemeDefinition.CaptionTextColor;
                appearance.HoverColor = schemeDefinition.HoverColor;
                appearance.ControlBorderColor = schemeDefinition.ControlBorderColor;
                appearance.TodayColor = schemeDefinition.TodayColor;
                appearance.DayMarker = schemeDefinition.DayMarker;
                appearance.ControlBackColor = schemeDefinition.ControlBackColor;
                appearance.DateDaySaperatorColor = schemeDefinition.DateDaySaperatorColor;
                appearance.Radius = 2;
                appearance.ArrowHoverColor = schemeDefinition.ArrowHoverColor;
                appearance.DisabledMask = schemeDefinition.TodayColor;
                calPreview.Appearance.Assign(appearance);
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

            private void OnSaveClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (XmlWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8))
                    {
                        var serializer = new XmlSerializer(typeof (MonthCalanderAppearance));
                        serializer.Serialize(writer, pgrdMain.SelectedObject);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }

            private void OnLoadClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof (MonthCalanderAppearance));
                        var app = (MonthCalanderAppearance) serializer.Deserialize(fs);
                        var appearance = (MonthCalanderAppearance) pgrdMain.SelectedObject;
                        appearance.Assign(app);
                    }
                }
            }

            private void OnResetClick(object sender, LinkLabelLinkClickedEventArgs e)
            {
                var appearance = (MonthCalanderAppearance) pgrdMain.SelectedObject;
                appearance.Reset();
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.pnlTop = new System.Windows.Forms.Panel();
                this.pnlRight = new System.Windows.Forms.Panel();
                this.lblCurrentStyle = new System.Windows.Forms.Label();
                this.pgrdMain = new System.Windows.Forms.PropertyGrid();
                this.pnlLeft = new System.Windows.Forms.Panel();
                this.lblReset = new System.Windows.Forms.LinkLabel();
                this.lblSave = new System.Windows.Forms.LinkLabel();
                this.lblLoad = new System.Windows.Forms.LinkLabel();
                this.lblPreview = new System.Windows.Forms.Label();
                this.calPreview = new CalanderControl.MonthCalander();
                this.lblAvailableTheme = new System.Windows.Forms.Label();
                this.lblApply = new System.Windows.Forms.LinkLabel();
                this.lbxTemplate = new System.Windows.Forms.ListBox();
                this.pnlBottom = new System.Windows.Forms.Panel();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnOK = new System.Windows.Forms.Button();
                this.pnlTop.SuspendLayout();
                this.pnlRight.SuspendLayout();
                this.pnlLeft.SuspendLayout();
                this.pnlBottom.SuspendLayout();
                this.SuspendLayout();
                // 
                // pnlTop
                // 
                this.pnlTop.Controls.Add(this.pnlRight);
                this.pnlTop.Controls.Add(this.pnlLeft);
                this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
                this.pnlTop.Location = new System.Drawing.Point(0, 0);
                this.pnlTop.Name = "pnlTop";
                this.pnlTop.Size = new System.Drawing.Size(420, 393);
                this.pnlTop.TabIndex = 0;
                // 
                // pnlRight
                // 
                this.pnlRight.Controls.Add(this.lblCurrentStyle);
                this.pnlRight.Controls.Add(this.pgrdMain);
                this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlRight.Location = new System.Drawing.Point(179, 0);
                this.pnlRight.Name = "pnlRight";
                this.pnlRight.Size = new System.Drawing.Size(241, 393);
                this.pnlRight.TabIndex = 1;
                // 
                // lblCurrentStyle
                // 
                this.lblCurrentStyle.AutoSize = true;
                this.lblCurrentStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                    ((System.Drawing.FontStyle)
                                                                     ((System.Drawing.FontStyle.Bold |
                                                                       System.Drawing.FontStyle.Underline))),
                                                                    System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                this.lblCurrentStyle.Location = new System.Drawing.Point(6, 9);
                this.lblCurrentStyle.Name = "lblCurrentStyle";
                this.lblCurrentStyle.Size = new System.Drawing.Size(80, 13);
                this.lblCurrentStyle.TabIndex = 0;
                this.lblCurrentStyle.Text = "Current Style";
                // 
                // pgrdMain
                // 
                this.pgrdMain.CommandsVisibleIfAvailable = false;
                this.pgrdMain.HelpVisible = false;
                this.pgrdMain.Location = new System.Drawing.Point(6, 26);
                this.pgrdMain.Name = "pgrdMain";
                this.pgrdMain.PropertySort = System.Windows.Forms.PropertySort.NoSort;
                this.pgrdMain.Size = new System.Drawing.Size(237, 361);
                this.pgrdMain.TabIndex = 1;
                this.pgrdMain.ToolbarVisible = false;
                // 
                // pnlLeft
                // 
                this.pnlLeft.Controls.Add(this.lblReset);
                this.pnlLeft.Controls.Add(this.lblSave);
                this.pnlLeft.Controls.Add(this.lblLoad);
                this.pnlLeft.Controls.Add(this.lblPreview);
                this.pnlLeft.Controls.Add(this.calPreview);
                this.pnlLeft.Controls.Add(this.lblAvailableTheme);
                this.pnlLeft.Controls.Add(this.lblApply);
                this.pnlLeft.Controls.Add(this.lbxTemplate);
                this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
                this.pnlLeft.Location = new System.Drawing.Point(0, 0);
                this.pnlLeft.Name = "pnlLeft";
                this.pnlLeft.Size = new System.Drawing.Size(179, 393);
                this.pnlLeft.TabIndex = 0;
                // 
                // lblReset
                // 
                this.lblReset.AutoSize = true;
                this.lblReset.Location = new System.Drawing.Point(6, 194);
                this.lblReset.Name = "lblReset";
                this.lblReset.Size = new System.Drawing.Size(35, 13);
                this.lblReset.TabIndex = 7;
                this.lblReset.TabStop = true;
                this.lblReset.Text = "&Reset";
                this.lblReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnResetClick);
                // 
                // lblSave
                // 
                this.lblSave.AutoSize = true;
                this.lblSave.Location = new System.Drawing.Point(6, 175);
                this.lblSave.Name = "lblSave";
                this.lblSave.Size = new System.Drawing.Size(68, 13);
                this.lblSave.TabIndex = 6;
                this.lblSave.TabStop = true;
                this.lblSave.Text = "&Save Theme";
                this.lblSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSaveClick);
                // 
                // lblLoad
                // 
                this.lblLoad.AutoSize = true;
                this.lblLoad.Location = new System.Drawing.Point(6, 156);
                this.lblLoad.Name = "lblLoad";
                this.lblLoad.Size = new System.Drawing.Size(67, 13);
                this.lblLoad.TabIndex = 5;
                this.lblLoad.TabStop = true;
                this.lblLoad.Text = "&Load Theme";
                this.lblLoad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLoadClick);
                // 
                // lblPreview
                // 
                this.lblPreview.AutoSize = true;
                this.lblPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                               ((System.Drawing.FontStyle)
                                                                ((System.Drawing.FontStyle.Bold |
                                                                  System.Drawing.FontStyle.Underline))),
                                                               System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                this.lblPreview.Location = new System.Drawing.Point(6, 219);
                this.lblPreview.Name = "lblPreview";
                this.lblPreview.Size = new System.Drawing.Size(52, 13);
                this.lblPreview.TabIndex = 3;
                this.lblPreview.Text = "Preview";
                // 
                // calPreview
                // 
                this.calPreview.Location = new System.Drawing.Point(7, 235);
                this.calPreview.Name = "calPreview";
                this.calPreview.Size = new System.Drawing.Size(164, 152);
                this.calPreview.TabIndex = 4;
                this.calPreview.Text = "monthCalander1";
                this.calPreview.ThemeProperty.UseTheme = false;
                // 
                // lblAvailableTheme
                // 
                this.lblAvailableTheme.AutoSize = true;
                this.lblAvailableTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                                                                      ((System.Drawing.FontStyle)
                                                                       ((System.Drawing.FontStyle.Bold |
                                                                         System.Drawing.FontStyle.Underline))),
                                                                      System.Drawing.GraphicsUnit.Point, ((byte) (0)));
                this.lblAvailableTheme.Location = new System.Drawing.Point(6, 8);
                this.lblAvailableTheme.Name = "lblAvailableTheme";
                this.lblAvailableTheme.Size = new System.Drawing.Size(103, 13);
                this.lblAvailableTheme.TabIndex = 0;
                this.lblAvailableTheme.Text = "Available themes";
                // 
                // lblApply
                // 
                this.lblApply.AutoSize = true;
                this.lblApply.Location = new System.Drawing.Point(6, 137);
                this.lblApply.Name = "lblApply";
                this.lblApply.Size = new System.Drawing.Size(117, 13);
                this.lblApply.TabIndex = 2;
                this.lblApply.TabStop = true;
                this.lblApply.Text = "&Apply to current Theme";
                this.lblApply.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnApplyClick);
                // 
                // lbxTemplate
                // 
                this.lbxTemplate.FormattingEnabled = true;
                this.lbxTemplate.Location = new System.Drawing.Point(7, 26);
                this.lbxTemplate.Name = "lbxTemplate";
                this.lbxTemplate.Size = new System.Drawing.Size(165, 108);
                this.lbxTemplate.TabIndex = 1;
                // 
                // pnlBottom
                // 
                this.pnlBottom.Controls.Add(this.btnCancel);
                this.pnlBottom.Controls.Add(this.btnOK);
                this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pnlBottom.Location = new System.Drawing.Point(0, 393);
                this.pnlBottom.Name = "pnlBottom";
                this.pnlBottom.Size = new System.Drawing.Size(420, 33);
                this.pnlBottom.TabIndex = 1;
                // 
                // btnCancel
                // 
                this.btnCancel.Anchor =
                    ((System.Windows.Forms.AnchorStyles)
                     ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnCancel.Location = new System.Drawing.Point(333, 6);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 1;
                this.btnCancel.Text = "&Cancel";
                this.btnCancel.UseVisualStyleBackColor = true;
                // 
                // btnOK
                // 
                this.btnOK.Anchor =
                    ((System.Windows.Forms.AnchorStyles)
                     ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.btnOK.Location = new System.Drawing.Point(252, 6);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(75, 23);
                this.btnOK.TabIndex = 0;
                this.btnOK.Text = "&Ok";
                this.btnOK.UseVisualStyleBackColor = true;
                // 
                // AppearanceEditor
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(420, 426);
                this.Controls.Add(this.pnlBottom);
                this.Controls.Add(this.pnlTop);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Name = "AppearanceEditor";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Appearance Editor";
                this.pnlTop.ResumeLayout(false);
                this.pnlRight.ResumeLayout(false);
                this.pnlRight.PerformLayout();
                this.pnlLeft.ResumeLayout(false);
                this.pnlLeft.PerformLayout();
                this.pnlBottom.ResumeLayout(false);
                this.ResumeLayout(false);
            }

            #endregion
        }

        #endregion
    }
}