using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleVille.Equipment
{
    public class Food : IEquipment
    {
        public required string Name { get; set; }
        public int HealthPoints { get; set; }

        public void Equip()
        {
            throw new NotImplementedException();
        }

        public void Unequip()
        {
            throw new NotImplementedException();
        }
    }
}
