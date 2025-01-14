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
    // Create an array of the specified length
    double[] multiples = new double[length];

    // Loop through the array and calculate the multiples of the given number
    for (int i = 0; i < length; i++)
    {
        multiples[i] = number * (i + 1); // Multiply the number by (i + 1) to get the multiple
    }

    // Return the array of multiples
    return multiples;
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
    // If the amount is greater than or equal to the list size, we can take the modulo to handle wrapping
    amount = amount % data.Count;

    // Extract the last 'amount' elements and move them to the front
    List<int> lastElements = data.GetRange(data.Count - amount, amount);
    List<int> remainingElements = data.GetRange(0, data.Count - amount);

    // Clear the original list and add the rotated elements
    data.Clear();
    data.AddRange(lastElements);
    data.AddRange(remainingElements);
}
}
