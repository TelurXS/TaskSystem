namespace TaskExecutor
{
    partial class TaskVisualizerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskVisualizerForm));
            this.TasksLayoutGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.RedrawButton = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Synchronyze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TasksLayoutGroup
            // 
            this.TasksLayoutGroup.Location = new System.Drawing.Point(12, 56);
            this.TasksLayoutGroup.Name = "TasksLayoutGroup";
            this.TasksLayoutGroup.Size = new System.Drawing.Size(758, 385);
            this.TasksLayoutGroup.TabIndex = 0;
            // 
            // RedrawButton
            // 
            this.RedrawButton.Location = new System.Drawing.Point(15, 12);
            this.RedrawButton.Name = "RedrawButton";
            this.RedrawButton.Size = new System.Drawing.Size(130, 38);
            this.RedrawButton.TabIndex = 1;
            this.RedrawButton.Text = "Redraw";
            this.RedrawButton.UseVisualStyleBackColor = true;
            this.RedrawButton.Click += new System.EventHandler(this.RedrawButton_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "NotifyIcon";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // Synchronyze
            // 
            this.Synchronyze.Location = new System.Drawing.Point(151, 12);
            this.Synchronyze.Name = "Synchronyze";
            this.Synchronyze.Size = new System.Drawing.Size(130, 38);
            this.Synchronyze.TabIndex = 2;
            this.Synchronyze.Text = "Synchronyze";
            this.Synchronyze.UseVisualStyleBackColor = true;
            this.Synchronyze.Click += new System.EventHandler(this.Synchronyze_Click);
            // 
            // TaskVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.Synchronyze);
            this.Controls.Add(this.RedrawButton);
            this.Controls.Add(this.TasksLayoutGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskVisualizerForm";
            this.Text = "Task Visualizer";
            this.Resize += new System.EventHandler(this.TaskVisualizerForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel TasksLayoutGroup;
        private Button RedrawButton;
        private NotifyIcon NotifyIcon;
        private Button Synchronyze;
    }
}