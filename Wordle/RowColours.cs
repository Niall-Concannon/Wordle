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
    private Color _Row1Col1Colour = Colors.White;
    private Color _Row1Col1TextColour = Colors.Black;
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
    public Color Row1Col1TextColour
    {
        get => _Row1Col1TextColour;
        set
        {
            if (_Row1Col1TextColour != value)
            {
                _Row1Col1TextColour = value;
                OnPropertyChanged(nameof(Row1Col1TextColour));
            }
        }
    }

    private Color _Row1Col2Colour = Colors.White;
    private Color _Row1Col2TextColour = Colors.Black;
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
    public Color Row1Col2TextColour
    {
        get => _Row1Col2TextColour;
        set
        {
            if (_Row1Col2TextColour != value)
            {
                _Row1Col2TextColour = value;
                OnPropertyChanged(nameof(Row1Col2TextColour));
            }
        }
    }

    private Color _Row1Col3Colour = Colors.White;
    private Color _Row1Col3TextColour = Colors.Black;
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
    public Color Row1Col3TextColour
    {
        get => _Row1Col3TextColour;
        set
        {
            if (_Row1Col3TextColour != value)
            {
                _Row1Col3TextColour = value;
                OnPropertyChanged(nameof(Row1Col3TextColour));
            }
        }
    }

    private Color _Row1Col4Colour = Colors.White;
    private Color _Row1Col4TextColour = Colors.Black;
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
    public Color Row1Col4TextColour
    {
        get => _Row1Col4TextColour;
        set
        {
            if (_Row1Col4TextColour != value)
            {
                _Row1Col4TextColour = value;
                OnPropertyChanged(nameof(Row1Col4TextColour));
            }
        }
    }

    private Color _Row1Col5Colour = Colors.White;
    private Color _Row1Col5TextColour = Colors.Black;
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
    public Color Row1Col5TextColour
    {
        get => _Row1Col5TextColour;
        set
        {
            if (_Row1Col5TextColour != value)
            {
                _Row1Col5TextColour = value;
                OnPropertyChanged(nameof(Row1Col5TextColour));
            }
        }
    }

    // Row 2 colours
    private Color _Row2Col1Colour = Colors.White;
    private Color _Row2Col1TextColour = Colors.Black;
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
    public Color Row2Col1TextColour
    {
        get => _Row2Col1TextColour;
        set
        {
            if (_Row2Col1TextColour != value)
            {
                _Row2Col1TextColour = value;
                OnPropertyChanged(nameof(Row2Col1TextColour));
            }
        }
    }

    private Color _Row2Col2Colour = Colors.White;
    private Color _Row2Col2TextColour = Colors.Black;
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
    public Color Row2Col2TextColour
    {
        get => _Row2Col2TextColour;
        set
        {
            if (_Row2Col2TextColour != value)
            {
                _Row2Col2TextColour = value;
                OnPropertyChanged(nameof(Row2Col2TextColour));
            }
        }
    }

    private Color _Row2Col3Colour = Colors.White;
    private Color _Row2Col3TextColour = Colors.Black;
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
    public Color Row2Col3TextColour
    {
        get => _Row2Col3TextColour;
        set
        {
            if (_Row2Col3TextColour != value)
            {
                _Row2Col3TextColour = value;
                OnPropertyChanged(nameof(Row2Col3TextColour));
            }
        }
    }

    private Color _Row2Col4Colour = Colors.White;
    private Color _Row2Col4TextColour = Colors.Black;
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
    public Color Row2Col4TextColour
    {
        get => _Row2Col4TextColour;
        set
        {
            if (_Row2Col4TextColour != value)
            {
                _Row2Col4TextColour = value;
                OnPropertyChanged(nameof(Row2Col4TextColour));
            }
        }
    }

    private Color _Row2Col5Colour = Colors.White;
    private Color _Row2Col5TextColour = Colors.Black;
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
    public Color Row2Col5TextColour
    {
        get => _Row2Col5TextColour;
        set
        {
            if (_Row2Col5TextColour != value)
            {
                _Row2Col5TextColour = value;
                OnPropertyChanged(nameof(Row2Col5TextColour));
            }
        }
    }

    // Repeat the same pattern for Row 3, Row 4, Row 5, Row 6
    // Row 3
    private Color _Row3Col1Colour = Colors.White;
    private Color _Row3Col1TextColour = Colors.Black;
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
    public Color Row3Col1TextColour
    {
        get => _Row3Col1TextColour;
        set
        {
            if (_Row3Col1TextColour != value)
            {
                _Row3Col1TextColour = value;
                OnPropertyChanged(nameof(Row3Col1TextColour));
            }
        }
    }

    private Color _Row3Col2Colour = Colors.White;
    private Color _Row3Col2TextColour = Colors.Black;
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
    public Color Row3Col2TextColour
    {
        get => _Row3Col2TextColour;
        set
        {
            if (_Row3Col2TextColour != value)
            {
                _Row3Col2TextColour = value;
                OnPropertyChanged(nameof(Row3Col2TextColour));
            }
        }
    }

    private Color _Row3Col3Colour = Colors.White;
    private Color _Row3Col3TextColour = Colors.Black;
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
    public Color Row3Col3TextColour
    {
        get => _Row3Col3TextColour;
        set
        {
            if (_Row3Col3TextColour != value)
            {
                _Row3Col3TextColour = value;
                OnPropertyChanged(nameof(Row3Col3TextColour));
            }
        }
    }

    private Color _Row3Col4Colour = Colors.White;
    private Color _Row3Col4TextColour = Colors.Black;
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
    public Color Row3Col4TextColour
    {
        get => _Row3Col4TextColour;
        set
        {
            if (_Row3Col4TextColour != value)
            {
                _Row3Col4TextColour = value;
                OnPropertyChanged(nameof(Row3Col4TextColour));
            }
        }
    }

    private Color _Row3Col5Colour = Colors.White;
    private Color _Row3Col5TextColour = Colors.Black;
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
    public Color Row3Col5TextColour
    {
        get => _Row3Col5TextColour;
        set
        {
            if (_Row3Col5TextColour != value)
            {
                _Row3Col5TextColour = value;
                OnPropertyChanged(nameof(Row3Col5TextColour));
            }
        }
    }

    // Row 4 colours
    private Color _Row4Col1Colour = Colors.White;
    private Color _Row4Col1TextColour = Colors.Black;
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
    public Color Row4Col1TextColour
    {
        get => _Row4Col1TextColour;
        set
        {
            if (_Row4Col1TextColour != value)
            {
                _Row4Col1TextColour = value;
                OnPropertyChanged(nameof(Row4Col1TextColour));
            }
        }
    }

    private Color _Row4Col2Colour = Colors.White;
    private Color _Row4Col2TextColour = Colors.Black;
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
    public Color Row4Col2TextColour
    {
        get => _Row4Col2TextColour;
        set
        {
            if (_Row4Col2TextColour != value)
            {
                _Row4Col2TextColour = value;
                OnPropertyChanged(nameof(Row4Col2TextColour));
            }
        }
    }

    private Color _Row4Col3Colour = Colors.White;
    private Color _Row4Col3TextColour = Colors.Black;
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
    public Color Row4Col3TextColour
    {
        get => _Row4Col3TextColour;
        set
        {
            if (_Row4Col3TextColour != value)
            {
                _Row4Col3TextColour = value;
                OnPropertyChanged(nameof(Row4Col3TextColour));
            }
        }
    }

    private Color _Row4Col4Colour = Colors.White;
    private Color _Row4Col4TextColour = Colors.Black;
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
    public Color Row4Col4TextColour
    {
        get => _Row4Col4TextColour;
        set
        {
            if (_Row4Col4TextColour != value)
            {
                _Row4Col4TextColour = value;
                OnPropertyChanged(nameof(Row4Col4TextColour));
            }
        }
    }

    private Color _Row4Col5Colour = Colors.White;
    private Color _Row4Col5TextColour = Colors.Black;
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
    public Color Row4Col5TextColour
    {
        get => _Row4Col5TextColour;
        set
        {
            if (_Row4Col5TextColour != value)
            {
                _Row4Col5TextColour = value;
                OnPropertyChanged(nameof(Row4Col5TextColour));
            }
        }
    }

    // Row 5 colours
    private Color _Row5Col1Colour = Colors.White;
    private Color _Row5Col1TextColour = Colors.Black;
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
    public Color Row5Col1TextColour
    {
        get => _Row5Col1TextColour;
        set
        {
            if (_Row5Col1TextColour != value)
            {
                _Row5Col1TextColour = value;
                OnPropertyChanged(nameof(Row5Col1TextColour));
            }
        }
    }

    private Color _Row5Col2Colour = Colors.White;
    private Color _Row5Col2TextColour = Colors.Black;
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
    public Color Row5Col2TextColour
    {
        get => _Row5Col2TextColour;
        set
        {
            if (_Row5Col2TextColour != value)
            {
                _Row5Col2TextColour = value;
                OnPropertyChanged(nameof(Row5Col2TextColour));
            }
        }
    }

    private Color _Row5Col3Colour = Colors.White;
    private Color _Row5Col3TextColour = Colors.Black;
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
    public Color Row5Col3TextColour
    {
        get => _Row5Col3TextColour;
        set
        {
            if (_Row5Col3TextColour != value)
            {
                _Row5Col3TextColour = value;
                OnPropertyChanged(nameof(Row5Col3TextColour));
            }
        }
    }

    private Color _Row5Col4Colour = Colors.White;
    private Color _Row5Col4TextColour = Colors.Black;
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
    public Color Row5Col4TextColour
    {
        get => _Row5Col4TextColour;
        set
        {
            if (_Row5Col4TextColour != value)
            {
                _Row5Col4TextColour = value;
                OnPropertyChanged(nameof(Row5Col4TextColour));
            }
        }
    }

    private Color _Row5Col5Colour = Colors.White;
    private Color _Row5Col5TextColour = Colors.Black;
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
    public Color Row5Col5TextColour
    {
        get => _Row5Col5TextColour;
        set
        {
            if (_Row5Col5TextColour != value)
            {
                _Row5Col5TextColour = value;
                OnPropertyChanged(nameof(Row5Col5TextColour));
            }
        }
    }

    // Row 6 colours
    private Color _Row6Col1Colour = Colors.White;
    private Color _Row6Col1TextColour = Colors.Black;
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
    public Color Row6Col1TextColour
    {
        get => _Row6Col1TextColour;
        set
        {
            if (_Row6Col1TextColour != value)
            {
                _Row6Col1TextColour = value;
                OnPropertyChanged(nameof(Row6Col1TextColour));
            }
        }
    }

    private Color _Row6Col2Colour = Colors.White;
    private Color _Row6Col2TextColour = Colors.Black;
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
    public Color Row6Col2TextColour
    {
        get => _Row6Col2TextColour;
        set
        {
            if (_Row6Col2TextColour != value)
            {
                _Row6Col2TextColour = value;
                OnPropertyChanged(nameof(Row6Col2TextColour));
            }
        }
    }

    private Color _Row6Col3Colour = Colors.White;
    private Color _Row6Col3TextColour = Colors.Black;
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
    public Color Row6Col3TextColour
    {
        get => _Row6Col3TextColour;
        set
        {
            if (_Row6Col3TextColour != value)
            {
                _Row6Col3TextColour = value;
                OnPropertyChanged(nameof(Row6Col3TextColour));
            }
        }
    }

    private Color _Row6Col4Colour = Colors.White;
    private Color _Row6Col4TextColour = Colors.Black;
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
    public Color Row6Col4TextColour
    {
        get => _Row6Col4TextColour;
        set
        {
            if (_Row6Col4TextColour != value)
            {
                _Row6Col4TextColour = value;
                OnPropertyChanged(nameof(Row6Col4TextColour));
            }
        }
    }

    private Color _Row6Col5Colour = Colors.White;
    private Color _Row6Col5TextColour = Colors.Black;
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
    public Color Row6Col5TextColour
    {
        get => _Row6Col5TextColour;
        set
        {
            if (_Row6Col5TextColour != value)
            {
                _Row6Col5TextColour = value;
                OnPropertyChanged(nameof(Row6Col5TextColour));
            }
        }
    }

} // RowColours