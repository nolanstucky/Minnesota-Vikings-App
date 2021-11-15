using Minnesota_Vikings_App.Commands;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;


namespace Minnesota_Vikings_App.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int passesAttempted;
        private int passesCompleted;
        private int passingYards;
        private int touchdownPasses;
        private int thrownInterceptions;

        private string playerName;
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
               playerName = value;
               
            }
        }

        public ICommand CalculateQuarterbackCommand { get; }

        public MainPageViewModel()
        {
            CalculateQuarterbackCommand = new CalculateQuarterbackCommand(this);
        }

        public void buttonClick()
        {
            Debug.WriteLine($"Here is name '{PlayerName}'.");
        }

    }

}