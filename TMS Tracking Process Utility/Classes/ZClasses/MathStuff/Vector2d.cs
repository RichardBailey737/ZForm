using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeomLib
{
    public class Vector2D
    {

        public Double X;
        public Double Y;

        // constructor
        public  Vector2D() {
            X = 0.0;
            Y = 0.0;
        }

        // parametrised constructor
        public  Vector2D(Double xx, Double yy) {
            X = xx;
            Y = yy;
        }

        // copy constructor
        public  Vector2D(Vector2D Vec)
        {
            X = Vec.X;
            Y = Vec.Y;
        }

        // set vector from two points
        public Vector2D(Point2D StartPt, Point2D EndPt)
        {
            X = EndPt.X - StartPt.X;
            Y = EndPt.Y - StartPt.Y;
        }

        // to redefine the vector variables
        public void SetVector(Double xx, Double yy) {
            X = xx;
            Y = yy;
        }

        // find the angle of this vector and return it
        public double Angle() {
            return System.Math.Atan(Y / X);
        }

        public double AngleD() {
            return 180.0 / Math.PI * System.Math.Atan(Y / X);
        }

        // dot product of this vector and the parameter vector
        public double DotProduct(Vector2D Vec) {
            return (X * Vec.X) + (Y * Vec.Y);
        }

        // length of this vector
        public double Length() {
            return System.Math.Sqrt(X * X + Y * Y);
        }

        public double LengthSquared()
        {
            return X * X + Y * Y;
        }

        // find the angle between this vector and the parameter vector
        public double AngleTo(Vector2D Vec) {
            double AdotB = DotProduct(Vec);
            double ALstarBL = Length() * Vec.Length();
            if (ALstarBL == 0)
            {
                return 0.0;
            }
            return 180.0 / Math.PI * System.Math.Acos(AdotB / ALstarBL);
        }

        // find the unit vector and return it
        public Vector2D UnitVector() {
            Vector2D Vec = new Vector2D();
            double len = Length();
            if (len == 0.0)
            {
                Vec.SetVector(0.0, 0.0);
                return Vec;
            }
            Vec.X = X / len;
            Vec.Y = Y / len;
            return Vec;
        }

        // checks whether this vector is codirectional to the parameter vector
        public Boolean IsCodirectionalTo(Vector2D Vec) {
            Vector2D Vec1 = UnitVector();
            Vector2D Vec2 = Vec.UnitVector();
            if (Vec1.X == Vec2.X && Vec1.Y == Vec2.Y) {
                return true;
            } else { 
                return false;
            }
        }

        // checks whether this vector is equal to the parameter vector
        public Boolean IsEqualTo(Vector2D Vec) {
            if (X == Vec.X && Y == Vec.Y) {
                return true;
            } else {
                return false;
            }
        }

        // checks whether this vector is parallel to the parameter vector
        public Boolean IsParallelTo(Vector2D Vec) {
            Vector2D Vec1 = UnitVector();
            Vector2D Vec2 = Vec.UnitVector();
            if ((Vec1.X == Vec2.X && Vec1.Y == Vec2.Y) || (Vec1.X == -Vec2.X && Vec1.Y == -Vec2.Y)) {
                return true;
            } else {
                return false;
            }
        }

        // checks whether this vector is perpendicular to the parameter vector
        public Boolean IsPerpendicularTo(Vector2D Vec) {
            double Ang = AngleTo(Vec);
            if (Ang == (90 * System.Math.PI / 180.0)) {
                return true;
            } else {
                return false;
            }
        }

        // checks whether this vector is X axis
        public bool IsXAxis() {
            if (X != 0 && Y == 0) 
                return true;
            else 
                return false;
        }

        // checks whether this vector is Y axis
        public bool IsYAxis() {
            if (X == 0 && Y != 0) 
                return true;
            else 
                return false;
        }

        // negate this vector
        public void Negate() {
            X = X * -1.0;
            Y = Y * -1.0;
        }

        // transform this vector with given matrix
        public void TransformBy(Matrix2D Mat) {
            double xx = 0; double yy = 0;
            xx = (X * Mat.matrix[0, 0]) + (Y * Mat.matrix[1, 0]) + (Mat.matrix[0, 2]);

            yy = (X * Mat.matrix[0, 1]) + (Y * Mat.matrix[1, 1]) + (Mat.matrix[1, 2]);

            X = xx;
            Y = yy;
        }

        // add this vector with the parameter vector
        // and return the result
        public Vector2D Add(Vector2D Vec) {
            Vector2D NewVec = new Vector2D();
            NewVec.X = X + Vec.X;
            NewVec.Y = Y + Vec.Y;
            return NewVec;
        }

        // subtract this vector with the parameter vector
        // and return the result
        public Vector2D Subtract(Vector2D Vec) {
            Vector2D NewVec = new Vector2D();
            NewVec.X = X - Vec.X;
            NewVec.Y = Y - Vec.Y;
            return NewVec;
        }

        public Vector2D Divide(Double Value) {
            Vector2D newvec = new Vector2D();
            newvec.X = X / Value;
            newvec.Y = Y / Value;
            return newvec;
        }

        public Vector2D Multiply(Double Value) {
            Vector2D newvec = new Vector2D();
            newvec.X = X * Value;
            newvec.Y = Y * Value;
            return newvec;
        }

        public static Vector2D Lerp(Vector2D value1, Vector2D value2, float amount)
        {
            Vector2D vector2 = new Vector2D();
            vector2.X = value1.X + (value2.X - value1.X) * amount;
            vector2.Y = value1.Y + (value2.Y - value1.Y) * amount;
            return vector2;
        }
    }
}
