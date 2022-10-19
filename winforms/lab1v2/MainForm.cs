using GPUProject.Resources;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace GPUProject.lab1v2;


// TODO: add, delete, save, load
public partial class MainForm : Form
{
    ListBox gpuList;
    TextBox saveLoadTextBox;
    Label saveLoadResultLabel;

    ComboBox manufacturerDropDown;
    TextBox modelTextBox;
    Button[] outputButtons;
    ListBox outputList;
    CheckBox[] resolutionCheckBoxes;

    NumericUpDown priceNumericUpDown;
    NumericUpDown baseClockNumericUpDown;
    ComboBox memoryTypeDropDown;
    ComboBox memoryManufacturerDropDown;
    NumericUpDown memorySizeNumericUpDown;
    CheckBox productionCheckbox;

    BindingList<GraphicsCard> modelData;
    GraphicsCard selectedGpu;

    #region memory middleman
    public MemoryManufacturer memoryManufacturer
    {
        get
        {
            return selectedGpu.Memory.manufacturer;
        }
        set
        {
            if (value != selectedGpu.Memory.manufacturer) selectedGpu.Memory = new Memory
            {
                manufacturer = value,
                type = selectedGpu.Memory.type,
                size = selectedGpu.Memory.size,
            };
        }
    }

    public MemoryType memoryType
    {
        get
        {
            return selectedGpu.Memory.type;
        }
        set
        {
            if (value != selectedGpu.Memory.type) selectedGpu.Memory = new Memory
            {
                manufacturer = selectedGpu.Memory.manufacturer,
                type = value,
                size = selectedGpu.Memory.size,
            };
        }
    }

    public byte memorySize
    {
        get
        {
            return selectedGpu.Memory.size;
        }
        set
        {
            if (value != selectedGpu.Memory.size) selectedGpu.Memory = new Memory
            {
                manufacturer = selectedGpu.Memory.manufacturer,
                type = selectedGpu.Memory.type,
                size = value,
            };
        }
    }
    #endregion



    public MainForm()
    {
        InitializeComponent();

        #region col1
        modelData = new BindingList<GraphicsCard>(GraphicsCard.GenerateGraphicsCards(10).ToList());
        selectedGpu = modelData.First();

        gpuList = new ListBox
        {
            Height = 330,
            DataSource = modelData,
            DisplayMember = "Model",
        };

        gpuList.MouseDoubleClick += GPUList_MouseDoubleClick;
        gpuList.MouseUp += GPUList_MouseClick;

        gpuList.SelectedValueChanged += GPUList_SelectedValueChanged;

        Controls.Add(gpuList);


        saveLoadTextBox = new TextBox
        {
            Location = new Point(0, 330),
            Width = 120,
            PlaceholderText = "File to save/load",
        };

        Controls.Add(saveLoadTextBox);

        var saveButton = new Button
        {
            Location = new Point(0, 360),
            Width = 60,
            Height = 30,
            Text = "Save",
        };

        saveButton.Click += (sender, e) => SaveGPU();

        Controls.Add(saveButton);

        var loadButton = new Button
        {
            Location = new Point(60, 360),
            Width = 60,
            Height = 30,
            Text = "Load",
        };

        loadButton.Click += (sender, e) => LoadGPU();

        Controls.Add(loadButton);

        saveLoadResultLabel = new Label
        {
            Location = new Point(0, 390),
            Width = 400,
        };

        Controls.Add(saveLoadResultLabel);

        #endregion

        #region col2
        manufacturerDropDown = new ComboBox
        {
            Location = new Point(130, 0),
            DataSource = Enum.GetValues<Manufacturer>(),
        };

        Controls.Add(manufacturerDropDown);


        modelTextBox = new TextBox
        {
            Location = new Point(130, 35),
            Width = 120,
            PlaceholderText = "Model",
        };

        Controls.Add(modelTextBox);


        outputButtons = new Button[] {
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

        outputButtons[0].Click += (sender, e) => AddOutputType(OutputType.VGA);
        outputButtons[1].Click += (sender, e) => AddOutputType(OutputType.DVI);
        outputButtons[2].Click += (sender, e) => AddOutputType(OutputType.HDMI);
        outputButtons[3].Click += (sender, e) => AddOutputType(OutputType.DisplayPort);

        Controls.AddRange(outputButtons);

        outputList = new ListBox
        {
            Location = new Point(130, 140),
            Height = 110,
            DataSource = selectedGpu.OutputTypes,
        };

        Controls.Add(outputList);

        resolutionCheckBoxes = new CheckBox[] {
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

        priceNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 0),
            Maximum = 2000,
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

        baseClockNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 35),
            Maximum = 3000,
            Width = 71,
        };
        Controls.Add(baseClockNumericUpDown);


        memoryTypeDropDown = new ComboBox
        {
            Location = new Point(260, 70),
            DataSource = Enum.GetValues<MemoryType>(),
            DisplayMember = "MemoryType",
            ValueMember = "MemoryType",
        };
        Controls.Add(memoryTypeDropDown);

