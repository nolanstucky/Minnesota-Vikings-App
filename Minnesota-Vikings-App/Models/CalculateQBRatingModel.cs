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
        
        public double calculate(int passesAttempted, int passesCompleted, int passingYards, int touchdownPasses, int thrownInterceptions)
        {
            double passCompletionRatio = ((double)passesCompleted / (double)passesAttempted);
            double weightedCompletions = ((passCompletionRatio * 100) - 30) * 0.05;
            return weightedCompletions;
        }
    }
}
