namespace GPUProject.lab1v2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        var labelArr = new Label[10];

        // foreach (ref var l in labelArr.AsSpan())
        for (int i = 0; i < labelArr.Length; i++)
        {
            var l = new Label();
            l.Text = $"label text {i}";
            l.Location = new Point(0, i*20);
            Controls.Add(l);
        }

        // var b = new Button();
        // b.Text = "button text";
        // Controls.Add(b);
    }
}
