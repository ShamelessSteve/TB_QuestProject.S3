using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public abstract class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Big,
            Ugly,
            Angry,
            Dragon,
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _swampLocationID;
        private RaceType _race;
        private int _characterID;

        private bool _isAlive;

        #endregion


        #region PROPERTIES

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual int SwampLocationID
        {
            get { return _swampLocationID; }
            set { _swampLocationID = value; }
        }

        public virtual RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public virtual int CharacterID
        {
            get { return _characterID; }
            set { _characterID = value; }
        }



        public virtual bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }



        #endregion


        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int swampLocationID)
        {
            _name = name;
            _race = race;
            _swampLocationID = swampLocationID;
        }

        #endregion


        #region METHODS



        #endregion




    }
}
