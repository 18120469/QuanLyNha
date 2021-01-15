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
    public partial class adminFix : Form
    {
        public BindingSource dsnha = new BindingSource();
        public static string maadmin;
        public adminFix(string ma)
        {
            maadmin = ma;
            InitializeComponent();
            load();
        }
        public void load()
        {
            danhsachnha.DataSource = dsnha;
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "select * from Nha";
                connection.Open();
                SqlCommand command2 = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                adapter.Fill(data);
                connection.Close();
                dsnha.DataSource = data.Tables[0];
            }
            manha.DataBindings.Add(new Binding("text", danhsachnha.DataSource, "MaNha"));
        }

        private void timkiemhopdong_Click(object sender, EventArgs e)
        {
            if (hopdongthue.Checked == true )
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    DataTable table = new DataTable();
                    DataSet data = new DataSet();
                    string query = "exec ThongKeHopDongThue1  @ngaybatdau, @ngayketthuc";
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(query, connection);
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
                        tongsohopdong.Text = row["SoLuongHopDong"].ToString();
                    }
                }
            if (hopdongban.Checked == true)
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    DataTable table = new DataTable();
                    DataSet data = new DataSet();
                    string query = "exec ThongKeHopDongBan1 @ngaybatdau, @ngayketthuc";
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(query, connection);
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
                        tongsohopdong.Text = row["SoLuongHopDong"].ToString();
                    }
                }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataTable table = new DataTable();
                DataSet data = new DataSet();
                string query = "exec ThongKeKhachHangTheoTieuChi1";
                connection.Open();
                SqlCommand command2 = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                adapter.Fill(data);
                connection.Close();
                bangtieuchi.DataSource = data.Tables[0];
                table = data.Tables[1];
                foreach (DataRow row in table.Rows)
                {
                    soluongtieuchi.Text = row["tongsotieuchi"].ToString();
                }
            }
        }

        private void xemls_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec KHXemLichSuXemNha1 '" + manhaxemls.Text + "'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                banglsxemnha.DataSource = data.Tables[0];
                connection.Close();
            }
        }

        private void timkiemnha_Click(object sender, EventArgs e)
        {
            if (machunha.Text!="")
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataTable table = new DataTable();
                DataSet data = new DataSet();
                string query = "exec ThongKeLichSuDangNha1 @machunha";
                connection.Open();
                SqlCommand command2 = new SqlCommand(query, connection);
                command2.Parameters.AddWithValue("@machunha", machunha.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command2;
                adapter.Fill(data);
                connection.Close();
                danhsachnha.DataSource = data.Tables[0];
                table = data.Tables[1];
                foreach (DataRow row in table.Rows)
                {
                    soluongnha.Text = row["SoLuongNhaDang"].ToString();
                }
            }
            if (controng.Checked == true)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
                {
                    DataTable table = new DataTable();
                    DataSet data = new DataSet();
                    string query = "exec ThongKeNhaTrong1";
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command2;
                    adapter.Fill(data);
                    connection.Close();
                    danhsachnha.DataSource = data.Tables[0];
                    table = data.Tables[1];
                    foreach (DataRow row in table.Rows)
                    {
                        soluongnha.Text = row["SoLuongNhaTrong"].ToString();
                    }
                }
            }
        }

        private void timtc_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec ThongKeKhachHangTheoTieuChi1";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@khuvuc", khuvuc.Text);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(data);
                connection.Close();
                dskhtc.DataSource = data.Tables[0];
            }
        }

        private void xemlsxn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionstring))
            {
                DataSet data = new DataSet();
                string query = "exec XemLichSuXemNha1 "+ manha.Text;
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(data);
                connection.Close();
                dslsxemnha.DataSource = data.Tables[0];
            }
        }

        private void chuafix_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adm = new admin(maadmin);
            adm.ShowDialog();
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
