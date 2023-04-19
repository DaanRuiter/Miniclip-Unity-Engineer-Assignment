using UnityEngine;

namespace Miniclip.Core
{
    public class GameScoreService
    {
        public GameScoreHandle StartSession()
        {
            var handle = new GameScoreHandle();

            handle.SubmitScoreEvent += SubmitScore;

            return handle;
        }

        public void SubmitScore(GameScoreHandle handle)
        {
            handle.SubmitScoreEvent -= SubmitScore;
        }
    }
}