public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        //Using the new Contain function to check if the value is in the BST
        if (Contains(value) == true)
        {//If the value is found, the new value will not be added.
         //This is because the value will not be unique
            return;
        }
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Checking if the value is inside the Binary Search Tree
        if (Data == value)
        {
            //return true if the value is inside the BST
            return true;
        }
        if (value < Data)
        {
            //Checking the Left Values with recursion
            if (Left is not null)
            {
                return Left.Contains(value);
            }
        }
        else
        {
            //Checking the Right Values with recursion
            if (Right is not null)
            {
                return Right.Contains(value);
            }
        }
        return false;
    }

    public int GetHeight()
    {
        int leftHeight = 0;
        int rightHeight = 0;
        if (Left is not null)
        {
            //If a value in Left is found, the leftHeight will increase by 1
            leftHeight = +Left.GetHeight();
        }
        if (Right is not null)
        {
            //If a value in Right is found, the rightHeight will increase by 1
            rightHeight = +Right.GetHeight();
        }
        //Returning the Max Height
        return 1 + Math.Max(rightHeight, leftHeight);
    }
}