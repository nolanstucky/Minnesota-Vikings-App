using System;
using System.Windows.Input;
using Minnesota_Vikings_App.ViewModels;

namespace Minnesota_Vikings_App.Commands
{
    //Class that enables button function following mvvm pattern
    public class CalculateQBCommand : ICommand
    {
        private readonly MainPageViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public CalculateQBCommand(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        public bool CanExecute(object parameter) => true;

        public void Execute(object paramter)
        {

            _viewModel.buttonClick();
        }
    }
}
