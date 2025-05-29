using System.Collections;
using System.Transactions;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        //First I created a new node.
        Node newNode = new(value);
        //If the list is empty, I will point the head and tail to the new node
        if (_tail is null)
        {
            _tail = newNode;
            _head = newNode;
        }
        //If the list is not empty, Only the tail will be affected
        else
        {
            newNode.Prev = _tail; //Connect the new node to the previous tail
            _tail.Next = newNode; //Connect the previous tail with the new node 
            _tail = newNode; //Update the tail with the new node.
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // Check if the list has only one node
        if (_tail == _head)
        {
            // Set both head and tail to null to indicate the list is now empty
            _tail = null;
            _head = null;
        }
        //If the list has more than one item and the tail has a value
        else if (_tail is not null)
        {
            //Disconnect the current tail node from the list by setting the previous node's next to null.
            _tail.Prev!.Next = null;
            //Setting the node before the tail to be the new tail.
            _tail = _tail.Prev;
        }

    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        //Creating a new node with the value of the head of the list.
        Node? curr = _head;
        //Created a while loop to iterate through every node of the linked list.
        while (curr is not null)
        {
            //Checking if the value of the node is equal to the value we want to remove
            if (value == curr.Data)
            {
                if (curr == _tail)
                {
                    RemoveTail(); //If the value is the tail, The remove tail function is used
                }
                else if (curr == _head)
                {
                    RemoveHead(); //If the value is the head, the remove head function is used
                }
                else
                {
                    curr.Next!.Prev = curr.Prev; //Linking the next node with the current previous node
                    curr.Prev!.Next = curr.Next; //Linking the node previous node with the current next node
                }
                return; //Exit the function once first node that contains value is removed
            }
            curr = curr.Next; //Go to the next value
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        //Creating a new node with the value of the head of the list.
        Node? curr = _head;
        //Created a while loop to iterate through every node of the linked list.
        while (curr is not null)
        {
            if (oldValue == curr.Data)
            {
                if (curr == _tail)
                {
                    // If the location of 'value' is at the end of the list, then the tail is removed using the RemoveTail() function,
                    // and a new tail is added using the InsertTail()  function with the "newvalue"
                    RemoveTail();
                    InsertTail(newValue);
                }
                else if (curr == _head)
                {
                    // If the location of 'value' is at the beggining of the list, then the head is removed using the RemoveHead() function,
                    // and a new head is added using the InsertHead() function with the "newvalue"
                    RemoveHead();
                    InsertHead(newValue);
                }
                else
                {
                    //If the location of the value is not at the beggining or end of the list, then the new value is inserted after the oldValue
                    //Using the InsertAfter() Function, and the oldValue is removed using the Remove() function
                    InsertAfter(oldValue, newValue);
                    Remove(oldValue);
                }
            }
            curr = curr.Next; //Going to the next node of the list
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        var curr = _tail; //Start at the end of the list, since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; //Provide (yield) each item to the user
            curr = curr.Prev; //Go backward in the linked list
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}