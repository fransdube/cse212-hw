using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Original implementation didn't remove items from queue and had incorrect loop bounds
    public void TestPriorityQueue_BasicFunctionality()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 2);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: Items should be dequeued in FIFO order when priorities are equal
    // Defect(s) Found: Original implementation didn't maintain FIFO order for same priority items
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 1);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities including duplicates
    // Expected Result: Highest priority items dequeued first, with FIFO for same priority
    // Defect(s) Found: Original implementation didn't properly handle mixed priorities
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 1);
        priorityQueue.Enqueue("Item4", 3);
        priorityQueue.Enqueue("Item5", 2);

        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item5", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Exception should be thrown with appropriate message
    // Defect(s) Found: None - this test case passed originally
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: Item should be dequeued successfully
    // Defect(s) Found: Original implementation didn't remove the item from queue
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual(0, priorityQueue.ToString().Length - 2); // Check queue is empty
    }

    [TestMethod]
    // Scenario: Enqueue items with negative priorities
    // Expected Result: Items should be dequeued according to priority rules
    // Defect(s) Found: Original implementation should handle negative priorities
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", -1);
        priorityQueue.Enqueue("Item2", -2);
        priorityQueue.Enqueue("Item3", -3);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }
}