﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// define all treasure objects
    /// </summary>
    public class Treasure : GameObject
    {
        public enum Type
        {
            Weapon,
            Armor,
        }

        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public Type TreasureType { get; set; }

        public override string Description { get; set; }

        public override int SwampLocationID { get; set; }

        public override bool HasValue { get; set; }

        public override int Value { get; set; }

        public override bool CanAddToInventory { get; set; }

    }
}
