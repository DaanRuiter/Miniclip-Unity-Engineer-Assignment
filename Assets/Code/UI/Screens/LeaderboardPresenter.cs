using Miniclip.Scoring;
using Miniclip.UI.Displays;

namespace Miniclip.UI.Screens
{
    public class LeaderboardPresenter : UIPresenter<LeaderboardView>
    {
        public void DisplayScores(ScoreData scoreData)
        {
            View.DisposeEntries();

            for (int i = 0; i < scoreData.Entries.Length; i++)
            {
                var entry = scoreData.Entries[i];
                var entryDisplay =
                    PrefabFactory.SpawnPrefab<LeaderboardEntryDisplay>("UI/LeaderboardEntryDisplay",
                        View.EntryContainer);

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
    }
}