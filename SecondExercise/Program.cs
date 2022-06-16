using SecondExercise;

public class Program
{
    static void Main(string[] args)
    {
        // Create children / nodes
        // Level 1 
        Branch root = new Branch();

        // Level 2
        Branch leftChild = new Branch();
        Branch rightChild = new Branch();

        // Level 3
        Branch leftLeftChild = new Branch();
        Branch rightLeftChild = new Branch();
        Branch rightMiddleChild = new Branch();
        Branch rightRightChild = new Branch();

        // Level 4
        Branch rightLeftLeftChild = new Branch();
        Branch rightMiddleLeftChild = new Branch();
        Branch rightMiddleRightChild = new Branch();

        // Level 5
        Branch rightMiddleLeftMiddleChild = new Branch();

        // Assign children
        // Level 4
        rightMiddleLeftChild.AddBranch(rightMiddleLeftMiddleChild);

        // Level 3
        rightLeftChild.AddBranch(rightLeftLeftChild);

        rightMiddleChild.AddBranchList(new List<Branch>()
        {
            rightMiddleLeftChild,
            rightMiddleRightChild
        });

        // Level 2
        leftChild.AddBranch(leftLeftChild);

        rightChild.AddBranchList(new List<Branch>()
        {
            rightLeftChild,
            rightMiddleChild,
            rightRightChild
        });

        // Level 1
        root.AddBranchList(new List<Branch>()
        {
            leftChild,
            rightChild
        });

        Console.WriteLine($"Branch depth is: {root.GetDepth(0)}");
    }
}
