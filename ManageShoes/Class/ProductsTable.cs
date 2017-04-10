using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes
{
    class ProductsTable
    {
        public const String ProductTableName = "products";
        public const String COLUMN_ID = "_id";
        public const String COLUMN_NAME = "_name";
        public const String COLUMN_DESC = "_desc";
        public const String COLUMN_SIZE = "_size";
        public const String COLUMN_PRICE = "_price";
        public const String COLUMN_QUANTITY = "_quantity";
        public const String COLUMN_NOTE = "_note";
        public const String COLUMN_IMAGE = "_image";

        public static String COLUMN_ID_NAME = "Mã";
        public static String COLUMN_NAME_NAME = "Tên";
        public static String COLUMN_DESC_NAME = "Mô tả";
        public static String COLUMN_SIZE_NAME = "Size";
        public static String COLUMN_PRICE_NAME = "Giá";
        public static String COLUMN_QUANTITY_NAME = "Số lượng";
        public static String COLUMN_NOTE_NAME = "Ghi chú";
        public static String COLUMN_IMAGE_NAME = "Hình ảnh";
    }
}
