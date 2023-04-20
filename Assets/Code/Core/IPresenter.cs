namespace Miniclip.Core
{
    public interface IPresenter
    {
        void SetVisible(bool visible);
        
        void Destroy();
    }
}