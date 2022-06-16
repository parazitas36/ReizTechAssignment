using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondExercise
{
    public class Branch
    {
        List<Branch> branches;
        public Branch()
        {
            branches = new List<Branch>();
        }

        // Add chlid to the list
        public void AddBranch(Branch branch)
        {
            branches.Add(branch);
        }

        // Add a list of children to the list
        public void AddBranchList(List<Branch> branchList)
        {
            branches.AddRange(branchList);
        }

        // Go recursively through whole hierarchy and return maximum depth for each child
        public int GetDepth(int parentDepth)
        {
            int myDepth = parentDepth + 1;
            int myMaxDepth = myDepth;

            foreach(var branch in branches)
            {
                int depth = branch.GetDepth(myDepth);
                if(depth > myMaxDepth)
                {
                    myMaxDepth = depth;
                }
            }
            return myMaxDepth;
        }
    }
}
