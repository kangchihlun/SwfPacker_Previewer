namespace SpriteSheetEditor
{
    partial class frmSelectReplaceColor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectReplaceColor));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.customColorPicker = new PJLControls.CustomColorPicker();
            this.labelWeb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(416, 353);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 21);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // customColorPicker
            // 
            this.customColorPicker.Location = new System.Drawing.Point(0, 0);
            this.customColorPicker.Name = "customColorPicker";
            this.customColorPicker.Size = new System.Drawing.Size(497, 272);
            this.customColorPicker.TabIndex = 0;
            this.customColorPicker.ColorChanged += new PJLControls.ColorChangedEventHandler(this.colorPanel_ColorChanged);
            // 
            // labelWeb
            // 
            this.labelWeb.Location = new System.Drawing.Point(12, 275);
            this.labelWeb.Name = "labelWeb";
            this.labelWeb.Size = new System.Drawing.Size(251, 65);
            this.labelWeb.TabIndex = 7;
            this.labelWeb.Text = "labelWeb";
            this.labelWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSelectReplaceColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 388);
            this.Controls.Add(this.labelWeb);
            this.Controls.Add(this.customColorPicker);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectReplaceColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color";
            this.Load += new System.EventHandler(this.frmSelectReplaceColor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private PJLControls.CustomColorPicker customColorPicker;
        private System.Windows.Forms.Label labelWeb;
    }
}