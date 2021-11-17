using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minnesota_Vikings_App.Models
{
    internal class StringConverterModel
    {
        public StringConverterModel()
        {

        }

        public int stringConverter(string userInputString)
        {
            int x = 0;
            int userInputNum;

            // if variable is an int it will parse and store the variable otherwise it returns -1
            if (Int32.TryParse(userInputString, out x))
            {
                userInputNum = Int32.Parse(userInputString);
                return userInputNum;
            } else
            {
                return -1;
            }
        }
           
    }
}
