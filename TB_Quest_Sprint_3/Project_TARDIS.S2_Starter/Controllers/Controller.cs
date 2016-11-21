using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// CIT 195
    /// Scott Kuhlman
    /// 11/20/16
    /// TB Quest Game Sprint 3
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Ogre _gameOgre;
        private Kingdom _gameKingdom;
        private Dragon _gameDragon;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // instantiate a Salesperson object
            //
            _gameOgre = new Ogre();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameOgre, _gameKingdom);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameKingdom = new Kingdom();
            _gameOgre = new Ogre();
            _gameConsoleView = new ConsoleView(_gameOgre, _gameKingdom);
            _gameDragon = new Dragon();

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            OgreAction ogreActionChoice = OgreAction.None;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {
                //not currently using the ogreActionChoice function
                UpdateGameStatus(ogreActionChoice);
                //
                // get a menu choice from the ConsoleView object
                //
                ogreActionChoice = _gameConsoleView.DisplayGetOgreActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (ogreActionChoice)
                {
                    case OgreAction.None:
                        break;
                    case OgreAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case OgreAction.TalkTo:
                        _gameConsoleView.DisplayTalkTo();
                        break;
                    case OgreAction.LookAt:
                        _gameConsoleView.DisplayLookAt();
                        break;
                    case OgreAction.PickUpItem:
                        int itemID;
                        itemID = _gameConsoleView.DisplayPickUpItem();

                        Item PickedUpItem = new Item();
                        PickedUpItem = _gameKingdom.GetItemtByID(itemID);

                        _gameOgre.OgresItems.Add(PickedUpItem);

                        PickedUpItem.SwampLocationID = 0;

                        break;
                    case OgreAction.PickUpTreasure:
                        int treasureID = _gameConsoleView.DisplayPickUpTreasure();

                        Treasure PickedUpTreasure = new Treasure();
                        PickedUpTreasure = _gameKingdom.GetTreasuretByID(treasureID);

                        _gameOgre.OgresTreasures.Add(PickedUpTreasure);

                        PickedUpTreasure.SwampLocationID = 0;

                        break;
                    case OgreAction.PutDownItem:
                        int itemToPutDown = _gameConsoleView.DisplayPutDownItem();

                        Item ItemToDrop = new Item();
                        ItemToDrop = _gameKingdom.GetItemtByID(itemToPutDown);

                        _gameOgre.OgresItems.Remove(ItemToDrop);

                        ItemToDrop.SwampLocationID = _gameOgre.SwampLocationID;

                        break;
                    case OgreAction.PutDownTreasure:
                        int treasureToPutDown = _gameConsoleView.DisplayPutDownTreasure();

                        Treasure TreasureToDrop = new Treasure();
                        TreasureToDrop = _gameKingdom.GetTreasuretByID(treasureToPutDown);

                        _gameOgre.OgresTreasures.Remove(TreasureToDrop);

                        TreasureToDrop.SwampLocationID = _gameOgre.SwampLocationID;

                        break;
                    case OgreAction.Travel:
                        _gameOgre.SwampLocationID = _gameConsoleView.DisplayGetOgresNewDestination().SwampLocationID;

                        break;
                    case OgreAction.OgreInfo:
                        _gameConsoleView.DisplayOgreInfo();
                        break;
                    case OgreAction.OgreInventory:
                        _gameConsoleView.DisplayOgreItems();
                        break;
                    case OgreAction.OgreTreasure:
                        _gameConsoleView.DisplayOgreTreasure();
                        break;
                    case OgreAction.ListSwampDestinations:
                        _gameConsoleView.DisplayListAllSwampDestinations();
                        break;
                    case OgreAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case OgreAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case OgreAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            _gameConsoleView.DisplayGameSetupIntro();
            _gameOgre.Name = _gameConsoleView.DisplayGetOgresName();
            _gameOgre.Race = _gameConsoleView.DisplayGetOgresRace();
            _gameOgre.Age = _gameConsoleView.DisplayGetOgresAge();
            _gameOgre.SwampLocationID = _gameConsoleView.DisplayGetOgresNewDestination().SwampLocationID;

            // 
            // add initial items to the traveler's inventory
            //
            AddItemToOgresInventory(3);
            AddItemToOgresTreasure(1);
        }

        /// <summary>
        /// add a game item to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToOgresInventory(int itemID)
        {
            Item item;

            item = _gameKingdom.GetItemtByID(itemID);
            item.SwampLocationID = 0;

            _gameOgre.OgresItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToOgresTreasure(int itemID)
        {
            Treasure item;

            item = _gameKingdom.GetTreasuretByID(itemID);
            item.SwampLocationID = 0;

            _gameOgre.OgresTreasures.Add(item);
        }

        //not currently using the ogreActionChoice function
        private void UpdateGameStatus(OgreAction ogreActionChoice)
        {

            if (_gameOgre.SwampLocationID == 1)
            {
                _gameOgre.Health = 500;
            }

            if (_gameOgre.SwampLocationID == 5 && ogreActionChoice == OgreAction.TalkTo)
            {
                Dragon enemyDragon;

                enemyDragon = _gameKingdom.GetDragonByID(2);
                enemyDragon.Health = enemyDragon.Health - 100;
                _gameOgre.Health = _gameOgre.Health - 100;

                if (_gameOgre.Health == 0)
                {
                    Console.WriteLine("You have died in battle. Bardul will now eat what remains of you.");
                    Console.ReadLine();

                    _usingGame = false;
                }

                else if (_gameOgre.Health < 200)
                {
                    Console.WriteLine("Your health is getting low.  You should return to Silvara to heal.");
                    Console.ReadLine();
                }

                else if (enemyDragon.Health == 0 && _gameOgre.Health != 0)
                {
                    Console.WriteLine("Hurry!! You have have defeated the evil Dragon and made the world a better place.");
                    Console.ReadLine();

                    _usingGame = false;
                }

                
            }




        }

        #endregion
    }
}
