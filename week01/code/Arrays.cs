public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of doubles with the specified length
        double[] result = new double[length];

        // Step 2: Fill the array with multiples of the input number
        // The first element is number*1, second is number*2, etc.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Step 3: Return the populated array
        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Handle edge case - if amount equals list count, no rotation needed
        if (amount == data.Count)
        {
            return;
        }

        // Step 2: Calculate the split point (where the rotation occurs)
        int splitIndex = data.Count - amount;

        // Step 3: Get the right part that needs to be moved to the front
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 4: Remove the right part from its original position
        data.RemoveRange(splitIndex, amount);

        // Step 5: Insert the right part at the beginning of the list
        data.InsertRange(0, rightPart);

        // Note: The list is modified in place as required by the problem statement
    }
}
