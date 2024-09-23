using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class Matrix<T> where T : IComparable<T>
    {
        private T[,] _data;

        public Matrix(int rows, int columns)
        {
            _data = new T[rows, columns];
        }
        public T this[int row, int column]
        {
            get => _data[row, column];
            set => _data[row, column] = value;
        }
        public void Fill(T value)
        {
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    _data[i, j] = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    stringBuilder.Append($"{_data[i, j]} ");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        public int CountColumnsWithZero()
        {
            int count = 0;

            for (int j = 0; j < Columns; j++)
            {
                for (int i = 0; i < Rows; i++)
                {
                    if (_data[i, j].Equals(default(T))) 
                    {
                        count++;
                        break; 
                    }
                }
            }

            return count;
        }

        public int RowWithMostEqualElements()
        {
            int maxEqualCount = 0;
            int rowWithMaxEqual = -1;

            for (int i = 0; i < Rows; i++)
            {
                Dictionary<T, int> elementCount = new Dictionary<T, int>();
                for (int j = 0; j < Columns; j++)
                {
                    if (elementCount.ContainsKey(_data[i, j]))
                    {
                        elementCount[_data[i, j]]++;
                    }
                    else
                    {
                        elementCount[_data[i, j]] = 1;
                    }
                }

                int maxInRow = elementCount.Values.Max();
                if (maxInRow > maxEqualCount)
                {
                    maxEqualCount = maxInRow;
                    rowWithMaxEqual = i;
                }
            }
            return rowWithMaxEqual;
        }
        public int Rows => _data.GetLength(0);
        public int Columns => _data.GetLength(1);
    }

}
