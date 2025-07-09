//Этот файл содержит точку входа, отвечает за запуск формы 

using System;
using System.Windows.Forms;

namespace FileOpener;

static class Program//Основной класс
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()//Метод как точка входа
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}