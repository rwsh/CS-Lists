using System;
using System.Collections.Generic;
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

namespace Lists
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		List<Ellipse> Circs; // список
		private void cmCreate(object sender, RoutedEventArgs e)
		{
			Circs = new List<Ellipse>(); // создать список
			Random rnd = new Random(); // генератор случайных чисел

			double R = 30; // радиус шара
			int N = 10; // количество шаров

			for (int n = 0; n < N; n++)
			{
				Ellipse O = new Ellipse(); // создать эллипс
				O.Width = 2 * R; 
				O.Height = 2 * R;
				O.Margin = new Thickness(n * (2 * R), 0, 0, 0);
				int c = rnd.Next(3); // случайный цвет
				switch (c)
				{
					case 0:
						O.Fill = Brushes.Blue;
						break; 
					case 1:
						O.Fill = Brushes.Red;
						break;
					case 2:
						O.Fill = Brushes.Yellow;
						break;
				}
				Circs.Add(O); // добавляем в список
			}
			Sync(); // синхронизовать список с хослтом
		}
		void Sync()
		{
			g.Children.Clear(); // очистить холст
			foreach (Ellipse O in Circs) // перебираем шары
			{
				g.Children.Add(O); // добавляем на холст
			}
		}

		private void cmDelete(object sender, RoutedEventArgs e)
		{
			if (Circs.Count == 0) // проверить не пустой ли список
			{
				return; // если пустой, то выход
			}

			Random rnd = new Random(); // генератор случайных чисел
			int n = rnd.Next(Circs.Count); // выбираем случайный шар

			Circs.RemoveAt(n); // удаляем в списке
			Sync(); // синхронизируем
		}
	}
}
