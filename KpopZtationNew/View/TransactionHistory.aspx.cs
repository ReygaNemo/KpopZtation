using KpopZtationNew.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationNew.View
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartItems();
        }
        private void BindCartItems()
        {
            Customer userTemp = (Customer)Session["user"];
            int UserId = userTemp.CustomerID;
            List<TransactionHeader> TransH = TransactionController.GetTransHeadByCustomerId(UserId);
            List<TransactionDetail> TransD = TransactionController.GetTransDetailByCustomerId(UserId);
            List<displayTrans> displayTransList = (from tranH in TransH
                                                   join tranD in TransD on tranH.TransactionID equals tranD.TransactionID
                                                   select new displayTrans
                                                   {
                                                       CustomerName = GetCustomerName(tranH.CustomerID),
                                                       TransactionID = tranH.TransactionID,
                                                       TransDate = tranH.TransactionDate,
                                                       AlbumID = tranD.AlbumID,
                                                       AlbumPic = GetAlbumPic(tranD.AlbumID),
                                                       AlbumName = GetAlbumName(tranD.AlbumID),
                                                       Price = GetAlbumPrice(tranD.AlbumID),
                                                       Quantity = tranD.Qty
                                                   }).ToList();
            cartsRepeater.DataSource = displayTransList;
            cartsRepeater.DataBind();
        }
        public class displayTrans
        {
            public string AlbumPic { get; set; }
            public int AlbumID { get; set; }
            public string AlbumName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int TransactionID { get; set; }
            public DateTime TransDate { get; set; }
            public string CustomerName { get; set; }
        }
        private string GetAlbumName(int albumId)
        {
            using (DBE db = new DBE())
            {
                return db.Albums.Where(a => a.AlbumID == albumId).Select(a => a.AlbumName).FirstOrDefault();
            }
        }
        private int GetAlbumPrice(int albumId)
        {
            using (DBE db = new DBE())
            {
                return db.Albums.Where(a => a.AlbumID == albumId).Select(a => a.AlbumPrice).FirstOrDefault();
            }
        }
        private string GetCustomerName(int custId)
        {
            using (DBE db = new DBE())
            {
                return db.Customers.Where(a => a.CustomerID == custId).Select(a => a.CustomerName).FirstOrDefault();
            }
        }
        private string GetAlbumPic(int albumId)
        {
            using (DBE db = new DBE())
            {
                return db.Albums.Where(a => a.AlbumID == albumId).Select(a => a.AlbumImage).FirstOrDefault();
            }
        }
    }
}