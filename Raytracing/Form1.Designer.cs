namespace OpenGL
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openGlControl = new OpenTK.GLControl();
            this.lblType = new System.Windows.Forms.Label();
            this.tbVision = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbReflection = new System.Windows.Forms.TrackBar();
            this.tbRefraction = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTracing = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbMaterial = new System.Windows.Forms.TrackBar();
            this.tbVisionY = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbVision)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbReflection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRefraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTracing)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVisionY)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // openGlControl
            // 
            this.openGlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGlControl.BackColor = System.Drawing.Color.Black;
            this.openGlControl.Location = new System.Drawing.Point(1, 1);
            this.openGlControl.Margin = new System.Windows.Forms.Padding(1);
            this.openGlControl.Name = "openGlControl";
            this.openGlControl.Size = new System.Drawing.Size(407, 416);
            this.openGlControl.TabIndex = 0;
            this.openGlControl.VSync = false;
            this.openGlControl.Load += new System.EventHandler(this.openGlControl_Load);
            this.openGlControl.Paint += new System.Windows.Forms.PaintEventHandler(this.openGlControl_Paint);
            this.openGlControl.Resize += new System.EventHandler(this.openGlControl_Resize);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblType.Location = new System.Drawing.Point(544, 131);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(17, 13);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "lbl";
            // 
            // tbVision
            // 
            this.tbVision.Location = new System.Drawing.Point(523, 23);
            this.tbVision.Maximum = 35;
            this.tbVision.Minimum = -35;
            this.tbVision.Name = "tbVision";
            this.tbVision.Size = new System.Drawing.Size(98, 45);
            this.tbVision.TabIndex = 3;
            this.tbVision.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbVision.Scroll += new System.EventHandler(this.tbVisionX_Scroll);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Вид";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип материала";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.openGlControl);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 394);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 63);
            this.label4.TabIndex = 2;
            this.label4.Text = "Преломление";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 51);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отражения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbReflection
            // 
            this.tbReflection.Location = new System.Drawing.Point(124, 5);
            this.tbReflection.Maximum = 20;
            this.tbReflection.Name = "tbReflection";
            this.tbReflection.Size = new System.Drawing.Size(126, 45);
            this.tbReflection.TabIndex = 3;
            this.tbReflection.Scroll += new System.EventHandler(this.tbReflection_Scroll);
            // 
            // tbRefraction
            // 
            this.tbRefraction.Location = new System.Drawing.Point(124, 58);
            this.tbRefraction.Maximum = 20;
            this.tbRefraction.Minimum = 9;
            this.tbRefraction.Name = "tbRefraction";
            this.tbRefraction.Size = new System.Drawing.Size(126, 45);
            this.tbRefraction.TabIndex = 3;
            this.tbRefraction.Value = 11;
            this.tbRefraction.Scroll += new System.EventHandler(this.tbRefraction_Scroll);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 57);
            this.label7.TabIndex = 2;
            this.label7.Text = "Глубина трейсинга";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTracing
            // 
            this.tbTracing.Location = new System.Drawing.Point(124, 123);
            this.tbTracing.Minimum = 1;
            this.tbTracing.Name = "tbTracing";
            this.tbTracing.Size = new System.Drawing.Size(126, 45);
            this.tbTracing.TabIndex = 3;
            this.tbTracing.Value = 1;
            this.tbTracing.Scroll += new System.EventHandler(this.tbTracing_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.BackColor = System.Drawing.SystemColors.Control;
            this.btnColor.Location = new System.Drawing.Point(124, 182);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(159, 62);
            this.btnColor.TabIndex = 5;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnColor, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbTracing, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRefraction, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbReflection, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(435, 157);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 249);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tbMaterial
            // 
            this.tbMaterial.BackColor = System.Drawing.SystemColors.Control;
            this.tbMaterial.Location = new System.Drawing.Point(534, 86);
            this.tbMaterial.Maximum = 3;
            this.tbMaterial.Minimum = 1;
            this.tbMaterial.Name = "tbMaterial";
            this.tbMaterial.Size = new System.Drawing.Size(126, 45);
            this.tbMaterial.TabIndex = 3;
            this.tbMaterial.Value = 1;
            this.tbMaterial.Scroll += new System.EventHandler(this.tbMaterialType_Scroll);
            // 
            // tbVisionY
            // 
            this.tbVisionY.Location = new System.Drawing.Point(627, 12);
            this.tbVisionY.Maximum = 35;
            this.tbVisionY.Minimum = -35;
            this.tbVisionY.Name = "tbVisionY";
            this.tbVisionY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbVisionY.Size = new System.Drawing.Size(45, 68);
            this.tbVisionY.TabIndex = 3;
            this.tbVisionY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbVisionY.Scroll += new System.EventHandler(this.tbVisionY_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 425);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbVision);
            this.Controls.Add(this.tbVisionY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMaterial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ClientSizeChanged += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tbVision)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbReflection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRefraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTracing)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVisionY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private OpenTK.GLControl openGlControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar tbVision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbReflection;
        private System.Windows.Forms.TrackBar tbRefraction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbTracing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar tbMaterial;
        private System.Windows.Forms.TrackBar tbVisionY;
    }
}

