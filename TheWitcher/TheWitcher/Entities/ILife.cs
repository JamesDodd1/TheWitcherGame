using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Entities
{
    interface ILife
    {
        /// <summary> Maximum amount of health possible </summary>
        int FullHealth { get; }

        /// <summary> Amount of life remaining </summary>
        int Health { get; set; }

        /// <summary> Amount of damage each attack will cause </summary>
        int AttackPower { get; }
    }
}
