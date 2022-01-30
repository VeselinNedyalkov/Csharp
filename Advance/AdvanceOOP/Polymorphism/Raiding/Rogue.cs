using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            Power = 80;
        }

        public override int Power { get => base.Power; }
        public override string CastAbility()
        {
            return $"Rogue - {Name} hit for {Power} damage";
        }
    }
}
