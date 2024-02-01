
namespace Course_Work
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPaint = new System.Windows.Forms.Button();
            this.buttonLearning = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelActivity = new System.Windows.Forms.Panel();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.panelPaintInstruments = new System.Windows.Forms.Panel();
            this.buttonEraser = new System.Windows.Forms.Button();
            this.buttonGoal = new System.Windows.Forms.Button();
            this.buttonBarricade = new System.Windows.Forms.Button();
            this.buttonRobot = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.graphPanel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelActivity.SuspendLayout();
            this.panelPaintInstruments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPaint
            // 
            this.buttonPaint.BackColor = System.Drawing.Color.LightGray;
            this.buttonPaint.Location = new System.Drawing.Point(0, 584);
            this.buttonPaint.Name = "buttonPaint";
            this.buttonPaint.Size = new System.Drawing.Size(406, 45);
            this.buttonPaint.TabIndex = 1;
            this.buttonPaint.Text = "Малювати";
            this.buttonPaint.UseVisualStyleBackColor = false;
            this.buttonPaint.Click += new System.EventHandler(this.buttonPaint_Click);
            // 
            // buttonLearning
            // 
            this.buttonLearning.Enabled = false;
            this.buttonLearning.Location = new System.Drawing.Point(0, 539);
            this.buttonLearning.Name = "buttonLearning";
            this.buttonLearning.Size = new System.Drawing.Size(406, 45);
            this.buttonLearning.TabIndex = 2;
            this.buttonLearning.Text = "Пошук шляху";
            this.buttonLearning.UseVisualStyleBackColor = true;
            this.buttonLearning.Click += new System.EventHandler(this.buttonLearning_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(0, 494);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(406, 45);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Запуск алгоритму";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelActivity
            // 
            this.panelActivity.Controls.Add(this.buttonContinue);
            this.panelActivity.Controls.Add(this.buttonStop);
            this.panelActivity.Location = new System.Drawing.Point(0, 449);
            this.panelActivity.Name = "panelActivity";
            this.panelActivity.Size = new System.Drawing.Size(406, 45);
            this.panelActivity.TabIndex = 4;
            // 
            // buttonContinue
            // 
            this.buttonContinue.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(203, 0);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(203, 45);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Їхати";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(0, 0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(203, 45);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Зупинка";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // panelPaintInstruments
            // 
            this.panelPaintInstruments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaintInstruments.Controls.Add(this.buttonEraser);
            this.panelPaintInstruments.Controls.Add(this.buttonGoal);
            this.panelPaintInstruments.Controls.Add(this.buttonBarricade);
            this.panelPaintInstruments.Controls.Add(this.buttonRobot);
            this.panelPaintInstruments.Location = new System.Drawing.Point(0, 0);
            this.panelPaintInstruments.Name = "panelPaintInstruments";
            this.panelPaintInstruments.Padding = new System.Windows.Forms.Padding(5);
            this.panelPaintInstruments.Size = new System.Drawing.Size(1098, 49);
            this.panelPaintInstruments.TabIndex = 5;
            this.panelPaintInstruments.Visible = false;
            // 
            // buttonEraser
            // 
            this.buttonEraser.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonEraser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEraser.BackgroundImage")));
            this.buttonEraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEraser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEraser.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEraser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonEraser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEraser.Location = new System.Drawing.Point(295, 5);
            this.buttonEraser.Name = "buttonEraser";
            this.buttonEraser.Size = new System.Drawing.Size(94, 37);
            this.buttonEraser.TabIndex = 9;
            this.toolTip1.SetToolTip(this.buttonEraser, "Видалення ");
            this.buttonEraser.UseVisualStyleBackColor = false;
            this.buttonEraser.Click += new System.EventHandler(this.buttonEraser_Click);
            // 
            // buttonGoal
            // 
            this.buttonGoal.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonGoal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGoal.BackgroundImage")));
            this.buttonGoal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonGoal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoal.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonGoal.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGoal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGoal.Location = new System.Drawing.Point(197, 5);
            this.buttonGoal.Name = "buttonGoal";
            this.buttonGoal.Size = new System.Drawing.Size(98, 37);
            this.buttonGoal.TabIndex = 8;
            this.toolTip1.SetToolTip(this.buttonGoal, "Кінцева точка");
            this.buttonGoal.UseVisualStyleBackColor = false;
            this.buttonGoal.Click += new System.EventHandler(this.buttonGoal_Click);
            // 
            // buttonBarricade
            // 
            this.buttonBarricade.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonBarricade.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBarricade.BackgroundImage")));
            this.buttonBarricade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBarricade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBarricade.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBarricade.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonBarricade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBarricade.Location = new System.Drawing.Point(103, 5);
            this.buttonBarricade.Name = "buttonBarricade";
            this.buttonBarricade.Size = new System.Drawing.Size(94, 37);
            this.buttonBarricade.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonBarricade, "Перешкоди у приміщенні");
            this.buttonBarricade.UseVisualStyleBackColor = false;
            this.buttonBarricade.Click += new System.EventHandler(this.buttonBarricade_Click);
            // 
            // buttonRobot
            // 
            this.buttonRobot.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonRobot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRobot.BackgroundImage")));
            this.buttonRobot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRobot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRobot.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRobot.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRobot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRobot.Location = new System.Drawing.Point(5, 5);
            this.buttonRobot.Name = "buttonRobot";
            this.buttonRobot.Size = new System.Drawing.Size(98, 37);
            this.buttonRobot.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonRobot, "Точка звідки починає рухатись робот");
            this.buttonRobot.UseVisualStyleBackColor = false;
            this.buttonRobot.Click += new System.EventHandler(this.buttonRobot_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.graphPanel.Location = new System.Drawing.Point(406, 0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(692, 629);
            this.graphPanel.TabIndex = 6;
            this.graphPanel.TabStop = false;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            this.graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseDown);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseMove);
            this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Перешкоди:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 629);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.panelPaintInstruments);
            this.Controls.Add(this.panelActivity);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonLearning);
            this.Controls.Add(this.buttonPaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelActivity.ResumeLayout(false);
            this.panelPaintInstruments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonPaint;
        private System.Windows.Forms.Button buttonLearning;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelActivity;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Panel panelPaintInstruments;
        private System.Windows.Forms.Button buttonGoal;
        private System.Windows.Forms.Button buttonRobot;
        private System.Windows.Forms.Button buttonEraser;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonBarricade;
        private System.Windows.Forms.PictureBox graphPanel;
        private System.Windows.Forms.Label label1;
    }
}

