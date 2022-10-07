namespace _2DBinPacking
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BoxCountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PaddingTextBox = new System.Windows.Forms.TextBox();
            this.MarginTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlacingRectsButton = new System.Windows.Forms.Button();
            this.GeneratingRectsButton = new System.Windows.Forms.Button();
            this.SpaceCoverageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1051, 579);
            this.splitContainer1.SplitterDistance = 638;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Panel1Collapsed = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(408, 579);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(408, 465);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SpaceCoverageLabel);
            this.panel1.Controls.Add(this.BoxCountTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PaddingTextBox);
            this.panel1.Controls.Add(this.MarginTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PlacingRectsButton);
            this.panel1.Controls.Add(this.GeneratingRectsButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 114);
            this.panel1.TabIndex = 2;
            // 
            // BoxCountTextBox
            // 
            this.BoxCountTextBox.Location = new System.Drawing.Point(51, 44);
            this.BoxCountTextBox.Name = "BoxCountTextBox";
            this.BoxCountTextBox.Size = new System.Drawing.Size(72, 22);
            this.BoxCountTextBox.TabIndex = 7;
            this.BoxCountTextBox.Text = "40";
            this.BoxCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Count";
            // 
            // PaddingTextBox
            // 
            this.PaddingTextBox.Location = new System.Drawing.Point(311, 44);
            this.PaddingTextBox.Name = "PaddingTextBox";
            this.PaddingTextBox.Size = new System.Drawing.Size(72, 22);
            this.PaddingTextBox.TabIndex = 5;
            this.PaddingTextBox.Text = "0";
            this.PaddingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MarginTextBox
            // 
            this.MarginTextBox.Location = new System.Drawing.Point(311, 12);
            this.MarginTextBox.Name = "MarginTextBox";
            this.MarginTextBox.Size = new System.Drawing.Size(72, 22);
            this.MarginTextBox.TabIndex = 4;
            this.MarginTextBox.Text = "0";
            this.MarginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Padding";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Margin";
            // 
            // PlacingRectsButton
            // 
            this.PlacingRectsButton.Location = new System.Drawing.Point(248, 77);
            this.PlacingRectsButton.Name = "PlacingRectsButton";
            this.PlacingRectsButton.Size = new System.Drawing.Size(140, 31);
            this.PlacingRectsButton.TabIndex = 1;
            this.PlacingRectsButton.Text = "Place rects";
            this.PlacingRectsButton.UseVisualStyleBackColor = true;
            this.PlacingRectsButton.Click += new System.EventHandler(this.PlacingRectsButton_Click);
            // 
            // GeneratingRectsButton
            // 
            this.GeneratingRectsButton.Location = new System.Drawing.Point(3, 77);
            this.GeneratingRectsButton.Name = "GeneratingRectsButton";
            this.GeneratingRectsButton.Size = new System.Drawing.Size(140, 31);
            this.GeneratingRectsButton.TabIndex = 0;
            this.GeneratingRectsButton.Text = "Generate rects";
            this.GeneratingRectsButton.UseVisualStyleBackColor = true;
            this.GeneratingRectsButton.Click += new System.EventHandler(this.GeneratingRectsButton_Click);
            // 
            // SpaceCoverageLabel
            // 
            this.SpaceCoverageLabel.AutoSize = true;
            this.SpaceCoverageLabel.Location = new System.Drawing.Point(173, 85);
            this.SpaceCoverageLabel.Name = "SpaceCoverageLabel";
            this.SpaceCoverageLabel.Size = new System.Drawing.Size(14, 14);
            this.SpaceCoverageLabel.TabIndex = 8;
            this.SpaceCoverageLabel.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 579);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "2D Bin Packing Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button GeneratingRectsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button PlacingRectsButton;
        private System.Windows.Forms.TextBox BoxCountTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PaddingTextBox;
        private System.Windows.Forms.TextBox MarginTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SpaceCoverageLabel;
    }
}

