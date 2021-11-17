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
        
        private CalculateQBRatingModel qbRatingModel;
        private StringConverterModel converterModel;

        //Player Name variable from user input
        private string playerName = "Player Name";
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
        private string passesAttempted = "0";
        public string PassesAttempted
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
        private string passesCompleted = "0";
        public string PassesCompleted
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
        private string passingYards = "0";
        public string PassingYards
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
        private string touchdownPasses = "0";
        public string TouchdownPasses
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
        private string thrownInterceptions = "0";
        public string ThrownInterceptions
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
        //Variable that is bound to Textblock for qb results
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

        //class used to allow button execute 
        public ICommand CalculateQBCommand { get; }


        public MainPageViewModel()
        {
            CalculateQBCommand = new CalculateQBCommand(this);
            qbRatingModel = new CalculateQBRatingModel(); 
            converterModel = new StringConverterModel();
        }

        public void buttonClick()
        {
            
            //passes in user input variables to CalculateQBRatingModel calculate method to produce QB Rating

            //calculates qbRating from user input while also checking if it's a valid number or not
            double qbRating = qbRatingModel.calculate(converterModel.stringConverter(PassesAttempted), 
                                                      converterModel.stringConverter(PassesCompleted), 
                                                      converterModel.stringConverter(PassingYards), 
                                                      converterModel.stringConverter(TouchdownPasses), 
                                                      converterModel.stringConverter(ThrownInterceptions)
                                                      );
            //Debug.WriteLine(qbRating);
            validateInput(qbRating);

        }
        //method that checks user input errors 
        public void validateInput(double rating)
        {
            if (PlayerName == "")
            {
                ResultTextBlock = "Please enter Player Name.";
            }
            else if (rating == -1)
            {
                ResultTextBlock = "Please enter valid numbers for each field.";
            }
            else if (rating == -2)
            {
                ResultTextBlock = "Player must have at least 1 pass attempted.";
            }
            else
            {
                ResultTextBlock = $"{PlayerName}'s QB Rating is: {rating}";
            }
        }

    }

}