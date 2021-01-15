using System;
using System.IO;
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
    public partial class KhachHangFix : Form
    {
        public string makhachang;
        public BindingSource ttnha = new BindingSource();
        public BindingSource tieuchi = new BindingSource();
        public KhachHangFix(string ma)
        {
            makhachang = ma;
            InitializeComponent();
            load();
        }
        public void load()
        {
            thuemua.Items.Add("Thuê");
            thuemua.Items.Add("Mua");
            thongtinnha.DataSource = ttnha;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "SELECT * FROM Nha WITH (NOLOCK)";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                ttnha.DataSource = data.Tables[0];
                connection.Close();
            }
            manhadk.DataBindings.Add(new Binding("text", thongtinnha.DataSource, "MaNha"));
            danhsachtieuchi.DataSource = tieuchi;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "SELECT * FROM TieuChiChonNha where MaKhachHang = '"+makhachang+"'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                tieuchi.DataSource = data.Tables[0];
                connection.Close();
            }
            stttc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "STT"));
            thuemua.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "YeuCauThueMua"));
            loainhatc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "MaLoaiNha"));
            sophongtc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "SoLuongPhong"));
            giathapnhattc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "GiaMin"));
            giacaonhattc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "GiaMax"));
            khuvuctc.DataBindings.Add(new Binding("text", danhsachtieuchi.DataSource, "KhuVuc"));
        }

        private void timkiemnha_Click(object sender, EventArgs e)
        {
            try
            {
                if (manhatimkiem.Text == "")
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                    {
                        DataSet data = new DataSet();
                        string query = "SELECT * FROM Nha WITH (NOLOCK)";
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.Fill(data);
                        ttnha.DataSource = data.Tables[0];
                        connection.Close();
                    }
                }
                else
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                    {
                        DataSet data = new DataSet();
                        string query = "exec XemThongTinNha1 '" + manhatimkiem.Text + "'";
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        adapter.Fill(data);
                        ttnha.DataSource = data.Tables[0];
                        connection.Close();
                    }
            }
            catch(Exception)
            {
                MessageBox.Show("vui lòng nhập đúng mã nhà", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xemls_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec XemLichSuXemNha1 '"+makhachang+"'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                banglsxemnha.DataSource = data.Tables[0];
                connection.Close();
            }
        }

        private void buttonDKXemNha_Click(object sender, EventArgs e)
        {

        }
        
        private void buttonSuaTieuChi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    string query2 = "exec CapNhatTieuChiChonNha1 @stt,@makhachhang,@loainha,@khuvuc,@sophong,@giamin,@giamax,@yeucau";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@stt", stttc.Text);
                    command2.Parameters.AddWithValue("@makhachhang", makhachang);
                    command2.Parameters.AddWithValue("@loainha", loainhatc.Text);
                    command2.Parameters.AddWithValue("@sophong", sophongtc.Text);
                    command2.Parameters.AddWithValue("@khuvuc", khuvuctc.Text);
                    command2.Parameters.AddWithValue("@giamin", giathapnhattc.Text);
                    command2.Parameters.AddWithValue("@giamax", giacaonhattc.Text);
                    command2.Parameters.AddWithValue("@yeucau", thuemua.Text);
                    int result = command2.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                        DataSet data12 = new DataSet();
                        string query12 = "SELECT * FROM TieuChiChonNha where MaKhachHang = '" + makhachang + "'";
                        SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                        adapter12.Fill(data12);
                        tieuchi.DataSource = data12.Tables[0];
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
        private void buttonXoaTieuChi_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                string query2 = "exec XoaTieuChiChonNha1 @makhachhang,@stt";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@stt", stttc.Text);
                command2.Parameters.AddWithValue("@makhachhang", makhachang);
                int result = command2.ExecuteNonQuery();
                if (result < 0)
                    MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                    DataSet data12 = new DataSet();
                    string query12 = "SELECT * FROM TieuChiChonNha where MaKhachHang = '" + makhachang + "'";
                    SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                    adapter12.Fill(data12);
                    tieuchi.DataSource = data12.Tables[0];
                }
                connection.Close();
            }
        }

        private void buttonThemTieuChi_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                string query2 = "exec Insert_ThongTinTieuChiNha1 @stt,@makhachhang,@loainha,@khuvuc,@sophong,@giamin,@giamax,@yeucau";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@stt", stttc.Text);
                command2.Parameters.AddWithValue("@makhachhang", makhachang);
                command2.Parameters.AddWithValue("@loainha", loainhatc.Text);
                command2.Parameters.AddWithValue("@sophong", sophongtc.Text);
                command2.Parameters.AddWithValue("@khuvuc", khuvuctc.Text);
                command2.Parameters.AddWithValue("@giamin", giathapnhattc.Text);
                command2.Parameters.AddWithValue("@giamax", giacaonhattc.Text);
                command2.Parameters.AddWithValue("@yeucau", thuemua.Text);
                int result = command2.ExecuteNonQuery();
                if (result < 0)
                    MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                    DataSet data12 = new DataSet();
                    string query12 = "SELECT * FROM TieuChiChonNha where MaKhachHang = '" + makhachang + "'";
                    SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                    adapter12.Fill(data12);
                    tieuchi.DataSource = data12.Tables[0];
                }
                connection.Close();
            }
        }

        private void chuafix_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form khachhang = new KhachHang(makhachang);
            khachhang.ShowDialog();
            this.Close();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form lg = new login();
            lg.ShowDialog();
            this.Close();
        }
    }
}
