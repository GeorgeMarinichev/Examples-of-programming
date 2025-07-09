namespace GifWallpaper;

public partial class Form1: Form // Основной класс формы
{
    public Form1()// Конструктор формы
    {
        InitializeComponent();// Инициализация компонентов формы
        LoadGif();// Вызов метода для загрузки GIF

        //this.FormBorderStyle = FormBorderStyle.None; // Убираем рамку
        this.WindowState = FormWindowState.Maximized; // Разворачиваем форму на весь экран
        this.StartPosition = FormStartPosition.CenterScreen; // Центрируем форму на экране
        this.MaximizeBox = false; // Отключаем кнопку "Развернуть"
    }

    private void LoadGif()// Метод для загрузки анимированного GIF
    {
        //string gifPath = Console.ReadLine();
        string gifPath = @"C:\Users\User\Desktop\fff.gif";// Путь к gif файлу

        PictureBox pictureBox = new PictureBox()// Создание нового элемента PictureBox
        {
            ImageLocation = gifPath, // Установка пути к изображению
            SizeMode = PictureBoxSizeMode.StretchImage, // Растянуть изображение по размеру PictureBox
            Dock = DockStyle.Fill, // Заставить PictureBox занимать всю форму
        };
        this.Controls.Add(pictureBox);// Добавление PictureBox на форму

    }
}
