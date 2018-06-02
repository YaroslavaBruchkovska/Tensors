using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormKursova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<List<Matrixx>> GlobalList = new List<List<Matrixx>>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            ClearOutpur();
            Matrixx matrixA = new Matrixx(2, 2);
            string text = "1 2 ; 3 4 ;";
            matrixA.setMatrix(text);
            Matrixx matrixx = new Matrixx(2, 4);
            int ri = 2;
            int rj = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixx[i, j] = matrixA[i, j];
                    matrixx[i, rj] = matrixA[i, j];
                    rj++;
                }
                rj = 2;
                //ri++;
            }



            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrixA);
            PrintToGrid(listA, tabControl1);
            List<Matrixx> listB = new List<Matrixx>();
            listB.Add(matrixx);
            PrintToGrid(listB, tabControl2);
           
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DefMatrix123();

            DefMatrixParni();
            DefMatrix111();


        }
        public void DefMatrix123()
        {
            Matrixx matrix1 = new Matrixx(3, 3);
            string text = "1 2 3 ; 4 5 6 ; 7 8 9 ;";
            matrix1.setMatrix(text);

            Matrixx matrix2 = new Matrixx(3, 3);
            text = "10 11 12 ; 13 14 15 ; 16 17 18 ;";
            matrix2.setMatrix(text);

            Matrixx matrix3 = new Matrixx(3, 3);
            text = "19 20 21 ; 22 23 24 ; 25 26 27 ;";
            matrix3.setMatrix(text);

            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrix1);
            listA.Add(matrix2);
            listA.Add(matrix3);
            GlobalList.Add(listA);
        }
        public void DefMatrixParni()
        {
            Matrixx matrix1 = new Matrixx(3, 3);
            string text = "2 4 6 ; 8 10 12 ; 14 16 18 ;";
            matrix1.setMatrix(text);

            Matrixx matrix2 = new Matrixx(3, 3);
            text = "1 3 5 ; 7 9 11 ; 13 15 17 ;";
            matrix2.setMatrix(text);

            Matrixx matrix3 = new Matrixx(3, 3);
            text = "1 1 2 ; 3 5 8 ; 13 21 1 ;";
            matrix3.setMatrix(text);

            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrix1);
            listA.Add(matrix2);
            listA.Add(matrix3);
            GlobalList.Add(listA);
        }
        public void DefMatrix111()
        {
            Matrixx matrix1 = new Matrixx(3, 3);
            string text = "1 1 1 ; 1 1 1 ; 1 1 1 ;";
            matrix1.setMatrix(text);

            Matrixx matrix2 = new Matrixx(3, 3);
            text = "1 1 1 ; 1 5 1 ; 1 1 1 ;";
            matrix2.setMatrix(text);

            Matrixx matrix3 = new Matrixx(3, 3);
            text = "1 1 1 ; 1 1 1 ; 1 1 1 ;";
            matrix3.setMatrix(text);

            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrix1);
            listA.Add(matrix2);
            listA.Add(matrix3);
            GlobalList.Add(listA);
        }

        private void кронекераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Matrixx matrixA = new Matrixx(2, 2);
            //string text = "1 2 ; 3 4 ;";
            //matrixA.setMatrix(text);
            //Matrixx matrixB = new Matrixx(2, 2);
            //text = "0 5 ; 6 7 ;";
            //matrixB.setMatrix(text);

            List<Matrixx> matrixC =Kronekera(GlobalList[comboBox1.SelectedIndex], GlobalList[comboBox2.SelectedIndex]);   


            //List<Matrixx> matricesxA = new List<Matrixx>();
            //List<Matrixx> matricesxB = new List<Matrixx>();
            //List<Matrixx> matricesxC = new List<Matrixx>();
            //matricesxA.Add(matrixA);
            //matricesxB.Add(matrixB);
            //matricesxC.Add(matrixC);

            PrintToGrid(GlobalList[comboBox1.SelectedIndex], tabControl1);
            PrintToGrid(GlobalList[comboBox2.SelectedIndex], tabControl2);
            PrintToGrid(matrixC, tabControl3);
            ////Norma(textBox1, matrixA);
            ////Norma(textBox2, matrixB);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void Norma(TextBox textBox,Matrixx matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.column; i++)
            {
                for (int j = 0; j < matrix.row; j++)
                {
                    sum += matrix[i,j] * matrix[i,j];
                }
            }

            textBox.Text += "Норма Тензора= " + Math.Sqrt(sum).ToString();
        }
        public List<Matrixx> Adamara(List<Matrixx> list1, List<Matrixx> list2)
        {
            var numbersAndWords = list1.Zip(list2, (matrixA, matrixB) => new { matrixA = matrixA, matrixB = matrixB });
            //foreach (var nw in numbersAndWords)


            List<Matrixx> resalt = new List<Matrixx>();
            foreach (var item in numbersAndWords)
            {
                Matrixx matrix2 = item.matrixA * item.matrixB;

                resalt.Add(matrix2);
            }
            return resalt;

        }
        private void множенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Matrixx matrixx = new Matrixx(3, 2);
            //string text = "10 10 ; 10 10 ; 10 10 ;";
            //matrixx.setMatrix(text);
            //Matrixx matrix1 = new Matrixx(3, 2);
            //text = "1 2 ; 3 4 ; 5 6 ;";
            //matrix1.setMatrix(text);
            //Matrixx matrix2 = matrixx * matrix1;

            //List<Matrixx> matricesxA = new List<Matrixx>();
            //List<Matrixx> matricesxB = new List<Matrixx>();
            //List<Matrixx> matricesxC = new List<Matrixx>();
            //matricesxA.Add(matrixx);
            //matricesxB.Add(matrix1);
            //matricesxC.Add(matrix2);




            PrintToGrid(GlobalList[0], tabControl1);
            PrintToGrid(GlobalList[1], tabControl2);
            PrintToGrid(Adamara(GlobalList[0],GlobalList[1]), tabControl3);
        }
        public List<Matrixx> XariRao(List<Matrixx> list1, List<Matrixx> list2)
        {
            var numbersAndWords = list1.Zip(list2, (matrixA, matrixB) => new { matrixA = matrixA, matrixB = matrixB });
            //foreach (var nw in numbersAndWords)


            List<Matrixx> resalt = new List<Matrixx>();
            foreach (var item in numbersAndWords)
            {
                Matrixx matrix2 = item.matrixA / item.matrixB;

                resalt.Add(matrix2);
            }
            return resalt;
        }
        private void буквиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Matrixx matrix1 = new Matrixx(2, 3);
            //string text = "1 2 3 ; 4 5 6 ;";
            //matrix1.setMatrix(text);
            //Matrixx matrix2 = new Matrixx(2, 3);
            //text = "7 8 9 ; 10 11 12 ;";
            //matrix2.setMatrix(text);
            //Matrixx C = matrix1 / matrix2;

            //List<Matrixx> matricesxA = new List<Matrixx>();
            //List<Matrixx> matricesxB = new List<Matrixx>();
            //List<Matrixx> matricesxC = new List<Matrixx>();
            //matricesxA.Add(matrix1);
            //matricesxB.Add(matrix2);
            //matricesxC.Add(C);

            //PrintToGrid(matricesxA, tabControl1);
            //PrintToGrid(matricesxB, tabControl2);
            //PrintToGrid(matricesxC, tabControl3);
            PrintToGrid(GlobalList[0], tabControl1);
            PrintToGrid(GlobalList[1], tabControl2);
            PrintToGrid(XariRao(GlobalList[0], GlobalList[1]), tabControl3);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Matrixx matrix1 = new Matrixx(3, 3);
            string text = "1 1 1 ; 1 1 1 ; 1 1 1 ;";
            matrix1.setMatrix(text);
            Matrixx matrix2 = new Matrixx(3, 3);
            text = "1 1 1 ; 1 5 1 ; 1 1 1 ;";
            matrix2.setMatrix(text);



            List<Matrixx> matricesx = new List<Matrixx>();
            matricesx.Add(matrix1);
            matricesx.Add(matrix2);
            matricesx.Add(matrix1);
            PrintToGrid(matricesx, tabControl1);
            SuperSemetr(matricesx, textBox1);
            
            MainDiagonal(matricesx, textBox1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Matrixx matrix1 = new Matrixx(3, 3);
            string text = "1 1 1 ; 1 1 1 ; 1 1 1 ;";
            matrix1.setMatrix(text);
            Matrixx matrix2 = new Matrixx(3, 3);
            text = "2 2 2 ; 2 2 2 ; 2 2 2 ;";
            matrix2.setMatrix(text);
            Matrixx matrix3 = new Matrixx(3, 3);
            text = "3 3 3 ; 3 3 3 ; 3 3 3 ;";
            matrix3.setMatrix(text);

            List<Matrixx> matricesx = new List<Matrixx>();
            matricesx.Add(matrix1);
            matricesx.Add(matrix2);
            matricesx.Add(matrix3);
            PrintToGrid(matricesx, tabControl1);
            Matrixx matrix01 = new Matrixx(3, 3);
            Matrixx matrix02 = new Matrixx(3, 3);
            Matrixx matrix03 = new Matrixx(3, 3);
            List<Matrixx> matricesx0 = new List<Matrixx>();
            matricesx0.Add(matrix01);
            matricesx0.Add(matrix02);
            matricesx0.Add(matrix03);
            PrintToGrid(matricesx0, tabControl2);

            int[] u = { 1, 2, 3};
            int[] v = { 1, 2, 3 };
            int[] w = { 1, 2, 3 };
            for (int i = 0; i < matricesx[0].row; i++)
            {
                for (int j = 0; j < matricesx[0].row; j++)
                {
                    for (int k = 0; k < matricesx[0].row; k++)
                    {
                        matricesx0[i][j, k] = u[i] * v[j] * w[k];
                    }
                }
            }

            PrintToGrid(matricesx0, tabControl3);


        }
        public void ClearOutpur()
        {
            tabControl1.TabPages.Clear();
            tabControl2.TabPages.Clear();
            tabControl3.TabPages.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void MainDiagonal(List<Matrixx> list, TextBox textBox)
        {
            List<double> tempList = new List<double>();
            for (int i = 0; i < list[0].column; i++)
            {
                tempList.Add(list[i][i, i]);
            }
            double sum = 0;
            foreach (double l in tempList)
            {
                sum += l;
            }
            if (sum / tempList.Count == tempList[0])
            {
                textBox.Text += Environment.NewLine;
                textBox.Text += "Крута головна діагональ";
            }


        }
        public List<Matrixx> Kronekera(List<Matrixx> list1, List<Matrixx> list2)
        {
            var numbersAndWords = list1.Zip(list2, (matrixA, matrixB) => new { matrixA = matrixA, matrixB = matrixB });
            //foreach (var nw in numbersAndWords)
            

            List<Matrixx> resalt = new List<Matrixx>();
            foreach (var item in numbersAndWords)
            {
                Matrixx matrixC = new Matrixx(item.matrixA.column*3, item.matrixA.row * 3);
                for (int i = 0; i < item.matrixA.column; i++)
                {
                    for (int j = 0; j < item.matrixA.row; j++)
                    {
                        for (int ri = 0; ri < item.matrixA.column; ri++)
                        {
                            for (int rj = 0; rj < item.matrixA.row; rj++)
                            {
                                matrixC[ri + i * item.matrixA.column, rj + j * item.matrixA.row] = item.matrixA[i, j] * item.matrixB[ri, rj];
                            }
                        }
                    }
                }
                resalt.Add(matrixC);
            }
            return resalt;


        }
        public void SuperSemetr(List<Matrixx> mat, TextBox textBox)
        {
            List<int> boolean = new List<int>();
            List<int> booleanCount = new List<int>();
            //int[,,] mat = new int[3, 3, 3];
            //for (int k = 0; k < 3; k++)
            //{
            //    int newI = 0;
            //    for (int i = k * 3; i < 3 * (k + 1); i++)
            //    {
            //        for (int j = 0; j < 3; j++)
            //        {
            //            mat[k, newI, j] = matrixx[i,j];
            //        }
            //        newI++;
            //    }
            //}

            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        booleanCount.Add(5);
                        if (mat[i][j, k] == mat[i][k, j] && mat[i][j, k] == mat[j][i, k] && mat[i][j, k] == mat[j][k, i] && mat[i][j, k] == mat[k][i, j] && mat[i][j, k] == mat[k][j, i])
                        {
                            boolean.Add(4);
                        }
                    }
                }
            }
            if (boolean.Count == booleanCount.Count)
            {
                textBox.Text += "Тензор супер симетричний";
            }
            else
            {
                textBox.Text += "Тензор не є супер симетричний";
            }

        }
        public void PrintToGrid(List<Matrixx> list, TabControl tabControl)
        {
            int count = 0;
            foreach (Matrixx matrixA in list)
            {
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Size = new Size(550, 550);
                for (int a = 1; a <= matrixA.row; a++)
                {
                    dataGridView1.Columns.Add(new DataGridViewColumn() { HeaderText = "[" + a.ToString() + "]", Width=30, CellTemplate = new DataGridViewTextBoxCell() });
                }
                for (int i = 0; i < matrixA.column; i++)
                {

                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    for (int j = 0; j < matrixA.row; j++)//тут було ров
                    {
                        row.Cells[j].Value = matrixA[i, j];
                        // dataGridView1.Rows.Add(matrixA[i, 0], matrixA[i, 1], matrixA[i, 2], matrixA[i, 3]);
                    }
                    dataGridView1.Rows.Add(row);
                }
                TabPage tabPage = new TabPage();
                tabPage.Text = "[" + count + "]";
                tabPage.Controls.Add(dataGridView1);
                tabControl.TabPages.Add(tabPage);
                count++;
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ClearOutpur();
            Matrixx matrixA = new Matrixx(2, 2);
            string text = "1 2 ; 3 4 ;";
            matrixA.setMatrix(text);
            Matrixx matrixx = new Matrixx(2, 4);

            Matrixx temp = new Matrixx(2, 2);
            int rj = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    temp[j, i] = matrixA[i, j];
                    //matrixx[i, rj] = matrixA[i, j];
                    // rj++;
                }
                rj = 2;
                //ri++;
            }

            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrixA);
            PrintToGrid(listA, tabControl1);
            List<Matrixx> listB = new List<Matrixx>();
            listB.Add(temp);
            PrintToGrid(listB, tabControl2);
            rj = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrixx[i, j] = temp[i, j];
                    matrixx[i, rj] = temp[i, j];
                    rj++;
                }
                rj = 2;
                //ri++;
            }
            List<Matrixx> listC = new List<Matrixx>();
            listC.Add(matrixx);
            PrintToGrid(listC, tabControl3);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            ClearOutpur();
            Matrixx matrixA = new Matrixx(2, 2);
            string text = "1 2 ; 3 4 ;";
            matrixA.setMatrix(text);
            Matrixx matrixB = new Matrixx(2, 2);
            text = "5 6 ; 7 8 ;";
            matrixB.setMatrix(text);
            Matrixx matrixx = new Matrixx(2, 4);
            int i = 0; 
            foreach(var m in matrixA.m)
            {
                matrixx[0, i] = m;
                i++;
            }
            i = 0;
            foreach (var m in matrixB.m)
            {
                matrixx[1, i] = m;
                i++;
            }
            List<Matrixx> listA = new List<Matrixx>();
            listA.Add(matrixA);
            PrintToGrid(listA, tabControl1);

            List<Matrixx> listB = new List<Matrixx>();
            listB.Add(matrixB);
            PrintToGrid(listB, tabControl2);



            List<Matrixx> listC = new List<Matrixx>();
            listC.Add(matrixx);
            PrintToGrid(listC, tabControl3);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            PrintToGrid(GlobalList[2], tabControl1);
            SuperSemetr(GlobalList[2], textBox1);
        }
    }
}
