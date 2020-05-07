namespace Lazy_sem3.task1
{
    /// <summary>
    /// Lazy computations interface.
    /// </summary>
    public interface ILazy<T>
    {
        /// <summary>
        /// Method to get result of the computation.
        /// </summary>
        T Get();
    }
}
