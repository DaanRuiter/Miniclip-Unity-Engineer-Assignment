using System.Linq;
using Miniclip.Core.Interfaces;
using Miniclip.Core.UI.Elements;
using UnityEngine;

namespace Miniclip.Core.UI.Screens
{
    public class LeaderboardPresenter : UIPresenter<LeaderboardView>
    {
        private IScoreService _scoreService;

        public void Init(IScoreService scoreService)
        {
            _scoreService = scoreService;

            OpenedEvent += FetchScores;
        }

        public void DisplayScores(IScoreData scoreData)
        {
            View.DisposeEntries();

            var sortedEntries = scoreData.ScoreEntries.ToList();
            sortedEntries.Sort((scoreA, scoreB) => scoreB.PlayerScore - scoreA.PlayerScore);

            for (int i = 0; i < sortedEntries.Count; i++)
            {
                var entry = sortedEntries[i];
                var entryDisplay =
                    PrefabFactory.SpawnPrefab<LeaderboardEntryDisplay>("UI/Elements/LeaderboardEntry",
                        View.EntryContainer);

                entryDisplay.Init(entry.PlayerName, entry.PlayerScore);
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