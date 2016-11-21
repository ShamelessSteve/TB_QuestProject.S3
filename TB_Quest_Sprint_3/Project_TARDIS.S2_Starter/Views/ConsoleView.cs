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
    /// 11/21/16
    /// TB Quest Game Sprint 3
    /// </summary>
    /// 
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Kingdom and Ogre object for the ConsoleView object to use
        //
        Kingdom _gameKingdom;
        Ogre _gameOgre;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Ogre gameOgre, Kingdom gameKingdom)
        {
            _gameOgre = gameOgre;
            _gameKingdom = gameKingdom;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "The TB Quest Project";
            ConsoleUtil.HeaderText = "The TB Quest Project";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thanks for playing my TB Quest Game.  Have a good day. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The TB Quest Project");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Written by Scott Kuhlman");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("You are a bored Ogre living in your life long swamp home  deep  ");
            sb.AppendFormat("in the forest.  You awake one day with a strong urge to travel. ");
            sb.AppendFormat("You set out to explore more of your world and see the Kingdom. ");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("First you need to create your Ogre for travel.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Ogre object
        /// </summary>
        public void DisplayGameSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();

            //
            // display intro
            //
            ConsoleUtil.DisplayMessage("You will now be prompted to enter the starting parameters of your game.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming game setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your game setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your ogre information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetOgresName()
        {
            string ogresName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Ogre's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Please Enter Your Ogre's Name: ");
            ogresName = Console.ReadLine();

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {ogresName} as your name.");

            DisplayContinuePrompt();

            return ogresName;
        }

        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Ogre.RaceType DisplayGetOgresRace()
        {
            bool validResponse = false;
            Ogre.RaceType ogresRace = Ogre.RaceType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Ogre's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                ConsoleUtil.DisplayMessage("Races");
                StringBuilder sb = new StringBuilder();
                foreach (Character.RaceType raceType in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (raceType != Character.RaceType.None)
                    {
                        sb.Append($" [{raceType}] ");
                    }

                }
                ConsoleUtil.DisplayMessage(sb.ToString());

                ConsoleUtil.DisplayPromptMessage("Enter Your Ogre's Race: ");

                //
                // validate user response for race
                //
                if (Enum.TryParse<Character.RaceType>(Console.ReadLine(), out ogresRace))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {ogresRace} as your race type.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage("You must limit your race to the list above.");
                    ConsoleUtil.DisplayMessage("Please reenter your race.");
                }

                DisplayContinuePrompt();
            }

            return ogresRace;
        }
        ///Get Ogres Age
        ///
        public int DisplayGetOgresAge()
        {
            bool validResponse = false;
            int ogresAge = 0;

            while (!validResponse)
            {


                // display header
                ConsoleUtil.HeaderText = "Ogre's Age";
                ConsoleUtil.DisplayReset();

                ConsoleUtil.DisplayPromptMessage("Please Enter Your Ogre's Age: ");
                if (int.TryParse(Console.ReadLine(), out ogresAge))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"Your Ogre's name is now :  {ogresAge} .");
                }

                else
                {
                    ConsoleUtil.DisplayPromptMessage("Please enter a valid age.");
                }


                DisplayContinuePrompt();
            }

            return ogresAge;
        }

        /// <summary>
        /// get and validate the player's TARDIS destination
        /// </summary>
        /// <returns>space-time location</returns>
        public SwampLocation DisplayGetOgresNewDestination()
        {
            bool validResponse = false;
            int swampID;
            SwampLocation nextSwampLocation = new SwampLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Swamp Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplaySwampDestinationsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Choose your swamp location by using its ID: ");

                //
                // user's response is an integer
                //
                if (int.TryParse(Console.ReadLine(), out swampID))
                {
                    ConsoleUtil.DisplayMessage("");

 

                    try
                    {
                        nextSwampLocation = _gameKingdom.GetSwampLocationByID(swampID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextSwampLocation.Name} as your destination.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextSwampLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("Your journey continues.");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears this destination is not available to you at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid location ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");
                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the location ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextSwampLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplaySwampDestinationsTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location name and id
            //
            foreach (SwampLocation location in _gameKingdom.SwampLocations)
            {
                ConsoleUtil.DisplayMessage(location.SwampLocationID.ToString().PadRight(10) + location.Name.PadRight(20));
                locationNumber++;
            }

        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public OgreAction DisplayGetOgreActionChoice()
        {
            OgreAction ogreActionChoice = OgreAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Ogre Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("What would you like to do (Type Letter).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Ogre Actions" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "A. Look Around" + Environment.NewLine +
                    "\t" + "B. Talk To" + Environment.NewLine +
                    "\t" + "C. Look At" + Environment.NewLine +
                    "\t" + "D. Pick Up Item" + Environment.NewLine +
                    "\t" + "E. Pick Up Treasure" + Environment.NewLine +
                    "\t" + "F. Put Down Item" + Environment.NewLine +
                    "\t" + "G. Put Down Treasure" + Environment.NewLine +
                    "\t" + "H. Travel" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Traveler Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "I. Display General Ogre Info" + Environment.NewLine +
                    "\t" + "J. Display Ogre Inventory" + Environment.NewLine +
                    "\t" + "K. Display Ogre Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Game Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "L. Display All Swamp Destinations" + Environment.NewLine +
                    "\t" + "M. Display All Game Items" + Environment.NewLine +
                    "\t" + "N. Display All Game Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Q. Quit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'A':
                    case 'a':
                        ogreActionChoice = OgreAction.LookAround;
                        usingMenu = false;
                        break;
                    case 'B':
                    case 'b':
                        ogreActionChoice = OgreAction.TalkTo;
                        usingMenu = false;
                        break;
                    case 'C':
                    case 'c':
                        ogreActionChoice = OgreAction.LookAt;
                        usingMenu = false;
                        break;
                    case 'D':
                    case 'd':
                        ogreActionChoice = OgreAction.PickUpItem;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        ogreActionChoice = OgreAction.PickUpTreasure;
                        usingMenu = false;
                        break;
                    case 'F':
                    case 'f':
                        ogreActionChoice = OgreAction.PutDownItem;
                        usingMenu = false;
                        break;
                    case 'G':
                    case 'g':
                        ogreActionChoice = OgreAction.PutDownTreasure;
                        usingMenu = false;
                        break;
                    case 'H':
                    case 'h':
                        ogreActionChoice = OgreAction.Travel;
                        usingMenu = false;
                        break;
                    case 'I':
                    case 'i':
                        ogreActionChoice = OgreAction.OgreInfo;
                        usingMenu = false;
                        break;
                    case 'J':
                    case 'j':
                        ogreActionChoice = OgreAction.OgreInventory;
                        usingMenu = false;
                        break;
                    case 'K':
                    case 'k':
                        ogreActionChoice = OgreAction.OgreTreasure;
                        usingMenu = false;
                        break;
                    case 'L':
                    case 'l':
                        ogreActionChoice = OgreAction.ListSwampDestinations;
                        usingMenu = false;
                        break;
                    case 'M':
                    case 'm':
                        ogreActionChoice = OgreAction.ListItems;
                        usingMenu = false;
                        break;
                    case 'N':
                    case 'n':
                        ogreActionChoice = OgreAction.ListTreasures;
                        usingMenu = false;
                        break;
                    case 'Q':
                    case 'q':
                        ogreActionChoice = OgreAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return ogreActionChoice;
        }

        /// <summary>
        /// display information about the current swamp location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Swamp Location Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(_gameKingdom.GetSwampLocationByID(_gameOgre.SwampLocationID).Description);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current location.");
            foreach (Item item in _gameKingdom.GetItemsBySwampLocationID(_gameOgre.SwampLocationID))
            {
                ConsoleUtil.DisplayMessage(item.Name + " - " + item.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current location.");
            foreach (Treasure treasure in _gameKingdom.GetTreasuresBySwampLocationID(_gameOgre.SwampLocationID))
            {
                ConsoleUtil.DisplayMessage(treasure.Name + " - " + treasure.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Dragons in current location.");
            foreach (Dragon dragon in _gameKingdom.GetDragonsBySwampLocationID(_gameOgre.SwampLocationID))
            {
                ConsoleUtil.DisplayMessage(dragon.Name + " - " + dragon.Description);
                ConsoleUtil.DisplayMessage(dragon.Name + " - " + "Health = " + dragon.Health);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all Swamp destinations
        /// <summary>
        public void DisplayListAllSwampDestinations()
        {
            ConsoleUtil.HeaderText = "Swamp Locations";
            ConsoleUtil.DisplayReset();

            foreach (SwampLocation location in _gameKingdom.SwampLocations)
            {
                ConsoleUtil.DisplayMessage("ID: " + location.SwampLocationID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                ConsoleUtil.DisplayMessage("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessable);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game items
        /// <summary>
        public void DisplayListAllGameItems()
        {
            ConsoleUtil.HeaderText = "Game Items";
            ConsoleUtil.DisplayReset();

            foreach (Item item in _gameKingdom.Items)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);

                //
                // all treasure in the traveler's inventory have a SpaceTimeLocationID of 0
                //
                if (item.SwampLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameKingdom.GetSwampLocationByID(item.SwampLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Ogre's Inventory");
                }


                ConsoleUtil.DisplayMessage("Value: " + item.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + item.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game treasures
        /// <summary>
        public void DisplayListAllGameTreasures()
        {
            ConsoleUtil.HeaderText = "Game Treasures";
            ConsoleUtil.DisplayReset();

            foreach (Treasure treasure in _gameKingdom.Treasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);

                //
                // all treasure in the Ogre's inventory have a SwampLocationID of 0
                //
                if (treasure.SwampLocationID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameKingdom.GetSwampLocationByID(treasure.SwampLocationID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Ogre's Inventory");
                }

                ConsoleUtil.DisplayMessage("Value: " + treasure.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + treasure.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current ogre information
        /// </summary>
        public void DisplayOgreInfo()
        {
            ConsoleUtil.HeaderText = "Ogre Info";
            ConsoleUtil.DisplayReset();
            
            ConsoleUtil.DisplayMessage($"Ogre's Name: {_gameOgre.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Ogre's Race: {_gameOgre.Race}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Ogre's Age: {_gameOgre.Age}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Ogre's Health: {_gameOgre.Health}");
            ConsoleUtil.DisplayMessage("");
            string swampLocationName = _gameKingdom.GetSwampLocationByID(_gameOgre.SwampLocationID).Name;
            ConsoleUtil.DisplayMessage($"Ogre's Current Location: {swampLocationName}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current ogre's inventory
        /// </summary>
        public void DisplayOgreItems()
        {
            ConsoleUtil.HeaderText = "Ogre's Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Ogre's Items");
            ConsoleUtil.DisplayMessage("");

            foreach (Item item in _gameOgre.OgresItems)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                ConsoleUtil.DisplayMessage("Description: " + item.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current ogre's treasure
        /// </summary>
        public void DisplayOgreTreasure()
        {
            ConsoleUtil.HeaderText = "Ogre's Treasure";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Ogre's Treasure");
            ConsoleUtil.DisplayMessage("");

            foreach (Treasure treasure in _gameOgre.OgresTreasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                ConsoleUtil.DisplayMessage("Description: " + treasure.Description);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        public void DisplayLookAt()
        {
            int locationID = _gameOgre.SwampLocationID;
            List<Item> itemsInSwamp = new List<Item>();
            List<Treasure> treasureInSwamp = new List<Treasure>();
            Item itemToSee = new Item();
            Treasure treasureToSee = new Treasure();

            itemsInSwamp = _gameKingdom.GetItemsBySwampLocationID(locationID);
            treasureInSwamp = _gameKingdom.GetTreasuresBySwampLocationID(locationID);

            ConsoleUtil.HeaderText = "Items in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage(_gameKingdom.GetSwampLocationByID(locationID).Name);
            ConsoleUtil.DisplayMessage("");

            if (itemsInSwamp != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Items in Current location.");
                foreach (Item item in _gameKingdom.Items)
                {
                    if (item.SwampLocationID == locationID)
                    {
                        Console.WriteLine(item.GameObjectID + " - " + item.Name);
                        Console.WriteLine();
                    }
                }
                ConsoleUtil.DisplayPromptMessage("Enter item number or press Enter to move on to Treasures.");
                Console.WriteLine();
                int itemIDChoice;

                if (int.TryParse(Console.ReadLine(), out itemIDChoice))
                {
                    itemToSee = _gameKingdom.GetItemtByID(itemIDChoice);
                    ConsoleUtil.DisplayMessage(itemToSee.Description);

                    DisplayContinuePrompt();
                }
            }

            if (treasureInSwamp != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Treasures in Current location.");
                foreach (Treasure treasure in _gameKingdom.Treasures)
                {
                    if (treasure.SwampLocationID == locationID)
                    {
                        Console.WriteLine(treasure.GameObjectID + " - " + treasure.Name);
                        Console.WriteLine();
                    }
                }
                ConsoleUtil.DisplayPromptMessage("Enter treasure number or press Enter to move on.");
                Console.WriteLine();
                int treasureIDChoice;

                if (int.TryParse(Console.ReadLine(), out treasureIDChoice))
                {
                    treasureToSee = _gameKingdom.GetTreasuretByID(treasureIDChoice);
                    ConsoleUtil.DisplayMessage(treasureToSee.Description);

                    DisplayContinuePrompt();
                }
            }

        }

        public void DisplayTalkTo()
        {
            int locationID = _gameOgre.SwampLocationID;
            List<Dragon> dragonsInSwamp = new List<Dragon>();
            Dragon dragonToTalkTo = new Dragon();

            dragonsInSwamp = _gameKingdom.GetDragonsBySwampLocationID(locationID);

            ConsoleUtil.HeaderText = "Talk To";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage(_gameKingdom.GetSwampLocationByID(locationID).Name);
            ConsoleUtil.DisplayMessage("");

            if (dragonsInSwamp != null)
            {
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayMessage("Dragons in Current location.");
                foreach (Dragon dragon in _gameKingdom.Dragons)
                {
                    if (dragon.SwampLocationID == locationID)
                    {
                        Console.WriteLine(dragon.CharacterID + " - " + dragon.Name);
                        Console.WriteLine();
                    }
                }
                ConsoleUtil.DisplayPromptMessage("Select a number to speak with a dragon.");
                Console.WriteLine();
                int dragonIDChoice;

                if (int.TryParse(Console.ReadLine(), out dragonIDChoice))
                {
                    dragonToTalkTo = _gameKingdom.GetDragonByID(dragonIDChoice);
                    ConsoleUtil.DisplayMessage(dragonToTalkTo.Message);
                }

                DisplayContinuePrompt();
            }
        }
        
        public int DisplayPickUpItem()
        {
            ConsoleUtil.HeaderText = "Pick Up Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current location");
            ConsoleUtil.DisplayMessage("");

            int itemID = 0;
            bool validResponse = false;

            int locationID;
            locationID = _gameOgre.SwampLocationID;
            while (!validResponse)
            {
                foreach (Item item in _gameKingdom.Items)
                {
                    if (item.SwampLocationID == locationID)
                    {
                        Console.WriteLine(item.GameObjectID);
                        Console.WriteLine(item.Name);
                        Console.WriteLine();
                    }
                }

                ConsoleUtil.DisplayPromptMessage("Enter Item Number:");

                if (int.TryParse(Console.ReadLine(), out itemID))
                {

                        if (itemID > 0 && itemID <= 6 )
                        {
                            validResponse = true;
                        }

                        else
                        {
                            Console.WriteLine("Please select an option from the list");
                        }
                }
                else
                {
                    Console.WriteLine("Please select an option from the list");
                }
            }
            DisplayContinuePrompt();

            return itemID;
        }
        public int DisplayPickUpTreasure()
        {
            ConsoleUtil.HeaderText = "Pick Up Treasure";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current location");
            ConsoleUtil.DisplayMessage("");

            int treasureID = 0;
            bool validResponse = false;

            int locationID;
            locationID = _gameOgre.SwampLocationID;

            while (!validResponse)
            {
                foreach (Treasure treasure in _gameKingdom.Treasures)
                {
                    if (treasure.SwampLocationID == locationID)
                    {
                        Console.WriteLine(treasure.GameObjectID);
                        Console.WriteLine(treasure.Name);
                        Console.WriteLine();
                    }
                }

                ConsoleUtil.DisplayPromptMessage("Enter Treasure Number:");
                if (int.TryParse(Console.ReadLine(), out treasureID))
                {
                    if (treasureID > 0 && treasureID <= 4)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select an option from the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please select an option from the list");
                }

            }
            DisplayContinuePrompt();

            return treasureID;
        }

        public int DisplayPutDownTreasure()
        {
            ConsoleUtil.HeaderText = "Put Down Treasure";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasures in current inventory");
            ConsoleUtil.DisplayMessage("");

            int treasureToPutDown = _gameOgre.SwampLocationID;
            bool validResponse = false;

            int locationID;
            locationID = _gameOgre.SwampLocationID;
            while (!validResponse)
            {
                foreach (Treasure treasure in _gameOgre.OgresTreasures)
                {
                    Console.WriteLine(treasure.GameObjectID);
                    Console.WriteLine(treasure.Name);
                    Console.WriteLine();
                }

                ConsoleUtil.DisplayPromptMessage("Enter Treasure Number To Put Down:");
                if (int.TryParse(Console.ReadLine(), out treasureToPutDown))
                {
                    if (treasureToPutDown > 0 && treasureToPutDown <= 4)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select an option from the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please select an option from the list");
                }

            }
            DisplayContinuePrompt();

            return treasureToPutDown;
        }

        public int DisplayPutDownItem()
        {
            ConsoleUtil.HeaderText = "Put Down Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in current inventory");
            ConsoleUtil.DisplayMessage("");

            int itemToPutDown = _gameOgre.SwampLocationID;
            bool validResponse = false;

            int locationID;
            locationID = _gameOgre.SwampLocationID;
            while (!validResponse)
            {
                foreach (Item item in _gameOgre.OgresItems)
                {
                    Console.WriteLine(item.GameObjectID);
                    Console.WriteLine(item.Name);
                    Console.WriteLine();
                }

                ConsoleUtil.DisplayPromptMessage("Enter Item Number To Put Down:");
                if (int.TryParse(Console.ReadLine(), out itemToPutDown))
                {
                    if (itemToPutDown > 0 && itemToPutDown <= 6)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select an option from the list");
                    }
                }
                else
                {
                    Console.WriteLine("Please select an option from the list");
                }

            }
            DisplayContinuePrompt();

            return itemToPutDown;
        }
        #endregion
    }
}
