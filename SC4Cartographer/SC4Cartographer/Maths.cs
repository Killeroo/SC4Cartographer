using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC4CartographerUI
{
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;

        public Vector(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public static Vector operator /(Vector v, float f) => new Vector(v.X / f, v.Y / f, v.Z / f);


        public static Vector Cross(Vector v1, Vector v2)
        {
            float crossX = v1.Y * v2.Z - v2.Y * v1.Z;
            float crossY = v1.Z * v2.X - v2.Z * v1.X;
            float crossZ = v1.X * v2.Y - v2.X * v1.Y;

            return new Vector(crossX, crossY, crossZ);
        }

        public static float Mag(Vector v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static Vector Normalise(Vector v)
        {
            float magnitude = Mag(v);

            return new Vector(v.X / magnitude, v.Y / magnitude, v.Z / magnitude);
        }
    }
}
