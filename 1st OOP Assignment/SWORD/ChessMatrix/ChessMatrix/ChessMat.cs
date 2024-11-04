using System;

namespace chessMat
{
    public class Chess
    {
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };
        #endregion
        private readonly int size;
        private readonly double[,] matrix;
        private readonly int numValues;
        public Chess(int size)
        {
            if (size <= 0)
            {
                throw new NegativeSizeException();
            }

            this.size = size;
            this.matrix = new double[size, size];
            numValues = ((size * size) / 2);
            if (((size * size) % 2) != 0)
            {
                numValues++;
            }
        }
        public Chess(Chess b)
        {
            this.size=b.size;
            this.matrix = b.matrix.Clone() as double[,];
            this.numValues=b.numValues;
        }
        public int Size
        {
            get { return this.size; }
        }

        public double this[int row, int col]
        {
            get
            {
                if (row<0||row>=this.size||col<0||col>=this.size)
                {
                    throw new ReferenceToNullPartException();
                }

                return this.matrix[row, col];
            }
            set {
                if (row<0||row>=this.size||col<0||col>=this.size)
                {
                    throw new ReferenceToNullPartException();
                }
                if (row % 2 == col % 2) matrix[row, col] = value;
                else throw new ReferenceToNullPartException();
            }
        }
        public void Set(in List<double> x)
        {
            int val = 0;
            if (this.numValues != x.Count) throw new DifferentSizeException();
            for (int i=0;i<Size;i++){
                for(int j=0;j<Size;j++){
                    if (i%2==j%2){
                        this.matrix[i,j]=x[val];
                        ++val;
                    }
                }
                
            }
        }
        public override bool Equals(Object? obj)
        {
            if (obj == null || !(obj is Chess))
                return false;
            else
            {
                Chess? board = obj as Chess;
                if (board!.Size != this.Size) { 
                    return false; 
                }
                for (int i=0;i<Size;i++)
                {
                    for (int j=0;j<Size;j++)
                    {
                        if (matrix[i,j]!=board.matrix[i,j]){ 
                            return false;
                        }
                    }

                }
                return true;
            }
        }
        public static Chess operator +(Chess a, Chess b)
        {
            if (a.Size != b.Size)
            {
                throw new DifferentSizeException();
            }

            Chess result = new Chess(a.Size);

            for (int row=0; row<result.Size;row++)
            {
                for (int col=0;col<result.Size;col++)
                {
                    result.matrix[row,col]=a[row,col]+b[row,col];
                }
            }

            return result;
        }

        public static Chess operator *(Chess a, Chess b)
        {
            if (a.Size != b.Size)
            {
                throw new DifferentSizeException();
            }

            Chess result = new Chess(a.Size);

            for (int row=0;row<result.Size;row++)
            {
                for (int col=0;col<result.Size;col++)
                {
                    result.matrix[row,col]=a[row,col]*b[row,col];
                }
            }
            return result;
        }

        public override string ToString()
        {
            string str = "";
            for (int row=0; row<this.size;row++)
            {
                for (int col=0;col<this.size;col++)
                {
                    str += "\t" + this[row,col];
                }

                str += "\n";
            }
            return str;
        }
    }

}
