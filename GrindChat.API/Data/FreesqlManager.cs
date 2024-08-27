namespace GrindChat.API.Data
{
    public class FreesqlManager
    {

        static string connectionStr = "server=SVLYIA;database=GrindChat;uid=sa;pwd=123456;Encrypt=True; TrustServerCertificate=True;";


        private static Lazy<IFreeSql> freeSQL = new Lazy<IFreeSql>(() => new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer, connectionStr)
                .UseAutoSyncStructure(true)
                .Build());
        public static IFreeSql HsjFreeSQL => freeSQL.Value;
    }
}


