
namespace GOLStartUpTemplate
{
    partial class ModalDialog
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
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.TimerUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.GridXUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.GridYUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimerUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridXUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridYUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(221, 142);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(140, 142);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // TimerUpDown3
            // 
            this.TimerUpDown3.Location = new System.Drawing.Point(151, 51);
            this.TimerUpDown3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TimerUpDown3.Name = "TimerUpDown3";
            this.TimerUpDown3.Size = new System.Drawing.Size(120, 20);
            this.TimerUpDown3.TabIndex = 4;
            this.TimerUpDown3.ValueChanged += new System.EventHandler(this.TimerUpDown3_ValueChanged);
            // 
            // GridXUpDown1
            // 
            this.GridXUpDown1.Location = new System.Drawing.Point(151, 78);
            this.GridXUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridXUpDown1.Name = "GridXUpDown1";
            this.GridXUpDown1.Size = new System.Drawing.Size(120, 20);
            this.GridXUpDown1.TabIndex = 5;
            this.GridXUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridXUpDown1.ValueChanged += new System.EventHandler(this.GridXUpDown1_ValueChanged);
            // 
            // GridYUpDown2
            // 
            this.GridYUpDown2.Location = new System.Drawing.Point(151, 105);
            this.GridYUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridYUpDown2.Name = "GridYUpDown2";
            this.GridYUpDown2.Size = new System.Drawing.Size(120, 20);
            this.GridYUpDown2.TabIndex = 6;
            this.GridYUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridYUpDown2.ValueChanged += new System.EventHandler(this.GridYUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Timer(in MiliSeconds)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grid Size X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Grid Size Y";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ModalDialog
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(308, 177);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GridYUpDown2);
            this.Controls.Add(this.GridXUpDown1);
            this.Controls.Add(this.TimerUpDown3);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModalDialog";
            ((System.ComponentModel.ISupportInitialize)(this.TimerUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridXUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridYUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.NumericUpDown TimerUpDown3;
        private System.Windows.Forms.NumericUpDown GridXUpDown1;
        private System.Windows.Forms.NumericUpDown GridYUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}