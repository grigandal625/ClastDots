using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace ClastDots
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			AnT.InitializeContexts();
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			AnT.InitializeContexts();					
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Gl.glClearColor(255, 255, 255, 1);
			Gl.glViewport(0, 0, AnT.Width, AnT.Height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluOrtho2D(0.0, 100.0 * (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width), 0.0, 100.0);
			Gl.glMatrixMode(Gl.GL_MODELVIEW); 
			Gl.glLoadIdentity();
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			Gl.glLoadIdentity();
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			button1.PerformClick();
		}
		
		public class BorderThread
		{
			Thread t;
			claster c;
			public BorderThread(claster cl)
			{
				this.c = cl;
				t = new Thread(getBorders);
			}
			public void Start()
			{
				t.Start();
			}
			public void Join()
			{
				t.Join();
			}
			void getBorders()
			{
				Dot[][] bs = c.getBorders();
				AllBorders = DotArrayMethods.push(AllBorders, bs);
			}
		}
		public static Dot[][][] AllBorders = new Dot[0][][];
		private void drawAxis() // Нарисовать оси
		{
			Gl.glColor3f(0, 0, 0);
			
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			Gl.glBegin(Gl.GL_LINE_STRIP);
			Gl.glVertex2d(50.0f * rel, 0);
			Gl.glVertex2d(50.0f * rel, 100);
			Gl.glVertex2d(50.5f * rel, 97);
			Gl.glVertex2d(49.5f * rel, 97);
			Gl.glVertex2d(50.0f * rel, 100);
			Gl.glEnd();
			Gl.glBegin(Gl.GL_LINE_STRIP);
			Gl.glVertex2d(0.0f * rel, 50.0);
			Gl.glVertex2d(100.0f * rel, 50.0);
			Gl.glVertex2d(97f * rel, 51);
			Gl.glVertex2d(97f * rel, 49);
			Gl.glVertex2d(100.0f * rel, 50);
			Gl.glEnd();
		}
		private void Draw2DDot(Dot d)// Нарисовать точку
		{
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			Gl.glColor3f(255, 0, 0);
			Gl.glPointSize(1);
			Gl.glBegin(Gl.GL_LINE_STRIP);
			Gl.glVertex2d((float)(d.cords()[0] + 50) * rel, d.cords()[1] + 50);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glEnd();	
		}
		private void Draw2DDot(Dot d, float r, float g, float b) // Нарисовать точку отдельным цветом
		{
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			Gl.glColor3f(r, g, b);
			Gl.glPointSize(1);
			Gl.glBegin(Gl.GL_LINE_STRIP);
			Gl.glVertex2d((float)(d.cords()[0] + 50) * rel, d.cords()[1] + 50);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 - 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 - 1);
			Gl.glVertex2d((float)(d.cords()[0] + 50 + 1 / rel) * rel, d.cords()[1] + 50 + 1);
			Gl.glEnd();
		}
		private void drawNeibours(Dot[] ds) // Нарисовать соединения соседей
		{
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			for (int i = 0; i < ds.Length; i++) {
				Dot[] n = Space.neibours(ds[i], ds, Double.Parse(Coef.Text));
				Gl.glColor3f(0, 0, 255);
				Gl.glPointSize(1);
				Gl.glBegin(Gl.GL_LINE_STRIP);
				for (int j = 0; j < n.Length; j++) {
					Gl.glVertex2d((float)(ds[i].cords()[0] + 50) * rel, ds[i].cords()[1] + 50);
					Gl.glVertex2d((float)(n[j].cords()[0] + 50) * rel, n[j].cords()[1] + 50);
				}
				Gl.glEnd();
			}
		}
		private void drawNeibours(Dot[] dts, float r, float g, float b) // Нарисовать соединения соседей заданным цветом
		{
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			for (int i = 0; i < dts.Length; i++) {
				Dot[] n = Space.neibours(dts[i], dts, Double.Parse(Coef.Text));
				Gl.glColor3f(r, g, b);
				Gl.glPointSize(1);
				Gl.glBegin(Gl.GL_LINE_STRIP);
				for (int j = 0; j < n.Length; j++) {
					Gl.glVertex2d((float)(dts[i].cords()[0] + 50) * rel, dts[i].cords()[1] + 50);
					Gl.glVertex2d((float)(n[j].cords()[0] + 50) * rel, n[j].cords()[1] + 50);
				}
				Gl.glEnd();
			}
		}
		private void drawAllClasts(claster[] clasts)
		{
			float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
			for (int i = 0; i < clasts.Length; i++) {
				float r = (float)RandomDouble.GetRandomNumber(0.4, 1);
				float g = (float)RandomDouble.GetRandomNumber(0.4, 1);
				float b = (float)RandomDouble.GetRandomNumber(0.4, 1);
				drawNeibours(clasts[i].getDots(), r, g, b); // Соединения в каждом кластере отдельным цветом
				Dot[][] borders = clasts[i].getBorders();
				for (int j = 0; j < borders.Length; j++) {
					float r1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float g1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float b1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
					for (int k = 0; k < borders[j].Length; k++) {
						Draw2DDot(borders[j][k], r1, g1, b1); // Точки в каждой границе отдельным цветом
					}
				}
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void Button1Click(object sender, EventArgs e)
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			drawAxis();
			my2Ddots = new Dot[0];
			Gl.glFlush();
			AnT.Invalidate();
		}
		private Dot[] my2Ddots = new Dot[0];
		// Все точки
		private void add2DDot(Dot d) // Добавить точку
		{
			int l = my2Ddots.Length;
			Dot[] tmp = new Dot[l + 1];
			for (int i = 0; i < l; i++) {
				tmp[i] = my2Ddots[i];
			}
			tmp[l] = d;
			my2Ddots = Space.deleteEquals(tmp);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			for (int i = 0; i < my2Ddots.Length; i++) {
				Draw2DDot(my2Ddots[i]);
			}
			drawNeibours(my2Ddots);
			drawAxis();
			Gl.glFlush();
			AnT.Invalidate();
		}
		void Button3Click(object sender, EventArgs e)
		{
			Dot nDot = Space.randomDot(2, 50);
			add2DDot(nDot);
		}
		claster[] AllClasts = new claster[0];
		void Button4Click(object sender, EventArgs e)
		{
			AllBorders = new Dot[0][][];
			claster[] clasts = Space.clasts(my2Ddots, Double.Parse(Coef.Text));
			AllClasts = clasts;
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
			drawAxis();
			for (int i = 0; i < my2Ddots.Length; i++) {
				Draw2DDot(my2Ddots[i]);
			}
			//BorderThread[] ts = new BorderThread[clasts.Length];
			for (int i = 0; i < clasts.Length; i++) {
				BorderThread t = new BorderThread(clasts[i]);
				t.Start();
			//	ts[i] = t;
				t.Join();
			}
			/*for (int i = 0; i < ts.Length; i++){
				ts[i].Join();
			}*/

			//if (AllBorders.Length == AllClasts.Length) {
				
				float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
				for (int i = 0; i < AllClasts.Length; i++) {
					float r = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float g = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float b = (float)RandomDouble.GetRandomNumber(0.4, 1);
					drawNeibours(AllClasts[i].getDots(), r, g, b);// Соединения в каждом кластере отдельным цветом
					Dot[][] borders = AllBorders[i];
					for (int j = 0; j < borders.Length; j++) {
						float r1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						float g1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						float b1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						for (int k = 0; k < borders[j].Length; k++) {
							Draw2DDot(borders[j][k], r1, g1, b1); // Точки в каждой границе отдельным цветом
						}
					}
				}
				AllBorders = new Dot[0][][];
				Gl.glFlush();
				AnT.Invalidate();
			//}
		}
		void AnTMouseClick(object sender, MouseEventArgs e)// Нарисовать точку на месте клика
		{
			Dot nDot = new Dot(2);
			nDot.setCord(((Double)e.X / (Double)AnT.Width) * 100 - 50, 0);
			nDot.setCord(((Double)(AnT.Height - e.Y) / (Double)AnT.Height) * 100 - 50, 1);
			add2DDot(nDot);
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if (AllBorders.Length == AllClasts.Length) {
				timer1.Enabled = false;
				float rel = (float)Max.get(AnT.Height, AnT.Width) / (float)Min.get(AnT.Height, AnT.Width);
				for (int i = 0; i < AllClasts.Length; i++) {
					float r = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float g = (float)RandomDouble.GetRandomNumber(0.4, 1);
					float b = (float)RandomDouble.GetRandomNumber(0.4, 1);
					drawNeibours(AllClasts[i].getDots(), r, g, b);
					// Соединения в каждом кластере отдельным цветом
					Dot[][] borders = AllBorders[i];
					for (int j = 0; j < borders.Length; j++) {
						float r1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						float g1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						float b1 = (float)RandomDouble.GetRandomNumber(0.4, 1);
						for (int k = 0; k < borders[j].Length; k++) {
							Draw2DDot(borders[j][k], r1, g1, b1); // Точки в каждой границе отдельным цветом
						}
					}
				}
				AllBorders = new Dot[0][][];
				Gl.glFlush();
				AnT.Invalidate();
			}
		}
	}
	public static class DotArrayMethods //Полезные методы для массивов и др
	{
		public static Dot[] push(Dot[] a, Dot d)
		{
			Dot[] tmp = new Dot[a.Length + 1];
			for (int i = 0; i < a.Length; i++) {
				tmp[i] = a[i];
			}
			tmp[tmp.Length - 1] = d;
			return tmp;
		}
		public static Dot[] remove(Dot[] a, int n)
		{
			int c = 0;
			Dot[] tmp = new Dot[a.Length - 1];
			for (int i = 0; i < a.Length; i++) {
				if (i != n) {
					tmp[c] = a[i];
					c++;
				}
			}
			return tmp;
		}
		public static bool quadsEqual(int[] q1, int[] q2)
		{
			if (q1.Length != q2.Length) {
				throw new Exception();
			}
			for (int i = 0; i < q1.Length; i++) {
				if (q1[i] != q2[i]) {
					return false;
				}
			}
			return true;
		}
		public static Dot[] copyArray(Dot[] ds)
		{
			Dot[] res = new Dot[ds.Length];
			for (int i = 0; i < ds.Length; i++) {
				res[i] = ds[i];
			}
			return res;
		}
		public static Dot[] concat(Dot[] ds1, Dot[] ds2)
		{
			Dot[] res = ds1;
			for (int i = 0; i < ds2.Length; i++) {
				res = DotArrayMethods.push(res, ds2[i]);
			}
			return res;
		}
		public static int indexOf(Dot d, Dot[] ds, Func<Double[], Double[], Double> metric)
		{
			if (ds.Length == 1) {
				if (Space.areEqualDots(d, ds[0])) {
					return 0;
				} else {
					return -1;
				}
			}
			for (int i = 0; i < ds.Length - 1; i++) {
				if (Space.areEqualDots(d, ds[i])) {
					return i;
				}
			}
			int k = ds.Length - 1;
			if (k >= 0) {
				if (Space.areEqualDots(d, ds[k])) {
					return k;
				}
			}
			return -1;
		}
		public static int indexOf(Dot d, Dot[] ds)
		{
			return indexOf(d, ds, Space.default_metrick);
		}
		public static claster[] push(claster[] a, claster d)
		{
			claster[] tmp = new claster[a.Length + 1];
			for (int i = 0; i < a.Length; i++) {
				tmp[i] = a[i];
			}
			tmp[tmp.Length - 1] = d;
			return tmp;
		}
		public static claster[] remove(claster[] a, int n)
		{
			int c = 0;
			claster[] tmp = new claster[a.Length - 1];
			for (int i = 0; i < a.Length; i++) {
				if (i != n) {
					tmp[c] = a[i];
					c++;
				}
			}
			return tmp;
		}
		public static claster[] copyArray(claster[] ds)
		{
			claster[] res = new claster[ds.Length];
			for (int i = 0; i < ds.Length; i++) {
				res[i] = ds[i];
			}
			return res;
		}
		public static claster[] concat(claster[] ds1, claster[] ds2)
		{
			claster[] res = ds1;
			for (int i = 0; i < ds2.Length; i++) {
				res = DotArrayMethods.push(res, ds2[i]);
			}
			return res;
		}
		public static Dot[][] push(Dot[][] a, Dot[] d)
		{
			Dot[][] tmp = new Dot[a.Length + 1][];
			for (int i = 0; i < a.Length; i++) {
				tmp[i] = a[i];
			}
			tmp[tmp.Length - 1] = d;
			return tmp;
		}
		public static Dot[][][] push(Dot[][][] a, Dot[][] d)
		{
			Dot[][][] tmp = new Dot[a.Length + 1][][];
			for (int i = 0; i < a.Length; i++) {
				tmp[i] = a[i];
			}
			tmp[tmp.Length - 1] = d;
			return tmp;
		}
	}
	//То, чего остро не хватает в Math-----------------------------------------------------------------
	public static class Max
	{
		public static Double get(Double x, Double y)
		{
			if (x > y) {
				return x;
			} else {
				return y;
			}
		}
		public static int get(int x, int y)
		{
			if (x > y) {
				return x;
			} else {
				return y;
			}
		}
	}
	public static class Min
	{
		public static Double get(Double x, Double y)
		{
			if (x < y) {
				return x;
			} else {
				return y;
			}
		}
		public static int get(int x, int y)
		{
			if (x < y) {
				return x;
			} else {
				return y;
			}
		}
	}
	public static class RandomDouble
	{
		public static Random random = new Random();
		public static Double GetRandomNumber(Double minimum, Double maximum)
		{
			return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
		}
	}
	//--------------------------------------------------------------------------------------------------
	
	public class CoordinateCollection //: IEnumerable
	{
		private double[] coordinates;
		
		internal CoordinateCollection(Dot owner){}
		
		public double this [int[] indexes]
		{
			get {return this.coordinates[GetIndexFromCoordinateIndexes(indexes)];}
			set {this.coordinates[GetIndexFromCoordinateIndexes(indexes)] = value;}
		}
		
		private int GetIndexFromCoordinateIndexes(int[] indexes)
		{
			return 0;
		}
	}
	
	///Класс для точки (мой супер многомерный класс)
	public class Dot 
	{
		///Размерность
		private int dim;
		///Координаты
		private Double[] cordinates;
		public Dot(int n)
		{
			this.dim = n;
			this.cordinates = new Double[n];
		}
		public void setCord(Double c, int n)
		{
			if (n < 0 || n >= this.dim) {
				throw new Exception();
			}
			this.cordinates[n] = c;
		}
		public void setCords(Double[] cs)
		{
			if (cs.Length < this.dim) {
				throw new Exception();
			}
			for (int i = 0; i < this.dim; i++) {
				this.cordinates[i] = cs[i];
			}
		}
		public Double[] cords()
		{
			return this.cordinates;
		}
		public Double dest(Dot d, Func<Double[], Double[], Double> metric) // Расстояние до другой точки по заданной метрике
		{
			return Space.destination(this.cords(), d.cords(), metric);
		}
		public Double dest(Dot d) // Расстояние по стандартной метрике
		{
			return Space.destination(this.cords(), d.cords());
		}
		
		public int[] quadrant(Dot d) // Определить, в каком квадранте лежит другая точка по отношению к этой
		{
			if (d.cords().Length != dim) {
				throw new Exception();
			}
			int[] q = new int[this.dim];
			for (int i = 0; i < this.dim; i++) {
				if (d.cords()[i] >= this.cordinates[i]) {
					q[i] = 1;
				} else {
					q[i] = -1;
				}
			}
			return q;
		}
	}
	
	public class claster // Класс для кластера
	{
		private Dot[] dots = new Dot[0];
		private int dim;
		private Double R;
		// Максимальное расстояние до соседей
		private Func<Double[], Double[], Double> metrick;
		
		// Различные конструкторы --------------------------------------------------------------------------------------------------------
		public claster(int n, Double R, Func<Double[], Double[], Double> metric)
		{
			this.dim = n;
			this.R = R;
			this.metrick = metric;
		}
		public claster(int n, Double R)
		{
			this.dim = n;
			this.R = R;
			this.metrick = Space.default_metrick;
		}
		public claster(int n, Func<Double[], Double[], Double> metric)
		{
			this.dim = n;
			this.R = 5;
			this.metrick = metric;
		}
		public claster(Double R, Func<Double[], Double[], Double> metric)
		{
			this.dim = 2;
			this.R = R;
			this.metrick = metric;
		}
		public claster(int n)
		{
			this.dim = n;
			this.R = 5;
			this.metrick = Space.default_metrick;
		}
		public claster(Double R)
		{
			this.dim = 2;
			this.R = R;
			this.metrick = Space.default_metrick;
		}
		public claster()
		{
			this.dim = 2;
			this.R = 5;
			this.metrick = Space.default_metrick;
		}
		//-------------------------------------------------------------------------------------------------------------------
		
		public void addDot(Dot d) // Добавляет точку, если она "соседствует" с уже добавленными
		{
			if (d.cords().Length != this.dim) {
				throw new Exception();
			}
			if (this.dots.Length == 0 || Space.neibours(d, this.dots, this.R, this.metrick).Length != 0) {
				this.dots = DotArrayMethods.push(this.dots, d);
			}
			this.dots = Space.deleteEquals(this.dots);
		}
		public void addDots(Dot[] ds) // Добавляет точки, если они все соседствуют минимум с одной уже имеющейся
		{
			if (this.dots.Length == 0 || Space.areBinded(this.dots, ds, this.R, this.metrick)) {
				this.dots = DotArrayMethods.concat(this.dots, ds);
			}
			this.dots = Space.deleteEquals(this.dots);
		}
		public void removeDot(int i)
		{
			this.dots = DotArrayMethods.remove(this.dots, i);
		}
		public Dot[] getDots()
		{
			return DotArrayMethods.copyArray(this.dots);
		}
		public Func<Double[], Double[], Double> getMetricks()
		{
			return this.metrick;
		}
		public int getDim()
		{
			return this.dim;
		}
		public Double getR()
		{
			return this.R;
		}
		public Dot[] getBorderDots() // Находит все граничные точки (НЕ ГРАНИЦЫ) из имеющихся
		{
			Dot[] res = new Dot[0];
			int[][] qs = Space.allQuadrants(this.dim);
			for (int i = 0; i < this.dots.Length; i++) {
				for (var j = 0; j < qs.Length; j++) {
					if (Space.quadrantNeibours(this.dots[i], this.dots, this.R, qs[j], this.metrick).Length == 0) {
						res = DotArrayMethods.push(res, this.dots[i]);
					}
				}
			}
			return res;
		}
		
		public Dot[][] getBorders() // Находит все границы по граничным точкам
		{
			Dot[][] res = new Dot[0][];
			Dot[] bds = this.getBorderDots();
			//int i = 0;
			while (bds.Length != 0) {
				Dot[] c = new Dot[0];
				Dot d = bds[0];
				c = DotArrayMethods.push(c, d);
				bds = DotArrayMethods.remove(bds, 0);
				while (Space.neibours(c, bds, this.R, this.metrick).Length != 0) {
					c = DotArrayMethods.concat(c, Space.neibours(c, bds, this.R, this.metrick));
					
					for (int j = 0; j < c.Length; j++) {
						if (DotArrayMethods.indexOf(c[j], bds) != -1) {
							bds = DotArrayMethods.remove(bds, DotArrayMethods.indexOf(c[j], bds));
						}
					}
				}
				res = DotArrayMethods.push(res, c);
			}
			return res;
		}
	}
	
	
	public static class Space // Интерфейс для различных действий с точками
	{
		public static Double default_metrick(Double[] d1, Double[] d2)
		{
			if (d1.Length != d2.Length) {
				throw new Exception();
			}
			Double s = 0;
			for (int i = 0; i < d1.Length; i++) {
				s += Math.Pow(d1[i] - d2[i], 2);
			}
			return Math.Sqrt(s);
		}

		public static Double destination(Double[] d1, Double[] d2)
		{
			return Space.default_metrick(d1, d2);
		}
		public static Double destination(Double[] d1, Double[] d2, Func<Double[], Double[], Double> metric)
		{
			return metric(d1, d2);
		}
		public static Double destination(Dot d1, Dot d2, Func<Double[], Double[], Double> metric)
		{
			return metric(d1.cords(), d2.cords());
		}
		public static double Distance(this Dot d1, Dot d2)
		{
			//d1.Distance(d2);
			return 0;
		}
		public static Double destination(Dot d1, Dot d2)
		{
			return Space.default_metrick(d1.cords(), d2.cords());
		}
		
		public static int[][] allQuadrants(int n) // Все возможные квадранты для пространства заданной размерности
		{
			int k = (int)Math.Pow(2, n);
			int[][] res = new int[k][];
			for (int i = 0; i < Math.Pow(2, n); i++) {
				int[] tmp = new int[n];
				int t = i;
				for (int j = 0; j < n; j++) {
					tmp[j] = (t % 2) * 2 - 1;
					t = t / 2;
				}

				res[i] = tmp;
			}
			return res;
		}
		
		public static Dot randomDot(int n, Double scatter)
		{
			Dot res = new Dot(n);
			Double[] cs = new Double[n];
			for (int i = 0; i < n; i++) {
				cs[i] = RandomDouble.GetRandomNumber(-1 * scatter, scatter);
			}
			res.setCords(cs);
			return res;
		}
		
		public static bool areEqualDots(Dot d1, Dot d2)
		{
			if (d1.cords().Length != d2.cords().Length) {
				throw new Exception();
			}
			for (int i = 0; i < d1.cords().Length; i++) {
				if (d1.cords()[i].CompareTo(d2.cords()[i]) != 0) {
					return false;
				}
			}
			return true;
		}
		
		public static Dot[] deleteEquals(Dot[] ds) // Находит и схлопывает одинаковые точки в массиве точек
		{
			Dot[] res = new Dot[0];
			for (int i = 0; i < ds.Length; i++) {
				if (res.Length == 0) {
					res = new Dot[1];
					res[0] = ds[i];
				} else {
					bool add = true;
					for (int j = 0; j < res.Length; j++) {
						add = add && !areEqualDots(ds[i], res[j]);
					}
					if (add) {
						Dot[] tmp = new Dot[res.Length + 1];
						for (int j = 0; j < res.Length; j++) {
							tmp[j] = res[j];
						}
						tmp[tmp.Length - 1] = ds[i];
						res = tmp;
					}
				}
			}
			return res;
		}
		public static Dot[] neibours(Dot d, Dot[] ds, Double R, Func<Double[], Double[], Double> metric) // Находит соседей точки в заданном множестве
		{
			Dot[] res = new Dot[0];
			for (int i = 0; i < ds.Length; i++) {
				if (Space.destination(d, ds[i]).CompareTo(R) == -1 && Space.destination(d, ds[i], metric).CompareTo(0) != 0) {
					Dot[] tmp = new Dot[res.Length + 1];
					for (var j = 0; j < res.Length; j++) {
						tmp[j] = res[j];
					}
					tmp[tmp.Length - 1] = ds[i];
					res = tmp;
				}
			}
			return res;
		}
		public static Dot[] neibours(Dot d, Dot[] ds, Double R)
		{
			return neibours(d, ds, R, default_metrick);
		}
		
		public static Dot[] neibours(Dot[] d, Dot[] ds, Double R, Func<Double[], Double[], Double> metric) // Находит всех соседей каждой точки из множества среди другого множества
		{
			Dot[] res = new Dot[0];
			for (int i = 0; i < d.Length; i++) {
				res = DotArrayMethods.concat(res, Space.neibours(d[i], ds, R, metric));
			}
			return Space.deleteEquals(res);
		}
		public static Dot[] neibours(Dot[] d, Dot[] ds, Double R)
		{
			return neibours(d, ds, R, default_metrick);
		}
		
		public static Dot[] quadrantNeibours(Dot d, Dot[] ds, Double R, int[] q, Func<Double[], Double[], Double> metric) // Находит всех соседей точки в заданном квадранте
		{
			if (q.Length != d.cords().Length) {
				throw new Exception();
			}
			Dot[] res = new Dot[0];
			Dot[] tmp = neibours(d, ds, R, metric);
			for (int i = 0; i < tmp.Length; i++) {
				if (DotArrayMethods.quadsEqual(q, d.quadrant(tmp[i]))) {
					res = DotArrayMethods.push(res, tmp[i]);
				}
			}
			return res;
		}
		public static Dot[] quadrantNeibours(Dot d, Dot[] ds, Double R, int[] q)
		{
			return quadrantNeibours(d, ds, R, q, default_metrick);
		}
		
		public static bool areBinded(Dot[] ds1, Dot[] ds2, Double R, Func<Double[], Double[], Double> metric) // Проверить, связаны ли множества
		{
			for (int i = 0; i < ds2.Length; i++) {
				if (neibours(ds2[i], ds1, R, metric).Length == 0) {
					return false;
				}
			}
			return true;
		}
		public static bool areBinded(Dot[] ds1, Dot[] ds2, Double R)
		{
			return areBinded(ds1, ds2, R, default_metrick);
		}
		
		public static claster[] clasts(Dot[] ds, Double R, Func<Double[], Double[], Double> metric) // Все кластеры из множества
		{
			claster[] res = new claster[0];
			Dot[] tds = DotArrayMethods.copyArray(ds);
			int i = 0;
			while (tds.Length != 0) {
				claster c = new claster(ds[0].cords().Length, R, metric);
				Dot d = tds[0];
				c.addDot(d);
				tds = DotArrayMethods.remove(tds, 0);
				while (Space.neibours(c.getDots(), tds, R, metric).Length != 0) {
					c.addDots(Space.neibours(c.getDots(), tds, R, metric));
					
					for (int j = 0; j < c.getDots().Length; j++) {
						if (DotArrayMethods.indexOf(c.getDots()[j], tds) != -1) {
							tds = DotArrayMethods.remove(tds, DotArrayMethods.indexOf(c.getDots()[j], tds));
						}
					}
				}
				res = DotArrayMethods.push(res, c);
			}
			return res;
		}
		public static claster[] clasts(Dot[] ds, Double R)
		{
			return clasts(ds, R, default_metrick);
		}
	}
}
