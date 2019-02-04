/* Name: Elia Anagnostou
*  File: Constellation.cs
*
*  Desc: A class that defines constellations.
*
*/



using System;
using System.IO;
using System.Collections.Generic;

class Constellation
{
	// A collection of pairs of endpoints (contained in each line of the txt files)
	// constitutes a constellation
	List<Endpoint> _lines;

	public Constellation(List<Endpoint> lines)
	{
		_lines = lines;
	}

	// INPUT: the file path of a file that contains the constellation info
	// OUTPUT: a constellation
	public static Constellation fileToList(string filePath)
	{
		if(!File.Exists(filePath))
		{
			Console.WriteLine("File not found");
		}

		List<Endpoint> list = new List<Endpoint>();

		foreach(string line in File.ReadLines(filePath))
		{
			string[] starpoints = line.Split(',');
			// stores the star names of each line in an Endpoint
			Endpoint point = new Endpoint(starpoints[0], starpoints[1]);
			list.Add(point);
		}

		return new Constellation(list);
	}

	// INPUT: a string text that contains the constellation info
	// OUTPUT: a constellation
	public static Constellation stringToList(string text)
	{
		List<Endpoint> list = new List<Endpoint>();

		StringReader strReader = new StringReader(text);
		while(true)
		{
    		string line = strReader.ReadLine();
		    if(line != null)
		    {
		    	string[] starpoints = line.Split(',');
				Endpoint point = new Endpoint(starpoints[0], starpoints[1]);
				list.Add(point);
		    }
		    else
		    {
		        break;
		    }
		}

		return new Constellation(list);
	}

	// returns the number of lines in a constellation
	public int getNumberOfLines()
	{
		return _lines.Count;
	}

	// returns the ith endpoint of a constellation
	public Endpoint getEndpointAt(int index)
	{
		return _lines[index];
	}

/*
	public string getStringEndpointAt(int index)
	{
		return _lines[index].getEndpoint();
	}

	public static int getNumberOfConstellations(List<Constellation> list)
	{
		return list.Count;
	}
	*/


}