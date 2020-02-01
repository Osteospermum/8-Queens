using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Queens
{
	public partial class frmMain : Form
	{
		private int index;
		private bool inProgress = false;

		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void picBoard_Paint(object sender, PaintEventArgs e)
		{
			int squareSize;
			if (legalPositions != null)
			{
				squareSize = picBoard.Width / legalPositions.Count();
				picBoard.Width = squareSize * legalPositions.Count();
				picBoard.Height = squareSize * legalPositions.Count();
			} else
			{
				squareSize = picBoard.Width / (int)updSize.Value;
				picBoard.Width = squareSize * (int)updSize.Value;
				picBoard.Height = squareSize * (int)updSize.Value;
			}

			int tempX = 0;
			int tempY = 0;

			while (tempX <= picBoard.Width)
			{
				tempY = 0;
				while (tempY <= picBoard.Height)
				{
					if (tempX % (squareSize * 2) == 0)
					{
						if (tempY % (squareSize * 2) == 0)
						{
							e.Graphics.FillRectangle(Brushes.Black, tempX, tempY, squareSize, squareSize);
						} else
						{
							e.Graphics.FillRectangle(Brushes.White, tempX, tempY, squareSize, squareSize);
						}
					} else
					{
						if (tempY % (squareSize * 2) == 0)
						{
							e.Graphics.FillRectangle(Brushes.White, tempX, tempY, squareSize, squareSize);
						}
						else
						{
							e.Graphics.FillRectangle(Brushes.Black, tempX, tempY, squareSize, squareSize);
						}
					}
					tempY += squareSize;
				}
				tempX += squareSize;
			}
			if (solutions != null)
			{
				if (inProgress == false)
				{
					for (int i = 0; i < legalPositions.Length; i++)
					{
						e.Graphics.DrawImage(_8_Queens.Properties.Resources.queen, squareSize * solutions[index][i] + 5, squareSize * i + 5, squareSize - 10, squareSize - 10);
					}
				}
				else
				{
					for (int i = 0; i < decisions.Count(); i++)
					{
						e.Graphics.DrawImage(_8_Queens.Properties.Resources.queen, squareSize * decisions[i] + 5, squareSize * i + 5, squareSize - 10, squareSize - 10);
					}
				}
			}
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			picBoard.Refresh();
			solutions = new List<int[]>();
			decisions = new List<int>();
			int size = (int)updSize.Value;
			legalPositions = new Boolean[size][];
			for (int i = 0; i < size; i++)
			{
				legalPositions[i] = new Boolean[size];
				for (int k = 0; k < size; k++)
				{
					legalPositions[i][k] = true;
				}
			}
			for (int i = lstPossibilities.Items.Count - 1; i >= 0; i--)
			{
				lstPossibilities.Items.RemoveAt(i);
			}
			inProgress = true;
			findSolutions();
			inProgress = false;
			lstPossibilities.Items.Add("Total: " + solutions.Count().ToString());
			index = 0;
			picBoard.Refresh();
		}

		private void picBoard_Click(object sender, EventArgs e)
		{
			if (solutions != null)
			{
				index++;
				if (index >= solutions.Count())
				{
					index = 0;
				}
				picBoard.Refresh();
			}
		}

		#region "Algorithm functions"

		private Boolean[][] legalPositions;
		public List<int[]> solutions;
		private List<int> decisions;

		private void FindNext(int rowNum)
		{
			int realRow = (rowNum - legalPositions.Length) * -1;
			List<int> prevThisRow = new List<int>();
			for (int i = 0; i < solutions.Count(); i++)
			{
				prevThisRow.Add(solutions[i][realRow]);
			}
			for (int i = 0; i < legalPositions.Length; i++)
			{
				UpdateLegal();
				if (legalPositions[realRow][i] == true)
				{
					decisions.Add(i);
					UpdateLegal();
					if (updWait.Value > 0)
					{
						picBoard.Refresh();
						System.Threading.Thread.Sleep((int)updWait.Value);
					}
					if (rowNum == 1)
					{
						solutions.Add(decisions.ToArray());
						string s = "";
						for (int k = 0; k < decisions.Count(); k++)
						{
							s += decisions[k].ToString("X");
						}
						lstPossibilities.Items.Add(s);
						lstPossibilities.Refresh();
						if (updWait.Value > 0)
						{
							System.Threading.Thread.Sleep(Math.Max(1000, (int)updWait.Value * 3));
						}
					}
					else
					{
						FindNext(rowNum - 1);
					}
					decisions.Remove(i);
					if (updWait.Value > 0)
					{
						picBoard.Refresh();
						System.Threading.Thread.Sleep((int)updWait.Value);
					}
				}
			}
		}

		private void UpdateLegal()
		{
			for (int i = 0; i < legalPositions.Length; i++)
			{
				for (int k = 0; k < legalPositions[i].Length; k++)
				{
					legalPositions[i][k] = true;
				}
			}
			if (decisions.Count() > 0)
			{
				for (int i = 0; i < decisions.Count(); i++)
				{
					int currentParse = decisions[i];
					Point testPos = new Point();
					for (int k = 0; k < legalPositions.Length; k++)
					{
						legalPositions[i][k] = false;
						legalPositions[k][currentParse] = false;
						for (int mulX = -1; mulX <= 1; mulX += 2)
						{
							for (int mulY = -1; mulY <= 1; mulY += 2)
							{
								testPos = new Point(currentParse - k * mulX, i - k * mulY);
								if (testPos.X < 0 || testPos.X >= legalPositions.Length || testPos.Y < 0 || testPos.Y >= legalPositions.Length)
								{
									break;
								}
								legalPositions[testPos.Y][testPos.X] = false;
							}
						}
					}
				}
			}
		}
		public void findSolutions()
		{
			solutions = new List<int[]>();
			FindNext(legalPositions.Length);
			if (updWait.Value > 0)
			{
				System.Threading.Thread.Sleep(Math.Max(1000, (int)updWait.Value * 3));
			}
			decisions = new List<int>();
		}

		public void printLegalPos()
		{
			Console.WriteLine();
			for (int i = 0; i < legalPositions.Length; i++)
			{
				for (int k = 0; k < legalPositions.Length; k++)
				{
					if (legalPositions[i][k] == true)
					{
						Console.Write('O');
					}
					else
					{
						Console.Write('X');
					}
				}
				Console.WriteLine();
			}
		}
		public void printBoard()
		{
			Console.WriteLine();
			for (int i = 0; i < legalPositions.Length; i++)
			{
				for (int k = 0; k < legalPositions.Length; k++)
				{
					if (decisions.Count >= i + 1)
					{
						if (decisions[i] == k)
						{
							Console.Write('X');
						}
						else
						{
							Console.Write('O');
						}
					}
					else
					{
						Console.Write('O');
					}
				}
				Console.WriteLine();
			}
		}
	}
#endregion
}
