using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace StockAppV3

{
    class DatabaseUtility
    {

        public static string WorkerName = "";
        public static string WorkerAge = "";
        public static string WorkerNationality = "";
        public static string WorkerPhoneNr = "";
        public static string WorkerPayRate = "";
        public static string WorkerScanner = "";
        public static string WorkerDescription = "";
        public static string WorkerIplOrAgency = "";
        public static string WorkerHolidays = "";
        public static bool WorkerFlag;
        public static string WorkerCons = "";
        public static string WorkerPros = "";
        public static string WorkerDepartment = "";

        public static string[] listed = new string[] {
            WorkerName,
            WorkerAge,
            WorkerNationality,
            WorkerPhoneNr,
            WorkerPayRate,
            WorkerDescription,
            WorkerIplOrAgency,
            WorkerHolidays
            ,WorkerCons,
            WorkerPros,
            WorkerDepartment };


        public static OleDbConnection ConnectToDb()
        {

            string ConnStr = "Provider = Microsoft.ACE.OLEDB.12.0; data source=Workers.mdb";
            OleDbConnection con = new OleDbConnection(ConnStr);
            con.Open();
            return con;
        }

        public static string getData(int id)
        {
            string data = "";
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT * from WorkersTable WHERE WID=" + id + "", ConnectToDb());
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                data = reader["WorkerName"].ToString();
            }
            return data;
        }
        public static string getData(int id,string table)
        {
            string data = "";
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT * from " +table+ " ", ConnectToDb());
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                data = reader["WorkerName"].ToString();
            }
            return data;
        }

        public static void getData(string UserName,string department)
        {
            OleDbDataReader reader = null;

            OleDbCommand command = new OleDbCommand("SELECT * from WorkersTable WHERE WorkerName='" +UserName+ "' AND WorkerDepartment='"+department+"'", ConnectToDb());
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                WorkerName = (reader["WorkerName"].ToString());
                WorkerAge = (reader["WorkerAge"].ToString());
                WorkerNationality = (reader["WorkerNationality"].ToString());
                WorkerPayRate = (reader["WorkerPayRate"].ToString());
                WorkerPhoneNr = (reader["WorkerPhone"].ToString());
                WorkerDescription = (reader["WorkerDescription"].ToString());
                WorkerIplOrAgency = (reader["WorkerContract"].ToString());
                WorkerHolidays = (reader["WorkerHolidays"].ToString());
                WorkerFlag = Convert.ToBoolean(reader["WorkerFlag"]);
                WorkerCons = (reader["WorkerCons"].ToString());
                WorkerPros = (reader["WorkerPros"].ToString());
                WorkerDepartment = (reader["WorkerDepartment"].ToString());
            }

            CloseDb();
        }

        public static int SelectCount(string tableName)
        {
            OleDbDataReader reader = null;
            int count = 0;
            OleDbCommand command = new OleDbCommand("SELECT * from " + tableName +"", ConnectToDb());

            using (reader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                count = dt.Rows.Count;
            }
            return count;

        }
        public static int SelectCount(string tableName,string department)
        {
            OleDbDataReader reader = null;
            int count = 0;
            OleDbCommand command = new OleDbCommand("SELECT * from " + tableName + " WHERE WorkerDepartment='"+department+"' ORDER BY WorkerDepartment DESC", ConnectToDb());

            using (reader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                count = dt.Rows.Count;
            }
            return count;

        }
        public static void CloseDb()
        {
            ConnectToDb().Close();
        }

        public static string[] split(string splitable, char spliter)
        {
            string[] data;

            data = splitable.Split(spliter);
            return data;


        }

    }
}
