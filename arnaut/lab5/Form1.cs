namespace lab5;

public partial class Form1 : Form
{
    private readonly ListBox[] _listBoxes = new ListBox[GraphicsCard.PropertyCount];
    private int _selectedIndex;
    private readonly ToolStripMenuItem _editToolStripMenuItem;
    private readonly ToolStripMenuItem _removeToolStripMenuItem;
    public Form1()
    {
        InitializeComponent();

        Text = "Lab 5";
        
        #region Tabs
        
        var tabControl = new TabControl { Dock = DockStyle.Fill };
        Controls.Add(tabControl);

        for (var i = 0; i < GraphicsCard.CategoriesCount; i++)
        {
            var tabPage = new TabPage
            {
                Dock = DockStyle.Fill,
                Text = GraphicsCard.Categories[i]
            };

            for (var j = 0; j < GraphicsCard.PropertyCount/GraphicsCard.CategoriesCount; j++)
            {
                var id = j + i * GraphicsCard.PropertyCount / GraphicsCard.CategoriesCount;
                
                var label = new Label
                {
                    Text = GraphicsCard.Properties[id],
                    Location = new Point(10 + j * 220, 10),
                    Size = new Size(210, 30),
                };
                tabPage.Controls.Add(label);

                _listBoxes[id] = new ListBox
                {
                    Location = new Point(10 + j * 220, 40),
                    Size = new Size(210, 160),
                };
                _listBoxes[id].SelectedIndexChanged += (_, _) => 
                    _selectedIndex = _listBoxes[id].SelectedIndex >= 0 
                        ? _listBoxes[id].SelectedIndex 
                        : _selectedIndex;
                tabPage.Controls.Add(_listBoxes[id]);
            }
            
            tabControl.TabPages.Add(tabPage);
        }
        
        #endregion
        
        #region MenuStrip
        
        var menuStrip = new MenuStrip();
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        
        var fileToolStripMenuItem = new ToolStripMenuItem("&File");
        menuStrip.Items.Add(fileToolStripMenuItem);
        
        var newToolStripMenuItem = new ToolStripMenuItem
        {
            Text = "&New", 
            ShortcutKeys = Keys.Control | Keys.N,
        };
        newToolStripMenuItem.Click += (_, _) => AddElement();
        
        _editToolStripMenuItem = new ToolStripMenuItem
        {
            Text = "&Edit",
            ShortcutKeys = Keys.Control | Keys.E,
        };
        _editToolStripMenuItem.Click += (_,_) => EditElement();
        
        _removeToolStripMenuItem = new ToolStripMenuItem
        {
            Text = "&Remove",
            ShortcutKeys = Keys.Control | Keys.R,
        };
        _removeToolStripMenuItem.Click += RemoveElement;
        fileToolStripMenuItem.DropDownItems.AddRange(new[]
        {
            newToolStripMenuItem,
            _editToolStripMenuItem,
            _removeToolStripMenuItem
        });

        ValidateEditRemoveButtonState();

        #endregion
    }
    
    public void AddElement()
    {
        var form = new AddElementForm(_listBoxes);
        form.ShowDialog();
        
        ValidateEditRemoveButtonState();
    }

    public void EditElement()
    {
        if (_listBoxes[0].Items.Count == 0)
        {
            MessageBox.Show("You cannot edit an empty list");
            return;
        }
        var form = new EditElementForm(_listBoxes, _selectedIndex);
        form.ShowDialog();
    }
    
    private void RemoveElement(object o, EventArgs eventArgs)
    {
        if (MessageBox.Show($"Are you sure you want to remove element {_selectedIndex}?", "Remove Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            foreach (var listBox in _listBoxes)
                listBox.Items.RemoveAt(_selectedIndex);
        
        ValidateEditRemoveButtonState();
    }

    public void ValidateEditRemoveButtonState()
    {
        bool isActive = _listBoxes[0].Items.Count > 0;
        _editToolStripMenuItem.Enabled = isActive;
        _removeToolStripMenuItem.Enabled = isActive;
    }
}
