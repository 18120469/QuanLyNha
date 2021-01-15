using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNha
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void dangnhap_Click(object sender, EventArgs e)
        {
            if (typeuser(username.Text, password.Text) == 0)
                MessageBox.Show("tên tài khoản và mật khẩu không chính xác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (typeuser(username.Text, password.Text) == 1)
            {
                string makhachhang ;
                string query = "select MaKhachHang from KhachHang where username = '" + username.Text + "'";
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    makhachhang = (string)command.ExecuteScalar();
                    connection.Close();
                }
                this.Hide();
                Form khachhang = new KhachHang(makhachhang);
                khachhang.ShowDialog();
                this.Close();
            }
            if (typeuser(username.Text, password.Text) == 2)
            {
                string machunha;
                string query = "select MaChuNha from ChuNha where TenTaiKhoan = '" + username.Text + "'";
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    machunha = (string)command.ExecuteScalar();
                    connection.Close();
                }
                this.Hide();
                Form chunha = new ChuNha(machunha);
                chunha.ShowDialog();
                this.Close();
            }
            if (typeuser(username.Text, password.Text) == 3)
            {
                string machunha;
                string query = "select MaNhanVien from NhanVien where TenTaiKhoan = '" + username.Text + "'";
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    machunha = (string)command.ExecuteScalar();
                    connection.Close();
                }
                this.Hide();
                Form nhanvien = new NhanVien("1");
                nhanvien.ShowDialog();
                this.Close();
            }
            if (typeuser(username.Text, password.Text) == 4)
            {
                this.Hide();
                Form ad = new admin("1");
                ad.ShowDialog();
                this.Close();
            }
        }
        int typeuser(string username, string password)
        {
            int type = 0;
            string query = "select dbo.loginform('" + username + "', '" + password + "')";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                type = (int)command.ExecuteScalar();
                connection.Close();
            }
            return type;
        }
        string makhachhang(string username, string password)
        {
            string ma;
            string query = "select kh.MaKhachHang from TaiKhoan tk join KhachHang kh on tk.MaTaiKhoan = kh.MaTaiKhoan where" +
                " tk.TenTaiKhoan='" + @username + "' and tk.MatKhau='" + @password + "'";
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                ma = (string)command.ExecuteScalar();
                connection.Close();
            }
            return ma;
        }
    }
}
