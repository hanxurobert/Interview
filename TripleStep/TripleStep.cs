namespace TripleStep {
    public class TripleStep {
        public int CountPossiblity(int staireSteps) {
             int count = 0;
             if (staireSteps == 0) { count++; }
             if (staireSteps >= 1) { count += CountPossiblity(staireSteps - 1); }
             if (staireSteps >= 2) { count += CountPossiblity(staireSteps - 2); } 
             if (staireSteps >= 3) { count += CountPossiblity(staireSteps - 3); }

             return count;
        }
    }
}