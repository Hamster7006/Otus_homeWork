namespace Otus_homeWork.Help
{
    public static class VariableData
    {
        internal static string[,] AvalibleComands = new string[10, 2];
        private static readonly int len = AvalibleComands.GetLength(0);

        public static int Length
        {
            get
            {
                return len;
            }
        }
        public static string VersionBot
        {
            get
            {
                return "1.4.1";
            }
        }

        public static string DateRelise
        {
            get
            {
                return "16.09.2025";
            }
        }
    }
}
