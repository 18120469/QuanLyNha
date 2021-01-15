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
    public partial class NhanVien : Form
    {
        public BindingSource hopdong = new BindingSource();
        public BindingSource danhsachnha = new BindingSource();
        public string manhanvien;
        public NhanVien(string ma)
        {
            manhanvien = ma;
            InitializeComponent();
            load();
        }
        public void load()
        {
            danhsachhopdong.DataSource = hopdong;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from HopDong";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                hopdong.DataSource = data.Tables[0];
                connection.Close();
            }
            mahopdong.DataBindings.Add(new Binding("text", danhsachhopdong.DataSource, "MaHopDong"));
            makhachhang.DataBindings.Add(new Binding("text", danhsachhopdong.DataSource, "MaKhachHang"));
            manha.DataBindings.Add(new Binding("text", danhsachhopdong.DataSource, "MaNha"));
            ngaykyhd.DataBindings.Add(new Binding("text", danhsachhopdong.DataSource, "NgayKyHopDong"));
            if (hdban.Checked == true)
            {
                giamua1.Enabled = true;
                ngaythue1.Enabled = false;
                ngayhethan1.Enabled = false;
            }
            dsnha.DataSource = danhsachnha;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from Nha";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                danhsachnha.DataSource = data.Tables[0];
                connection.Close();
            }
            manhals.DataBindings.Add(new Binding("text", dsnha.DataSource, "MaNha"));
        }

        private void xemtieuchi_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec XemTieuChiNha '" + makhachhangxtc.Text + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                bangtieuchi.DataSource = data.Tables[0];
                connection.Close();
            }
        }


        private void xoahd_Click(object sender, EventArgs e)
        {
            if (hopdongthue.Checked == true)
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    connection.Open();
                    string query2 = "exec XoaHopDongThue @mahopdong";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@mahopdong", mahopdong.Text);
                    int result = command2.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                        DataSet data12 = new DataSet();
                        string query12 = "select * from HopDong";
                        SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                        adapter12.Fill(data12);
                        hopdong.DataSource = data12.Tables[0];
                    }
                    connection.Close();
                }
        }

        private void mahopdong_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from HopDongThue where MaHopDongThue = '" + mahopdong.Text + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                if (data.Tables[0].Rows.Count == 0)
                {
                    giamuanha.Enabled = true;
                    DataSet data2 = new DataSet();
                    string query2 = "select * from HopDongMua where MaHopDongMua = '" + mahopdong.Text + "'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                    adapter2.Fill(data2);
                    foreach (DataRow row in data2.Tables[0].Rows)
                    {
                        giamuanha.Text = row["GiaMua"].ToString();
                    }
                    hopdongban.Checked = true;
                    ngaythue.Enabled = false;
                    ngayhethan.Enabled = false;
                }
                else
                {
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        giamuanha.Text = null;
                        giamuanha.Enabled = false;
                        hopdongthue.Checked = true;
                        ngaythue.Enabled = true;
                        ngayhethan.Enabled = true;
                        ngaythue.Text = row["NgayBatDau"].ToString();
                        ngayhethan.Text = row["NgayHetHan"].ToString();
                    }
                }
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void hdban_CheckedChanged(object sender, EventArgs e)
        {
            if (hdban.Checked == true)
            {
                giamua1.Enabled = true;
                ngaythue1.Enabled = false;
                ngayhethan1.Enabled = false;
            }
            else
            {
                giamua1.Enabled = false;
                ngaythue1.Enabled = true;
                ngayhethan1.Enabled = true;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
                if (hdthue.Checked == true)
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                    {
                        string mahd = "";
                        do
                        {
                            mahd = Path.GetRandomFileName();
                            mahd = mahd.Replace(".", "");
                        }
                        while (mahd.Length > 11);
                        connection.Open();
                        string query2 = "exec ThemHopDongThue @mahd, @makh, @manha,@ngaykyhd, @ngaythue, @ngayketthuc";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.Parameters.AddWithValue("@mahd", mahd);
                        command2.Parameters.AddWithValue("@makh", makh1.Text);
                        command2.Parameters.AddWithValue("@manha", manha1.Text);
                        command2.Parameters.AddWithValue("@ngaykyhd", ngaykyhopdong1.Value);
                        command2.Parameters.AddWithValue("@ngaythue", ngaythue1.Value);
                        command2.Parameters.AddWithValue("@ngayketthuc", ngayhethan1.Value);
                        int result = command2.ExecuteNonQuery();
                        if (result < 0)
                            MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                            DataSet data12 = new DataSet();
                            string query12 = "select * from HopDong";
                            SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                            adapter12.Fill(data12);
                            hopdong.DataSource = data12.Tables[0];
                        }
                        connection.Close();
                    }
                if (hdban.Checked == true)
                    using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                    {
                        string mahd = "";
                        do
                        {
                            mahd = Path.GetRandomFileName();
                            mahd = mahd.Replace(".", "");
                        }
                        while (mahd.Length > 11);
                        connection.Open();
                        string query2 = "exec ThemHopDongBan @mahd, @makh, @manha, @ngaykyhd, @giatien";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.Parameters.AddWithValue("@mahd", mahd);
                        command2.Parameters.AddWithValue("@makh", makh1.Text);
                        command2.Parameters.AddWithValue("@manha", manha1.Text);
                        command2.Parameters.AddWithValue("@ngaykyhd", ngaykyhopdong1.Value);
                        command2.Parameters.AddWithValue("@giatien", giamua1.Text);
                        int result = command2.ExecuteNonQuery();
                        if (result < 0)
                            MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                            DataSet data12 = new DataSet();
                            string query12 = "select * from HopDong";
                            SqlDataAdapter adapter12 = new SqlDataAdapter(query12, connection);
                            adapter12.Fill(data12);
                            hopdong.DataSource = data12.Tables[0];
                        }
                        connection.Close();
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec XemLichSuXemNha '" + makhachhangxtc.Text + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                lsxemnha.DataSource = data.Tables[0];
                connection.Close();
            }
        }

        private void themlsxn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                connection.Open();
                string query2 = "exec ThemLichSuXemNha @makh,@manha,@ngayxem,@nhanxet";
                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.Parameters.AddWithValue("@makh", makhls.Text);
                command2.Parameters.AddWithValue("@manha", manhals.Text);
                command2.Parameters.AddWithValue("@ngayxem", ngayxemls.Value);
                command2.Parameters.AddWithValue("@nhanxet", nhanxetls.Text);
                int result = command2.ExecuteNonQuery();
                if (result < 0)
                    MessageBox.Show("không Thành công", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Thành công", "Success", MessageBoxButtons.OK);
                }
                connection.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fix_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form nhanvienfix = new NhanVienFix(manhanvien);
            nhanvienfix.ShowDialog();
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
