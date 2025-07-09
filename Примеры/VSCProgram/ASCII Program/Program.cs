using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Space
{
    public static class Extension
    {
        public static void ToGrayscale(this Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }
        }
    }//
    public class BitmapToASCIIConverter
    {
        char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };//Монохромная политра цвета

        private readonly Bitmap _bitmap;
        public BitmapToASCIIConverter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public char[][] Converter()
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, _asciiTable.Length - 1);
                    result[x][y] = _asciiTable[mapIndex];
                    
                }
            }
            return result;
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)//Метод мапит значения из одного диапазона в другой диапазон
        {
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }//

    class Program
    {
        private const double WIDTH_OFSET = 1.5;//Компенсация картинки по отношению к тексту где каждый символ выше, чем шире
        private const int MAX_WIDTH = 200;

        [STAThread]
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;//
            Console.ForegroundColor = ConsoleColor.Black;//

            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.gif; *.jpg; *.JPEG"
            };

            Console.WriteLine("ASCII Program Convertor, Press enter to start...\n");

            while (true)
            {
                //Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }

                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayscale();

                var convertor = new BitmapToASCIIConverter(bitmap);
                var rows = convertor.Converter();

                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                }
                File.WriteAllLines("image.txt", rows.Select(r => new string(r)));

                Console.SetCursorPosition(0, 0);
            }

            //openFileDialog.ShowDialog();
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            //var maxWidth = 350;
            var newHeight = bitmap.Height / WIDTH_OFSET * MAX_WIDTH / bitmap.Width;

            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
            {
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));

            }
            return bitmap;
        }

    }

}
