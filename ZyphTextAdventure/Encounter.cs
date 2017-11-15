using System;
using System.Collections.Generic;

public class Encounter
{

    public String name;
    public String text;
    public List<EncounterOption> options;

    public Encounter()
	{
        options = new List<EncounterOption>();
	}
}
