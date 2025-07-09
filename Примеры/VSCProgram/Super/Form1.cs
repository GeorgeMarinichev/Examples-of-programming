using Microsoft.VisualBasic.ApplicationServices;
using System.Net;

namespace Super
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////
        readonly string path = @"C:\Users\SmartPlayer\Desktop\123.txt";
        readonly string text = "George1985";
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "Жми!";
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = "Создать";
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                label1.Text = "Файл уже создан!";

            }
            else
            {
                //File.Create(path);//.Dispose();//.Close();
                //FileStream file = new FileStream(path, FileMode.OpenOrCreate);

                using (StreamWriter stream = new StreamWriter(path, true))
                {
                    stream.WriteLine("Абра-кадабра");
                }
                label1.Text = "Файл создан!";

                //using (FileStream file = new FileStream(path, FileMode.Append))
                //{
                //    using (StreamWriter stream = new StreamWriter(file))
                //    {
                //        stream.WriteLine("wwwwwwwwwwwwwww_");
                //        label1.Text = "Файл создан!";
                //    }

                //}




                //File.Copy(path, @"C:\Users\SmartPlayer\Desktop\1\000.txt", true);
                //File.WriteAllText(@"C:\Users\SmartPlayer\Desktop\1\000.txt", text);
                //file.Seek(0, SeekOrigin.End);





                //полная перезапись файла
                //using StreamWriter writer = new StreamWriter(path, false);
                //await writer.WriteLineAsync(text);
                //полная перезапись файла
                //using (StreamWriter writer = new StreamWriter(path, true))
                //{
                //    await writer.WriteLineAsync("Addition");
                //    await writer.WriteLineAsync("4, 5");
                //}

            }
        }

        /////////////////////////////////////////////////////////////
        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Text = "Жми!";
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = "Удалить";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                label1.Text = "Файл удален";
            }
            else
            {
                label1.Text = "Нечего удалять!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

            //using (WebClient wc = new WebClient())
            //{
            //    wc.DownloadFile("https://google.ru/ua/com/lang.txt", path);
            //}
            



        }


    }
}
