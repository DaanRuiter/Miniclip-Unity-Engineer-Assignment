using System.Linq;
using Miniclip.Scoring;
using Miniclip.UI.Displays;
using UnityEngine;

namespace Miniclip.UI.Screens
{
    public class LeaderboardPresenter : UIPresenter<LeaderboardView>
    {
        private IScoreService _scoreService;

        public void Init(IScoreService scoreService)
        {
            _scoreService = scoreService;

            OpenedEvent += FetchScores;
        }

        public void DisplayScores(ScoreData scoreData)
        {
            View.DisposeEntries();

            var sortedEntries = scoreData.Entries.ToList();
            sortedEntries.Sort((scoreA, scoreB) => scoreB.Score - scoreA.Score);

            for (int i = 0; i < sortedEntries.Count; i++)
            {
                var entry = sortedEntries[i];
                var entryDisplay =
                    PrefabFactory.SpawnPrefab<LeaderboardEntryDisplay>("UI/Elements/LeaderboardEntry", View.EntryContainer);

                entryDisplay.Init(entry.PlayerName, entry.Score);
                entryDisplay.transform.SetSiblingIndex(i);
            }
        }

        protected override void OnViewSet()
        {
            View.CloseButtonPressedEvent += Close;
        }

        protected override void OnViewUnSet()
        {
            View.CloseButtonPressedEvent -= Close;
        }

        private void FetchScores()
        {
            _scoreService.FetchScoreData(DisplayScores, () => Debug.LogError($"Failed to load scores"));
        }
    }
}