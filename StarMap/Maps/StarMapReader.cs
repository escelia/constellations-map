/* Name: Elia Anagnostou
*  File: StarMapReader.cs
*
*  Desc: Star: A class that defines stars.
* 		 Words: A helper class that processes/parses input files
*		 StarCoords: A class that stores the (x,y,z) coordinates of a Star
*		 StarMapReader: An API that lets the user edit a list of Star and a list of Constellation
*
*/


using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

class Star
{
	// x, y, z coordinates of star
	float _x;
	float _y;
	float _z;

	// Henry Draper number
	float _henDrap;

	// magnitude of star
	float _mag;

	// Harvard Revised ID
	float _harRevId;

	// names (if any) of each star
	List<string> _names;

	public Star(float x, float y, float z, float henDrap, float mag, float harRevId, List<string> names)
	{
		_x = x;
		_y = y;
		_z = z;
		_henDrap = henDrap;
		_mag = mag;
		_harRevId = harRevId;
		_names = names;
	}

	public float getX()
	{
		return _x;
	}

	public float getY()
	{
		return _y;
	}

	public float getZ()
	{
		return _z;
	}

	public float getHenDrap()
	{
		return _henDrap;
	}

	public float getMag()
	{
		return _mag;
	}

	public float getHarRevId()
	{
		return _harRevId;
	}

	public List<string> getNames()
	{
		return _names;
	}

	// returns the number of stars in a list
	public static int getStarAmount(List<Star> list)
	{
		return list.Count;
	}

	// INPUT: name of a star and list of stars
	// OUTPUT: the coordinates of the star that has the desired name within the list. Returns
	// (0, 0, 0) if coordinate was not found
	public static StarCoords getCoordsByName(string name, List<Star> list)
	{
		StarCoords coords = new StarCoords(0, 0, 0);

		foreach(Star star in list)
		{
			foreach(string stName in star.getNames())
			{
				if(string.Equals(name, stName))
				{
					coords = new StarCoords(star.getX(), star.getY(), star.getZ());
				}
			}
		}

		return coords;
	}
}


// A class that stores star coordinates (helper function for getCoordsByName)
class StarCoords
{
	float _x;
	float _y;
	float _z;

	public StarCoords(float x, float y, float z)
	{
		_x = x;
		_y = y;
		_z = z;
	}

	public float getX()
	{
		return _x;
	}

	public float getY()
	{
		return _y;
	}

	public float getZ()
	{
		return _z;
	}
}

// helper functions
class Words
{
	// helper function that stores the first 6 (numeric) properties of each star
	// INPUT: an array of strings that contains 6 words in a line separated by commas
	// OUTPUT: an array of strings that contains the first 6 words separated by commas (that contain numeric properties)
	public static float[] getProperties(string[] words, string line)
	{
		float[] new_arr = new float[6];
		
		try{
			for(int i = 0; i < 6; i++)
			{
				new_arr[i] = Convert.ToSingle(words[i]);
			}
		}
		catch{
			Console.WriteLine("Failed to read line " + line);
		}
		

		return new_arr;
	}

	// helper function that stores the names of stars contained in each line
	// INPUT: an array of strings that contains all the words in a line separated by commas
	// OUTPUT: an array of strings that contains the name/s of each star
	public static List<string> getWords(string[] words)
	{
		List<string> listEv = new List<string>();

		int index = 6;
		string line = "";
		while(index < words.Length)
		{
			line = line + " " + words[index];
			index++;
		}

		string[] names = line.Split(';');

		if(names.Length == 1 && names[0] == "")
		{
			return new List<string>(); //return null list if no names were found
		}

		foreach(string name in names)
		{
			string trimmedName = "";

			//cuts the unnecessary space in front of each name that remained after Split
			if(name.Length > 0 && string.Equals(name.Substring(0,1)," "))
			{
				trimmedName = name.Substring(1);
			}
			else
			{
				trimmedName = name;
			}

			listEv.Add(trimmedName);
		}

		return listEv;

	}

}

class StarMapReader
{
	// list that stores stars
	List<Star> starList = new List<Star>();
	
	// list that stores constellations
	List<Constellation> constList = new List<Constellation>();

	public StarMapReader()
	{

	}

