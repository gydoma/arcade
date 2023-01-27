using System;
using System.Collections.Generic;

namespace snakegame
{
    public class direction
    {
        public readonly static direction left = new direction(0, -1);
        public readonly static direction right = new direction(0, 1);
        public readonly static direction up = new direction(-1, 0);
        public readonly static direction down = new direction(1, 0);
        public int Soroffset { get; }
        public int Oszlopoffset { get; }

        private direction(int soroffset, int oszlopoffset)
        {
            Soroffset = soroffset;
            Oszlopoffset = oszlopoffset;
        }

        public direction Opposite()
        {
            return new direction(-Soroffset, -Oszlopoffset);
        }

        public override bool Equals(object obj)
        {
            return obj is direction direction &&
                   Soroffset == direction.Soroffset &&
                   Oszlopoffset == direction.Oszlopoffset;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Soroffset, Oszlopoffset);
        }

        public static bool operator ==(direction left, direction right)
        {
            return EqualityComparer<direction>.Default.Equals(left, right);
        }

        public static bool operator !=(direction left, direction right)
        {
            return !(left == right);
        }
    }
}
