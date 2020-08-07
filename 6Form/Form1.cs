using System;
using System.Linq;
using System.Windows.Forms;

namespace _6Form
{
    public partial class Form1 : Form
    {
        private int[] arr;
        private int[,] twoArr;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void StructureForOneDimArrButton(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && Сheck(textBox1.Text))
            {
                GetStricture(Convert.ToInt32(textBox1.Text));
            }
            
        }
        private void GetStricture(int size)
        {
            dataGridView1.ColumnCount = size;
            arr = new int[size];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool Сheck(String s)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsDigit(arr[i]) && arr[i] != '-')
                {
                    return false;
                }
            }
            return true;
        }

        private void GetDataButton(object sender, EventArgs e)
        {
            InitOneDimArr();
            ShowOneDimArrInfo();
        }

        private void ShowOneDimArrInfo()
        {
            if (CheckSum(arr)) textBox3.Text = "двузначное число";
            else textBox3.Text = "недвузначное число";
            textBox5.Text = Convert.ToString(CountSum(arr));
        }

        private void InitOneDimArr()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    arr[col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }

        }
        private bool CheckSum(int[,] twoArr)
        {
            int sum = 0;
            for (int i = 0; i < twoArr.GetLength(0); ++i)
            {
                for (int j = 0; j < twoArr.GetLength(1); ++j)
                {
                    sum += twoArr[i, j];
                }
            }
            if (sum > -100 && sum < -9 || sum > 9 && sum < 100) return true;
            return false;
        }
        private static bool CheckSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; ++i) sum += arr[i];
            if (sum > -100 && sum < -9 || sum > 9 && sum < 100) return true;
            return false;
        }
        private int CountSum(int[] arr)
        {
            int neededCount = 0;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > arr[i - 1])
                    neededCount++;
            return neededCount;
        }

        private void StructureForTwoDimArrButton(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && Сheck(textBox2.Text) &&
                textBox8.Text != "" && Сheck(textBox8.Text) && Convert.ToInt32(textBox2.Text) == Convert.ToInt32(textBox8.Text))
            {
                GetStricture(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox2.Text));
            }
        }
        private void GetStricture(int lines, int columns)
        {
            dataGridView2.RowCount = lines;
            dataGridView2.ColumnCount = columns;
            twoArr = new int[lines, columns];
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetDataForTwoDimArrayButton(object sender, EventArgs e)
        {
            InitTwoDimArr();
            ShowTwoDimArrInfo();
        }

        private void ShowTwoDimArrInfo()
        {
            if (CheckSum(twoArr)) textBox4.Text = "двузначное число";
            else textBox4.Text = "не двузначное число";
            if (CheckNegativeColumn(twoArr)) textBox6.Text = "есть";
            else textBox6.Text = "отсутсвует";
            int[][] alternativeTwoArray = GetAlternativeTwoDimArr();
            int[] arr1 = GetMinMultFromRows(alternativeTwoArray);

            dataGridView3.ColumnCount = arr1.Length;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int rows = 0; rows < dataGridView3.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView3.Rows[rows].Cells.Count; col++)
                {
                    dataGridView3.Rows[rows].Cells[col].Value = arr1[col];
                }
            }

            textBox7.Text = arr1.Min().ToString();

        }
        private int[][] GetAlternativeTwoDimArr()
        {
            int[][] temp = new int[twoArr.GetLength(0)][];
            for (int i = 0; i < twoArr.GetLength(0); i++)
            {
                temp[i] = new int[twoArr.GetLength(0)];
                for (int j = 0; j < twoArr.GetLength(1); j++)
                {
                    temp[i][j] = twoArr[i, j];
                }
            }
            return temp;

        }

        private void InitTwoDimArr()
        {
            for (int rows = 0; rows < dataGridView2.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView2.Rows[rows].Cells.Count; col++)
                {
                    twoArr[rows, col] = Convert.ToInt32(dataGridView2.Rows[rows].Cells[col].Value);
                }
            }
        }
        private bool CheckNegativeColumn(int[,] twoArr)
        {
            bool check = true;
            for (int i = 0; i < twoArr.GetLength(0); ++i)
            {
                check = true;
                for (int j = 0; j < twoArr.GetLength(1); ++j)
                {
                    if (twoArr[j, i] > 0) check = false;
                }
                if (check == true) return check;
            }
            return check;
        }
        private int[] GetMinMultFromRows(int[][] twoArr)
        {
            int[] a = new int[twoArr.GetLength(0)];
            for (int i = 0; i < a.Length; ++i)
            {
                int temp = 1;

                for (int j = 0; j <a.Length; ++j)
                {
                    temp *= twoArr[j][i];
                }
                a[i] = temp;
            }
            return a;
        }
    }

}
