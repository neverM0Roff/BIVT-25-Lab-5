using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double sum = 0;
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                    
                }
            }
            if (count == 0)
            {
                average = 0;
            }
            else 
            { 
                average = sum / count;
            }
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int Min = int.MaxValue;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < Min)
                    {
                        Min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int Max = int.MinValue;
            int Max_row = 0;
            if (k < columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, k] > Max)
                    {
                        Max = matrix[i, k];
                        Max_row = i;
                    }
                }
                if (Max_row != 0)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int vrem = matrix[0, j];
                        matrix[0, j] = matrix[Max_row, j];
                        matrix[Max_row, j] = vrem;
                    }
                }
            }
            
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            int Min = int.MaxValue;
            int Min_row = 0;
            int k = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] < Min)
                {
                    Min = matrix[i, k];
                    Min_row = i;
                }
            }
            answer = new int[rows - 1, columns];
            for (int i = 0; i < rows - 1; i++)
            {
                if (i < Min_row)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < columns; j++)
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (rows == columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    sum += matrix[i, i];
                }
            }
            
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int fneg = -1;
                int lneg = -1;
                int max_el = int.MinValue;
                int max_ind = -1;
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (fneg == -1)
                        {
                            fneg = j;
                        }
                        lneg = j;
                    }
                    if (fneg == -1 && matrix[i, j] > max_el)
                    {
                        max_el = matrix[i, j];
                        max_ind = j;
                    }
                }
                if (max_ind != -1 && lneg != -1)
                {
                    int vrem = matrix[i, max_ind];
                    matrix[i, max_ind] = matrix[i, lneg];
                    matrix[i, lneg] = vrem;
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int k = 0;
            int neg = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        neg++;
                    }
                }
            }
            if (neg != 0)
            {
                negatives = new int[neg];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[k] = matrix[i, j];
                            k++;
                        }
                    }
                }
            }
            
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (column == 1)
                {
                    continue;
                }
                int max_ind = 0;
                int max_el = int.MinValue;
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] > max_el)
                    {
                        max_el = matrix[i, j];
                        max_ind = j;
                    }
                }
                int left = max_ind - 1;
                int right = max_ind + 1;
                if (max_ind > 0 && max_ind < column - 1)
                {
                    if (matrix[i, left] > matrix[i, right])
                    {
                        matrix[i, right] *= 2;
                    }
                    else if (matrix[i, left] < matrix[i, right])
                    {
                        matrix[i, left] *= 2;
                    }
                    else
                    {
                        matrix[i, left] *= 2;
                    }
                }
                else if (max_ind == 0)
                {
                    matrix[i, left + 2] *= 2;
                }
                else if (max_ind == column - 1)
                {
                    matrix[i, column - 2] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column / 2; j++)
                {
                    int vrem = matrix[i, j];
                    matrix[i, j] = matrix[i, column - 1 - j];
                    matrix[i, column - 1 - j] = vrem;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            if (rows == column)
            {
                for (int i = rows / 2; i < rows; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int column = matrix.GetLength(1);
            int woz_counter = 0;
            for (int i = 0; i < rows; i++)
            {
                bool zero = false;
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }
                if (zero == false)
                {
                    woz_counter++;
                }
            }
            if (woz_counter == 0)
            {
                answer = new int[0, column];
            }
            else if (woz_counter == rows)
            {
                answer = new int[rows, column];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
            }
            else
            {
                answer = new int[woz_counter, column];
                int k = 0;
                for (int i = 0; i < rows; i++)
                {
                    bool zero = false;
                    for (int j = 0; j < column; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            zero = true; 
                            break;
                        }
                    }
                    if (zero == false)
                    {
                        for (int j = 0; j < column; j++)
                        {
                            answer[k, j] = matrix[i, j];
                        }
                        k++;
                    }
                }
            }
                // end

                return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;
            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int k = 0; k < array[i].Length; k++)
                    sum += array[i][k];
                sums[i] = sum;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (sums[i] > sums[j])
                    {
                        int vrem_sum = sums[i];
                        sums[i] = sums[j];
                        sums[j] = vrem_sum;
                        int[] vrem_arr = array[i];
                        array[i] = array[j];
                        array[j] = vrem_arr;
                    }
                }
            }
            // end

        }
    }
}