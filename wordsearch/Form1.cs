using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordsearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.doWordSearch();
        }

        private bool tooLong(int direction, Point wordStart, int wordLength)
        {
            if (direction == 1) // Word going up
            {
                if ((wordStart.Y - wordLength) < 0)
                    return true;
            }
            else if (direction == 2) // Word going diagonal up-right
            {
                if ((wordStart.Y - wordLength) < 0 || (wordStart.X + wordLength) > 10)
                    return true;
            }
            else if (direction == 3) // Word going right 
            {
                if ((wordStart.X + wordLength) > 10)
                    return true;
            }
            else if (direction == 4) // Word going diagonal down-right
            {
                if ((wordStart.Y + wordLength) > 10 || (wordStart.X + wordLength) > 10)
                    return true;
            }
            else if (direction == 5) // Word going down
            {
                if ((wordStart.Y + wordLength) > 10)
                    return true;
            }
            else if (direction == 6) // Word going diagonal down-left
            {
                if ((wordStart.Y + wordLength) > 10 || (wordStart.X - wordLength) < 0)
                    return true;
            }
            else if (direction == 7) // Word going Left
            {
                if ((wordStart.X - wordLength) < 0)
                    return true;
            }
            else if (direction == 8) // Word going diagonal up left
            {
                if ((wordStart.Y - wordLength) < 0 || (wordStart.X - wordLength) < 0)
                    return true;
            }
            return false;
        }

        // Method used to generate random numbers:
        private object stateLock = new object();
        private Random rnd = new Random();
        private int getRand(int num, int num2)
        {
            lock (stateLock)
                return rnd.Next(num, num2);
        }

        // Method used to reload the word search
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.doWordSearch();
        }

        private void doWordSearch()
        {
            this.wordSearch.Rows.Clear();
            this.wordSearch.Columns.Clear();

            this.wordSearch.AllowUserToAddRows = false;

            // Setting up the word search by adding 10 columns and 10 rows:
            for (int i = 0; i < 10; i++)
            {
                string colNum = "col" + (i + 1);
                this.wordSearch.Columns.Add(colNum, colNum);
            }
            this.wordSearch.Rows.Add(10);

            // For loops used to fill in remaining gaps after the word has been layed out inside the grid:
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.wordSearch[i, j].Value = (char)(('a') + getRand(0, 26));
                }
            }

            // Setting up arrays of pre-installed words for the user to find + an alphabet array:
            this.locationsOfLetters = new List<Point>();
            string[] words = this.lstWords.Items.OfType<string>().ToArray();
            
            //If there are no words don't continue running this method
            if (words.Length == 0)
                return;
            
            //Get random word
            string word = words[getRand(0, words.Length)];

            // Tell the user what word they are looking for:
            this.lblWord.Text = "Word to look for: " + word;

            // Setting up directions for the word to span:
            int[] directions = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int direction = directions[getRand(0, directions.Length)];

            // Get a location for the word to start at:
            Point wordStart;

            do
            {
                wordStart = new Point(getRand(0, 10), getRand(0, 10));
            } while (this.tooLong(direction, wordStart, word.Length));

            // Iterate over the chosen word and lay it out in the randomly chosen direction:
            Point currentPoint = new Point(wordStart.X, wordStart.Y);
            for (int i = 0; i < word.Length; i++)
            {
                this.wordSearch[currentPoint.X, currentPoint.Y].Value = word[i];
                this.locationsOfLetters.Add(currentPoint);
                this.wordSearch[currentPoint.X, currentPoint.Y].Style.BackColor = Color.LightGray;
                switch (direction)
                {
                    case 1:
                        currentPoint.Y = (currentPoint.Y - 1);
                        break;

                    case 2:
                        currentPoint.Y = (currentPoint.Y - 1);
                        currentPoint.X = (currentPoint.X + 1);
                        break;

                    case 3:
                        currentPoint.X = (currentPoint.X + 1);
                        break;
                    case 4:
                        currentPoint.Y = (currentPoint.Y + 1);
                        currentPoint.X = (currentPoint.X + 1);
                        break;
                    case 5:
                        currentPoint.Y = (currentPoint.Y + 1);
                        break;
                    case 6:
                        currentPoint.Y = (currentPoint.Y + 1);
                        currentPoint.X = (currentPoint.X - 1);
                        break;
                    case 7:
                        currentPoint.X = (currentPoint.X - 1);
                        break;
                    case 8:
                        currentPoint.Y = (currentPoint.Y - 1);
                        currentPoint.X = (currentPoint.X - 1);
                        break;
                }
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            //Add a word to the listbox of words available
            string wordEdited = this.txtInput.Text.Replace(" ", "");
            if (wordEdited.Length > 0 && wordEdited.Length <= 10 && !this.lstWords.Items.Contains(wordEdited))
            {
                this.lstWords.Items.Add(wordEdited);
            }
            else
            {
                MessageBox.Show("Word is too long, short, or has already been entered");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Removing a word from the available words
            this.lstWords.Items.Remove(this.lstWords.SelectedItem);
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            //Adding a file full of words into the listbox of available words
            DialogResult result = this.openFileDialog.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string file = this.openFileDialog.FileName;
                try
                {
                    foreach (string word in File.ReadAllLines(file))
                        this.lstWords.Items.Add(word);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<Point> locationsOfLetters;
        private void selectionChanged(object sender, EventArgs e)
        {
            /*
            Check to see if the user has selected all the letters positions allowing for the word to
            be found
            */
            
            DataGridViewSelectedCellCollection cells = this.wordSearch.SelectedCells;

            if (cells.Count <= 0 || this.locationsOfLetters == null)
                return;
            
            //Points selected
            List<Point> pointsSelected = new List<Point>();
            foreach (DataGridViewTextBoxCell cell in cells)
            {
                pointsSelected.Add(new Point(cell.ColumnIndex, cell.RowIndex));
            }
            
            //If the letters positions are the same as the selected positions
            if (pointsSelected.All(this.locationsOfLetters.Contains) && pointsSelected.Count == this.locationsOfLetters.Count)
                this.label1.Text = "Found word";
            else
                this.label1.Text = "Not found word yet";
        }
    }
}
