using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get ; set ; }
        public virtual int Power { get ; set ; }

        public virtual string CastAbility()
        {
            return string.Empty;
        }
    }
}
