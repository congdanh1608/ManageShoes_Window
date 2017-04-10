using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes.Class
{
    class OrdersTable
    {
        public static String OrdersTableName = "orders";
        public static String COLUMN_ID = "_id";
        public static String COLUMN_BUYER = "_buyer";
        public static String COLUMN_ADDRESS = "_address";
        public static String COLUMN_PHONE = "_phone";
        public static String COLUMN_DATE = "_date";
        public static String COLUMN_PRODUCTS = "_products";
        public static String COLUMN_TOTALPRICE = "_totalprice";
        public static String COLUMN_DISCOUNT = "_discount";
        public static String COLUMN_NOTE = "_note";

        public static String COLUMN_ID_NAME = "Mã";
        public static String COLUMN_BUYER_NAME = "Người mua";
        public static String COLUMN_ADDRESS_NAME = "Địa chỉ";
        public static String COLUMN_PHONE_NAME = "Phone";
        public static String COLUMN_DATE_NAME = "Ngày mua";
        public static String COLUMN_PRODUCTS_NAME = "Sản phẩm";
        public static String COLUMN_TOTALPRICE_NAME = "Tổng giá tiền";
        public static String COLUMN_DISCOUNT_NAME = "Giảm giá";
        public static String COLUMN_NOTE_NAME = "Ghi chú";
    }
}
