using System;

namespace Miniclip.Core.Interfaces
{
    public interface IScoreService
    {
        IScoreHandle StartSession();

        void SubmitScore(IScoreHandle handle);

        void FetchScoreData(Action<IScoreData> successCallback, Action failCallback);
    }
}