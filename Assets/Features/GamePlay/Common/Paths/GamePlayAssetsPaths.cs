namespace GamePlay.Common.Paths
{
    public class GamePlayAssetsPaths
    {
        public const string Root = "GamePlay/";
        public const string Config = Root + "Config/";

        public const string LogsPrefix = "LogSettings_";
        public const string ServicePrefix = "LocalService_";
        public const string ConfigPrefix = "LocalConfig_";
        public const string QuestionPrefix = "Question_";
        public const string AnswerPrefix = "Question_";

        private const string _services = Root + "Services/";

        public const string LevelCamera = _services + "LevelCamera/";
        public const string LevelLoop = _services + "LevelLoop/";
        public const string Quiz = _services + "Quiz/";
        public const string QuizUi = _services + "QuizUi/";
        public const string QuestionsStorage = _services + "QuestionsStorage/";
        public const string QuizLoop = _services + "QuizLoop/";
        public const string Score = _services + "Score/";
        public const string Final = _services + "Final/";
        public const string Health = _services + "Health/";
        public const string DeathMenu = _services + "DeathMenu/";

        public const string GameBackground = _services + "GameBackground/";
    }
}