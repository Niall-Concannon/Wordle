using System.ComponentModel;
using System.Runtime.CompilerServices;

public class RowColours : INotifyPropertyChanged
{
    // Create event for PropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Row 1 colours
    private Color _Row1Col1Colour = Colors.White; // Default colour is white
    public Color Row1Col1Colour
    {
        get => _Row1Col1Colour;
        set
        {
            if (_Row1Col1Colour != value)
            {
                _Row1Col1Colour = value;
                OnPropertyChanged(nameof(Row1Col1Colour));
            }
        }
    }

    private Color _Row1Col2Colour = Colors.White;
    public Color Row1Col2Colour
    {
        get => _Row1Col2Colour;
        set
        {
            if (_Row1Col2Colour != value)
            {
                _Row1Col2Colour = value;
                OnPropertyChanged(nameof(Row1Col2Colour));
            }
        }
    }

    private Color _Row1Col3Colour = Colors.White;
    public Color Row1Col3Colour
    {
        get => _Row1Col3Colour;
        set
        {
            if (_Row1Col3Colour != value)
            {
                _Row1Col3Colour = value;
                OnPropertyChanged(nameof(Row1Col3Colour));
            }
        }
    }

    private Color _Row1Col4Colour = Colors.White;
    public Color Row1Col4Colour
    {
        get => _Row1Col4Colour;
        set
        {
            if (_Row1Col4Colour != value)
            {
                _Row1Col4Colour = value;
                OnPropertyChanged(nameof(Row1Col4Colour));
            }
        }
    }

    private Color _Row1Col5Colour = Colors.White;
    public Color Row1Col5Colour
    {
        get => _Row1Col5Colour;
        set
        {
            if (_Row1Col5Colour != value)
            {
                _Row1Col5Colour = value;
                OnPropertyChanged(nameof(Row1Col5Colour));
            }
        }
    }

    // Row 2 colours
    private Color _Row2Col1Colour = Colors.White;
    public Color Row2Col1Colour
    {
        get => _Row2Col1Colour;
        set
        {
            if (_Row2Col1Colour != value)
            {
                _Row2Col1Colour = value;
                OnPropertyChanged(nameof(Row2Col1Colour));
            }
        }
    }

    private Color _Row2Col2Colour = Colors.White;
    public Color Row2Col2Colour
    {
        get => _Row2Col2Colour;
        set
        {
            if (_Row2Col2Colour != value)
            {
                _Row2Col2Colour = value;
                OnPropertyChanged(nameof(Row2Col2Colour));
            }
        }
    }

    private Color _Row2Col3Colour = Colors.White;
    public Color Row2Col3Colour
    {
        get => _Row2Col3Colour;
        set
        {
            if (_Row2Col3Colour != value)
            {
                _Row2Col3Colour = value;
                OnPropertyChanged(nameof(Row2Col3Colour));
            }
        }
    }

    private Color _Row2Col4Colour = Colors.White;
    public Color Row2Col4Colour
    {
        get => _Row2Col4Colour;
        set
        {
            if (_Row2Col4Colour != value)
            {
                _Row2Col4Colour = value;
                OnPropertyChanged(nameof(Row2Col4Colour));
            }
        }
    }

    private Color _Row2Col5Colour = Colors.White;
    public Color Row2Col5Colour
    {
        get => _Row2Col5Colour;
        set
        {
            if (_Row2Col5Colour != value)
            {
                _Row2Col5Colour = value;
                OnPropertyChanged(nameof(Row2Col5Colour));
            }
        }
    }

    // Row 3 colours
    private Color _Row3Col1Colour = Colors.White;
    public Color Row3Col1Colour
    {
        get => _Row3Col1Colour;
        set
        {
            if (_Row3Col1Colour != value)
            {
                _Row3Col1Colour = value;
                OnPropertyChanged(nameof(Row3Col1Colour));
            }
        }
    }

    private Color _Row3Col2Colour = Colors.White;
    public Color Row3Col2Colour
    {
        get => _Row3Col2Colour;
        set
        {
            if (_Row3Col2Colour != value)
            {
                _Row3Col2Colour = value;
                OnPropertyChanged(nameof(Row3Col2Colour));
            }
        }
    }

    private Color _Row3Col3Colour = Colors.White;
    public Color Row3Col3Colour
    {
        get => _Row3Col3Colour;
        set
        {
            if (_Row3Col3Colour != value)
            {
                _Row3Col3Colour = value;
                OnPropertyChanged(nameof(Row3Col3Colour));
            }
        }
    }

    private Color _Row3Col4Colour = Colors.White;
    public Color Row3Col4Colour
    {
        get => _Row3Col4Colour;
        set
        {
            if (_Row3Col4Colour != value)
            {
                _Row3Col4Colour = value;
                OnPropertyChanged(nameof(Row3Col4Colour));
            }
        }
    }

    private Color _Row3Col5Colour = Colors.White;
    public Color Row3Col5Colour
    {
        get => _Row3Col5Colour;
        set
        {
            if (_Row3Col5Colour != value)
            {
                _Row3Col5Colour = value;
                OnPropertyChanged(nameof(Row3Col5Colour));
            }
        }
    }

