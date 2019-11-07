using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track of the current tower.
/// </summary>
public class TrackedLinkedList<T> : IEnumerable
{

    private LinkedList<T> objects = new LinkedList<T>();

    private LinkedListNode<T> current = null;

    #region Fields
    /// <summary>
    /// Gets the current value of the list.
    /// </summary>
    public T CurrentValue
    {
        get => current.Value;
    }

    /// <summary>
    /// Gets the number of objects in the list.
    /// </summary>
    public int Count
    {
        get => objects.Count;
    }

    /// <summary>
    /// Gets the value of the first object in the list.
    /// </summary>
    public T First
    {
        get => objects.First.Value;
    }

    /// <summary>
    /// Gets the value of the last object in the list.
    /// </summary>
    public T Last
    {
        get => objects.Last.Value;
    }
    #endregion Fields

    #region Public Methods
    /// <summary>
    /// Moves the the next location in the list.
    /// </summary>
    public void GoToNext()
    {
        current = current?.Next ?? objects.First;
    }

    /// <summary>
    /// Moves to the previous location in the list.
    /// </summary>
    public void GoToPrevious()
    {
        current = current?.Previous ?? objects.Last;
    }

    /// <summary>
    /// Adds the value after the current object.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void AddObjectAfterCurrent(T value)
    {
        objects.AddAfter(current, value);
    }

    /// <summary>
    /// Adds the value before the current object.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void AddObjectBeforeCurrent(T value)
    {
        objects.AddBefore(current, value);
    }

    /// <summary>
    /// Adds the value at the end of the list.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void AddObjectAtEnd(T value)
    {
        objects.AddLast(value);
    }

    /// <summary>
    /// Places an object at the start of the list.
    /// </summary>
    /// <param name="value">The value to add to the list.</param>
    public void AddObjectAtStart(T value)
    {
        objects.AddFirst(value);
    }

    /// <summary>
    /// Alias for TrackedLinkedList.AddObjectAtEnd().
    /// </summary>
    /// <param name="value">The value to be added to the list.</param>
    /// <see cref="TrackedLinkedList{T}.AddObjectAtEnd(T)"/>
    public void Add(T value)
    {
        AddObjectAtEnd(value);
    }

    /// <summary>
    /// Removes the value from the list.
    /// </summary>
    /// <param name="value">The value to be removed.</param>
    public void Remove(T value)
    {
        objects.Remove(value);
    }

    #endregion Public Methods

    #region Private Methods
    private void SetFirst()
    {
        if (current == null)
            current = objects.First;
    }
    #endregion

    #region Interface Implementations
    public IEnumerator<T> GetEnumerator()
    {
        return objects.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    #endregion Interface Implementations
}
