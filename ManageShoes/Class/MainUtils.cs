using iTextSharp.text.pdf;
using ManageShoes.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageShoes
{
    class MainUtils
    {
        DatabaseHelper DBhelper;
        public MainUtils()
        {
            DBhelper = new DatabaseHelper();
        }

        public static String readDataConnect()
        {
            String strCon = null;
            string path = Application.StartupPath + "\\Connection.DAT";
            if (File.Exists(path) == false)
                return null;
            StreamReader sr = new StreamReader(path);
            string strTest = sr.ReadLine();
            if (strTest != "")
            {
                strCon = strTest;
            }
            sr.Close();
            return strCon;
        }

        public static void checkFolder()
        {
            if (!Directory.Exists(ConstantPath.imagePath))
                Directory.CreateDirectory(ConstantPath.imagePath);
            if (!Directory.Exists(ConstantPath.pdfPath))
                Directory.CreateDirectory(ConstantPath.pdfPath);
            if (!Directory.Exists(ConstantPath.jsonPath))
                Directory.CreateDirectory(ConstantPath.jsonPath);
        }

        public static void writeFileJson(String str, String filePath)
        {
            File.WriteAllText(filePath, str);
        }

        public void prepareJsonFile()
        {
            //info file
            VersionUpload versionUpload = new VersionUpload(TimeUtils.getCurrentTimeInMilisecond(), System.Environment.MachineName);
            String jsonVersion = JsonHelper.ParseVersionUploadToJson(versionUpload);
            MainUtils.writeFileJson(jsonVersion, ConstantPath.jsonPath + ConstantPath.verJson);

            String json = JsonHelper.ParseProductsToJson(DBhelper.getAllProduct());
            MainUtils.writeFileJson(json, ConstantPath.jsonPath + ConstantPath.productJson);
            //json = JsonHelper.ParseOrdersToJson(DBhelper.getAllOrder());
            //MainUtils.writeFileJson(json, ConstantPath.jsonPath + ConstantPath.orderJson);

            //save version in local
            Properties.Settings.Default.FinalVersionUpload = Convert.ToString(versionUpload.time);
        }

        public bool checkVersionWithDialog(DropboxNemiro dropboxNemiro, MainForm mainForm)
        {
            if (!checkVersionUpload(dropboxNemiro))
            {
                DialogResult dr = MessageBox.Show("Dữ liệu trên máy đã cũ, bạn phải cập nhất trước khi thay đổi! \n Chọn Yes để cập nhật.", "Cập nhật", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    mainForm.SyncToDropboxNow();
                    return true;
                }
                else if (dr == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        public bool checkVersionUpload(DropboxNemiro dropboxNemiro)      //true - new    false - old
        {
            String versionPath = ConstantPath.jsonPath + ConstantPath.verJson;
            {
                dropboxNemiro.downloadFileVersionFromDropbox();
                if (File.Exists(versionPath))
                {
                    double currentTime = TimeUtils.getCurrentTimeInMilisecond();

                    VersionUpload versionUpload = JsonHelper.loadVersionUploadFromJson(File.ReadAllText(versionPath));
                    if (versionUpload.time != Double.Parse(Properties.Settings.Default.FinalVersionUpload))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void updateDataBaseFromJson(DropboxNemiro dropboxNemiro)
        {
            String versionJsonPath = ConstantPath.jsonPath + ConstantPath.verJson;
            String productJsonPath = ConstantPath.jsonPath + ConstantPath.productJson;
            String orderJsonPath = ConstantPath.jsonPath + ConstantPath.orderJson;

            dropboxNemiro.downloadFileFromDropbox();
            if (File.Exists(productJsonPath))
            {
                List<Product> products = JsonHelper.loadProductsFromJson(File.ReadAllText(productJsonPath));
                DBhelper.removeAllProduct();        //remove all db in local
                foreach (Product pro in products)       //add new db from json
                {
                    DBhelper.addProduct(pro);
                }
            }

            //if (File.Exists(orderJsonPath))
            //{
            //    List<Order> orders = JsonHelper.loadOrdersFromJson(File.ReadAllText(orderJsonPath));
            //foreach (Order ord in orders)
            //{
            //    DBhelper.updateProductByID(pro);
            //}
            //}

            //save version in local
            if (File.Exists(versionJsonPath))
            {
                VersionUpload versionUpload = JsonHelper.loadVersionUploadFromJson(File.ReadAllText(versionJsonPath));
                Properties.Settings.Default.FinalVersionUpload = Convert.ToString(versionUpload.time);
            }
        }

        public static String getCurrentDate()   //dd-mm-yyyy
        {
            String date = null;
            DateTime datetime = DateTime.Today;
            date = datetime.ToString("dd/MM/yyyy");
            return date;
        }

        public String getListName_ID_QuantityFromListBuyProducts(List<BuyProduct> buyPro)
        {
            String str = null;
            if (buyPro.Count > 0)
            {
                foreach (BuyProduct p in buyPro)
                {
                    str = str + p.getProduct().getName() + "(" + p.getProduct().getpID() + ")" + "    SL:" + p.getQuantity() + System.Environment.NewLine;
                }
            }
            return str;
        }

        public List<BuyProduct> getListProductFromString(String str)
        {
            List<BuyProduct> buyProducts = new List<BuyProduct>();
            String[] array = str.Split(';');
            if (array.Length > 0)
            {
                foreach (String s in array)
                {
                    String[] arr = s.Split('-');
                    if (arr.Length > 0)
                    {
                        Product p;
                        p = DBhelper.getProductBy(ProductsTable.COLUMN_ID, arr[0]);
                        buyProducts.Add(new BuyProduct(p, Int32.Parse(arr[1])));
                    }
                }
            }
            return buyProducts;
        }

        public String getName_ID_QuantityFromBuyProduct(BuyProduct buyPro)
        {
            String str = null;
            if (buyPro != null)
            {
                str = str + buyPro.getProduct().getName() + "(" + buyPro.getProduct().getpID() + ")" + "    SL:" + buyPro.getQuantity() + System.Environment.NewLine;
            }
            return str;
        }

        public BuyProduct getBuyProductFromName_ID_Quantity(String str)
        {
            BuyProduct b;
            String id = getIDFromName_ID_Quantity(str);
            b = new BuyProduct(DBhelper.getProductBy(ProductsTable.COLUMN_ID, id),
                getQuantityFromName_ID_Quantity(str));
            return b;
        }

        public String getStringFromListBuyProduct(List<BuyProduct> buy)
        {
            String str = null;
            if (buy.Count > 0)
            {
                foreach (BuyProduct b in buy)
                {
                    if (str == null)
                    {
                        str += b.getProduct().getpID() + "-" + b.getQuantity();
                    }
                    else
                    {
                        str += ";" + b.getProduct().getpID() + "-" + b.getQuantity(); ;
                    }
                }
            }
            return str;
        }

        public List<String> getListInfosOfAllProduct(List<String> arrays)
        {
            List<String> listStr = new List<string>();
            List<Product> listPro = new List<Product>();
            listPro = DBhelper.getAllProduct();
            if (listPro.Count > 0)
            {
                foreach (Product p in listPro)
                {
                    String str = "";
                    for (int i = 0; i < arrays.Count; i++)
                    {
                        String columm = arrays[i];
                        switch (columm)
                        {
                            case ProductsTable.COLUMN_ID:
                                str += p.getpID();
                                break;
                            case ProductsTable.COLUMN_NAME:
                                str += p.getName();
                                break;
                            case ProductsTable.COLUMN_DESC:
                                str += p.getDesc();
                                break;
                            case ProductsTable.COLUMN_NOTE:
                                str += p.getNote();
                                break;
                            case ProductsTable.COLUMN_PRICE:
                                str += p.getPrice();
                                break;
                            case ProductsTable.COLUMN_QUANTITY:
                                str += p.getQuantity();
                                break;
                            case ProductsTable.COLUMN_SIZE:
                                str += p.getSize();
                                break;
                        }
                        if (!string.IsNullOrEmpty(str) && (i + 1 < arrays.Count))
                            str += " - ";
                    }
                    listStr.Add(str);
                }
            }
            return listStr;
        }

        public Product getProductInAutoComplete(String name)
        {
            Product p = new Product();
            p = DBhelper.getProductBy(ProductsTable.COLUMN_ID, getIDFromName_ID(name));
            return p;
        }

        public String getIDFromName_ID(String str)
        {
            String[] array = str.Split('-');
            return array[array.Length - 1];
        }

        public String getIDFromName_ID_Quantity(String str)
        {
            int start = str.IndexOf("(");
            int end = str.IndexOf(")");
            return str.Substring(start + 1, end - start - 1);
        }

        public int getQuantityFromName_ID_Quantity(String str)
        {
            int start = str.IndexOf("SL:");
            return Int32.Parse(str.Substring(start + 3, str.Length - start - 3));
        }

        public int calculatorTotalPrice(List<BuyProduct> buyPros, int discount)
        {
            int totalPrice = 0;
            if (buyPros.Count > 0)
            {
                foreach (BuyProduct b in buyPros)
                {
                    totalPrice += (Int32.Parse(b.getProduct().getPrice()) * b.getQuantity());
                }
            }
            return totalPrice - discount;
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public static DataTable convertListToDataTable(List<Product> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add(ProductsTable.COLUMN_ID_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_NAME_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_DESC_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_SIZE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_PRICE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_QUANTITY_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_NOTE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_IMAGE_NAME, typeof(string));

            foreach (Product p in list)
            {
                table.Rows.Add(p.getpID(), p.getName(), p.getDesc(), p.getSize(),
                    p.getPrice(), p.getQuantity(), p.getNote(), p.getImage());
            }

            return table;
        }

        public static DataTable convertListToDataTableCart(List<Product> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add(ProductsTable.COLUMN_ID_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_NAME_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_SIZE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_PRICE_NAME, typeof(string));
            table.Columns.Add(ProductsTable.COLUMN_QUANTITY_NAME, typeof(string));

            foreach (Product p in list)
            {
                table.Rows.Add(p.getpID(), p.getName(), p.getSize(),
                    p.getPrice(), p.getQuantity());
            }

            return table;
        }

        public void addButtonToGridView(DataGridView dgv)
        {
            if (dgv.Columns.Contains(Constant.NAME_VALUE_BTN_REMOVE) && dgv.Columns[Constant.NAME_VALUE_BTN_REMOVE].Visible)
            {

            }
            else
            {
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = Constant.NAME_VALUE_BTN_REMOVE;
                deleteButton.HeaderText = "Del";
                deleteButton.Text = "Del";
                deleteButton.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(deleteButton);
            }
        }

        public static string getCurrentTime(String format)
        {
            return DateTime.Now.ToString(format);
        }

        public bool checkProductExitsInCart(List<Product> productsCart, Product product)
        {
            foreach (Product pro in productsCart)
            {
                if (pro.getpID().Equals(product.getpID()))
                {
                    return true;
                }
            }
            return false;
        }

        public void printOrder(List<Product> productsCart)
        {
            var file = Path.GetTempFileName();
            string filepath = Path.GetTempPath();
            string strFilename = MainUtils.getCurrentTime("h_mm_ss") + ".pdf";
            using (MemoryStream ms = new MemoryStream())
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(getPageSize(), 20, 20, 15, 15);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Path.Combine(filepath, strFilename), FileMode.Create));
                document.AddTitle("Document Title");
                document.Open();

                iTextSharp.text.pdf.BaseFont Vn_Helvetica = iTextSharp.text.pdf.BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", "Identity-H", iTextSharp.text.pdf.BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(Vn_Helvetica, 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font subTitleFont = new iTextSharp.text.Font(Vn_Helvetica, 14, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldTableFont = new iTextSharp.text.Font(Vn_Helvetica, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font endingMessageFont = new iTextSharp.text.Font(Vn_Helvetica, 10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font bodyFont = new iTextSharp.text.Font(Vn_Helvetica, 12, iTextSharp.text.Font.NORMAL);

                document.Add(new iTextSharp.text.Paragraph(Properties.Settings.Default.ShopName, titleFont));

                var orderInfoTable = new PdfPTable(2);
                orderInfoTable.HorizontalAlignment = 0;
                orderInfoTable.SpacingBefore = 10;
                orderInfoTable.SpacingAfter = 10;
                orderInfoTable.DefaultCell.Border = 0;
                orderInfoTable.SetWidths(new int[] { 70, 150 });

                //Id of Order
                orderInfoTable.AddCell(new iTextSharp.text.Phrase("Mã đơn hàng: ", boldTableFont));
                orderInfoTable.AddCell("");
                double totalPrice = 0;

                //Products
                for (int i = 0; i < productsCart.Count; i++)
                {
                    int c = i + 1;
                    orderInfoTable.AddCell(new iTextSharp.text.Phrase("Sản phẩm " + c + ": ", boldTableFont));
                    orderInfoTable.AddCell(new iTextSharp.text.Phrase(productsCart[i].getName(), bodyFont));
                    orderInfoTable.AddCell(new iTextSharp.text.Phrase("Mã sản phẩm " + c + ": ", boldTableFont));
                    orderInfoTable.AddCell(productsCart[i].getpID());
                    orderInfoTable.AddCell(new iTextSharp.text.Phrase("Số lượng " + c + ": ", boldTableFont));
                    orderInfoTable.AddCell(productsCart[i].getQuantity().ToString());
                    totalPrice += double.Parse(productsCart[i].getPrice());
                }

                //Total price
                orderInfoTable.AddCell(new iTextSharp.text.Phrase("Tổng giá:", boldTableFont));
                orderInfoTable.AddCell(Convert.ToDecimal(totalPrice).ToString("###,###,###.00") + " dong");

                document.Add(orderInfoTable);

                document.Close();
            }
            System.Diagnostics.Process.Start(filepath + strFilename);
        }

        private iTextSharp.text.Rectangle getPageSize()
        {
            switch (Properties.Settings.Default.SizePagePrint)
            {
                case 0:
                    return iTextSharp.text.PageSize.A2;
                case 1:
                    return iTextSharp.text.PageSize.A3;
                case 2:
                    return iTextSharp.text.PageSize.A4;
                case 3:
                    return iTextSharp.text.PageSize.A4_LANDSCAPE;
                case 4:
                    return iTextSharp.text.PageSize.A5;
                case 5:
                    return iTextSharp.text.PageSize.A6;
                case 6:
                    return iTextSharp.text.PageSize.A7;
                case 7:
                    return iTextSharp.text.PageSize.A8;
                case 8:
                    return iTextSharp.text.PageSize.A9;
                case 9:
                default:
                    return iTextSharp.text.PageSize.A10;
            }
        }

        public void exportOther(List<Product> products)
        {
            //decrease number quantity product
            //list in database
            List<Product> productsInDB = new List<Product>();
            foreach (Product pro in products)
            {
                Product pr = DBhelper.getProductBy(ProductsTable.COLUMN_ID, pro.getpID());
                productsInDB.Add(pr);
            }

            for (int i = 0; i < products.Count; i++)
            {
                //decrease
                int quantityDB = Int32.Parse(productsInDB[i].getQuantity());
                int quantityCart = Int32.Parse(products[i].getQuantity());
                productsInDB[i].setQuantity(Convert.ToString(quantityDB - quantityCart));

                //update
                DBhelper.updateProductByID(productsInDB[i]);
            }
        }

        public async void runCheckConnection()
        {
            NetworkConnection networkConnection = new NetworkConnection();
            await networkConnection.CheckInternetAsync();
        }
    }
}