	/* ARGS: none
	   RETURNS: number of stars stored in StarMapReader
	 */
	public int NumberOfStars()
	{
		return starList.Count;
	}

	/* ARGS: none
	   RETURNS: number of constellations stored in StarMapReader
	*/
	public int NumberOfConstellations()
	{
		return constList.Count;
	}

	/* Loads new star into StarMapReader
	   ARGS: x coordinate of Star
	   		 y coordinate of Star
			 z coordinate of Star
			 Henry Draper number of Star
			 magnitude of Star
			 Harvard Revised ID of Star
			 list of names associated with Star
	 */
	public void LoadStar(float x, float y, float z, float henDrap, float mag, float harRevId, List<string> names)
	{
		starList.Add(new Star(x, y, z, henDrap, mag, harRevId, names));
	}

	/* Loads new constellation into StarMapReader
	   ARGS: a list of endpoints that constitutes the constellation
	*/
	public void LoadConstellation(List<Endpoint> lines)
	{
		constList.Add(new Constellation(lines));
	}

	// Removes all stars from StarMapReader
	public void RemoveAllStars()
	{
		starList.Clear();
	}

	// Removes all constellations from StarMapReader
	public void RemoveAllConstellations()
	{
		constList.Clear();
	}

	/* removes star with specified id from StarMapReader
	   ARGS: valid id of a star
	 */
	public void RemoveStarAtId(float id)
	{
		bool found = false;

		foreach (Star star in starList)
		{
			if(star.getHarRevId() == id)
			{
				starList.RemoveAt(starList.IndexOf(star));
				found = true;
			}
		}

		if(!found)
		{
			Console.WriteLine("No star with matching ID found.");
		}
	}
	/* ARGS: valid id of a star
	   RETURNS: star with specified id, exception if not found
	 */
	public Star FindAtId(float id)
	{

		foreach (Star star in starList)
		{
			if(star.getHarRevId() == id)
			{
				return star;
			}
		}

		throw new Exception("Star not found");

	}
	/* ARGS: none
	   RETURNS: the coordinates of every star in StarMapReader
	 */
	public List<StarCoords> DisplayCoords()
	{
		List<StarCoords> l = new List<StarCoords>();

		foreach (Star star in starList)
		{
			l.Add(new StarCoords(star.getX(), star.getY(), star.getZ()));
		}

		return l;
	}

	/* ARGS: the contents of a txt file as a string
	         --every line of the string must contain at least six valid star properties--
	   RETURNS: the contents of the file (stars and their properties) in a list
	*/
	public List<Star> stringToList(string text)
	{
		StringReader strReader = new StringReader(text);
		while(true)
		{
    		string line = strReader.ReadLine();
		    if(line != null)
		    {
				if(!string.IsNullOrWhiteSpace(line))
				{
					string[] old_words = line.Split(' ');
					float[] new_words = Words.getProperties(old_words, line);
					List<string> names = Words.getWords(old_words);
					if(new_words[5] != 0)
					{
						starList.Add(new Star(Convert.ToSingle(new_words[0]), Convert.ToSingle(new_words[1]), Convert.ToSingle(new_words[2]), Convert.ToSingle(new_words[3]), Convert.ToSingle(new_words[4]), Convert.ToSingle(new_words[5]), names));
					}
				}
			}
		    else
		    {
		        break;
		    }
		}

		return starList;
	}

	/*  INPUT: file path of the file that contains the star info
	           every line of the file must contain at least six valid star properties
	    OUTPUT: the contents of the file (stars and their properties) in a list
	*/
	public List<Star> fileToList(string filePath)
	{
		if(!File.Exists(filePath))
		{
			Console.WriteLine("File not found");
		}

		foreach(string line in File.ReadLines(filePath))
		{
			if(!string.IsNullOrWhiteSpace(line))
			{
				string[] old_words = line.Split(' ');
				float[] new_words = Words.getProperties(old_words, line);
				List<string> names = Words.getWords(old_words);
				if(new_words[5] != 0)
				{
					starList.Add(new Star(Convert.ToSingle(new_words[0]), Convert.ToSingle(new_words[1]), Convert.ToSingle(new_words[2]), Convert.ToSingle(new_words[3]), Convert.ToSingle(new_words[4]), Convert.ToSingle(new_words[5]), names));
				}
			}
		}

		return starList;
	}
}
