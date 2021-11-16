using Minnesota_Vikings_App.Commands;
using Minnesota_Vikings_App.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;


namespace Minnesota_Vikings_App.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged

    {
        //Allows for the update of the window by notifying client that a property has changed
        public event PropertyChangedEventHandler PropertyChanged;
 
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private CalculateQBRatingModel model;

        //Player Name variable from user input
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
        //Number of Passes Attempted variable from user input
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
        //Number of Passes Completed variable from user input
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
        //Number of Passing Yards variable from user input
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
        //Number of Touchdown Passes from user input
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
        //Number of Thrown Interceptions from user input
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

        private string resultTextBlock;
        public string ResultTextBlock
        {
            get
            {
                return resultTextBlock;
            }
            set
            {
                resultTextBlock = value;
                //used to notify that the resulttextblock value has changed and to update client
                OnPropertyChanged("ResultTextBlock");
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
            //passes in user input variables to CalculateQBRatingModel calculate method to produce QB Rating
            double qbRating = model.calculate(PassesAttempted, PassesCompleted, PassingYards, TouchdownPasses, ThrownInterceptions) ;
            Debug.WriteLine(qbRating);

            ResultTextBlock = $"{PlayerName}'s QB Rating is: {qbRating}";
            //ResultTextBlock = "Test";
            Debug.WriteLine(ResultTextBlock);


        }

    }

}