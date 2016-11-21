using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Dragon : Character
    {
        
        #region FIELDS

        private string _description;
        private int _health;

        private List<Dragon> _gameDragons;

        #endregion

        #region Properties

        public override int CharacterID { get; set; }

        public override RaceType Race { get; set; }

        public override string Name { get; set; }
        
        public override int SwampLocationID { get; set; }

        public override bool IsAlive { get; set; }

        public bool HasMessage { get; set; }

        public string Message { get; set; }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<Dragon> GameDragons
        {
            get { return _gameDragons; }
            set { _gameDragons = value; }
        }


        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        #endregion

        #region Constructors


        #endregion
    }
}
