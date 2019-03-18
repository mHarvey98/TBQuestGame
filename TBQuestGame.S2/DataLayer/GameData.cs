using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using WageSlave.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = 1,
                Name = "Mitch",
                Age = 21,
                Cash = 10000,
                CostOfLiving = 450,
                NetworkingPoints = 100,
                happiness = Character.Happiness.VeryHigh,
                Wage = 1000,
                TotalEarned = 50000,
                TotalSpent = 40000,
                WeeksPassed = 0,
                LocationId = 0
            };
        }

        //Methods
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You are a recent high school graduate, " +
                "and at 18 years old you must decide what direction your life will take. ", 
                "Your first task is to decide to go straight to work, go to a trade school, " +
                "or a 4-year University. In any of these three cases you will decide between two " +
                "careers.",
                "After that, the rest of your working life's financial decisions will be simulated." +
                "How you choose to spend and invest your money is critical, as the object of the game" +
                "is to retire as early as possible.",
                "Welcome to 'WageSlave'!"
            };
        }

        public static Location InitialGameMapLocation()
        {
            return new Location()
            {
                Id = 4,
                Name = "Newberry, MI",
                Description = "Description goes here.",
                Accessible = true,
                ModifyCash = 5
            };
        }

        public static Map GameMap()
        {
            Map gameMap = new Map();

            gameMap.Locations = new ObservableCollection<Location>()
            {
                new Location()
                {
                    Id = 4,
                    Name = "Newberry, MI",
                    Description = "Newberry Description here.",
                    Accessible = true,
                    ModifyCash = 5
                },

                new Location()
                {
                    Id = 3,
                    Name = "Grand Rapids, MI",
                    Description = "Grand Rapids Description here.",
                    Accessible = true,
                    ModifyCash = 10
                }
            };
            

            ////
            //// row 1
            ////
            //gameMap.MapLocations[0, 0] = new Location()
            //{
            //    Id = 4,
            //    Name = "Norlon Corporate Headquarters",
            //    Description = "The Norlon Corporation Headquarters is located in just outside of Detroit " +
            //    "Michigan.Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company with " +
            //    "huge holdings in defense and space research and development.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};
            //gameMap.MapLocations[0, 1] = new Location()
            //{
            //    Id = 1,
            //    Name = "Aion Base Lab",
            //    Description = "The Norlon Corporation research facility located in the city of Heraklion on " +
            //    "the north coast of Crete and the top secret research lab for the Aion Project.\nThe lab is a large, " + "" +
            //    "well lit room, and staffed by a small number of scientists, all wearing light blue uniforms with the hydra-like Norlan Corporation logo.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};

            ////
            //// row 2
            ////
            //gameMap.MapLocations[1, 1] = new Location()
            //{
            //    Id = 2,
            //    Name = "Felandrian Plains",
            //    Description = "The Felandrian Plains are a common destination for tourist. Located just north of the " +
            //    "equatorial line on the planet of Corlon, they provide excellent habitat for a rich ecosystem of flora and fauna.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};
            //gameMap.MapLocations[1, 2] = new Location()
            //{
            //    Id = 2,
            //    Name = "Epitoria's Reading Room",
            //    Description = "Queen Epitoria, the Torian Monarh of the 5th Dynasty, was know for her passion for " +
            //    "galactic history. The room has a tall vaulted ceiling, open in the middle  with four floors of wrapping " +
            //    "balconies filled with scrolls, texts, and infocrystals. As you enter the room a red fog desends from the ceiling " +
            //    "and you begin feeling your life energy slip away slowly until you are dead.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 50,
            //    ModifyLives = -1,
            //    RequiredExperiencePoints = 40
            //};

            ////
            //// row 3
            ////
            //gameMap.MapLocations[2, 0] = new Location()
            //{
            //    Id = 3,
            //    Name = "Xantoria Market",
            //    Description = "The Xantoria market, once controlled by the Thorian elite, is now an open market managed " +
            //    "by the Xantorian Commerce Coop. It is a place where many races from various systems trade goods." +
            //    "You purchase a blue potion in a thin, clear flask, drink it and receive 50 points of health.",
            //    Accessible = false,
            //    ModifiyExperiencePoints = 20,
            //    ModifyHealth = 50,
            //    Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
            //};
            //gameMap.MapLocations[2, 1] = new Location()
            //{
            //    Id = 4,
            //    Name = "The Tamfasia Galactic Academy",
            //    Description = "The Tamfasia Galactic Academy was founded in the early 4th galactic metachron. " +
            //    "You are currently in the library, standing next to the protoplasmic encabulator that stores all " +
            //    "recorded information of the galactic history.",
            //    Accessible = true,
            //    ModifiyExperiencePoints = 10
            //};

            return gameMap;
        }
    }
}
