using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;




namespace Sistema_de_Recomendacion
{
    public partial class frmSelect : Form
    {
        private string pathCSV = Path.Combine(Environment.CurrentDirectory, "Data", "movies.csv");
        private List<Models.Movie> ListMovies = new List<Models.Movie>();
        private int userId = 0;
        public int id { get => userId;}

        public frmSelect()
        {
            InitializeComponent();
            saveMovies();
            lblResultado.Visible = false;
            comboBox1.FormattingEnabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            fillCombo();
            comboBox1.SelectedIndex = 0;
            lblId.Text = "ID: " + userId;
        }

        //Guarda las peliculas del archivo a una lista
        private void saveMovies() {

            var reader = new StreamReader(File.OpenRead(pathCSV));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();

            while (!reader.EndOfStream)
            {
                //var movies = new StreamReader(File.OpenRead(pathCSV));
                var line = reader.ReadLine();
                var values = line.Split(';');
                string name = values[0].Split(',').ElementAt(1).TrimStart().Replace("\"","");
                string id = values[0].Split(',').ElementAt(0);

                ListMovies.Add(new Models.Movie() { Movies = name.ToUpper(), Codes = id });
                
            }
            reader.Close();
        }

        //carga las peliculas de la lista al combobox
        private void fillCombo()
        {
            foreach(Models.Movie Movies in ListMovies)
            {
                comboBox1.Items.Add(Movies.Movies);
            }
                
        }
        

        //calcula % de probabilidad de que le guste una pelicula
        private void process()
        {
            try
            {
                Predictions predictions = new Predictions();
                predictions.Process(userId.ToString(),findCode());

                if (predictions.LikeOrNot)
                {
                    MessageBox.Show("Esta pelicula te encantará","Genial",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No estoy seguro que sea tu tipo...","Emmm...",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                lblResultado.Text = predictions.MovRecomended;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //Buscar pelicula
        private void searchMovie()
        {
            try
            {
                if(txtBusqueda.Text.Trim().ToString() == "")
                {
                    MessageBox.Show("Debe escrbir algo para buscar", "Puto",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                var search = ListMovies.Where(Movies => Movies.Movies.Contains(txtBusqueda.Text.ToUpper()));
               
                    comboBox1.Items.Clear();
                    foreach (Models.Movie Movies in search)
                    {
                        comboBox1.Items.Add(Movies.Movies);
                    }
                if (comboBox1.Items.Count <= 0)
                {
                    MessageBox.Show("Pelicula no encontrada :(", "Opps!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    fillCombo();

                }
                else
                {
                    MessageBox.Show("Busqueda completada, deplega la lista de peliculas para encontrar su pelicula", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Busca las imagenes de manera dinamica
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                lblResultado.Visible = false;
                int code = 0;
                string img;
                code = int.Parse(findCode());
                img = Path.Combine(Environment.CurrentDirectory, "Movies", code + ".jpg");
                pictureBox1.ImageLocation = img;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Encuentra los id de las peliculas
        private string findCode()
        {

            try
            {
                string code = string.Empty;
                string img;
                var search = ListMovies.Where(Movies => Movies.Movies.StartsWith(comboBox1.Text));
                foreach (Models.Movie Movies in search)
                {
                    if (Movies.Codes != "movieId")
                    {
                        code = Movies.Codes;
                        img = Path.Combine(Environment.CurrentDirectory, "Movies", code + ".jpg");
                        pictureBox1.ImageLocation = img;
                        return code;
                    }
                    if (comboBox1.Text == "TITLE")
                    {
                        pictureBox1.ImageLocation = Path.Combine(Environment.CurrentDirectory, "Movies", code + ".jpg");
                        return "0";
                    }
                }
                return "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblResultado.Visible = false;
            searchMovie();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            process();
            lblResultado.Visible = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmWelcome welcome = new frmWelcome();
            welcome.Visible = true;
        }
    }
}
