namespace GamePlay.Common.Paths
{
    public class GamePlayAssetsPaths
    {
        public const string Root = "GamePlay/";
        public const string Config = Root + "Config/";

        public const string LogsPrefix = "LogSettings_";
        public const string ServicePrefix = "LocalService_";
        public const string ConfigPrefix = "LocalConfig_";

        private const string _services = Root + "Services/";

        public const string LevelCamera = _services + "LevelCamera/";
        public const string LevelLoop = _services + "LevelLoop/";
        public const string GameBackground = _services + "GameBackground/";
        public const string PaintCanvas = _services + "PaintCanvas/";
        public const string PaintConfig = _services + "PaintConfig/";
        public const string ColorSelection = _services + "ColorSelection/";
        public const string ToolSelection = _services + "ToolSelection/";
        public const string LineFactory = _services + "LineFactory/";
        public const string ToolHandler = _services + "ToolHandler/";
        public const string ImageStorage = _services + "ImageStorage/";
    }
}