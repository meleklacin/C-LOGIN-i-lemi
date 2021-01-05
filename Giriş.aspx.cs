using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CRMDeneme
{
    public partial class Giriş : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUyarı.Visible = false;
            //Sayfa yüklendiğinde görünen kısım
            //Girişin sağlanıp sağlanmadığı kontrolünü yapan uyarı label'ı



        }
       
        protected void Button1_Click1(object sender, EventArgs e)
        {
            

            SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-3A5PSISC;Initial Catalog=login;Integrated Security=True");
            SqlCommand sorgu = new SqlCommand("SELECT * FROM Login WHERE KulAdi=@KulAdi AND KulTipi=@KulTipi AND KulSifre=@KulSifre", baglanti);

            sorgu.Parameters.AddWithValue("@KulAdi", SqlDbType.VarChar).Value = KulAdi.Text;
            sorgu.Parameters.AddWithValue("@KulSifre", SqlDbType.VarChar).Value = KulSifre.Text;
            sorgu.Parameters.AddWithValue("@KulTipi", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.ToString();
            Session.Add("Deger",DropDownList1.SelectedIndex);
            SqlDataAdapter da = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            da.Fill(dt);

            
;            // Eğer bir kayıt varsa
            if (dt.Rows.Count > 0)
            {
                // Okunan verileri Session(Oturum) değişkenlerinde saklayalım

                // Giriş sayfasına yönlendir
                Response.Write("<script>alert ('you are loggined as " + dt.Rows[0][2] + "')</script>");
                
                if(DropDownList1.SelectedIndex==0)
                { Response.Redirect("Default.aspx"); }
                else if(DropDownList1.SelectedIndex==1)
                { Response.Redirect("Default.aspx"); }
                else if(DropDownList1.SelectedIndex==2)
                {
                    Response.Redirect("Musteriler.aspx");
                   
                }
                
            }
            else // Kayıt yoksa
            {
                lblUyarı.Visible = true;

            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }
    }
}
