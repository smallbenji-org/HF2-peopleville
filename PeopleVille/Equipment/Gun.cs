using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleVille.Equipment
{
    public class Gun : IEquipment
    {
        public required string Name { get; set; }
        public int Damage { get; set; }

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
