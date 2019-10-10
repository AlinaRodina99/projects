namespace ListMethodsNameSpace
{
    /// <summary>
    /// Interface for method which is defining whether element is null or not.
    /// </summary>
    public interface INullElement<T>
    {
        /// <summary>
        /// Method for defining if element is null.
        /// </summary>
        /// <param name="item">Current element.</param>
        /// <returns>Returns true if element is null and false if element is not null.</returns>
        bool IsNull(T item);
    }
}
