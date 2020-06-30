using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_3_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Point> pointsList;
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;
        double hx, hy;
        int id = 0;
        private Dictionary<int, List<Point>> bindings;
        private int maxBind = 1;

        public MainWindow()
        {
            pointsList = new ObservableCollection<Point>();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            InitializeComponent();
            bindings = new Dictionary<int, List<Point>>();
            bindings[maxBind] = pointsList.ToList();
            //label1.Content = "Table " + maxBind.ToString();
            combobox1.Items.Add(maxBind);
            dataGridPoints.ItemsSource = pointsList;

            dataGridPoints.Items.Refresh();



            //PaintGrid();
            //Paint_Grid();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                var writePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var item in pointsList)
                    {
                        sw.Write(item.X);
                        sw.Write(" ");
                        sw.Write(item.Y);
                        sw.WriteLine();
                    }
                }
            }
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                pointsList = new ObservableCollection<Point>();
                var fPath = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(fPath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' });
                        var t = new Point();
                        pointsList.Add(new Point() { X = Convert.ToDouble(words[0]), Y = Convert.ToDouble(words[1]) });
                    }

                }
                maxBind++;
                bindings.Add(maxBind, pointsList.ToList());
                combobox1.Items.Add(maxBind);
                label1.Content = "Table " + maxBind.ToString();
                combobox1.SelectedItem = maxBind;
                dataGridPoints.ItemsSource = pointsList;
                Update();
            }

        }

        private void Paint()
        {
            Paint_Grid();

            Polyline poly = new Polyline();
            PointCollection pc = new PointCollection();
            foreach (Point p in pointsList)
            {
                pc.Add(new System.Windows.Point(p.X * 30 / hx + (Grid.Width) / 2, (p.Y * 30 * -1.0 / hy + Grid.Height / 2)));
            }
            poly.Points = pc;
            poly.Stroke = Brushes.Red;
            poly.StrokeThickness = 1;

            id = Grid.Children.Add(poly);
        }

        private void Paint_Grid()
        {
            
            if (pointsList.Count != 0)
            {
                var r = pointsList.Last();
                if (Math.Abs(r.X) > 4)
                {
                    hx = Math.Ceiling(Math.Abs(r.X) / 4.0);
                }
                else hx = 1.0;
                if (Math.Abs(r.Y) > 3)
                {
                    hy = Math.Ceiling(Math.Abs(r.Y) / 3.0);
                }
                else hy = 1.0;
            }
            else { hx = 1.0; hy = 1.0; }
            //int width = (int)this.Width;
            int width = (int)Grid.Width;
            //int height = (int)this.Height;
            int height = (int)Grid.Height;
            int shiftX = 0, shiftY = 0;
            Grid.Children.Clear();
            this.UpdateLayout();
            bool gen = true;
            while (shiftX < width / 2)
            {
                LineGeometry line1 = new LineGeometry();
                line1.StartPoint = new System.Windows.Point(width / 2 + shiftX, 0);
                line1.EndPoint = new System.Windows.Point(width / 2 + shiftX, height);
                System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
                path.Stroke = Brushes.Black;
                path.StrokeThickness = 1;

                if (gen)
                {
                    path.StrokeThickness = 2;
                    gen = false;
                }
                path.Data = line1;
                Grid.Children.Add(path);
                Label label = new Label();
                label.Content = (shiftX / 30 * hx).ToString();
                label.Margin = new Thickness(width / 2 + shiftX, height / 2, 5, 0);
                Grid.Children.Add(label);
                LineGeometry line2 = new LineGeometry();
                line2.StartPoint = new System.Windows.Point(width / 2 - shiftX, 0);
                line2.EndPoint = new System.Windows.Point(width / 2 - shiftX, height);
                System.Windows.Shapes.Path path2 = new System.Windows.Shapes.Path();
                path2.Stroke = Brushes.Black;
                path2.StrokeThickness = 1;
                path2.Data = line2;
                Grid.Children.Add(path2);
                Label label2 = new Label();
                label2.Content = (-shiftX * hx / 30).ToString();
                label2.Margin = new Thickness(width / 2 - shiftX, height / 2, 5, 0);
                Grid.Children.Add(label2);
                shiftX += 30;
            }
            gen = true;
            while (shiftY < height / 2)
            {
                LineGeometry line1 = new LineGeometry();
                line1.StartPoint = new System.Windows.Point(0, height / 2 + shiftY);
                line1.EndPoint = new System.Windows.Point(width, height / 2 + shiftY);
                System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
                path.Stroke = Brushes.Black;
                path.StrokeThickness = 1;

                if (gen)
                {
                    path.StrokeThickness = 2;
                    gen = false;
                }
                path.Data = line1;
                Grid.Children.Add(path);
                Label label = new Label();
                label.Content = (-shiftY * hy / 30).ToString();
                label.Margin = new Thickness(width / 2, height / 2 + shiftY, 5, 0);
                Grid.Children.Add(label);

                LineGeometry line2 = new LineGeometry();
                line2.StartPoint = new System.Windows.Point(0, height / 2 - shiftY);
                line2.EndPoint = new System.Windows.Point(width, height / 2 - shiftY);
                System.Windows.Shapes.Path path2 = new System.Windows.Shapes.Path();
                path2.Stroke = Brushes.Black;
                path2.StrokeThickness = 1;
                path2.Data = line2;
                Grid.Children.Add(path2);

                Label label2 = new Label();
                label2.Content = (shiftY * hy / 30).ToString();
                label2.Margin = new Thickness(width / 2, height / 2 - shiftY, 5, 0);
                Grid.Children.Add(label2);
                shiftY += 30;
            }
        }

        private void Update()
        {
            if (pointsList.Count < 2)
                return;
            Grid.Children.RemoveAt(id);
            Paint();
        }




        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Paint_Grid();
        }

        private void _SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Update();
        }

        private void _CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Update();
        }

        private void _SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void buttonPaint_Click(object sender, RoutedEventArgs e)
        {
            //Paint_Grid();
            Polyline poly = new Polyline();
            PointCollection pc = new PointCollection();
            foreach (Point p in pointsList)
            {
                pc.Add(new System.Windows.Point(p.X * 30 / hx + (Grid.Width) / 2, (p.Y * 30 * -1.0 / hy + Grid.Height / 2)));
            }
            poly.Points = pc;
            poly.Stroke = Brushes.Red;
            poly.StrokeThickness = 1;

            id = Grid.Children.Add(poly);
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (bindings.Count == 1)
            {
                MessageBox.Show("Нельзя удалить последний");
                return;
            }
            bindings.Remove((int)combobox1.SelectedItem);
            int i = combobox1.Items.IndexOf((int)combobox1.SelectedItem);
            var tmp = bindings.LastOrDefault();
            pointsList = new ObservableCollection<Point>(tmp.Value);
            label1.Content = "Table " + tmp.Key.ToString();
            combobox1.SelectedItem = tmp.Key;
            combobox1.Items.RemoveAt(i);
            dataGridPoints.ItemsSource = pointsList;
            
            Update();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = Convert.ToInt16(combobox1.SelectedItem);
            pointsList = new ObservableCollection<Point>(bindings[i]);
            label1.Content = "Graphic " + i.ToString();
            combobox1.SelectedItem = i;
            dataGridPoints.ItemsSource = pointsList;
            Update();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.GetPosition(Grid).X < Grid.Width)
            {
                this.labelPosValue.Content = "(" +
                    String.Format("{0:0.##}", ((e.GetPosition(Grid).X - (Grid.Width) / 2) / 30.0 * hx)) + "; " +
                    String.Format("{0:0.##}", ((e.GetPosition(Grid).Y - Grid.Height / 2) * -1.0 / 30.0 * hy)) + ")";
            }
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString() { return $"{X} {Y}"; }

        public Point()
        {

        }
        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
