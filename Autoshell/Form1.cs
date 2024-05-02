using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Autoshell
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


		private void Form1_Paint(object sender, PaintEventArgs e)
		{

		}
		//����� ��� ��������� �����
		private void DrawDots(int countDots, Point[] Allpoints)
		{
			int x, y;
			Graphics g = CreateGraphics();
			g.Clear(Color.White);
			Random r = new Random();
			for (int i = 0; i < countDots; i++)
			{
				x = r.Next(250, 800);
				y = r.Next(1, 500);
				Allpoints[i] = new Point(x, y);
				g.FillEllipse(Brushes.Red, x, y, 5, 5);
			}
		}
		private void DrawDots2(int countDots, List<Point> Allpoints)
		{
			int x, y;
			Graphics g = CreateGraphics();
			g.Clear(Color.White);
			Random r = new Random();
			for (int i = 0; i < countDots; i++)
			{
				x = r.Next(250, 800);
				y = r.Next(1, 500);
				Allpoints.Add(new Point(x, y));
				g.FillEllipse(Brushes.Red, x, y, 5, 5);
			}
		}
		private void DrawRec(Point[] Arr)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < Arr.Length - 1; i++)
			{
				g.DrawLine(Pens.Black, Arr[i], Arr[i + 1]);
			}
			g.DrawLine(Pens.Black, Arr[0], Arr[Arr.Length - 1]);
		}
		//����� ��� ���������� ��������� ������ �����
		private void DrawFinalRec(List<Point> Arr)
		{

			Graphics g = CreateGraphics();
			for (int i = 0; i < Arr.Count() - 1; i++)
			{
				System.Threading.Thread.Sleep(500);
				g.DrawLine(Pens.Black, Arr[i], Arr[i + 1]);
			}
			System.Threading.Thread.Sleep(500);
			g.DrawLine(Pens.Black, Arr[0], Arr[Arr.Count() - 1]);
		}
		static bool checkPovorot(Point A, Point B, Point C)
		{
			if ((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y) < 0)
			{
				return true;
				//Console.WriteLine("����� ����� �� ������� �������.");
			}
			else
			{
				return false;
				//Console.WriteLine("����� ����� ������ ������� �������.");
			}
		}
		public void button1_Click(object sender, EventArgs e)
		{
			int count = Convert.ToInt32(maskedTextBox1.Text);
			Point[] AllPoints = new Point[count];
			DrawDots(count, AllPoints);

		}

		private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			int count = Convert.ToInt32(maskedTextBox1.Text);
			Point[] AllPoints = new Point[count];
			DrawDots(count, AllPoints);

			//���� ����� ����� �����
			Array.Sort(AllPoints, (a, b) => a.X.CompareTo(b.X));
			int j = 0;
			//���������� ���� ����� (����� AllPoints[0]-��), �� ������� �� ������� ������������ ��������� �����
			for (int i = 2; i < count; i++)
			{
				j = i;
				while (j > 1 && (checkPovorot(AllPoints[0], AllPoints[j - 1], AllPoints[j]) == true))
				{
					Point temp = AllPoints[j];
					AllPoints[j] = AllPoints[j - 1];
					AllPoints[j - 1] = temp;
					j -= 1;
				}
			}
			//DrawRec(AllPoints);
			List<Point> FinalRec = new List<Point>();
			FinalRec.Add(AllPoints[0]);
			FinalRec.Add(AllPoints[1]);

			j = 0;
			//����� �������� �� ���� �������� � ������� �� �� ���, � ������� ����������� ������ ������� (���� � ����� ������� ����������� ������ ������������).
			for (int i = 2; i < count; i++)
			{
				if (i < count)
				{
					while (i < count && checkPovorot(FinalRec[FinalRec.Count() - 2], FinalRec[FinalRec.Count() - 1], AllPoints[i]) == true)
					{
						if (FinalRec.Count() > 2)
						{
							FinalRec.RemoveAt(FinalRec.Count() - 1);
						}
						else
						{
							i += 1;
						}
					}
					if (i < count)
					{
						FinalRec.Add(AllPoints[i]);
					}

				}
			}
			DrawFinalRec(FinalRec);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int count = Convert.ToInt32(maskedTextBox1.Text);
			Point[] AllPoints = new Point[count];
			List<Point> FinalRec = new List<Point>();
			List<Point> TempRec = new List<Point>();
			DrawDots(count, AllPoints);
			//���� ����� ����� �����
			Array.Sort(AllPoints, (a, b) => a.X.CompareTo(b.X));
			//Final - H, Temp - P, AllPoints - A
			for (int i = 0; i < count; i++)
			{
				//FinalRec.Add(AllPoints[i]);
				TempRec.Add(AllPoints[i]);
			}
			//� ������ H(FinalRecc) ����� �� ������� ��������� �������, � �
			//������ P ��� ������� ��������� � ����� (��� �� �� � ����� ������ ������ � �������� ��������).
			FinalRec.Add(TempRec[0]);
			TempRec.RemoveAt(0);
			TempRec.Add(FinalRec[0]);
			int right;
			//����� ���������� ����� � H ��������� ������� ��������, ������� �� � ������� � �������� ����������.
			while (true)
			{

				right = 0;
				for(int i = 1; i < TempRec.Count(); ++i) 
				{
					// ���� ����� ����� ����� �� P ������������ ��������� ������� � H.
					if (checkPovorot(FinalRec[FinalRec.Count()-1], TempRec[right], TempRec[i]) == true)
					{

						right = i;
					}
				}
				//���� ��� ������� ���������, �� ��������� ���� 
				if (TempRec[right] == FinalRec[0])
				{
					break;
				}
				//���� ��� � �� ��������� ��������� ������� �� P � H.
				else
				{
					FinalRec.Add(TempRec[right]);
					TempRec.RemoveAt(right);
				}
			}
			DrawFinalRec(FinalRec);
		}
	}
}