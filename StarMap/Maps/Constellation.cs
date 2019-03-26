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
					if(!string.IsNullOrWhiteSpace(line))
					{
						string[] starpoints = line.Split(',');
						Endpoint point = new Endpoint(starpoints[0], starpoints[1]);
						list.Add(point);
					}
		    }
		    else
		    {
		        break;
		    }
		}

		return new Constellation(list);
	}

	/* ARGS: none
	*  RETURN: the number of lines in the constellation
	*/
	public int getNumberOfLines()
	{
		return _lines.Count;
	}
	/* ARGS: a valid index of a line in the constellation
	*  RETURN: the ith endpoint of a constellation
	*/
	public Endpoint getEndpointAt(int index)
	{
		return _lines[index];
	}

	/* INPUT: none
	*   OUTPUT: The member names of the constellation, if they exist	
	*/
	public List<string> NamesInConstellation()
	{
		List<string> names = new List<string>();

		foreach(Endpoint point in _lines)
		{
			names.Add(point.getStart());
		}

		return names;
	}

	/* ARGS: none
	*  RETURN: the coordinates of every member of the constellation
	*/
	public List<StarCoords> CoordsInConstellation()
	{
		List<StarCoords> coords = new List<StarCoords>();
		StarMapReader smr = new StarMapReader();
		List<Star> list = smr.fileToList(@"../../../../StarMap/Maps/stars.txt");

		foreach(Endpoint point in _lines)
		{
			coords.Add(Star.getCoordsByName(point.getStart(), list));
		}

		return coords;
	}

	/* ARGS: a valid index
	*  RETURN: the endpoint at given index
	*/
	public string getStringEndpointAt(int index)
	{
		return _lines[index].getEndpoint();
	}

	/* ARGS: a list of constellations
	*  RETURN: number of constellations in list
	*/
	public static int getNumberOfConstellations(List<Constellation> list)
	{
		return list.Count;
	}



}