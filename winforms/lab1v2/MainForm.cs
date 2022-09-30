namespace GPUProject.lab1v2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        #region col1
        var gpuList = new ListBox();
        gpuList.Height = 330;
        Controls.Add(gpuList);
        #endregion

        #region col2
        var manufacturerDropDown = new ComboBox
        {
            Location = new Point(130, 0),
        };
        Controls.Add(manufacturerDropDown);

        var modelTextBox = new TextBox
        {
            Location = new Point(130, 35),
            Width = 120,
            PlaceholderText = "Model"
        };
        Controls.Add(modelTextBox);

        var outputButtons = new Button[] {
            new Button {
                Text = "VGA",
                Location = new Point(130, 70),
                Width = 60,
                Height = 30,
            },
            new Button {
                Text = "DVI",
                Location = new Point(190, 70),
                Width = 60,
                Height = 30,
            },
            new Button {
                Text = "HDMI",
                Location = new Point(130, 105),
                Width = 60,
                Height = 30,
            },
            new Button {
                Text = "DP",
                Location = new Point(190, 105),
                Width = 60,
                Height = 30,
            },
        };
        Controls.AddRange(outputButtons);

        var outputList = new ListBox
        {
            Location = new Point(130, 140),
            Height = 110,
        };
        Controls.Add(outputList);

        var resolutionCheckBoxes = new CheckBox[] {
            new CheckBox {
                Location = new Point(130, 255),
                Text = "Full HD",
            },
            new CheckBox {
                Location = new Point(130, 280),
                Text = "1440p",
            },
            new CheckBox {
                Location = new Point(130, 305),
                Text = "4K",
            },
        };
        Controls.AddRange(resolutionCheckBoxes);

        #endregion

        #region col3
        var priceLabel = new Label
        {
            Location = new Point(260, 2),
            Text = "Price:",
            Width = 45,
        };
        Controls.Add(priceLabel);

        var priceNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 0),
            Width = 71,

        };
        Controls.Add(priceNumericUpDown);


        var baseClockLabel = new Label
        {
            Location = new Point(260, 36),
            Text = "Clock:",
            Width = 50,
        };
        Controls.Add(baseClockLabel);

        var baseClockNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 35),
            Width = 71,
        };
        Controls.Add(baseClockNumericUpDown);


        var memoryTypeDropDown = new ComboBox
        {
            Location = new Point(260, 70),
        };
        Controls.Add(memoryTypeDropDown);

        var memoryManufacturerDropDown = new ComboBox {
            Location = new Point(260, 105),
        };
        Controls.Add(memoryManufacturerDropDown);


        var memorySizeLabel = new Label {
            Location = new Point(260, 141),
            Text = "Size:",
            Width = 50,
        };
        Controls.Add(memorySizeLabel);

        var memorySizeNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 140),
            Width = 71,
        };
        Controls.Add(memorySizeNumericUpDown);

        var productionCheckbox = new CheckBox {
            Location = new Point(260, 175),
            Text = "Is in active\r\nproduction",
            Height = 50,
        };
        Controls.Add(productionCheckbox);
        #endregion
    }
}
