using System;
using System.Windows.Forms;

namespace GifWallpaper;

public class MainForm
{
    [STAThread]//Атрибут указывает, что метод будет использовать однопоточную модель
    static void Main()// Основной метод программы
    {
        Application.EnableVisualStyles();// Включение визуальных стилей
        Application.SetCompatibleTextRenderingDefault(false);// Установка совместимости с текстовым рендерингом
        Application.Run(new Form1());// Запуск приложения с созданием экземпляра MainForm
    }    

}




