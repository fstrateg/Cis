using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Data;

namespace CisNet.Models
{
    public class OraDriver
    {
        OracleConnection _con = new OracleConnection();
        StringBuilder _sql=new StringBuilder();
        public OraDriver Dbo { get { return _con==null?OraDriver.GetDbo():this; } }

        public static OraDriver GetDbo()
        {
            return new OraDriver();
        }

        public OraDriver Connect()
        {
            OracleConnectionStringBuilder cb = new OracleConnectionStringBuilder();
            cb.UserID = "TRANSIT";
            cb.Password = "Sdff44jBNE&dk$#569";
            cb.DataSource = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.73.15)(PORT=1521)))(CONNECT_DATA=(SID=MURZV)(SERVER=DEDICATED)))";
            _con.ConnectionString = cb.ToString();
            _con.Open();
            return this;
        }

        public OraDriver SetQuery(string sql)
        {
            _sql.Append(sql);
            return this;
        }

        public OracleDataReader GetReader()
        {
            OracleCommand cmd = new OracleCommand(_sql.ToString(), _con);
            return cmd.ExecuteReader();
        }
        
        public DataTable GetTable()
        {
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand(_sql.ToString(), _con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }



        public void Close()
        {
            _con.Close();
        }
    }
}
