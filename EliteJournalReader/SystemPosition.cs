using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteJournalReader
{
    public struct SystemPosition
    {
        public double X, Y, Z;

        public bool IsZero() => Math.Abs(X) <= 0.01 && Math.Abs(Y) <= 0.01 && Math.Abs(Z) <= 0.01;

        public override bool Equals(object obj) => obj is SystemPosition that && Equals(that);

        public bool Equals(SystemPosition that) => X == that.X && Y == that.Y && Z == that.Z;

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

        public SystemPosition Copy() => new SystemPosition() { X = X, Y = Y, Z = Z };

        public static float Distance(SystemPosition a, SystemPosition b)
        {
            double diff_x = a.X - b.X;
            double diff_y = a.Y - b.Y;
            double diff_z = a.Z - b.Z;
            return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y + diff_z * diff_z);
        }
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
