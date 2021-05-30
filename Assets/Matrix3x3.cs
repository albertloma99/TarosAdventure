using UnityEngine;

namespace Maths
{
    public class Matrix3x3
    {
        private Matrix4x4 _matrix;

        public Matrix3x3 Inverse => this._matrix.inverse;
        
        public Matrix3x3(Vector3 column0, Vector3 column1, Vector3 column2)
        {
            this._matrix = new Matrix4x4(new Vector4(column0.x, column0.y, column0.z, 0), new Vector4(column1.x, column1.y, column1.z, 0), new Vector4(column2.x, column2.y, column2.z, 0), new Vector4(0, 0, 0, 1));
        }


        public static implicit operator Matrix3x3(Matrix4x4 m)
        {
            return new Matrix3x3(new Vector3(m.GetColumn(0).x, m.GetColumn(0).y, m.GetColumn(0).z), new Vector3(m.GetColumn(1).x, m.GetColumn(1).y, m.GetColumn(1).z), new Vector3(m.GetColumn(2).x, m.GetColumn(2).y, m.GetColumn(2).z));
        }
        
        public static implicit operator Matrix4x4(Matrix3x3 m)
        {
            return new Matrix4x4(m._matrix.GetColumn(0), m._matrix.GetColumn(1), m._matrix.GetColumn(2), m._matrix.GetColumn(3));
        }

        public static Matrix3x3 operator*(Matrix3x3 a, Matrix3x3 b)
        {
            return (Matrix4x4)a * (Matrix4x4)b;
        }
        
        public static Vector3 operator*(Matrix3x3 a, Vector3 b)
        {
            return ((Matrix4x4)a).MultiplyVector(b);
        }
    }
}