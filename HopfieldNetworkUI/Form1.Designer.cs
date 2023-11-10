namespace HopfieldNetworkUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.swichErather = new System.Windows.Forms.Button();
            this.swichPen = new System.Windows.Forms.Button();
            this.addToNet = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            this.clearDataBtn = new System.Windows.Forms.Button();
            this.savedPhotos = new System.Windows.Forms.PictureBox();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedPhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // swichErather
            // 
            this.swichErather.Location = new System.Drawing.Point(93, 418);
            this.swichErather.Name = "swichErather";
            this.swichErather.Size = new System.Drawing.Size(75, 23);
            this.swichErather.TabIndex = 1;
            this.swichErather.Text = "Стирачка";
            this.swichErather.UseVisualStyleBackColor = true;
            this.swichErather.Click += new System.EventHandler(this.swichErather_Click);
            // 
            // swichPen
            // 
            this.swichPen.Location = new System.Drawing.Point(12, 418);
            this.swichPen.Name = "swichPen";
            this.swichPen.Size = new System.Drawing.Size(75, 23);
            this.swichPen.TabIndex = 2;
            this.swichPen.Text = "Олівець";
            this.swichPen.UseVisualStyleBackColor = true;
            this.swichPen.Click += new System.EventHandler(this.swichPen_Click);
            // 
            // addToNet
            // 
            this.addToNet.Location = new System.Drawing.Point(418, 12);
            this.addToNet.Name = "addToNet";
            this.addToNet.Size = new System.Drawing.Size(99, 41);
            this.addToNet.TabIndex = 3;
            this.addToNet.Text = "Додати до мережі";
            this.addToNet.UseVisualStyleBackColor = true;
            this.addToNet.Click += new System.EventHandler(this.addToNet_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(174, 418);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Очистити";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(418, 59);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(99, 41);
            this.solveBtn.TabIndex = 5;
            this.solveBtn.Text = "Розпізнати";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // clearDataBtn
            // 
            this.clearDataBtn.Location = new System.Drawing.Point(418, 106);
            this.clearDataBtn.Name = "clearDataBtn";
            this.clearDataBtn.Size = new System.Drawing.Size(99, 41);
            this.clearDataBtn.TabIndex = 6;
            this.clearDataBtn.Text = "Очистити пам\'ять";
            this.clearDataBtn.UseVisualStyleBackColor = true;
            this.clearDataBtn.Click += new System.EventHandler(this.clearDataBtn_Click);
            // 
            // savedPhotos
            // 
            this.savedPhotos.Location = new System.Drawing.Point(523, 12);
            this.savedPhotos.Name = "savedPhotos";
            this.savedPhotos.Size = new System.Drawing.Size(265, 265);
            this.savedPhotos.TabIndex = 7;
            this.savedPhotos.TabStop = false;
            // 
            // leftBtn
            // 
            this.leftBtn.Location = new System.Drawing.Point(523, 283);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(75, 23);
            this.leftBtn.TabIndex = 8;
            this.leftBtn.Text = "<--";
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // rightBtn
            // 
            this.rightBtn.Location = new System.Drawing.Point(713, 283);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(75, 23);
            this.rightBtn.TabIndex = 9;
            this.rightBtn.Text = "-->";
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.savedPhotos);
            this.Controls.Add(this.clearDataBtn);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.addToNet);
            this.Controls.Add(this.swichPen);
            this.Controls.Add(this.swichErather);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Hopfield Network";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savedPhotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Button swichErather;
        private Button swichPen;
        private Button addToNet;
        private Button clearBtn;
        private Button solveBtn;
        private Button clearDataBtn;
        private PictureBox savedPhotos;
        private Button leftBtn;
        private Button rightBtn;
    }
}