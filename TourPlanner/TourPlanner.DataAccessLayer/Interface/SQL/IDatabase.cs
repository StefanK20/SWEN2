using System.Data;
using System.Data.Common;

namespace TourPlanner.DAL.Interface.SQL
{
    public interface IDatabase
    {
        DbCommand CreateCommand(string cmdText);
        void DefineParameter(DbCommand cmd, string name, DbType type, object value);

        IDataReader ExecuteReader(DbCommand cmd);
        int ExecuteScalar(DbCommand cmd);
        double ExecuteScalarToDouble(DbCommand cmd);
        int ExecuteNonQuery(DbCommand cmd);
    }
}