﻿using System.Windows.Forms;

namespace lab5;

public partial class AddElementForm : Form
{
    private TextBox[] textBoxes = new TextBox[GraphicsCard.PropertyCount];
    
    public AddElementForm(ListBox[] listBoxes)
    {
        InitializeComponent();
        Text = "Add element";
        
        ClientSize = new Size(440, 55 + GraphicsCard.PropertyCount * 40);

        for (var i = 0; i < GraphicsCard.PropertyCount; i++)
        {
            var label = new Label
            {
                Text = GraphicsCard.Properties[i],
                Location = new Point(10, 10 + i * 40),
                Size = new Size(210, 40),
                TextAlign = ContentAlignment.MiddleRight
            };
            Controls.Add(label);
            
            textBoxes[i] = new TextBox
            {
                Location = new Point(220, 10 + i * 40),
                Size = new Size(210, 40),
            };
            Controls.Add(textBoxes[i]);
        }
        
        var button = new Button
        {
            Text = "Submit",
            Location = new Point(10, 10 + GraphicsCard.PropertyCount * 40),
            Size = new Size(420, 40),
        };
        button.Click += (_, _) =>
        {
            for (var i = 0; i < listBoxes.Length; i++) 
                listBoxes[i].Items.Add(textBoxes[i].Text);

            DialogResult = DialogResult.OK; 
            Close();
        };
        Controls.Add(button);

        foreach (var textBox in textBoxes) textBox.TextChanged += (_, _) => button.Enabled = ValidateTextBoxes();
        button.Enabled = ValidateTextBoxes();
    }

    private bool ValidateTextBoxes()
    {
        return textBoxes.All(textBox => textBox.Text != "");
    }
}