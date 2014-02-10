using System;

namespace GeomLib
{
    // the 2d matrix class
    public class Matrix2D
    {

        // storing the members of the matrix as array
        public double[,] matrix = new double[3, 3];

        // constructor - create instance of the array variable and
        // and fill with values of a idendity matrix
        public Matrix2D()
        {
            this.matrix = new double[3, 3];
            SetToIdentity();
        }

        // copy constructor
        public Matrix2D(Matrix2D Mat)
        {
            this.matrix = new double[3, 3];
            for (var i = matrix.GetLowerBound(0); i < matrix.GetUpperBound(0); i++)
            {
                for (var j = matrix.GetLowerBound(1); j < matrix.GetUpperBound(1); j++)
                {
                    matrix.SetValue(Mat.matrix[i, j], i, j);
                }
            }
        }

        // set the current matrix to identity matrix
        public void SetToIdentity()
        {
            for (var i = matrix.GetLowerBound(0); i < matrix.GetUpperBound(0); i++)
            {
                for (var j = matrix.GetLowerBound(1); j < matrix.GetUpperBound(1); j++)
                {
                    matrix.SetValue(0, i, j);
                }
            }
            matrix.SetValue(1, 0, 0);
            matrix.SetValue(1, 1, 1);
            matrix.SetValue(1, 2, 2);
        }

        // rotate the current matrix
        public void SetToRotation(Double Angle)
        {
            Angle = Angle * Math.PI / 180.0;
            Double SinAng = Math.Sin(Angle);
            Double CosAng = Math.Cos(Angle);
            matrix.SetValue(CosAng, 0, 0);
            matrix.SetValue(-SinAng, 0, 1);
            matrix.SetValue(SinAng, 1, 0);
            matrix.SetValue(CosAng, 1, 1);
        }

        // scale the current matrix
        public void SetToScaling(Double ScaleFac)
        {
            matrix.SetValue(ScaleFac, 0, 0);
            matrix.SetValue(ScaleFac, 1, 1);
        }

        // translate the current matrix
        public void SetToTranslation(Vector2D TransVec)
        {
            matrix.SetValue(TransVec.X, 0, 2);
            matrix.SetValue(TransVec.Y, 1, 2);
        }

        // multiply matrix 1 and 2 and return the resultant matrix
        public Matrix2D Multiply(Matrix2D Mat1, Matrix2D Mat2)
        {
            Matrix2D Mat = new Matrix2D();
            Double sum = 0;
            for (var ii = 0; ii < 2; ii++)
            {
                for (var jj = 0; jj < 2; jj++)
                {
                    sum = 0;
                    for (var kk = 0; kk < 2; kk++)
                    {
                        sum = sum + (Mat1.matrix[ii, kk] * Mat2.matrix[kk, jj]);
                    }
                    Mat.matrix.SetValue(sum, ii, jj);
                }
            }
            return Mat;
        }

        // find the determinant of the current matrix
        public Double Determinant()
        {
            Double det = 0.0;
            det = (matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[2, 1] * matrix[1, 2])) - (matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[2, 0] * matrix[1, 2])) + (matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[2, 0] * matrix[1, 1]));
            return det;
        }

        // find the transpose
        public void Transpose()
        {
            Double tmp = 0.0;

            for (var i = 1; i < 2; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    tmp = matrix[i, j];
                    matrix.SetValue(matrix[j, i], i, j);
                    matrix.SetValue(tmp, j, i);
                }
            }
        }

        // find the cofactor matrix and return the same
        public Matrix2D CoFactor()
        {
            int i1, j1;
            double det;
            Matrix2D m = new Matrix2D();
            Matrix2D CMat = new Matrix2D();

            for (var j = 0; j < 2; j++)
            {
                for (var i = 0; i < 2; i++)
                {
                    i1 = 0;
                    for (var ii = 0; ii < 2; ii++)
                    {
                        if (ii != i)
                        {
                            j1 = 0;
                            for (var jj = 0; jj < 2; jj++)
                            {
                                if (jj != j)
                                {
                                    m.matrix.SetValue(matrix[ii, jj], i1, j1);
                                    j1 = +j1 + 1;
                                }
                            }
                            i1 = i1 + 1;
                        }
                    }
                    det = m.Determinant();
                    CMat.matrix.SetValue(System.Math.Pow(-1.0, i + j + 2.0) * det, i, j);
                }
                m = null;
            }
            return CMat;
        }

        // multiply the currnet matrix with the parameter
        public void PreMultiplyBy(Matrix2D Mat)
        {
            Matrix2D ThisMat = new Matrix2D();
            Matrix2D CMat = new Matrix2D();
            ThisMat.matrix = matrix;
            CMat = Multiply(Mat, ThisMat);
            matrix = CMat.matrix;
            ThisMat = null;
            CMat = null;
        }

        // multiply the currnet matrix with the parameter
        public void PostMultiplyBY(Matrix2D Mat)
        {
            Matrix2D Thismat = new Matrix2D();
            Matrix2D CMat = new Matrix2D();
            Thismat.matrix = matrix;
            CMat = Multiply(Thismat, Mat);
            matrix = CMat.matrix;
            Thismat = null;
            CMat = null;
        }

        // get the inverse matrix of the current matrix and return it
        public Matrix2D GetInverse()
        {
            Matrix2D NewMatrix;
            Double det = Determinant();
            det = 1 / det;
            NewMatrix = CoFactor();
            NewMatrix.Transpose();

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    NewMatrix.matrix.SetValue(NewMatrix.matrix[i, j] * det, i, j);
                }
            }
            return NewMatrix;
        }
        // find the inverse matrix of the current matrix and set that as current matrix
        public void Invert()
        {
            Matrix2D NewMatrix;
            Double det = Determinant();
            det = 1 / det;
            NewMatrix = CoFactor();
            NewMatrix.Transpose();

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    matrix.SetValue(NewMatrix.matrix[i, j] * det, i, j);
                }
            }
            NewMatrix = null;
        }

    }
}
