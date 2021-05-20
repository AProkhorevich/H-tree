using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZedGraph;

namespace Program1
{
    public partial class Form1 : Form
    {
        private int n = 0;

        private void button_do_steps_Click(object sender, EventArgs e)
        {
            if (cnt_steps_box.Text.Length == 0)
            {
                error_label.Visible = true;
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            else
            {
                error_label.Visible = false;
                CreateGraph(zedGraphControl1);
            }
        }
        private void H(double x, double y, double razmer, GraphPane pane)//функция отрисовки одной Н
        {
            LineObj line = new LineObj(Color.Red, x - razmer, y - razmer, x - razmer, y + razmer);
            LineObj line2 = new LineObj(Color.Red, x - razmer, y, x + razmer, y);
            LineObj line3 = new LineObj(Color.Red, x + razmer, y - razmer, x + razmer, y + razmer);
            pane.GraphObjList.Add(line);
            pane.GraphObjList.Add(line2);
            pane.GraphObjList.Add(line3);
        }

        private void H_fractal(double x1, double y1, double razm_f, double n, GraphPane pane, int depth, double reduction_ratio)
        {
            depth++;
            //вершины фигуры Н
            double x00; double y00;
            double x01; double y01;
            double x10; double y10;
            double x11; double y11;
            x00 = x1 - razm_f;
            y00 = y1 - razm_f;
            x01 = x1 - razm_f;
            y01 = y1 + razm_f;
            x10 = x1 + razm_f;
            y10 = y1 - razm_f;
            x11 = x1 + razm_f;
            y11 = y1 + razm_f;


            H(x1, y1, razm_f, pane);//рисуем одну фигуру Н
            razm_f = razm_f / reduction_ratio;//уменьшаем размер в reduction_ratio раз

            if (depth < n)
            {
                H_fractal(x11, y11, razm_f, n, pane, depth, reduction_ratio);
                H_fractal(x01, y01, razm_f, n, pane, depth, reduction_ratio);
                H_fractal(x10, y10, razm_f, n, pane, depth, reduction_ratio);
                H_fractal(x00, y00, razm_f, n, pane, depth, reduction_ratio);
            }
        }


        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane pane = zgc.GraphPane;
            var rand = new Random();
            int n = Convert.ToInt32(cnt_steps_box.Text);
            int k;
            try
            {
                k = Convert.ToInt32(reduction_ratio_box.Text);
            }
            catch (Exception)
            {
                k = 2;
            }
            label1.Text = "k = " + Convert.ToString(k);
            label1.Visible = true;
            pane.Title.Text = "Фрактал";
            pane.XAxis.Cross = 0.0;
            pane.YAxis.Cross = 0.0;
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            zgc.IsShowHScrollBar = true;
            zgc.IsShowVScrollBar = true;
            zgc.ScrollMaxY = 5;
            zgc.ScrollMinY = -5;
            zgc.ScrollMaxX = 5;
            zgc.ScrollMinX = -5;
            double line_len = 1;
            H_fractal(0, 0, line_len, n, pane, 0, k);
            zgc.Update();
            zgc.AxisChange();
            zgc.Invalidate();

        }



        public Form1()
        {
            InitializeComponent();
        }

        private void SavePaneImage(ZedGraphControl zgc)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.jpg|*.jpeg|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                GraphPane pane = zgc.GraphPane;
                Bitmap bmp = pane.GetImage();
                if (dlg.FileName.EndsWith(".jpg") || dlg.FileName.EndsWith(".jpeg"))
                    bmp.Save(dlg.FileName, ImageFormat.Jpeg);
                else
                    bmp.Save(dlg.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePaneImage(zedGraphControl1);
        }
    }
}
