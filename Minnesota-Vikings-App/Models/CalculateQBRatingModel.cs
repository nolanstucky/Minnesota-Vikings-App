using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minnesota_Vikings_App.Models
{
    internal class CalculateQBRatingModel
    {

        public CalculateQBRatingModel()
        {

        }
        //method that takes in the 5 QB stats to calculate the final rating
        public double calculate(int passesAttempted, int passesCompleted, int passingYards, int touchdownPasses, int thrownInterceptions)
        {
            //formula for weighted value of percentage of completions per attempt
            double passCompletionRatio = ((double)passesCompleted / (double)passesAttempted);
            double weightedCompletions = ((passCompletionRatio * 100) - 30) * 0.05;
            weightedCompletions = valueValidate(weightedCompletions);

            //formula for weighted value of average yards gained per attempt
            double averageYardRatio = ((double)passingYards / (double)passesAttempted);
            double weightedAverageYards = ((averageYardRatio - 3) * 0.25);
            weightedAverageYards = valueValidate(weightedAverageYards);

            //formula for weighted value of percentage of touchdown passes
            double touchdownRatio = ((double)touchdownPasses / (double)passesAttempted);
            double weightedTouchdownPasses = ((touchdownRatio * 100) * 0.2);
            weightedTouchdownPasses = valueValidate(weightedTouchdownPasses);

            //formula for weighted value of interceptions
            double interceptionRatio = ((double)thrownInterceptions / (double)passesAttempted);
            double weightedInterceptions = ((interceptionRatio * 100) * 0.25);
            weightedInterceptions = valueValidate(weightedInterceptions);

            //formula for final calculation

            return weightedCompletions;
        }
        //method that takes in the weighted number and validates 
        public double valueValidate(double calculatedNumber)
        {
            if (calculatedNumber > 2.375)
            {
                calculatedNumber = 2.375;
                return calculatedNumber;
            }
            else if (calculatedNumber < 0)
            {
                calculatedNumber = 0;
                return calculatedNumber;
            }
            else return calculatedNumber;
        }
    }
}
