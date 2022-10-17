using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GPUProject.Resources;

static class InitValues
{
    public static string[] nvidiaModels = {
            "GTX 1660",
            "GTX 1060",
            "GT 1030",
            "GTX 1050Ti",
        };
    public static string[] amdModels = {
            "RX580",
            "Vega 56",
            "Radeon 7",
        };
    public static string[] intelModels = {
            "Iris Xe",
            "UH630"
        };
}
class GraphicsCard : INotifyPropertyChanged
{
#region getsetboilerplate
    public Manufacturer Manufacturer
    {
        get
        {
            return _manufacturer;
        }
        set
        {
            if (value != _manufacturer)
            {
                _manufacturer = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string Model
    {
        get
        {
            return _model;
        }
        set
        {
            if (value != _model)
            {
                _model = value;
                NotifyPropertyChanged();
            }
        }
    }

    public BindingList<OutputType> OutputTypes
    {
        get
        {
            return _outputTypes;
        }
        set
        {
            if (value != _outputTypes)
            {
                _outputTypes = value;
                NotifyPropertyChanged();
            }
        }
    }

    public ResolutionsRepresentation RecommendedResolutions
    {
        get
        {
            return _recommendedResolutions;
        }
        set
        {
            if (value != _recommendedResolutions)
            {
                _recommendedResolutions = value;
                NotifyPropertyChanged();
            }
        }
    }

    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value != _price)
            {
                _price = value;
                NotifyPropertyChanged();
            }
        }
    }

    public uint BaseClock
    {
        get
        {
            return _baseClock;
        }
        set
        {
            if (value != _baseClock)
            {
                _baseClock = value;
                NotifyPropertyChanged();
            }
        }
    }

    public Memory Memory
    {
        get
        {
            return _memory;
        }
        set
        {
            if (!_memory.Equals(value))
            {
                _memory = value;
                NotifyPropertyChanged();
            }
        }
    }

    public bool IsInActiveProduction
    {
        get
        {
            return _isInActiveProduction;
        }
        set
        {
            if (value != _isInActiveProduction)
            {
                _isInActiveProduction = value;
                NotifyPropertyChanged();
            }
        }
    }

    private Manufacturer _manufacturer;
    private string _model;
    private BindingList<OutputType> _outputTypes;
    private ResolutionsRepresentation _recommendedResolutions;
    private decimal _price;
    private uint _baseClock;
    private Memory _memory;
    private bool _isInActiveProduction;
#endregion

    public GraphicsCard()
    {
        Model = "New GPU";
        OutputTypes = new BindingList<OutputType>();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    #region done
    public static GraphicsCard[] GenerateGraphicsCards(int count)
    {
        var rng = new Random(80085);
        var results = new GraphicsCard[count];

        foreach (ref var graphicsCard in results.AsSpan())
        {
            var manufacturer = (Manufacturer)(rng.Next(3));
            string[] selectedArr;

            switch (manufacturer)
            {
                case Manufacturer.Nvidia:
                    selectedArr = InitValues.nvidiaModels;
                    break;
                case Manufacturer.AMD:
                    selectedArr = InitValues.amdModels;
                    break;
                case Manufacturer.Intel:
                    selectedArr = InitValues.intelModels;
                    break;
                default:
                    selectedArr = InitValues.nvidiaModels;
                    break;
            }

            string model = selectedArr[rng.Next() % selectedArr.Length];

            var outputTypes = new BindingList<OutputType>();
            // foreach (ref var outputType in outputTypes)
            outputTypes.Add((OutputType)(rng.Next(4)));

            var recommendedResolutions = new ResolutionsRepresentation(rng.Next(8));
            var price = (decimal)rng.NextSingle() * 500;
            var baseClock = (uint)rng.Next(1000) + 1000;
            var memory = new Memory
            {
                type = (MemoryType)(rng.Next(4)),
                manufacturer = (MemoryManufacturer)(rng.Next(3)),
                size = (byte)rng.Next(12),
            };

            var isInActiveProduction = rng.Next(2) == 0;


            graphicsCard = new GraphicsCard
            {
                Manufacturer = manufacturer,
                Model = model,
                OutputTypes = outputTypes,
                RecommendedResolutions = recommendedResolutions,
                Price = price,
                BaseClock = baseClock,
                Memory = memory,
                IsInActiveProduction = isInActiveProduction,
            };
        }



        return results;
    }

    static bool TryReadGPU(string path, out GraphicsCard graphicsCard)
    {
        // TODO: actually handle exceptions
        graphicsCard = JsonSerializer.Deserialize<GraphicsCard>(File.ReadAllText(path));
        return true;
    }

    static void WriteGPU(string path, GraphicsCard gpu)
    {
        File.WriteAllText(path, JsonSerializer.Serialize<GraphicsCard>(gpu));
    }
    #endregion
}

#region declarations

public struct Memory
{
    public MemoryType type { get; set; }
    public MemoryManufacturer manufacturer { get; set; }
    public byte size { get; set; }
}

[Flags]
public enum RecommendedResolutions
{
    None = 0,
    FullHD = 1 << 0,
    TwoK = 1 << 1,
    FourK = 1 << 2,
}

public enum Manufacturer
{
    Nvidia,
    AMD,
    Intel,
}

public enum MemoryType
{
    DDR4,
    GDDR5,
    GDDR6,
    GDDR6X,
}

public enum MemoryManufacturer
{
    SKHynix,
    Micron,
    Samsung,
}

public enum OutputType
{
    VGA,
    DVI,
    HDMI,
    DisplayPort,
}

#endregion


public class ResolutionsRepresentation : INotifyPropertyChanged
{
    public ResolutionsRepresentation(int value) {
        FullHD = (value & 1) == 1 ? true : false;
        TwoK = (value & 2) == 2 ? true : false;
        FourK = (value & 4) == 2 ? true : false;
    }
    private bool _FullHD;
    private bool _TwoK;
    private bool _FourK;

    public event PropertyChangedEventHandler? PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public bool FullHD
    {
        get
        {
            return _FullHD;
        }
        set
        {
            if (_FullHD != value)
            {
                _FullHD = value;
                NotifyPropertyChanged();
            }
        }
    }

    public bool TwoK
    {
        get
        {
            return _TwoK;
        }
        set
        {
            if (_TwoK != value)
            {
                _TwoK = value;
                NotifyPropertyChanged();
            }
        }
    }

    public bool FourK
    {
        get
        {
            return _FourK;
        }
        set
        {
            if (_FourK != value)
            {
                _FourK = value;
                NotifyPropertyChanged();
            }
        }
    }


}