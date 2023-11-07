using KpopZtationNew.Controller;
using KpopZtationNew.Handler;
using KpopZtationNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationNew.View
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartItems();
            }
        }
        protected void DeleteCart_Click(object sender, EventArgs e)
        {
            Button btnRemove = (Button)sender;
            Customer userTemp = (Customer)Session["user"];
            int UserId = userTemp.CustomerID;
            int albumId = Convert.ToInt32(btnRemove.CommandArgument);

            if (CartController.DeleteCart(UserId, albumId))
            {
                Response.Redirect("~/View/ViewCart.aspx");
            }
        }
        protected void Checkout_Click(object sender, EventArgs e)
        {
            //ambil id user dri session
            Customer userTemp = (Customer)Session["user"];
            int UserId = userTemp.CustomerID;

            //Add ke transaction database
            List<displayCart> checkoutList = Session["checkoutList"] as List<displayCart>;
            foreach (displayCart checkout in checkoutList)
            {
                TransactionController.AddTransaction(GetCurrentDateTime(), UserId, checkout.AlbumID, checkout.Quantity);
            }

            //Delete cartnya
            List<Cart> cartItems = CartController.GetCartByCustomerId(UserId);
            foreach (Cart displayCart in cartItems)
            {
                CartController.DeleteCartByCustomer(UserId);
            }
            Response.Redirect("~/View/ViewCart.aspx");
        }
        public DateTime GetCurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now;
            return currentDateTime;
        }
        private void BindCartItems()
        {
            Customer userTemp = (Customer)Session["user"];
            int UserId = userTemp.CustomerID;
            List<Cart> cartItems = CartController.GetCartByCustomerId(UserId);
            List<displayCart> cartList = new List<displayCart>();
            foreach (Cart displayCart in cartItems)
            {
                displayCart testItem = new displayCart();

                testItem.AlbumID = displayCart.AlbumID;
                testItem.AlbumPic = GetAlbumPic(displayCart.AlbumID);
                testItem.AlbumName = GetAlbumName(displayCart.AlbumID);
                testItem.Price = GetAlbumPrice(displayCart.AlbumID);
                testItem.Quantity = displayCart.Qty;
                cartList.Add(testItem);
            }
            Session["checkoutList"] = cartList;
            cartsRepeater.DataSource = cartList;
            cartsRepeater.DataBind();
        }
        public class displayCart
        {
            public string AlbumPic { get; set; }
            public int AlbumID { get; set; }
            public string AlbumName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
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
        private string GetAlbumPic(int albumId)
        {
            using (DBE db = new DBE())
            {
                return db.Albums.Where(a => a.AlbumID == albumId).Select(a => a.AlbumImage).FirstOrDefault();
            }
        }
    }
}