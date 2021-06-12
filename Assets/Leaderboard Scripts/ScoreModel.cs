using System;

namespace Leaderboard_Scripts
{
    [Serializable]
    public class ScoreModel
    {
        public int id;
        public string player;
        public string score;
    }

    [Serializable]
    public class RootScoreModel
    {
        public ScoreModel[] scores;
    }
}