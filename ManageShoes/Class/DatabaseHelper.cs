using ManageShoes.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    class DatabaseHelper
    {
        private DBConnection db;

        public DatabaseHelper()
        {
            db = new DBConnection();
            db.Connect();
        }

        public DBConnection getDBConnection()
        {
            return db;
        }

        public BindingSource getBindingSourceProducts()
        {
            String strReq = "select * from Products";
            db.Adt = new SqlDataAdapter(strReq, db.Cnn);
            db.Dt = new DataTable();
            db.Adt.FillSchema(db.Dt, SchemaType.Mapped);
            db.Adt.Fill(db.Dt);
            BindingSource bs = new BindingSource();
            if (db.Dt.Rows.Count != 0)
            {
                bs.DataSource = db.Dt;
                db.Adt.Update(db.Dt);
                return bs;
            }
            else
            {
                return null;
            }
        }

        public BindingSource getBindingSourceOrders()
        {
            String strReq = "select * from Orders";
            db.Adt = new SqlDataAdapter(strReq, db.Cnn);
            db.Dt = new DataTable();
            db.Adt.FillSchema(db.Dt, SchemaType.Mapped);
            db.Adt.Fill(db.Dt);
            BindingSource bs = new BindingSource();
            if (db.Dt.Rows.Count != 0)
            {
                bs.DataSource = db.Dt;
                db.Adt.Update(db.Dt);
                return bs;
            }
            else
            {
               return null;
            }
        }

      public Product getProductBy(string strDataColName, string strValue)
        {
            db.LoadDataToTable(ProductsTable.ProductTableName);
            SqlCommand cmm;
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            cmm = new SqlCommand(strReq, db.Cnn);

            SqlDataReader reader = cmm.ExecuteReader();

            Product product = null;
            while (reader.Read())
            {
                if (reader[strDataColName].ToString() == strValue)
                {
                    product = new Product();
                    product.setpID(reader.GetString(0));
                    product.setName(reader.GetString(1));
                    product.setDesc(reader.IsDBNull(2) ? null : reader.GetString(2));
                    product.setSize(reader.IsDBNull(3) ? null : reader.GetString(3));
                    product.setPrice(Convert.ToString(reader.GetInt32(4)));
                    product.setQuantity(Convert.ToString(reader.GetInt32(5)));
                    product.setNote(reader.IsDBNull(6) ? null : reader.GetString(6));
                    product.setImage(reader.IsDBNull(7) ? null : reader.GetString(7));
                }
            }

            cmm.Dispose();
            reader.Dispose();
            return product;
        }

        public List<Product> getAllProduct()
        {
            db.LoadDataToTable(ProductsTable.ProductTableName);
            SqlCommand cmm;
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            cmm = new SqlCommand(strReq, db.Cnn);

            SqlDataReader reader = cmm.ExecuteReader();

            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product();
                p.setpID(reader.GetString(0));
                p.setName(reader.GetString(1));
                p.setDesc(reader.IsDBNull(2) ? null : reader.GetString(2));
                p.setSize(reader.IsDBNull(3) ? null : reader.GetString(3));
                p.setPrice(Convert.ToString(reader.GetInt32(4)));
                p.setQuantity(Convert.ToString(reader.GetInt32(5)));
                p.setNote(reader.IsDBNull(6) ? null : reader.GetString(6));
                p.setImage(reader.IsDBNull(7) ? null : reader.GetString(7));

                products.Add(p);
            }

            cmm.Dispose();
            reader.Dispose();
            return products;
        }

        public void updateProductByID(Product product)
        {
            String id = product.getpID();
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName + " where " +
                ProductsTable.COLUMN_ID + " ='" + id + "'");
            exeCommandSql(strReq);
            DataRow newRow = db.Dt.Rows[0];
            //create data
            newRow[ProductsTable.COLUMN_ID] = product.getpID();
            newRow[ProductsTable.COLUMN_NAME] = product.getName();
            newRow[ProductsTable.COLUMN_DESC] = String.IsNullOrEmpty(product.getDesc()) ? null : product.getDesc();
            newRow[ProductsTable.COLUMN_IMAGE] = String.IsNullOrEmpty(product.getImage()) ? null : ConstantPath.imagePath + product.getImage();
            //newRow[ProductsTable.COLUMN_] = String.IsNullOrEmpty(cmbStatus.Text) ? null : cmbStatus.Text;
            newRow[ProductsTable.COLUMN_SIZE] = String.IsNullOrEmpty(product.getSize()) ? null : product.getSize();
            newRow[ProductsTable.COLUMN_QUANTITY] = product.getQuantity();
            newRow[ProductsTable.COLUMN_PRICE] = Int32.Parse(product.getPrice());
            newRow[ProductsTable.COLUMN_NOTE] = String.IsNullOrEmpty(product.getNote()) ? null : product.getNote();

            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            db.Adt.Update(db.Dt);
            db.Dt.AcceptChanges();
        }

        private void exeCommandSql(String strReq)
        {
            db.Adt = new SqlDataAdapter(strReq, db.Cnn);
            db.Dt = new DataTable();
            db.Adt.FillSchema(db.Dt, SchemaType.Mapped);
            db.Adt.Fill(db.Dt);
        }

        public void updateProduct(Product product, int iIndex)
        {
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            exeCommandSql(strReq);
            DataRow newRow = db.Dt.Rows[iIndex];
            //create data
            newRow[ProductsTable.COLUMN_ID] = product.getpID();
            newRow[ProductsTable.COLUMN_NAME] = product.getName();
            newRow[ProductsTable.COLUMN_DESC] = String.IsNullOrEmpty(product.getDesc()) ? null : product.getDesc();
            newRow[ProductsTable.COLUMN_IMAGE] = String.IsNullOrEmpty(product.getImage()) ? null : ConstantPath.imagePath + product.getImage();
            //newRow[ProductsTable.COLUMN_] = String.IsNullOrEmpty(cmbStatus.Text) ? null : cmbStatus.Text;
            newRow[ProductsTable.COLUMN_SIZE] = String.IsNullOrEmpty(product.getSize()) ? null : product.getSize();
            newRow[ProductsTable.COLUMN_QUANTITY] = product.getQuantity();
            newRow[ProductsTable.COLUMN_PRICE] = Int32.Parse(product.getPrice());
            newRow[ProductsTable.COLUMN_NOTE] = String.IsNullOrEmpty(product.getNote()) ? null : product.getNote();

            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            db.Adt.Update(db.Dt);
            db.Dt.AcceptChanges();
        }

        public void addProduct(Product product)
        {
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            exeCommandSql(strReq);
            DataRow newRow = db.Dt.NewRow();
            //create data
            newRow[ProductsTable.COLUMN_ID] = product.getpID();
            newRow[ProductsTable.COLUMN_NAME] = product.getName();
            newRow[ProductsTable.COLUMN_DESC] = String.IsNullOrEmpty(product.getDesc()) ? null : product.getDesc();
            newRow[ProductsTable.COLUMN_IMAGE] = String.IsNullOrEmpty(product.getImage()) ? null : ConstantPath.imagePath + product.getImage();
            //newRow[ProductsTable.COLUMN_] = String.IsNullOrEmpty(cmbStatus.Text) ? null : cmbStatus.Text;
            newRow[ProductsTable.COLUMN_SIZE] = String.IsNullOrEmpty(product.getSize()) ? null : product.getSize();
            newRow[ProductsTable.COLUMN_QUANTITY] = Int32.Parse(product.getQuantity());
            newRow[ProductsTable.COLUMN_PRICE] = Int32.Parse(product.getPrice());
            newRow[ProductsTable.COLUMN_NOTE] = String.IsNullOrEmpty(product.getNote()) ? null : product.getNote();

            db.Dt.Rows.Add(newRow);
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            db.Adt.Update(db.Dt);
            db.Dt.AcceptChanges();
        }

        public void removeProduct(int iIndex)
        {
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            exeCommandSql(strReq);
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            db.Dt.Rows[iIndex].Delete();
            db.Adt.Update(db.Dt);
            db.Dt.AcceptChanges();
        }

        public void removeProductByID(String id)
        {
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName);
            exeCommandSql(strReq);
            SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            for (int i = db.Dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = db.Dt.Rows[i];
                if (dr[ProductsTable.COLUMN_ID].Equals(id))
                    dr.Delete();
            }
            db.Adt.Update(db.Dt);
            db.Dt.AcceptChanges();
        }

        public void removeAllProduct()
        {
            string strReq = string.Format("TRUNCATE TABLE " + ProductsTable.ProductTableName);
            exeCommandSql(strReq);
            //SqlCommandBuilder ccm = new SqlCommandBuilder(db.Adt);
            //for (int i = db.Dt.Rows.Count - 1; i >= 0; i--)
            //{
            //    DataRow dr = db.Dt.Rows[i];
            //    dr.Delete();
            //}
            //db.Adt.Update(db.Dt);
            //db.Dt.AcceptChanges();
        }

        public List<Product> getProductsLike(string strDataColName, string strValue)
        {
            db.LoadDataToTable(ProductsTable.ProductTableName);
            SqlCommand cmm;
            string strReq = string.Format("select * from " + ProductsTable.ProductTableName + " where " + strDataColName +
                " LIKE N'%" + strValue + "%'");
            cmm = new SqlCommand(strReq, db.Cnn);

            SqlDataReader reader = cmm.ExecuteReader();

            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.setpID(reader.GetString(0));
                product.setName(reader.GetString(1));
                product.setDesc(reader.IsDBNull(2) ? null : reader.GetString(2));
                product.setSize(reader.IsDBNull(3) ? null : reader.GetString(3));
                product.setPrice(Convert.ToString(reader.GetInt32(4)));
                product.setQuantity(Convert.ToString(reader.GetInt32(5)));
                product.setNote(reader.IsDBNull(6) ? null : reader.GetString(6));
                product.setImage(reader.IsDBNull(7) ? null : reader.GetString(7));
                products.Add(product);
            }

            cmm.Dispose();
            reader.Dispose();
            return products;
        }

        public List<Order> getAllOrder()
        {
            db.LoadDataToTable(OrdersTable.OrdersTableName);
            SqlCommand cmm;
            int count = 0;
            string strReq = string.Format("select * from " + OrdersTable.OrdersTableName);
            cmm = new SqlCommand(strReq, db.Cnn);

            SqlDataReader reader = cmm.ExecuteReader();

            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                Order o = new Order();
                o.setoID(reader.GetString(0));
                o.setBuyer(reader.GetString(1));
                o.setAddress(reader.IsDBNull(2) ? null : reader.GetString(2));
                o.setPhone(reader.IsDBNull(3) ? null : reader.GetString(3));
                o.setDate(reader.IsDBNull(4) ? null : reader.GetString(4));
                o.setProducts(reader.IsDBNull(5) ? null : reader.GetString(5));
                o.setTotalprice(Convert.ToString(reader.GetInt32(6)));
                o.setDiscount(Convert.ToString(reader.GetInt32(7)));
                o.setNote(reader.IsDBNull(8) ? null : reader.GetString(8));

                orders.Add(o);
            }

            cmm.Dispose();
            reader.Dispose();
            return orders;
        }
    }
}
