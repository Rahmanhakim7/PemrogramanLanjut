using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktikum8
{
    public partial class GenresForm : Form
    {
        public GenresForm()
        {
            InitializeComponent();
        }

        
        GENRE genre = new GENRE();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text; 

            if (name.Trim().Equals(""))
            {
                MessageBox.Show("Enter the Genre Name",
                "Empty Genre",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                if (genre.addGenre(id, name))
                {
                    MessageBox.Show("New Genre Added Succesfully!",
                    "New Genre", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    dgGenres.DataSource = genre.GenresList();
                    
                }
                else
                {
                    MessageBox.Show("Genre Not Added ",
                    "Add Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;

                if (name.Trim().Equals(""))
                {
                    MessageBox.Show("Enter The Genre Name",
                    "Empty Genre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    if (genre.editGenre(id, name))
                    {
                        MessageBox.Show("Genre Name Updated Succesfully!",
                        "Edit Genre",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        dgGenres.DataSource = genre.GenresList();
                    }
                    else
                    {
                        MessageBox.Show("Genre Not Updated ",
                        "Edit Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);

                if (genre.removeGenre(id))
                {
                    MessageBox.Show("Genre Deleted Succesfully!",
                    "Delete Genre",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    txtId.Text = "";
                    txtName.Text = "";

                    dgGenres.DataSource = genre.GenresList();
                }
                else
                {
                    MessageBox.Show("Genre Not Deleted",
                    "Deleted Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }

        }

        private void GenresForm_Load(object sender, EventArgs e)
        {
                dgGenres.DataSource = genre.GenresList();
                dgGenres.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
                dgGenres.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial",
                    14, FontStyle.Bold);
                dgGenres.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgGenres.EnableHeadersVisualStyles = false;
        }

        private void dgGenres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgGenres.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgGenres.CurrentRow.Cells[1].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
