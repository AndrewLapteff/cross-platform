using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossplatform
{
    internal class DominoSet
    {
        public int CalculateTotalPoints(int maxPoints)
        {
            int totalPoints = 0;

            for (int i = 0; i <= maxPoints; i++)
            {
                for (int j = i; j <= maxPoints; j++)
                {
                    totalPoints += i + j;
                }
            }

            return totalPoints;
        }
    }
}
