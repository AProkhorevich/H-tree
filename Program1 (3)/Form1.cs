using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

namespace Program1
{
    public partial class Form1 : Form
    {
        //Возвращает рандомное число от 1 до 100
        public int GetRandom() {
            var rand = new Random();
            return rand.Next(1, 101);
        }

        //Возвращает матрицу A
        private double[][] GetMatrix(int p) {
            double[][] A = new double[2][];
            A[0] = new double[2];
            A[1] = new double[2];
            if (p == 1) {
                A[0][0] = 0;
                A[0][1] = 0;
                A[1][0] = 0;
                A[1][1] = 0.165;
            }
            else if (p <= 86) {
                A[0][0] = 0.84;
                A[0][1] = 0.045;
                A[1][0] = -0.045;
                A[1][1] = 0.86;
            }
            else if (p <= 93) {
                A[0][0] = 0.25;
                A[0][1] = -0.26;
                A[1][0] = 0.23;
                A[1][1] = 0.25;
            }
            else {
                A[0][0] = -0.135;
                A[0][1] = 0.28;
                A[1][0] = 0.26;
                A[1][1] = 0.245;
            }
            return A;
        }

        //Возвращает вектор B
        private double[] GetVector(int p) {
            double[] B = new double[2];
            if (p == 1) {
                B[0] = 0;
                B[1] = 0;
            }
            else if (p <= 86) {
                B[0] = 0;
                B[1] = 1.6;
            }
            else if (p <= 93) {
                B[0] = 0;
                B[1] = 1.6;
            }
            else {
                B[0] = 0;
                B[1] = 0.44;
            }
            return B;
        }

        //Считает координаты новой точки
        private double[] Calc(double[] x, double[][] A, double[] B)
        {
            double[] c = new double[2];
            c[0] = A[0][0] * x[0] + A[0][1] * x[1];
            c[1] = A[1][0] * x[0] + A[1][1] * x[1];
            c[0] += B[0];
            c[1] += B[1];
            return c;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetSize(); //установление размера ZedGraphControl (заполняет всю форму)
        }

        public Form1()
        {
            InitializeComponent();
        }

        //размер ZedGraphControl подстраивается под изменение размера формы
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void zedGraphControl1_MouseMove(object sender, MouseEventArgs e)//Обработка движения мыши
        {
            // Сюда будут записаны координаты в системе координат графика
            double x, y;
            // Пересчитываем пиксели в координаты на графике
            zedGraphControl1.GraphPane.ReverseTransform(e.Location, out x, out y);
            // Выводим результат
            string text = string.Format("X: {0};    Y: {1}", x, y);
            label1.Text = text;
        }

        private void CreateGraph(ZedGraphControl zgc)//Создание графика
        {
            //получим панель для рисования
            GraphPane pane = zgc.GraphPane;

            //заголовок и подписи осей
            pane.Title.Text = "График";
            pane.XAxis.Title.Text = "X";
            pane.YAxis.Title.Text = "Y";

            // Очистим список кривых на тот случай, если до этого уже было что-то нарисовано
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList list = new PointPairList();

            double[] X = new double[2];
            try
            {
                var tmp = textBox1.Text.Split(',');
                X[0] = Int32.Parse(tmp[0]);
                X[1] = Int32.Parse(tmp[1]);
            } catch (FormatException e)
            {
                X[0] = GetRandom();
                X[1] = GetRandom();
            }
            catch (System.IndexOutOfRangeException e)
            {
                X[0] = GetRandom();
                X[1] = GetRandom();
            }
            list.Add(X[0], X[1]);
            for (int i = 0; i < 100000; i++)
            {
                int p = GetRandom();
                var A = GetMatrix(p);
                var B = GetVector(p);
                var c = Calc(X, A, B);
                list.Add(c[0], c[1]);
                X[0] = c[0];
                X[1] = c[1];
            }
            LineItem myCurve = pane.AddCurve("", list, Color.Red, SymbolType.Circle);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Fill.Type = FillType.Solid;
            myCurve.Symbol.Size = 5;
            pane.XAxis.Cross = 0.0;
            // Ось Y будет пересекаться с осью X на уровне X = 0
            pane.YAxis.Cross = 0.0;
            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zgc.AxisChange();
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 350, ClientRectangle.Height - 170);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1); //прорисовка графика
        }

        private void SavePaneImage(ZedGraphControl zgc)
        {
            // ДИалог выбора имени файла создаем вручную
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.jpg;|*.jpeg|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Получием панель по ее индексу
                GraphPane pane = zgc.GraphPane;

                // Получаем картинку, соответствующую панели
                Bitmap bmp = pane.GetImage();

                // Сохраняем картинку средствами класса Bitmap
                // Формат картинки выбирается исходя из имени выбранного файла
                if (dlg.FileName.EndsWith(".jpg") || dlg.FileName.EndsWith(".jpeg"))
                {
                    bmp.Save(dlg.FileName, ImageFormat.Jpeg);
                }
                else
                {
                    bmp.Save(dlg.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SavePaneImage(zedGraphControl1);
        }
    }
}
