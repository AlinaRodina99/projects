namespace GUIforFTP
{
    /// <summary>
    /// Interface of the elements in folder manager.
    /// </summary>
    public interface IManagerElement
    {
        /// <summary>
        /// Image for the element: file or folder.
        /// </summary>
        string ImagePath { get; }

        /// <summary>
        /// Name of the file or folder.
        /// </summary>
        string ElementName { get; set; }
    }
}
