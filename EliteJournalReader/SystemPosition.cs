using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace EliteJournalReader
{
    public struct SystemPosition
    {
        public double X, Y, Z;

        public readonly bool IsZero() => Math.Abs(X) <= 0.01 && Math.Abs(Y) <= 0.01 && Math.Abs(Z) <= 0.01;

        public override bool Equals(object obj) => obj is SystemPosition that && Equals(that);

        public readonly bool Equals(SystemPosition that) => X == that.X && Y == that.Y && Z == that.Z;

        public override int GetHashCode()
        {
            //https://stackoverflow.com/a/892640/3131828
            unchecked
            {
                int h = 23;
                h *= 31 + X.GetHashCode();
                h *= 31 + Y.GetHashCode();
                h *= 31 + Z.GetHashCode();

                return h;
            }
        }

        public double[] ToArray() => new[] { X, Y, Z };

        public override string ToString() => FormattableString.Invariant($"{X:N2},{Y:N2},{Z:N2}");

        public static bool operator ==(SystemPosition left, SystemPosition right) => left.Equals(right);

        public static bool operator !=(SystemPosition left, SystemPosition right) => !(left == right);

        public static SystemPosition operator +(SystemPosition a, SystemPosition b)
        {
            SystemPosition result = default(SystemPosition);
            result.X = a.X + b.X;
            result.Y = a.Y + b.Y;
            result.Z = a.Z + b.Z;
            return result;
        }

        public static SystemPosition operator -(SystemPosition a, SystemPosition b)
        {
            SystemPosition result = default(SystemPosition);
            result.X = a.X - b.X;
            result.Y = a.Y - b.Y;
            result.Z = a.Z - b.Z;
            return result;
        }

        public static SystemPosition operator *(float d, SystemPosition a)
        {
            SystemPosition result = default(SystemPosition);
            result.X = a.X * d;
            result.Y = a.Y * d;
            result.Z = a.Z * d;
            return result;
        }

        public static SystemPosition operator *(SystemPosition a, float d)
        {
            SystemPosition result = default(SystemPosition);
            result.X = a.X * d;
            result.Y = a.Y * d;
            result.Z = a.Z * d;
            return result;
        }

        public SystemPosition Copy() => new SystemPosition() { X = X, Y = Y, Z = Z };

        public static float Distance(SystemPosition a, SystemPosition b)
        {
            double diff_x = a.X - b.X;
            double diff_y = a.Y - b.Y;
            double diff_z = a.Z - b.Z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }

        public static float Dot(SystemPosition lhs, SystemPosition rhs)
        {
            return (float)(lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z);
        }

        public readonly SystemPosition normalized
        {
            get
            {
                return Normalize(in this);
            }
        }

        public readonly float sqrMagnitude
        {
            get
            {
                return (float)(X * X + Y * Y + Z * Z);
            }
        }

        public static SystemPosition Normalize(in SystemPosition value)
        {
            float num = value.magnitude;
            if (!(num > 1E-05f))
            {
                return new() { X = 0, Y = 0, Z = 0 };
            }

            SystemPosition result = default;
            result.X = value.X / num;
            result.Y = value.Y / num;
            result.Z = value.Z / num;
            return result;
        }

        public readonly float magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public class SystemPositionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(SystemPosition);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var pos = (SystemPosition)existingValue;
            if (JToken.ReadFrom(reader) is JArray jarr)
            {
                double[] array = jarr.ToObject<double[]>();
                pos.X = Math.Round(array[0], 3);
                pos.Y = Math.Round(array[1], 3);
                pos.Z = Math.Round(array[2], 3);
            }
            return pos;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pos = (SystemPosition)value;
            new JArray(pos.X, pos.Y, pos.Z).WriteTo(writer);
        }
    }
}
