using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    class DBConnection
    {
        private SqlConnection cnn;
        private SqlDataAdapter adt;
        private DataTable dataTable;
        private bool connstatus;

        public SqlConnection Cnn { get; set; }
        public SqlDataAdapter Adt { get; set; }
        public DataTable Dt { get; set; }
        public bool Connstatus { get; set; }


         public DBConnection()
        {
            Cnn = null;
            Connstatus = false;
        }

         public void Connect()
         {
             if (!Connstatus)
             {
                 String strCon = MainUtils.readDataConnect();
                 //String strCon = ("server="+ Properties.Settings.Default.Server +";" +
                 //                         "Trusted_Connection=yes;" +
                 //                         "database="+ Properties.Settings.Default.Database +"; " +
                 //                         "connection timeout=30");
                 try
                 {
                     Cnn = new SqlConnection(strCon);
                     Cnn.Open();
 //                    MessageBox.Show("Well done!");
                     Connstatus = true;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("You failed!" + ex.Message);
                 }
             }
         }


         public void ReadTable(string TableName)
         {
             string strReq = "select * from " + TableName;
             this.Connect();
             Adt = new SqlDataAdapter(strReq, Cnn);
             Dt = new DataTable(TableName);
             Adt.FillSchema(Dt, SchemaType.Mapped);
             Adt.Fill(Dt);
         }

         //Hàm so sánh dữ liệu bảng với một giá trị trong đó bảng duyệt, cột duyệt và giá trị được truyền vào
         public bool CompareValue(string strDataTableName, string strDataColName, string strValue)
         {
             SqlCommand cmm;
             int count = 0;
             //Cnn.Open();
             string strReq = string.Format("select * from {0}", strDataTableName);
             cmm = new SqlCommand(strReq, Cnn);

             SqlDataReader reader = cmm.ExecuteReader();

             //So sánh giá trị với từng dòng truyền vào
             while (reader.Read())
             {
                 //Kiểm tra sự tồn tại của giá trị trong cột
                 if (reader[strDataColName].ToString() == strValue)
                     count++;
             }

             cmm.Dispose();
             reader.Dispose();

             if (count > 0)
                 return true;
             else
                 return false;
         }

         public void LoadDataToTable(string strTableName)
         {
             string strReq = string.Format("select * from {0}", strTableName);
             SqlCommandBuilder ccm = new SqlCommandBuilder(Adt);
             Adt = new SqlDataAdapter(strReq, this.Cnn);
             Dt = new DataTable(strTableName);
             Adt.FillSchema(Dt, SchemaType.Mapped);
             Adt.Fill(Dt);
         }

         //Hàm thống kê số lượng bảng, bảng là tham số truyền vào
         public int DataStatistic(string strDataTableName)
         {
             //Khai báo và kết nối dữ liệu
             SqlCommand cmm;
             this.Connect();

             string strReq = string.Format("select count(*) from {0}", strDataTableName);
             cmm = new SqlCommand(strReq, Cnn);

             //Lấy số liệu cần thiết
             int result = int.Parse(cmm.ExecuteScalar().ToString());

             Cnn.Close();
             cmm.Dispose();

             return result;
         }

    }
}