        memoryManufacturerDropDown = new ComboBox
        {
            Location = new Point(260, 105),
            DataSource = Enum.GetValues<MemoryManufacturer>(),
        };
        Controls.Add(memoryManufacturerDropDown);


        var memorySizeLabel = new Label
        {
            Location = new Point(260, 141),
            Text = "Size:",
            Width = 50,
        };
        Controls.Add(memorySizeLabel);

        memorySizeNumericUpDown = new NumericUpDown
        {
            Location = new Point(310, 140),
            Maximum = 255,
            Width = 71,
        };
        Controls.Add(memorySizeNumericUpDown);

        productionCheckbox = new CheckBox
        {
            Location = new Point(260, 175),
            Text = "Is in active\r\nproduction",
            Height = 50,
        };
        Controls.Add(productionCheckbox);

        var showButton = new Button
        {
            Location = new Point(260, 225),
            Height = 35,
            Text = "show"
        };
        showButton.Click += ShowCurrentValue;
        Controls.Add(showButton);
        #endregion

        ResetDataBindings();
    }

    void GPUList_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        if (gpuList.SelectedIndex != ListBox.NoMatches)
            modelData.RemoveAt(gpuList.SelectedIndex);

        if (modelData.Count == 0)
            modelData.Add(new GraphicsCard());

        selectedGpu = modelData[0];
        ResetDataBindings();
    }

    void GPUList_MouseClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
            modelData.AddNew();
    }

    void GPUList_SelectedValueChanged(object? sender, EventArgs e)
    {
        if (gpuList.SelectedIndex != ListBox.NoMatches)
            selectedGpu = (GraphicsCard)gpuList.SelectedValue;

        ResetDataBindings();
    }

    void ShowCurrentValue(object? sender, EventArgs e)
    {
        MessageBox.Show(JsonSerializer.Serialize<GraphicsCard>(selectedGpu));
    }

    void AddOutputType(OutputType outputType)
    {
        selectedGpu.OutputTypes.Add(outputType);
    }

    void SaveGPU()
    {
        if (saveLoadTextBox.Text != string.Empty)
        {
            GraphicsCard.WriteGPU(saveLoadTextBox.Text, selectedGpu);
            saveLoadResultLabel.Text = $"Saved to {saveLoadTextBox.Text}";
        }
        else
        {
            GraphicsCard.WriteGPU($"{selectedGpu.Model}.json", selectedGpu);
            saveLoadResultLabel.Text = $"Saved to {selectedGpu.Model}.json";
        }
    }

    void LoadGPU()
    {
        if (saveLoadTextBox.Text == string.Empty)
            saveLoadResultLabel.Text = "Specify a filename first!";

        if (GraphicsCard.TryReadGPU(saveLoadTextBox.Text, out var newGPU))
        {
            modelData.Add(newGPU);
            gpuList.SelectedIndex = gpuList.Items.Count - 1;
            selectedGpu = modelData.Last();
            ResetDataBindings();
            saveLoadResultLabel.Text = $"Successfully loaded {saveLoadTextBox.Text}";
        }
        else
        {
            saveLoadResultLabel.Text = "Load failed, probably missing file";
        }
    }

    void ResetDataBindings()
    {
        manufacturerDropDown.ResetBind(
            nameof(ComboBox.SelectedItem),
            selectedGpu,
            nameof(selectedGpu.Manufacturer)
        );

        modelTextBox.ResetBind(
            nameof(TextBox.Text),
            selectedGpu,
            nameof(selectedGpu.Model)
        );

        outputList.DataSource = selectedGpu.OutputTypes;

        resolutionCheckBoxes[0].ResetBind(
            nameof(CheckBox.Checked),
            selectedGpu.RecommendedResolutions,
            nameof(selectedGpu.RecommendedResolutions.FullHD)
        );

        resolutionCheckBoxes[1].ResetBind(
            nameof(CheckBox.Checked),
            selectedGpu.RecommendedResolutions,
            nameof(selectedGpu.RecommendedResolutions.TwoK)
        );

        resolutionCheckBoxes[2].ResetBind(
            nameof(CheckBox.Checked),
            selectedGpu.RecommendedResolutions,
            nameof(selectedGpu.RecommendedResolutions.FourK)
        );

        priceNumericUpDown.ResetBind(
            nameof(NumericUpDown.Value),
            selectedGpu,
            nameof(selectedGpu.Price)
        );

        baseClockNumericUpDown.ResetBind(
            nameof(NumericUpDown.Value),
            selectedGpu,
            nameof(selectedGpu.BaseClock)
        );


        memoryTypeDropDown.ResetBind(
            nameof(ComboBox.SelectedItem),
            this,
            nameof(this.memoryType)
        );

        memoryManufacturerDropDown.ResetBind(
            nameof(ComboBox.SelectedItem),
            this,
            nameof(this.memoryManufacturer)
        );

        memorySizeNumericUpDown.ResetBind(
            nameof(NumericUpDown.Value),
            this,
            nameof(this.memorySize)
        );


        productionCheckbox.ResetBind(
            nameof(CheckBox.Checked),
            selectedGpu,
            nameof(selectedGpu.IsInActiveProduction)
        );
    }
}

