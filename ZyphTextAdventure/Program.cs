using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZyphTextAdventure
{
    class Program
    {
        static public Encounter currentEncounter;

        static void Main(string[] args)
        {
            RunGame();
            //TestXML();
        }

        static public void TestXML()
        {
            XMLHandler readXML = new XMLHandler();
            readXML.loadEncounter("TestEncounter");
        }

        static public void RunGame()
        {
            XMLHandler readXML = new XMLHandler();
            currentEncounter = readXML.loadEncounter("TestEncounter");
            /*
            currentEncounter = new Encounter();
            currentEncounter.text = "You wake up out of bed, Booyah!\n";
            Encounter eggs = new Encounter();
            eggs.text = "You Decide to Eat Eggs\n";
            Encounter cereal = new Encounter();
            cereal.text = "You Decide to Eat Cereal\n";
            EncounterOption chooseEggs = new EncounterOption();
            chooseEggs.text = "Eat Eggs";
            chooseEggs.nextEncounter = "eggs";
            EncounterOption chooseCereal = new EncounterOption();
            chooseCereal.text = "Eat Cereal";
            chooseCereal.nextEncounter = "cereal";
            currentEncounter.options.Add(chooseEggs);
            currentEncounter.options.Add(chooseCereal);
            */
            int optionNumber;
            int playersOption;

            while (currentEncounter != null)
            {
                do
                {
                    Console.Write(currentEncounter.text + "\n");
                    optionNumber = 0;
                    foreach (EncounterOption EO in currentEncounter.options)
                    {
                        optionNumber++;
                        Console.Write(optionNumber + ") " + EO.text + "\n");
                    }
                    optionNumber = 0;
                }
                while (!Int32.TryParse(Console.ReadLine(), out playersOption) || playersOption <= 0 || playersOption > currentEncounter.options.Count);

                Console.Write("\n");


                if (currentEncounter.options != null && currentEncounter.options.Count > 0)
                {
                    //currentEncounter = currentEncounter.options[playersOption - 1].nextEncounter;
                    currentEncounter = readXML.loadEncounter(currentEncounter.options[playersOption - 1].nextEncounter);
                }
                else
                {
                    currentEncounter = null;
                }
                
            }
            
        }
    }
}
