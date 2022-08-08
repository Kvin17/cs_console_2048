using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_console_2048
{
    internal class Tile
    {
        public int _nominal { get; }
        public Picture _picture { get; }
        public Tile(bool empty)
        {
            if (empty) 
            { _nominal = 0;
                _picture = Program.pictures[_nominal]; }
            else
            {
                var rndm = new Random();
                if (rndm.Next(0, 11) > 9)
                    _nominal = 4;
                else _nominal = 2;
                _picture = Program.pictures[_nominal];
            }
        }
        public Tile(int nominal)
        {
            _nominal = nominal;
            _picture = Program.pictures[_nominal];
        }
       // public static bool operator!=(Tile left, Tile right) => left._nominal != right._nominal;
        //public static bool operator ==(Tile left, Tile right) => left._nominal==right._nominal;
    }
}
