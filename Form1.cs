using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_andmebaas
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\tooded.mdf;Integrated Security = True;");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kat_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void lisa_kat_btn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in kat_box.Items)
            {
                if (item.ToString() == kat_box.Text)
                {
                    on = true;
                }
            }

            if (on == false)
            {
                command = new SqlCommand("INSERT INTO Kategooriatabel (Kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", kat_box.Text);
                command.ExecuteNonQuery();
                connect.Close();
                kat_box.Items.Clear();
                Naitakategooriad();
            }
            else
            {
                MessageBox.Show("Selline kategooria on juba olemas");
            }
        }

        private void kustuta_kat_btn_Click(object sender, EventArgs e)
        {
            if (kat_box.SelectedItem!=null)
            {
                connect.Open();
                string kat_val = kat_box.SelectedItem.ToString();
                command = new SqlCommand("delete from Kategooriatabel where Kategooria_nimetus=@kat ",connect);
                command.Parameters.AddWithValue("@kat", kat_val);
                command.ExecuteNonQuery();
                connect.Close();
                kat_box.Items.Clear(); 
                Naitakategooriad();
            }
        }

        private void toode_pb_Click(object sender, EventArgs e)
        {

        }
        SaveFileDialog save;
        OpenFileDialog open;
        string extension = null;

        private void otsifail_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\source\repos\adriTARpv24\form+andmebaas\images";
            open.Multiselect = true;
            open.Filter = "images Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\source\repos\adriTARpv24\form+andmebaas\images" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\images");
                extension = Path.GetExtension(open.FileName);
                save.FileName = Toode_txt.Text + Path.GetExtension(open.FileName);
                save.Filter = "images" + Path.GetExtension(open.FileName) + "|" + Path.GetExtension(open.FileName);

                if (save.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    toode_pb.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või oli vajutatud Cancel");
            }
        }

        Form popupForm;
        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = new Size(200,200);
            
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            popupForm.Controls.Add(pictureBox);

            System.Drawing.Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            System.Drawing.Point popupLocation = dataGridView1.PointToScreen(cellRectangle.Location);

            popupForm.Location = new System.Drawing.Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
            popupForm.Show();

        }
        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            SqlDataAdapter adapter_toode = new SqlDataAdapter("Select Toodetabel.Id,Toodetabel.Toodenimetus,Toodetabel.Kogus,"+
                "Toodetabel.Hind,Toodetabel.Pilt,Toodetabel.Bpilt, Kategooriatabel.Kategooria_nimetus " +
                "as Kategooria_nimetus from Toodetabel inner join Kategooriatabel on Toodetabel.Kategooriad=Kategooriatabel.Id", connect);

            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach(DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            toode_pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\images"), "pood.png"));
            connect.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        byte[] imageData;


        private void lisa_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != string.Empty &&
                Kogus_txt.Text.Trim() != string.Empty &&
                Hind_txt.Text.Trim() != string.Empty &&
                kat_box.SelectedItem != null)
            {
                try
                {
                    if (open == null || string.IsNullOrEmpty(open.FileName))
                    {
                        MessageBox.Show("Palun vali esmalt toote pilt!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    connect.Open();

                    SqlCommand command = new SqlCommand(
                        "SELECT Id FROM Kategooriatabel WHERE Kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", kat_box.Text);
                    int Id = Convert.ToInt32(command.ExecuteScalar());

                    command = new SqlCommand(
                        "INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilt, Bpilt, Kategooriad) " +
                        "VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", connect);

                    command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus_txt.Text));
                    command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind_txt.Text));

                    string extension = Path.GetExtension(open.FileName);
                    command.Parameters.AddWithValue("@pilt", Toode_txt.Text + extension);

                    byte[] imageData = File.ReadAllBytes(open.FileName);
                    command.Parameters.AddWithValue("@bpilt", imageData);
                    command.Parameters.AddWithValue("@kat", Id);

                    command.ExecuteNonQuery();
                    connect.Close();

                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Andmebaasiga viga! " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad!", "Viga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Loopilt(image, e.RowIndex);
                    }
                }

            }

        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (popupForm != null && !popupForm.IsDisposed)
            {
                popupForm.Close();
            }
        }



        public void Naitakategooriad()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("Select Id,Kategooria_nimetus FROM Kategooriatabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!kat_box.Items.Contains(item["Kategooria_nimetus"]))
                {
                    kat_box.Items.Add(item["Kategooria_nimetus"]);
                }
                else
                {
                    command = new SqlCommand("Delete from Kategooriatabel where Id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }
    }
}
