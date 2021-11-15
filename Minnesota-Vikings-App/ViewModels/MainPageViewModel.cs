using Minnesota_Vikings_App.Commands;
using Minnesota_Vikings_App.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;


namespace Minnesota_Vikings_App.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;
        private CalculateQBRatingModel model;

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

        private int passesAttempted;
        public int PassesAttempted
        {
            get
            {
                return passesAttempted;
            }
            set
            {
                passesAttempted = value;

            }
        }

        private int passesCompleted;
        public int PassesCompleted
        {
            get
            {
                return passesCompleted;
            }
            set
            {
                passesCompleted = value;

            }
        }

        private int passingYards;
        public int PassingYards
        {
            get
            {
                return passingYards;
            }
            set
            {
                passingYards = value;

            }
        }

        private int touchdownPasses;
        public int TouchdownPasses
        {
            get
            {
                return touchdownPasses;
            }
            set
            {
                touchdownPasses = value;

            }
        }

        private int thrownInterceptions;
        public int ThrownInterceptions
        {
            get
            {
                return thrownInterceptions;
            }
            set
            {
                thrownInterceptions = value;

            }
        }

        public ICommand CalculateQBCommand { get; }

        public MainPageViewModel()
        {
            CalculateQBCommand = new CalculateQBCommand(this);
            model = new CalculateQBRatingModel(); 
        }

        public void buttonClick()
        {
            Debug.WriteLine($"Here is name '{PlayerName} {PassesAttempted}'.");
            double qbRating = model.calculate(PassesAttempted, PassesCompleted, PassingYards, TouchdownPasses, ThrownInterceptions) ;
            Debug.WriteLine(qbRating);
        }

    }

}