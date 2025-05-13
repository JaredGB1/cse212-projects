public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //To do the project, I will create a list(because it already has an Add method), multiply the number starting by 1 until reaching the length number, and add the multiple to the list.
        // Create a new empty List
        var newList = new List<double>();
        //Create a for loop to get the multiples. The for loop will iterate until reaching the length.
        for (int i = 1; i <= length; i++)
        {
            //Multiply the number and add it into the list
            newList.Add(i * number);
        }
        return newList.ToArray(); // return the list as an array.
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //To do the project, I will rotate the data inserting the last index data into the first index and removing the last index after saving its data in the first index.
        //Create a for loop to iterate the amount of times requested
        for (int i = 0; i < amount; i++)
        {
            //Insert the last index value to the first index
            data.Insert(0, data[data.Count - 1]);
            //Remove the existing value at the last index
            data.RemoveAt(data.Count - 1);
        }
    }
}
