using System;

namespace GeomLib
{
    // the 2d point class
    public class Point2D
    {
        // data members - X and Y coordinates
        public double X;
        public double Y;

        // constructor
        public  Point2D()
        {
            X = 0.0;
            Y = 0.0;
        }

        // parametrised constructor
        public  Point2D(double xx, double yy)
        {
            X = xx;
            Y = yy;
        }

        // copy constructor
        public  Point2D(Point2D Point)
        {
            X = Point.X;
            Y = Point.Y;
        }

        public  Point2D(System.Drawing.Point Pt)
        {
            X = Pt.X;
            Y = Pt.Y;
        }

        // to redefine the point variables
        public void SetPoint(Double xx, Double yy)
        {
            X = xx;
            Y = yy;
        }

        // find the distance between this point and the parameter point
        public Double DistanceTo(Point2D Point)
        {
            double xval = X - Point.X;
            double yval = Y - Point.Y;
            return System.Math.Sqrt(xval * xval + yval * yval);
        }

        // checks whether this point is equal to the parameter point
        public Boolean IsEqualTo(Point2D Point)
        {
            if (X == Point.X && Y == Point.Y)
                return true;
            else
                return false;
        }

        // translate this point by the parameter vector
        public void TranslateBy(Vector2D Vec)
        {
            //if Vec.Length() > 1.0 Then
            X = X + Vec.X;
            Y = Y + Vec.Y;
            //End if
        }

        // transform this point by the parameter matrix
        public void TransformBy(Matrix2D Mat)
        {
            double xx = 0; double yy = 0;
            xx = (X * Mat.matrix[0, 0]) + (Y * Mat.matrix[1, 0]) + (Mat.matrix[0, 2]);

            yy = (X * Mat.matrix[0, 1]) + (Y * Mat.matrix[1, 1]) + (Mat.matrix[1, 2]);

            X = xx;
            Y = yy;
        }

        // add this point with the parameter point
        // and return the result
        public Point2D Add(Point2D Point)
        {
            Point2D NewPoint = new Point2D();
            NewPoint.X = X + Point.X;
            NewPoint.Y = Y + Point.Y;
            return NewPoint;
        }

        // subtract this point with the parameter point
        // and return the result
        public Point2D Subtract(Point2D Point)
        {
            Point2D NewPoint = new Point2D();
            NewPoint.X = X - Point.X;
            NewPoint.Y = Y - Point.Y;
            return NewPoint;
        }

        public System.Drawing.Point ToPoint()
        {
            return new System.Drawing.Point(Convert.ToInt32(X), Convert.ToInt32(Y));
        }
    }

}