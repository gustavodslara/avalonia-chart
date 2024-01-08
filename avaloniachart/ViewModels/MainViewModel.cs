using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using xamarinchart.Services;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace avaloniachart.ViewModels;

public class MainViewModel : ViewModelBase , INotifyPropertyChanged
{
    private ProgrammerService _programmerService;

    public ISeries[] Series { get; set; }
    public Axis[] XAxes { get; set; }

    public MainViewModel()
    {
        _programmerService = new ProgrammerService();
        var p = _programmerService.GetAllProgrammers();
        Greeting = p[0].Name;

        Series = new ISeries[]
        {
            new ColumnSeries<double>
            {
                Name = "Demand",
                Values = new double[] { p[0].Demand, p[1].Demand, p[2].Demand, p[3].Demand }
            },
            new ColumnSeries<double>
            {
                Name = "Offer",
                Values = new double[] { p[0].Offer, p[1].Offer, p[2].Offer, p[3].Offer }
            }
        };

        XAxes = new Axis[]
        {
            new Axis
            {
                Labels = new string[] { p[0].Name, p[1].Name,p[2].Name, p[3].Name },
                LabelsRotation = 0,
                SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                SeparatorsAtCenter = false,
                TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                TicksAtCenter = true,
                ForceStepToMin = true,
                MinStep = 1
            }
        };
    }

    private string _greeting;

    public string Greeting
    {
        get { return _greeting; }
        set
        {
            if (_greeting != value)
            {
                _greeting = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
