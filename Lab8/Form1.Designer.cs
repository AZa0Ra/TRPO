﻿namespace Lab8
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.startTextBox = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "step";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "end";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "start";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Обчислити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stepTextBox
            // 
            this.stepTextBox.Location = new System.Drawing.Point(354, 247);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(100, 20);
            this.stepTextBox.TabIndex = 15;
            this.stepTextBox.Text = "1";
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(354, 213);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(100, 20);
            this.endTextBox.TabIndex = 14;
            this.endTextBox.Text = "10";
            // 
            // startTextBox
            // 
            this.startTextBox.Location = new System.Drawing.Point(354, 180);
            this.startTextBox.Name = "startTextBox";
            this.startTextBox.Size = new System.Drawing.Size(100, 20);
            this.startTextBox.TabIndex = 13;
            this.startTextBox.Text = "1";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 213);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(240, 23);
            this.progressBar2.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 177);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.Size = new System.Drawing.Size(442, 150);
            this.resultsDataGridView.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 346);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stepTextBox);
            this.Controls.Add(this.endTextBox);
            this.Controls.Add(this.startTextBox);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.resultsDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.TextBox startTextBox;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView resultsDataGridView;
    }
}

