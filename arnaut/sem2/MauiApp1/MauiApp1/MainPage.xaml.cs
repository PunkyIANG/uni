using System.Collections.ObjectModel;
using MauiApp1.Comparers;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    //todo: replace this with a list of actual controls
    private object _itemsList;
    private bool _isSorting;
    private Action? _sortAction;
    private int _selectedIndex = 0;
    private ObservableCollection<string> FilterList;

    public MainPage()
    {
        InitializeComponent();
        TypePicker.ItemsSource = new List<Type> { typeof(int), typeof(float), typeof(CustomString) };
        TypePicker.SelectedIndex = 0;
        SortPicker.ItemsSource = Enum.GetValues(typeof(SortAlgorithm));
        SortPicker.SelectedIndex = 0;
        RegenerateFilterList(this, null);
    }

    private void TypePicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var length = (int)LengthSlider.Value;

        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                _itemsList = new ObservableCollection<int>(Enumerable.Range(0, length));
                ItemsListView.ItemsSource = (ObservableCollection<int>)_itemsList;
                break;

            case var floatType when (Type)floatType == typeof(float):
                _itemsList = new ObservableCollection<float>(Enumerable.Range(0, length).Select(x => x / 10f));
                ItemsListView.ItemsSource = _itemsList as ObservableCollection<float>;
                break;

            case var stringType when (Type)stringType == typeof(CustomString):
                _itemsList =
                    new ObservableCollection<CustomString>(Generator.RandomWords.Take(length)
                        .Select(x => new CustomString(x)));
                ItemsListView.ItemsSource = _itemsList as ObservableCollection<CustomString>;
                break;
        }

        RegenerateSortAction();
    }

    private void LengthSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        var newLength = (int)LengthSlider.Value;

        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                var intList = _itemsList as ObservableCollection<int>;
                var oldLength = intList.Count;
                if (newLength == oldLength) return;

                if (newLength < oldLength)
                    for (var i = oldLength - 1; i >= newLength; i--)
                        intList.RemoveAt(i);
                else
                    for (int i = oldLength; i < newLength; i++)
                        intList.Add(i);
                break;

            case var floatType when (Type)floatType == typeof(float):
                var floatList = _itemsList as ObservableCollection<float>;
                var oldLength2 = floatList.Count;
                if (newLength == oldLength2) return;

                if (newLength < oldLength2)
                    for (var i = oldLength2 - 1; i >= newLength; i--)
                        floatList.RemoveAt(i);
                else
                    for (int i = oldLength2; i < newLength; i++)
                        floatList.Add(i / 10f);
                break;

            case var stringType when (Type)stringType == typeof(CustomString):
                var stringList = _itemsList as ObservableCollection<CustomString>;
                var oldLength3 = stringList.Count;
                if (newLength == oldLength3) return;

                if (newLength < oldLength3)
                    for (var i = oldLength3 - 1; i >= newLength; i--)
                        stringList.RemoveAt(i);
                else
                    for (int i = oldLength3; i < newLength; i++)
                        stringList.Add(new CustomString(Generator.RandomWords[i]));
                break;
        }
        
        BottomSlider.Maximum = newLength - 1;
        TopSlider.Maximum = newLength - 1;
        RegenerateFilterList(this, null);
    }

    private void SortButton_OnClicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(_sortAction);
    }

    private void ShuffleButton_OnClicked(object sender, EventArgs e)
    {
        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                var intList = (ObservableCollection<int>)_itemsList;
                intList.Shuffle();
                break;

            case var floatType when (Type)floatType == typeof(float):
                var floatList = (ObservableCollection<float>)_itemsList;
                floatList.Shuffle();
                break;

            case var stringType when (Type)stringType == typeof(CustomString):
                var stringList = (ObservableCollection<CustomString>)_itemsList;
                stringList.Shuffle();
                break;
        }
    }

    private void SortPicker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        RegenerateSortAction();
    }

    private void RegenerateSortAction()
    {
        if (TypePicker.SelectedItem == null || SortPicker.SelectedItem == null)
            return;

        var left = (int)BottomSlider.Value;
        var right = (int)TopSlider.Value;
        
        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                var intList = (ObservableCollection<int>)_itemsList;
                switch ((SortAlgorithm)SortPicker.SelectedItem)
                {
                    case SortAlgorithm.QuickSort:
                        _sortAction = async () => await intList.QuickSort(left, right, new IntComparer());
                        break;
                    case SortAlgorithm.BubbleSort:
                        _sortAction = async () => await intList.BubbleSort(left, right, new IntComparer());
                        break;
                    case SortAlgorithm.SelectionSort:
                        _sortAction = async () => await intList.SelectionSort(left, right, new IntComparer());
                        break;
                }
                break;

            case var floatType when (Type)floatType == typeof(float):
                var floatList = (ObservableCollection<float>)_itemsList;
                switch ((SortAlgorithm)SortPicker.SelectedItem)
                {
                    case SortAlgorithm.QuickSort:
                        _sortAction = async () => await floatList.QuickSort(left, right, new FloatComparer());
                        break;
                    case SortAlgorithm.BubbleSort:
                        _sortAction = async () => await floatList.BubbleSort(left, right, new FloatComparer());
                        break;
                    case SortAlgorithm.SelectionSort:
                        _sortAction = async () => await floatList.SelectionSort(left, right, new FloatComparer());
                        break;
                }
                break;

            case var stringType when (Type)stringType == typeof(CustomString):
                var stringList = (ObservableCollection<CustomString>)_itemsList;
                switch ((SortAlgorithm)SortPicker.SelectedItem)
                {
                    case SortAlgorithm.QuickSort:
                        _sortAction = async () => await stringList.QuickSort(left, right, new CustomStringComparer());
                        break;
                    case SortAlgorithm.BubbleSort:
                        _sortAction = async () => await stringList.BubbleSort(left, right, new CustomStringComparer());
                        break;
                    case SortAlgorithm.SelectionSort:
                        _sortAction = async () => await stringList.SelectionSort(left, right, new CustomStringComparer());
                        break;
                }
                break;
        }


    }

    private void ValueSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                var intList = (ObservableCollection<int>)_itemsList;
                if (intList.Count <= _selectedIndex) 
                    return;
                intList[_selectedIndex] = (int)ValueSlider.Value;
                break;

            case var floatType when (Type)floatType == typeof(float):
                var floatList = (ObservableCollection<float>)_itemsList;
                if (floatList.Count <= _selectedIndex) 
                    return;
                floatList[_selectedIndex] = (float)ValueSlider.Value / 10f;
                break;
            
            case var stringType when (Type)stringType == typeof(CustomString):
                var stringList = (ObservableCollection<CustomString>)_itemsList;
                if (stringList.Count <= _selectedIndex) 
                    return;
                stringList[_selectedIndex] = new CustomString(Generator.RandomWords[(int)ValueSlider.Value]);
                break;
        }
    }

    private void ItemsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ItemsListView.SelectedItem == null) return;
        
        switch (TypePicker.SelectedItem)
        {
            case var intType when (Type)intType == typeof(int):
                _selectedIndex = ((ObservableCollection<int>)_itemsList).IndexOf((int)ItemsListView.SelectedItem);
                ValueSlider.Value = (int)ItemsListView.SelectedItem;
                break;
            
            case var floatType when (Type)floatType == typeof(float):
                _selectedIndex = ((ObservableCollection<float>)_itemsList).IndexOf((float)ItemsListView.SelectedItem);
                ValueSlider.Value = (float)ItemsListView.SelectedItem * 10f;
                break;
            
            case var stringType when (Type)stringType == typeof(CustomString):
                _selectedIndex = ((ObservableCollection<CustomString>)_itemsList).IndexOf((CustomString)ItemsListView.SelectedItem);
                ValueSlider.Value = Generator.RandomWords.IndexOf(((CustomString)ItemsListView.SelectedItem).Value);
                break;
        }
    }

    private void RegenerateFilterList(object sender, ValueChangedEventArgs e)
    {
        FilterList = new ObservableCollection<string>();

        for (int j = 0; j < (int)LengthSlider.Value; j++)
        {
            if (j < (int)BottomSlider.Value || j > (int)TopSlider.Value)
                FilterList.Add("█");
            else
                FilterList.Add(" ");
        }

        FilterListView.ItemsSource = FilterList;
        RegenerateSortAction();
    }
}