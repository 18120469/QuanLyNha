using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNha
{
    public partial class ChuNhaFix : Form
    {
        
        public string machunha;
        public BindingSource nha = new BindingSource();
        public ChuNhaFix(string ma)
        {
            machunha = ma;
            InitializeComponent();
            load();
        }
        public void load()
        {
            cbloai.Items.Add("Thuê");
            cbloai.Items.Add("Mua");
            danhsachnha.DataSource = nha;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from Nha where MaChuNha = '" + machunha + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                nha.DataSource = data.Tables[0];
                connection.Close();
            }
            manha.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "MaNha"));
            duong.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "Duong"));
            quan.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "Quan"));
            thanhpho.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "ThanhPho"));
            khuvuc.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "KhuVuc"));
            ngaydang.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "NgayDang"));
            ngayhethan.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "NgayHethan"));
            sophong.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "SoLuongPhong"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hopdongban.Checked == true)
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    DataTable table = new DataTable();
                    DataSet data = new DataSet();
                    string query = "exec ChuNhaThongKeHopDongBan1 @machunha, @ngaybatdau, @ngayketthuc";
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(query, connection);
                    command2.Parameters.AddWithValue("@machunha", machunha);
                    command2.Parameters.AddWithValue("@ngaybatdau", ngaybatdau.Value);
                    command2.Parameters.AddWithValue("@ngayketthuc", ngayketthuc.Value);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command2;
                    adapter.Fill(data);
                    connection.Close();
                    banghopdong.DataSource = data.Tables[0];
                    table = data.Tables[1];
                    foreach (DataRow row in table.Rows)
                    {
                        soluong.Text = row["SoLuongHopDong"].ToString();
                    }
                }
            if (hopdongthue.Checked == true)
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    DataTable table = new DataTable();
                    DataSet data = new DataSet();
                    string query = "exec ChuNhaThongKeHopDongThue1 @machunha, @ngaybatdau, @ngayketthuc";
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(query, connection);
                    command2.Parameters.AddWithValue("@machunha", machunha);
                    command2.Parameters.AddWithValue("@ngaybatdau", ngaybatdau.Value);
                    command2.Parameters.AddWithValue("@ngayketthuc", ngayketthuc.Value);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command2;
                    adapter.Fill(data);
                    connection.Close();
                    banghopdong.DataSource = data.Tables[0];
                    table = data.Tables[1];
                    foreach (DataRow row in table.Rows)
                    {
                        soluong.Text = row["SoLuongHopDong"].ToString();
                    }
                }

        }

        private void manha_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from NhaBan where MaNhaBan = '" + manha.Text + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                if (data.Tables[0].Rows.Count == 0)
                {
                    thue.Checked = true;
                    DataSet data2 = new DataSet();
                    string query2 = "select * from NhaThue where MaNhaThue = '" + manha.Text + "'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                    adapter2.Fill(data2);
                    foreach (DataRow row in data2.Tables[0].Rows)
                    {
                        gia.Text = row["TienThueMotThang"].ToString();
                    }
                }
                else
                {
                    ban.Checked = true;
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        gia.Text = row["GiaBan"].ToString();
                    }
                }
                connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    string query2 = "exec CapNhatThongTinNha1 @manha,@duong,@quan,@khuvuc,@tp,'4',@slphong,@ngaydang,@ngayhethan,0,0,'2','1','1234567895'";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@manha", manha.Text);
                    command2.Parameters.AddWithValue("@duong", duong.Text);
                    command2.Parameters.AddWithValue("@quan", quan.Text);
                    command2.Parameters.AddWithValue("@khuvuc", khuvuc.Text);
                    command2.Parameters.AddWithValue("@tp", thanhpho.Text);
                    command2.Parameters.AddWithValue("@slphong", sophong.Text);
                    command2.Parameters.AddWithValue("@ngaydang", ngaydang.Text);
                    command2.Parameters.AddWithValue("@ngayhethan", ngayhethan.Text);
                    int result = command2.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                        DataSet data12 = new DataSet();
                        string query12 = "select * from Nha where MaChuNha = '" + machunha + "'";
                        SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                        adapter12.Fill(data12);
                        nha.DataSource = data12.Tables[0];
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                string query2 = "exec XoaThongTinNha1 @manha";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@manha", manha.Text);
                int result = command2.ExecuteNonQuery();
                if (result < 0)
                    MessageBox.Show("không thể xóa do nhà đã bán/thuê", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                    DataSet data12 = new DataSet();
                    string query12 = "select * from Nha where MaChuNha = '" + machunha + "'";
                    SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                    adapter12.Fill(data12);
                    nha.DataSource = data12.Tables[0];
                }
                connection.Close();
            }
        }

        private void btnDangTin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                string manha = "";
                do
                {
                    manha = Path.GetRandomFileName();
                    manha = manha.Replace(".", "");
                }
                while (manha.Length > 11);
                connection.Open();
                string query2 = "exec DangThongTinNha1 @manha,@duong,@quan,@khuvuc,@thanhpho,@loainha,@sophong,@ngaydang,@ngayhethan,0,0,@machunha,'1','CN_31'";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@manha", manha);
                command2.Parameters.AddWithValue("@duong", dnduong.Text);
                command2.Parameters.AddWithValue("@quan", dnquan.Text);
                command2.Parameters.AddWithValue("@khuvuc", dnkhuvuc.Text);
                command2.Parameters.AddWithValue("@thanhpho", dnthanhpho.Text);
                command2.Parameters.AddWithValue("@loainha",dnloainha.Text);
                command2.Parameters.AddWithValue("@sophong", dnsoluongphong.Text);
                command2.Parameters.AddWithValue("@ngayhethan", dnNgayHetHan.Value);
                command2.Parameters.AddWithValue("@ngaydang", dnNgayDang.Value);
                command2.Parameters.AddWithValue("@machunha", machunha);
                int result = command2.ExecuteNonQuery();
                if (result < 0)
                    MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                    DataSet data12 = new DataSet();
                    string query12 = "select * from Nha where MaChuNha = '" + machunha + "'";
                    SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                    adapter12.Fill(data12);
                    nha.DataSource = data12.Tables[0];
                }
                connection.Close();
            }
        }

        private void chuafix_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form chunha = new ChuNha(machunha);
            chunha.ShowDialog();
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

