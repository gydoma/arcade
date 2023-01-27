using System;
using System.Collections.Generic;

namespace snakegame
{
    public class position
    {
        public int Sor { get; }
        public int Oszlop { get; }

        public position (int sor, int oszlop)
        {
            Sor = sor;
            Oszlop = oszlop;
        }

        public position Translate(direction dir)
        {
            return new position (Sor + dir.Soroffset, Oszlop + dir.Oszlopoffset);
        }

        public override bool Equals(object obj)
        {
            return obj is position position &&
                   Sor == position.Sor &&
                   Oszlop == position.Oszlop;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sor, Oszlop);
        }

        public static bool operator ==(position left, position right)
        {
            return EqualityComparer<position>.Default.Equals(left, right);
        }

        public static bool operator !=(position left, position right)
        {
            return !(left == right);
        }
    }
}
