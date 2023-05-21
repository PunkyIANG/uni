using System.Collections;
using System.Collections.ObjectModel;

namespace lab2;

public partial class MainPage : ContentPage
{
    private readonly (string,IEnumerable<PropertyWrapper>)[] enumerables = Collections.GetEnumerables();
    
    public int Index { get; set; }
    public List<string> EnumerableNames => enumerables.Select(x => x.Item1).ToList();
    public IEnumerable<PropertyWrapper> SelectedEnumerable => enumerables[Index].Item2;

    public MainPage()
    {
        InitializeComponent();
        TypePicker.ItemsSource = EnumerableNames;
        TypePicker.SelectedIndex = Index;
        ItemsView.ItemsSource = SelectedEnumerable;
    }

    private void TypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Index = TypePicker.SelectedIndex;
        ItemsView.ItemsSource = SelectedEnumerable;
    }
}