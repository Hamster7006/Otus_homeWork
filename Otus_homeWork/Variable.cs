namespace Otus_homeWork
{
    public static class VariableData
    {
        private static string? name;
        private static readonly int len = Program.AvalibleComands.GetLength(0);

        public static int Length
        {
            get {
                return len;
            }
        }
        public static string Name
        {
            get { return name; }
            set { name = value; }
        }

        public static string VersionBot
        {
            get
            {
                return "1.2.1";
            }
        }

        public static string DateRelise
        {
            get
            {
                return "16.08.2025";
            }
        }
    }
}
