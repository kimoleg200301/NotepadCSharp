using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_13
{
    public partial class Form1 : Form
    {
        private RichTextBox myRichTextBox;

        private static string selectedFilePath;
        private string textContent;

        public Form1()
        {
            InitializeComponent();

            // Инициализация RichTextBox
            myRichTextBox = new RichTextBox();
            myRichTextBox.Dock = DockStyle.Fill;
            Controls.Add(myRichTextBox);

            // Добавление обработчиков событий изменения размеров формы
            this.SizeChanged += mainForm_SizeChanged;

            // Максимизация формы при запуске (полноэкранный режим)
            this.WindowState = FormWindowState.Maximized;
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            // При изменении размеров формы, обновите размеры RichTextBox
            myRichTextBox.Width = this.ClientRectangle.Width;
            myRichTextBox.Height = this.ClientRectangle.Height;
        }

        private void openFilesMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\Users\\User\\Downloads";
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // openFileDialog.FileName содержит выбранный путь к файлу
                //FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                selectedFilePath = openFileDialog.FileName;
                this.Text = $"NotepadC# - {selectedFilePath}"; // Назначаем имя названия окна
                string fileText = File.ReadAllText(selectedFilePath);
                mainForm.Text = fileText;
            }
        }

        private void saveFilesMenu_Click(object sender, EventArgs e)
        {
            if (selectedFilePath == null)
            {
                createAndSaveNewFile();
            }
            else
            {
                File.WriteAllText(selectedFilePath, mainForm.Text);
            }
        }

        private void newFilesMenu_Click(object sender, EventArgs e)
        {
            createAndSaveNewFile();
        }
        private void createAndSaveNewFile()
        {
            textContent = mainForm.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "C:\\Users\\User\\Downloads";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // saveFileDialog.FileName содержит выбранный путь к файлу
                selectedFilePath = saveFileDialog.FileName;
                this.Text = $"NotepadC# - {selectedFilePath}"; // Назначаем имя названия окна

                File.WriteAllText(selectedFilePath, textContent);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();
            mainForm.Text = clipboardText;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
