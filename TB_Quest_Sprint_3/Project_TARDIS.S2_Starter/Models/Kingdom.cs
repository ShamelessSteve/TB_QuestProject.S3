using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the Universe class manages all of the game elements
    /// </summary>
    public class Kingdom
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all space-time locations
        //
        public List<SwampLocation> SwampLocations { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

        //Dragons

        public List<Dragon> Dragons { get; set; }

        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Kingdom()
        {
            //
            // instantiate the lists of swamp locations and game objects
            //
            this.SwampLocations = new List<SwampLocation>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();
            this.Dragons = new List<Dragon>();

            //
            // add all of the swamp locations and game objects to their lists
            // 
            IntializeKingdomSwampLocations();
            IntializeKingdomItems();
            IntializeKingdomTreasures();
            IntializeKingdomDragons();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a SpaceTimeLocation object
        /// </summary>
        /// <returns>next SpaceTimeLocationObjectID </returns>
        private int GetNextSwampLocationID()
        {
            int MaxID = 0;

            foreach (SwampLocation SwampLocation in SwampLocations)
            {
                if (SwampLocation.SwampLocationID > MaxID)
                {
                    MaxID = SwampLocation.SwampLocationID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a SwampLocation object using an ID
        /// </summary>
        /// <param name="ID">swamp location ID</param>
        /// <returns>requested swamp location</returns>
        public SwampLocation GetSwampLocationByID(int ID)
        {
            SwampLocation swamp = null;

            //
            // run through the space-time location list and grab the correct one
            //
            foreach (SwampLocation location in SwampLocations)
            {
                if (location.SwampLocationID == ID)
                {
                    swamp = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (swamp == null)
            {
                string feedbackMessage = $"The Swamp Location ID {ID} does not exist in the current Kingdom.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return swamp;
        }

        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemtByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the Kingdom
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Kingdom.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasuretByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the kingdom
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Kingdom.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }

        // Get Dragon using an ID
        public Dragon GetDragonByID(int ID)
        {
            Dragon requestedDragon = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Dragon dragon in Dragons)
            {
                if (dragon.CharacterID == ID)
                {
                    requestedDragon = dragon;
                };
            }

            //
            // the specified ID was not found in the kingdom
            // throw and exception
            //
            if (requestedDragon == null)
            {
                string feedbackMessage = $"The dragon ID {ID} does not exist in the current Kingdom.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedDragon;
        }


        #endregion

        #region ***** define methods to get lists of game elements by location *****


        /// get a list of items using a swamp location ID
        /// </summary>
        /// <param name="ID">swamp location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemsBySwampLocationID(int ID)
        {
            // TODO validate SwampLocationID

            List<Item> itemsInSwampLocation = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.SwampLocationID == ID)
                {
                    itemsInSwampLocation.Add(item);
                }
            }

            return itemsInSwampLocation;
        }

        /// get a list of treasures using a swamp location ID
        /// </summary>
        /// <param name="ID">swamp location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuresBySwampLocationID(int ID)
        {
            // TODO validate SwampLocationID

            List<Treasure> treasuresInSwampLocation = new List<Treasure>();

            //
            // run through the treasure list and put all treasures in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.SwampLocationID == ID)
                {
                    treasuresInSwampLocation.Add(treasure);
                }
            }

            return treasuresInSwampLocation;
        }



        /// get a list of dragons using a swamp location ID
        /// </summary>
        /// <param name="ID">swamp location ID</param>
        /// <returns>list of dragons in the specified location</returns>
        public List<Dragon> GetDragonsBySwampLocationID(int ID)
        {
            // TODO validate SwampLocationID

            List<Dragon> dragonsInSwampLocation = new List<Dragon>();

            //
            // run through the dragon list and put all dragons in the current location
            // into a list
            //
            foreach (Dragon dragon in Dragons)
            {
                if (dragon.SwampLocationID == ID)
                {
                    dragonsInSwampLocation.Add(dragon);
                }
            }

            return dragonsInSwampLocation;
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the kingdom with all of the swamp locations
        /// </summary>
        private void IntializeKingdomSwampLocations()
        {
            SwampLocations.Add(new SwampLocation
            {
                Name = "Forest Swamp Home",
                SwampLocationID = 1,
                Description = "A damp swamp hidden deep in the forest, cloaked in the dark shadows of the trees, " +
                              "a secluded home for any Ogre wishing to get away from the chaos" +
                              "and frustrations of the civilized world",
                Accessable = true
            });

            SwampLocations.Add(new SwampLocation
            {
                Name = "Kingdom Road Swamp",
                SwampLocationID = 2,
                Description = "A swamp bordering the busy borderlands leading to the Kingdoms Capital." +
                              "A swampland bustling with life just outside the veiw of the world" +
                              "where an Ogre can have easy access to the pleasures of pillaging travelers.",
                Accessable = true
            });

            SwampLocations.Add(new SwampLocation
            {
                Name = "Southern Coast Swamp",
                SwampLocationID = 3,
                Description = "A swamp in the hot and wet southlands.  Dense in lush foliage and large reptiles. " +
                  "Near coastal towns filled with sailors going to and fro with treasures galore.",
                Accessable = true
            });

            SwampLocations.Add(new SwampLocation
            {
                Name = "The Desolate Waste",
                SwampLocationID = 4,
                Description = "A Vast Expanse of dried and rotting decay. " +
                 "Home of despairing wanderers and cruel creatures",
                Accessable = true
            });

            SwampLocations.Add(new SwampLocation
            {
                Name = "The Dragons Castle",
                SwampLocationID = 5,
                Description = "A Terrifying Castle wrapped in flame. ",
                
                Accessable = true
            });
        }

        /// <summary>
        /// initialize the kingdom with all of the items
        /// </summary>
        private void IntializeKingdomItems()
        {
            Items.Add(new Item
            {
                Name = "Wooden Club",
                GameObjectID = 1,
                Description = "A large wooden club. Useful for bashing things.",
                SwampLocationID = 0,
                HasValue = false,
                Value = 0,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Mirror",
                GameObjectID = 2,
                Description = "A full sized mirror, good for bashing people with.",
                SwampLocationID = 2,
                HasValue = true,
                Value = 150,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Hunk of Meat",
                GameObjectID = 3,
                Description = "A Hunk of Meat enjoyed by all hungry Ogres.",
                SwampLocationID = 0,
                HasValue = true,
                Value = 15,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Aspirin",
                GameObjectID = 4,
                Description = "For days when you are the one getting bashed.",
                SwampLocationID = 0,
                HasValue = true,
                Value = 10,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Large Snake",
                GameObjectID = 5,
                Description = "Your beloved pet. Loves to hug your enemies.",
                SwampLocationID = 1,
                HasValue = true,
                Value = 20,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Wolf Skull",
                GameObjectID = 6,
                Description = "Good for keeping the rain off your head.",
                SwampLocationID = 4,
                HasValue = true,
                Value = 10,
                CanAddToInventory = true
            });
        }

        /// <summary>
        /// initialize the kindom with all of the treasures
        /// </summary>
        private void IntializeKingdomTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Golden Bear Cloak",
                TreasureType = Treasure.Type.Armor,
                GameObjectID = 1,
                Description = "A tough cloak to keep you safe and warm",
                SwampLocationID = 2,
                HasValue = true,
                Value = 5000,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Silver War Axe",
                TreasureType = Treasure.Type.Weapon,
                GameObjectID = 2,
                Description = "A large silver axe, capable of splitting a horse in two in one swing.",
                SwampLocationID = 3,
                HasValue = true,
                Value = 5000,
                CanAddToInventory = true
            });

            Treasures.Add(new Treasure
            {
                Name = "Golden Marble",
                TreasureType = Treasure.Type.Weapon,
                GameObjectID = 3,
                Description = "A Marble of purest gold. Also hits with a solid thunk when thrown.",
                SwampLocationID = 3,
                HasValue = true,
                Value = 50,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Iron Helmet",
                TreasureType = Treasure.Type.Armor,
                GameObjectID = 4,
                Description = "Sturdy Helmet to protect your thick noggin.",
                SwampLocationID = 1,
                HasValue = true,
                Value = 5000,
                CanAddToInventory = true
            });
        }

        private void IntializeKingdomDragons()
        {
            Dragons.Add(new Dragon
            {
                Name = "Silvara",
                Race = Dragon.RaceType.Dragon,
                CharacterID = 1,
                Description = "A very large yet beautiful Dragon of glimmery silver color. ",
                SwampLocationID = 1,
                HasMessage = true,
                Message = "You must defeat the evil dragon Bardul in the Fiery Castle." +
                "Gather your axe, cloak, and helmet before you face him." +
                "Return here whenever you are injured and I will heal you.",
                Health = 100000000,
            });

            Dragons.Add(new Dragon
            {
                Name = "Bardul",
                Race = Dragon.RaceType.Dragon ,
                CharacterID = 2,
                Description = "An incredibly ferocious red dragon surrounded by flames. ",
                SwampLocationID = 5,
                HasMessage = true,
                Message = "Do You Challenge ME!?" +
                "The Dragon Charges In a Rage.",
                Health = 500,
                IsAlive = true,
            });
        }
        #endregion

    }
}

