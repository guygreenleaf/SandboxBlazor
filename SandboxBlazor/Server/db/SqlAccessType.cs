namespace SandboxBlazor.Server.db
{
    public class SqlAccessType
    {
        public static string Update { get { return "Update"; } }
        public static string Select { get { return "Select"; } }
        public static string Delete { get { return "Delete"; } }
        public static string Insert { get { return "Insert"; } }
        public static string StoredProcedure { get { return "StoredProcedure"; } }
    }
}
