//Основной файл содержащий логику приложения. Здесь пишуться обработчики событий и другие методы

namespace FileOpener;//Обьявление пространство имен

public partial class Form1 : Form//Обьявление класса Form1, который наследуется от Form
{
    public Form1()//Конструктор класса Form1
    {
        InitializeComponent();//Вызов метода инициализации компонентов формы
    }

    private void openFileButton_Click(object sender, EventArgs e)//Обработчик события Click для кнопки openFileButton
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Здесь можно обрабатывать открытый файл
                string filePath = openFileDialog.FileName;
                MessageBox.Show($"Вы открыли файл:{filePath}");
            }
        }
    }
}
