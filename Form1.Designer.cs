namespace xModeltoPicture
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openXmodelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.checkBoxSubmodels = new System.Windows.Forms.CheckBox();
            this.checkBoxFaces = new System.Windows.Forms.CheckBox();
            this.checkBoxStates = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(307, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Model File:";
            // 
            // openXmodelFileDialog
            // 
            this.openXmodelFileDialog.DefaultExt = "xmodel";
            this.openXmodelFileDialog.Filter = "xmodel files (*.xmodel)|*.xmodel|All files (*.*)|*.*";
            this.openXmodelFileDialog.Title = "Select xModel File";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(370, 56);
            this.listBox1.TabIndex = 6;
            // 
            // textBoxFile
            // 
            this.textBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFile.Location = new System.Drawing.Point(76, 6);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(225, 20);
            this.textBoxFile.TabIndex = 0;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Location = new System.Drawing.Point(307, 4);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select File";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // checkBoxSubmodels
            // 
            this.checkBoxSubmodels.AutoSize = true;
            this.checkBoxSubmodels.Location = new System.Drawing.Point(195, 37);
            this.checkBoxSubmodels.Name = "checkBoxSubmodels";
            this.checkBoxSubmodels.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxSubmodels.Size = new System.Drawing.Size(78, 17);
            this.checkBoxSubmodels.TabIndex = 4;
            this.checkBoxSubmodels.Text = "Submodels";
            this.checkBoxSubmodels.UseVisualStyleBackColor = true;
            // 
            // checkBoxFaces
            // 
            this.checkBoxFaces.AutoSize = true;
            this.checkBoxFaces.Location = new System.Drawing.Point(72, 37);
            this.checkBoxFaces.Name = "checkBoxFaces";
            this.checkBoxFaces.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxFaces.Size = new System.Drawing.Size(55, 17);
            this.checkBoxFaces.TabIndex = 2;
            this.checkBoxFaces.Text = "Faces";
            this.checkBoxFaces.UseVisualStyleBackColor = true;
            // 
            // checkBoxStates
            // 
            this.checkBoxStates.AutoSize = true;
            this.checkBoxStates.Location = new System.Drawing.Point(133, 37);
            this.checkBoxStates.Name = "checkBoxStates";
            this.checkBoxStates.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStates.Size = new System.Drawing.Size(56, 17);
            this.checkBoxStates.TabIndex = 3;
            this.checkBoxStates.Text = "States";
            this.checkBoxStates.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Generate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 127);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxStates);
            this.Controls.Add(this.checkBoxFaces);
            this.Controls.Add(this.checkBoxSubmodels);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(380, 150);
            this.Name = "Form1";
            this.Text = "xModel to Picture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openXmodelFileDialog;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.CheckBox checkBoxSubmodels;
        private System.Windows.Forms.CheckBox checkBoxFaces;
        private System.Windows.Forms.CheckBox checkBoxStates;
        private System.Windows.Forms.Label label2;
    }
}

