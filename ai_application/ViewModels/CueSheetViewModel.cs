using System.ComponentModel;

public class CueSheetViewModel : INotifyPropertyChanged
{
    public CueSheet CueSheet { get; set; }

    public CueSheetViewModel(CueSheet cueSheet)
    {
        CueSheet = cueSheet;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
