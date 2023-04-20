namespace Miniclip.Core
{
    /// <summary>
    /// A presenter for any visual component.
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Set the visibility of the visual component.
        /// </summary>
        /// <param name="visible">Desired visibility state.</param>
        void SetVisible(bool visible);

        /// <summary>
        /// Destroy and dispose of the visual component and any dependencies
        /// </summary>
        void Destroy();
    }
}