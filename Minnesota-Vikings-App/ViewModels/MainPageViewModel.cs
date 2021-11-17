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
        private string passesAttempted;
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
        private string passesCompleted;
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
        private string passingYards;
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
        private string touchdownPasses;
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
        private string thrownInterceptions;
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
            qbRatingModel = new CalculateQBRatingModel(); 
            converterModel = new StringConverterModel();
        }

        public void buttonClick()
        {
            Debug.WriteLine(PlayerName);
            //passes in user input variables to CalculateQBRatingModel calculate method to produce QB Rating

            //calculates qbRating from user input while also checking if it's a valid number or not
            double qbRating = qbRatingModel.calculate(converterModel.stringConverter(PassesAttempted), 
                                                      converterModel.stringConverter(PassesCompleted), 
                                                      converterModel.stringConverter(PassingYards), 
                                                      converterModel.stringConverter(TouchdownPasses), 
                                                      converterModel.stringConverter(ThrownInterceptions)
                                                      );
            Debug.WriteLine(qbRating);
            //ResultTextBlock = "Test";
            Debug.WriteLine(ResultTextBlock);

            if (qbRating == -1)
            {
                ResultTextBlock = "Please enter valid numbers for each field";
            } else
            {
                ResultTextBlock = $"{PlayerName}'s QB Rating is: {qbRating}";
            }

        }

    }

}