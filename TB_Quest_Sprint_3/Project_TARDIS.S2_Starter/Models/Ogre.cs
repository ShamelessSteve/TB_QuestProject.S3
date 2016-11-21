using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Ogre : Character
    {
        #region FIELDS

        private List<Item> _ogresItems;
        private List<Treasure> _ogresTreasures;
        private int _age;
        private int _health;

        #endregion

        #region PROPERTIES

        public List<Item> OgresItems
        {
            get { return _ogresItems; }
            set { _ogresItems = value; }
        }

        public List<Treasure> OgresTreasures
        {
            get { return _ogresTreasures; }
            set { _ogresTreasures = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Ogre()
        {
            _ogresItems = new List<Item>();
            _ogresTreasures = new List<Treasure>();
            _health = 500;
        }

        public Ogre(string name, RaceType race, int swampLocationID, int age ) : base(name, race, swampLocationID)
        {
            _age = Age;

        }

        #endregion


        #region METHODS



        #endregion
    }
}
