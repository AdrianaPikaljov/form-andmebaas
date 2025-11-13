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
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\tooded.mdf;Integrated Security = True;");
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
            if (kat_box.SelectedItem != null)
            {
                connect.Open();
                string kat_val = kat_box.SelectedItem.ToString();
                command = new SqlCommand("delete from Kategooriatabel where Kategooria_nimetus=@kat ", connect);
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
            open.Multiselect = false;
            open.Filter = "Images Files (*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

            if (open.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(Toode_txt.Text))
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\images");
                extension = Path.GetExtension(open.FileName);
                save.FileName = Toode_txt.Text + extension;
                save.Filter = "Images |*" + extension;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    // Lae algne pilt
                    Image original = Image.FromFile(open.FileName);

                    // Loo uus Bitmap sobivas suuruses (nt 300x300)
                    int newWidth = 300;
                    int newHeight = 300;
                    Bitmap resized = new Bitmap(newWidth, newHeight);

                    using (Graphics g = Graphics.FromImage(resized))
                    {
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(original, 0, 0, newWidth, newHeight);
                    }

                    // Salvesta vähendatud pilt
                    resized.Save(save.FileName);

                    // Näita vähendatud pilti PictureBoxis
                    toode_pb.Image = resized;
                    toode_pb.SizeMode = PictureBoxSizeMode.Zoom;

                    // Sulge originaalpilt (vältimaks lukku jäämist)
                    original.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Puudub toote nimetus või vajutati 'Cancel'");
            }
        }


        Form popupForm;
        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = new Size(200, 200);

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
            adapter_toode = new SqlDataAdapter(
    "SELECT Toodetabel.Id, Toodetabel.Toodenimetus, Toodetabel.Kogus, " +
    "Toodetabel.Hind, Toodetabel.Pilt, Toodetabel.Bpilt, " +
    "Kategooriatabel.Kategooria_nimetus AS Kategooria_nimetus " +
    "FROM Toodetabel INNER JOIN Kategooriatabel ON Toodetabel.Kategooriad = Kategooriatabel.Id",
    connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
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
                        "INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilt, BPilt, Kategooriad) " +
                        "VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", connect);

                    command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    command.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    command.Parameters.AddWithValue("@hind", Hind_txt.Text);

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

        private void puhasta_btn_Click(object sender, EventArgs e)
        {
            Toode_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            kat_box.SelectedItem = null;

            using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"..\..\images"), "pood.png"), FileMode.Open, FileAccess.Read))
            {
                toode_pb.Image = Image.FromStream(fs);
            }
        }

        private void kustuta_btn_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            MessageBox.Show(Id.ToString());
            if (Id != 0)
            {
                command = new SqlCommand("delete Toodetabel where Id=@id", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connect.Close();

                NaitaAndmed();
                MessageBox.Show("andmed tabelist tooded on kustutatud");

            }
            else
            {
                MessageBox.Show("viga tooded tabelist andmete kustutamisega");
            }
        }
        int Id = 0;
        private void uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text != "" && Kogus_txt.Text != "" && Hind_txt.Text != "" && toode_pb.Image != null)
            {
                try
                {
                    int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                    string file_pilt = Toode_txt.Text + extension;

                    MemoryStream ms = new MemoryStream();
                    toode_pb.Image.Save(ms, toode_pb.Image.RawFormat);
                    byte[] imgBytes = ms.ToArray();

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE ToodeTabel SET Toodenimetus=@toode, Kogus=@kogus, Hind=@hind, Pilt=@pilt, BPilt=@BPilt WHERE Id=@id",
                        connect))
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                        command.Parameters.AddWithValue("@kogus", Convert.ToInt32(Kogus_txt.Text));
                        command.Parameters.AddWithValue("@hind", Convert.ToDouble(Hind_txt.Text));
                        command.Parameters.AddWithValue("@pilt", file_pilt);
                        command.Parameters.Add("@BPilt", SqlDbType.VarBinary).Value = imgBytes;

                        connect.Open();
                        command.ExecuteNonQuery();
                        connect.Close();
                    }

                    NaitaAndmed();
                    MessageBox.Show("Andmed uuendatud");
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Viga: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik väljad ja lisa pilt");
            }
        }
        private List<string> Failid_KatId(int kat_Id)
        {
            string path = $@"..\..\images\{kat_Id}";
            if (!Directory.Exists(path))
                return new List<string>();
            return Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToList();
        }


        public void naita_kat_Click(object sender, EventArgs e)
        {
            Size newSize = new Size(1350, 600);
            TabControl kategooriad = new TabControl();
            kategooriad.Name = "kategooriad";
            kategooriad.Dock = DockStyle.Left;
            kategooriad.Width = 450;
            kategooriad.Height = newSize.Height;
            kategooriad.Location = new System.Drawing.Point(900, 0);

            SqlDataAdapter adapter_kat = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooriatabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);

            ImageList iconsList = new ImageList();
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);

            int i = 0;

            foreach (DataRow nimetus in dt_kat.Rows)
            {
                kategooriad.TabPages.Add((string)nimetus["kategooria_nimetus"]);

                iconsList.Images.Add(Image.FromFile(@"..\..\kat_pildid\" + (string)nimetus["kategooria_nimetus"] + ".jpg"));
                kategooriad.TabPages[i].ImageIndex = i;
                i++;

                int kat_Id = (int)nimetus["Id"];
                var fail_list = Failid_KatId(kat_Id);

                int r = 0;
                int c = 0;

                foreach (var fail in fail_list)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(@"..\..\images\" + fail);
                    pictureBox.Width = pictureBox.Height = 100;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new System.Drawing.Point(c, r);

                    c += 102;

                    kategooriad.TabPages[i - 1].Controls.Add(pictureBox);
                }
            }

            kategooriad.ImageList = iconsList;
            connect.Close();
            this.Controls.Add(kategooriad);
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
