using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormKursova
{

    public class Matrixx
    {
        public double[,] m;
        public int column;
        public int row;
        public Matrixx(int column, int row)
        {
            this.column = column;
            this.row = row;
            m = new double[column, row];
        }
        public double this[int i, int j]
        {
            get
            {
                return m[i, j];
            }
            set
            {
                m[i, j] = value;
            }
        }
        public void setMatrix(string text)
        {
            string[] someSplit = text.Split(' ');
            int i = 0;
            int j = 0;
            for (int count = 0; count < someSplit.Length; count++)
            {
                if (someSplit[count] == ";")
                {
                    i++;
                    j = 0;
                }
                if (someSplit[count] != " " && someSplit[count] != ";")
                {
                    m[i, j] = Convert.ToDouble(someSplit[count]);
                    j++;
                }

            }
        }
        public void printMatrix(TextBox textBox)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    textBox.Text += m[i, j] + " ";
                }
                textBox.Text += Environment.NewLine;
            }
        }
        public static Matrixx operator *(Matrixx A, Matrixx B)
        {
            if (A.column == B.column && A.row == B.row)
            {
                Matrixx C = new Matrixx(A.column, A.row);
                for (int i = 0; i < A.column; i++)
                    for (int j = 0; j < A.row; j++)
                        C[i, j] = A[i, j] * B[i, j];
                return C;
            }
            MessageBox.Show("Помилка!!! Розмірність матриць різна!");
            return new Matrixx(0, 0);

        }
        public static Matrixx operator /(Matrixx A, Matrixx B)
        {
            Matrixx C = new Matrixx(A.column* A.column, A.row);
            List<double> temp = new List<double>();
            for (int i = 0; i < A.row; i++)
            {
                for (int j = 0; j < A.column; j++)
                {
                    for (int k = 0; k < A.column; k++)
                    {
                        temp.Add(A[j, i] * B[k, i]);
                    }
                }
            }
            int count = 0;
            for (int j = 0; j < A.row; j++)
            {
                for (int i = 0; i < A.column * A.column; i++)
                {
                    C[i, j] = temp[count];
                    count++;
                }
            }
            return C;
        }

    }
}
