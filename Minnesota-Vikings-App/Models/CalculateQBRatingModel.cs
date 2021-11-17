using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //checks to see if any number equals negative which would equate user input being an error
            if (passesAttempted == -1 || passesCompleted == -1 || passingYards == -1 || touchdownPasses == -1 || thrownInterceptions == -1)
            {
                return -1;
            }
            
            if (passesAttempted < 1)
            {
                return -2;
            }
            //formula for weighted value of percentage of completions per attempt
            double passCompletionRatio = ((double)passesCompleted / (double)passesAttempted);
            double weightedCompletions = ((passCompletionRatio * 100) - 30) * 0.05;
            weightedCompletions = valueValidate(weightedCompletions, false);
            
            //Debug.WriteLine($"weightedCompletions {weightedCompletions}");

            //formula for weighted value of average yards gained per attempt
            double averageYardRatio = ((double)passingYards / (double)passesAttempted);
            double weightedAverageYards = ((averageYardRatio - 3) * 0.25);
            weightedAverageYards = valueValidate(weightedAverageYards,false);

            //Debug.WriteLine($"weightedAverageYards {weightedAverageYards}");

            //formula for weighted value of percentage of touchdown passes
            double touchdownRatio = ((double)touchdownPasses / (double)passesAttempted);
            double weightedTouchdownPasses = ((touchdownRatio * 100) * 0.2);
            weightedTouchdownPasses = valueValidate(weightedTouchdownPasses,true);

            //Debug.WriteLine($"weightedTouchdownPasses {weightedTouchdownPasses}");

            //formula for weighted value of interceptions
            double interceptionRatio = ((double)thrownInterceptions / (double)passesAttempted);
            double weightedInterceptionsMulti = ((interceptionRatio * 100) * 0.25);
            double weightedInterceptions = (2.375 - weightedInterceptionsMulti);
            weightedInterceptions = valueValidate(weightedInterceptions,false);

            //Debug.WriteLine($"weightedInterceptions {weightedInterceptions}");

            //formula for final calculation
            double finalCalculationRatio = ((double)(weightedCompletions + weightedAverageYards + weightedTouchdownPasses + weightedInterceptions) / (double)6);
            double finalCalculation = (finalCalculationRatio * 100);

            //Debug.WriteLine($"finalCalculationRatio {finalCalculationRatio}");
            //Debug.WriteLine($"finalCalculation {finalCalculation}");

            //rounds calculation to 1 decimal
            finalCalculation = Math.Round(finalCalculation, 1);
            //returns the final calculation number
            return finalCalculation;
        }
        //method that takes in the weighted number and validates it with a min value of 0 and a max of 2.375
        public double valueValidate(double calculatedNumber, bool canBeNegative)
        {
            if (calculatedNumber > 2.375)
            {
                calculatedNumber = 2.375;
                return calculatedNumber;
            }
            else if (calculatedNumber < 0 && !canBeNegative)
            {
                calculatedNumber = 0;
                return calculatedNumber;
            }
            else return calculatedNumber;
        }
    }
}
