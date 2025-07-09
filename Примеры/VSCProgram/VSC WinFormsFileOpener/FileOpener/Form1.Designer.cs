//Этот файл отвечает за за создание и настройку элементов управления на форме

namespace FileOpener;//Обьявление пространство имен

partial class Form1//Обьявляется частичный класс Form1, который будет содержать код для формы
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;//Компоненты формы которые будут использоваться

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private System.Windows.Forms.Button openFileButton;//Обьявление кнопки как компонента формы
    private void InitializeComponent()//Метод для инициализации компонентов формы
    {
        this.components = new System.ComponentModel.Container();//
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;//
        

        this.openFileButton = new System.Windows.Forms.Button();//Создание кнопки
        this.SuspendLayout();//Настойка компонентов

        //Настраивание свойств кнопки openFileButton
        this.openFileButton.Location = new System.Drawing.Point(12, 12);//Расположение кнопки на форме
        this.openFileButton.Name = "openFileButton";//Имя кнопки исползование в коде
        this.openFileButton.Size = new System.Drawing.Size(75, 23);//Размер кнопки
        this.openFileButton.TabIndex = 0;
        this.openFileButton.BackColor = System.Drawing.Color.Blue;//Настрока цвета кнопки
        this.openFileButton.ForeColor = System.Drawing.Color.Black;//Настрока цвета текста кнопки
        this.openFileButton.Text = "Открыть файл";//Текст на кнопке
        //this.openFileButton.UseVisualStyleBackColor = true;//Стиль стандартный
        this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);

        //Настраиваемые свойства основной формы
        this.ClientSize = new System.Drawing.Size(284, 261);//Установка размера формы
        
        this.Controls.Add(this.openFileButton);//Добавление кнопки на форме

        this.Name = "Form1";//Установка имени формы
        this.BackColor = System.Drawing.Color.Green;//Настрока цвета формы
        this.TransparencyKey = System.Drawing.Color.Green;//Создание прозрачных цветных элементов
        this.Text = "Открытие файлов";//Текст формы
        this.ForeColor = System.Drawing.Color.Red;//Настрока цвета кромки формы
        //this.Opacity = 0.5;//Настрока уровня прозрачности всей формы вместе с элементами
        this.ResumeLayout(false);//Завершение настройки компонентов
    }

    #endregion
}
