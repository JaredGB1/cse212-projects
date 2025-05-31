using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function should add an item (which contains both data and priority) to the back of the queue.
    // Expected Result: Bob (Pri:4), Sarah (Pri:10), Emma (Pri:6)
    // Defect(s) Found: No issues Found. The data is added to the end of the queue, no matter the priority.
    public void TestPriorityQueue_1()
    {
        //Creating a new PriorityQueue
        var priorityQueue = new PriorityQueue();
        //Adding data to the priority queue, to check if the data is added at the back of the queue.
        priorityQueue.Enqueue("Bob", 4);
        priorityQueue.Enqueue("Sarah", 10);
        priorityQueue.Enqueue("Emma", 6);
        //Expected Text output
        var expectedText = "[Bob (Pri:4), Sarah (Pri:10), Emma (Pri:6)]";
        //The expected Text should be equal to priorityQueue using ToString()
        Assert.AreEqual(expectedText, priorityQueue.ToString());

    }

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value. If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: Sarah, Isabella, Emma, Bob
    // Defect(s) Found: The Dequeue method did not remove the data from the array. The Dequeue method also didn't ran through the whole array. 
    // If two items had the same priority, It was deleting the item at the back of the queue before the closest to the front.
    //Fixed the first defect by adding the code _queue.RemoveAt(highPriorityIndex) to remove the high Priority index
    //Fixed the Second defect by deleting the -1 from the code < _queue.Count-1 
    //Fixed the third defect by changing the if statement code to _queue[index].Priority > _queue[highPriorityIndex]
    public void TestPriorityQueue_2()
    {
        //Creating a new PriorityQueue
        var priorityQueue = new PriorityQueue();
        //Adding data to the priority queue, to check if the Dequeue function works as expected until the queue is empty.
        //Adding values with the same priority to check if Sarah is Dequeue before Isabella.
        priorityQueue.Enqueue("Sarah", 10);
        priorityQueue.Enqueue("Bob", 4);
        priorityQueue.Enqueue("Emma", 6);
        priorityQueue.Enqueue("Isabella", 10);
        String[] expectedText = ["Sarah", "Isabella", "Emma", "Bob"];
        //Runnning a loop until the queue is empty
        for (int i = 0; i < 4; i++)
        {
            Assert.AreEqual(expectedText[i], priorityQueue.Dequeue());
        }

    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown.
    // Expected Result:  Exception should be thrown with appropriate error message.
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }

    }
}