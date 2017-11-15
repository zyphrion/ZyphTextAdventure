using System;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZyphTextAdventure
{
    class XMLHandler
    {
        //Sends string of encounter name, and takes string to find .xml file with that name and then set the encounter variables using file
        public Encounter loadEncounter(string encounterName)
        {
            XDocument doc = XDocument.Load("..\\..\\Resources\\" + encounterName + ".xml");

            Encounter myEncounter = new Encounter();

            
            myEncounter.name = doc.Element("Encounter").Element("Name").Value;
            myEncounter.text = doc.Element("Encounter").Element("Text").Value;
            EncounterOption encounterOption;
            foreach (XElement element in doc.Element("Encounter").Element("Options").Elements())
            {
                //Console.WriteLine(element.Element("Text").Value);
                encounterOption = new EncounterOption();
                encounterOption.text = element.Element("Text").Value;
                encounterOption.nextEncounter = element.Element("NextEncounter").Value;
                myEncounter.options.Add(encounterOption);
            }
            //Console.WriteLine(myEncounter.options[0].text);
            //Console.ReadLine();
                


            return myEncounter;
        }
    }
}
