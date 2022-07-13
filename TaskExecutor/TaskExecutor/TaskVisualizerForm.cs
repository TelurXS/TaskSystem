namespace TaskExecutor
{
    public partial class TaskVisualizerForm : Form
    {
        public TaskExecutor Executor { get; protected set; }


        public TaskVisualizerForm(TaskExecutor executor)
        {
            Executor = executor;
            InitializeComponent();

            Executor.OnCycleLeave += Redraw;
        }

        public void Redraw(List<Task> tasks)
        {
            TasksLayoutGroup.Controls.Clear();

            foreach(Task task in tasks) 
            {
                TasksLayoutGroup.Controls.Add(CreateVisualElement(task));
            }
        }

        public Panel CreateVisualElement(Task task)
        {
            Panel TaskPanel = new Panel();
            Label TaskLabel = new Label();
            PictureBox TaskIcon = new PictureBox();
            Label TaskTypeLabel = new Label();
            Label StateLabel = new Label();
            Label TaskExecutionTimeLabel = new Label();

            TaskPanel.Controls.Add(TaskTypeLabel);
            TaskPanel.Controls.Add(StateLabel);
            TaskPanel.Controls.Add(TaskExecutionTimeLabel);
            TaskPanel.Controls.Add(TaskLabel);
            TaskPanel.Controls.Add(TaskIcon);

            TaskPanel.BackColor = SystemColors.ControlLight;
            TaskPanel.Location = new Point(3, 3);
            TaskPanel.Name = "TaskPanel";
            TaskPanel.Size = new Size(730, 80);
            TaskPanel.TabIndex = 0;

            TaskTypeLabel.AutoSize = true;
            TaskTypeLabel.Font = new Font("Yu Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            TaskTypeLabel.Location = new Point(84, 7);
            TaskTypeLabel.Name = "TaskTypeLabel";
            TaskTypeLabel.Size = new Size(62, 30);
            TaskTypeLabel.TabIndex = 4;
            TaskTypeLabel.Text = task.Type;

            StateLabel.AutoSize = true;
            StateLabel.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StateLabel.Location = new Point(460, 28);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new Size(108, 26);
            StateLabel.TabIndex = 3;
            StateLabel.Text = $"({task.State.ToString()})";

            TaskExecutionTimeLabel.AutoSize = true;
            TaskExecutionTimeLabel.Font = new Font("Yu Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            TaskExecutionTimeLabel.Location = new Point(570, 31);
            TaskExecutionTimeLabel.Name = "TaskExecutionTimeLabel";
            TaskExecutionTimeLabel.Size = new Size(159, 22);
            TaskExecutionTimeLabel.TabIndex = 2;
            TaskExecutionTimeLabel.Text = task.ExecutionTime.ToString();

            TaskLabel.AutoSize = true;
            TaskLabel.Font = new Font("Yu Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            TaskLabel.Location = new Point(86, 46);
            TaskLabel.Name = "TaskLabel";
            TaskLabel.Size = new Size(85, 23);
            TaskLabel.TabIndex = 1;
            TaskLabel.Text = task.ShortDescription();

            TaskIcon.BackColor = SystemColors.Menu;
            TaskIcon.Location = new Point(2, 2);
            TaskIcon.Name = "TaskIcon";
            TaskIcon.Size = new Size(76, 76);
            TaskIcon.TabIndex = 0;
            TaskIcon.TabStop = false;
            TaskIcon.Image = task.Icon;

            return TaskPanel;
        }


        private void RedrawButton_Click(object sender, EventArgs e)
        {
            Redraw(Executor.Tasks);
        }

        private void TaskVisualizerForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                NotifyIcon.Visible = true;
            }
        }

        private void Synchronyze_Click(object sender, EventArgs e)
        {
            Executor.LoadTasks();
            Redraw(Executor.Tasks);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            NotifyIcon.Visible = false;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Executor.Path = OpenFileDialog.FileName;
                Executor.LoadTasks();
                Redraw(Executor.Tasks);
            }
        }
    }
}