    // Row 4 colours
    private Color _Row4Col1Colour = Colors.White;
    public Color Row4Col1Colour
    {
        get => _Row4Col1Colour;
        set
        {
            if (_Row4Col1Colour != value)
            {
                _Row4Col1Colour = value;
                OnPropertyChanged(nameof(Row4Col1Colour));
            }
        }
    }

    private Color _Row4Col2Colour = Colors.White;
    public Color Row4Col2Colour
    {
        get => _Row4Col2Colour;
        set
        {
            if (_Row4Col2Colour != value)
            {
                _Row4Col2Colour = value;
                OnPropertyChanged(nameof(Row4Col2Colour));
            }
        }
    }

    private Color _Row4Col3Colour = Colors.White;
    public Color Row4Col3Colour
    {
        get => _Row4Col3Colour;
        set
        {
            if (_Row4Col3Colour != value)
            {
                _Row4Col3Colour = value;
                OnPropertyChanged(nameof(Row4Col3Colour));
            }
        }
    }

    private Color _Row4Col4Colour = Colors.White;
    public Color Row4Col4Colour
    {
        get => _Row4Col4Colour;
        set
        {
            if (_Row4Col4Colour != value)
            {
                _Row4Col4Colour = value;
                OnPropertyChanged(nameof(Row4Col4Colour));
            }
        }
    }

    private Color _Row4Col5Colour = Colors.White;
    public Color Row4Col5Colour
    {
        get => _Row4Col5Colour;
        set
        {
            if (_Row4Col5Colour != value)
            {
                _Row4Col5Colour = value;
                OnPropertyChanged(nameof(Row4Col5Colour));
            }
        }
    }

    // Row 5 colours
    private Color _Row5Col1Colour = Colors.White;
    public Color Row5Col1Colour
    {
        get => _Row5Col1Colour;
        set
        {
            if (_Row5Col1Colour != value)
            {
                _Row5Col1Colour = value;
                OnPropertyChanged(nameof(Row5Col1Colour));
            }
        }
    }

    private Color _Row5Col2Colour = Colors.White;
    public Color Row5Col2Colour
    {
        get => _Row5Col2Colour;
        set
        {
            if (_Row5Col2Colour != value)
            {
                _Row5Col2Colour = value;
                OnPropertyChanged(nameof(Row5Col2Colour));
            }
        }
    }

    private Color _Row5Col3Colour = Colors.White;
    public Color Row5Col3Colour
    {
        get => _Row5Col3Colour;
        set
        {
            if (_Row5Col3Colour != value)
            {
                _Row5Col3Colour = value;
                OnPropertyChanged(nameof(Row5Col3Colour));
            }
        }
    }

    private Color _Row5Col4Colour = Colors.White;
    public Color Row5Col4Colour
    {
        get => _Row5Col4Colour;
        set
        {
            if (_Row5Col4Colour != value)
            {
                _Row5Col4Colour = value;
                OnPropertyChanged(nameof(Row5Col4Colour));
            }
        }
    }

    private Color _Row5Col5Colour = Colors.White;
    public Color Row5Col5Colour
    {
        get => _Row5Col5Colour;
        set
        {
            if (_Row5Col5Colour != value)
            {
                _Row5Col5Colour = value;
                OnPropertyChanged(nameof(Row5Col5Colour));
            }
        }
    }

    // Row 6 colours
    private Color _Row6Col1Colour = Colors.White;
    public Color Row6Col1Colour
    {
        get => _Row6Col1Colour;
        set
        {
            if (_Row6Col1Colour != value)
            {
                _Row6Col1Colour = value;
                OnPropertyChanged(nameof(Row6Col1Colour));
            }
        }
    }

    private Color _Row6Col2Colour = Colors.White;
    public Color Row6Col2Colour
    {
        get => _Row6Col2Colour;
        set
        {
            if (_Row6Col2Colour != value)
            {
                _Row6Col2Colour = value;
                OnPropertyChanged(nameof(Row6Col2Colour));
            }
        }
    }

    private Color _Row6Col3Colour = Colors.White;
    public Color Row6Col3Colour
    {
        get => _Row6Col3Colour;
        set
        {
            if (_Row6Col3Colour != value)
            {
                _Row6Col3Colour = value;
                OnPropertyChanged(nameof(Row6Col3Colour));
            }
        }
    }

    private Color _Row6Col4Colour = Colors.White;
    public Color Row6Col4Colour
    {
        get => _Row6Col4Colour;
        set
        {
            if (_Row6Col4Colour != value)
            {
                _Row6Col4Colour = value;
                OnPropertyChanged(nameof(Row6Col4Colour));
            }
        }
    }

    private Color _Row6Col5Colour = Colors.White;
    public Color Row6Col5Colour
    {
        get => _Row6Col5Colour;
        set
        {
            if (_Row6Col5Colour != value)
            {
                _Row6Col5Colour = value;
                OnPropertyChanged(nameof(Row6Col5Colour));
            }
        }
    }

} // RowColours