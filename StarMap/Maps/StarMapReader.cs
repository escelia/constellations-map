/* Name: Elia Anagnostou
*  File: StarMapReader.cs
*
*  Desc: A class that defines stars.
*
*/


using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class StarMapReader
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

	public StarMapReader(float x, float y, float z, float henDrap, float mag, float harRevId, List<string> names)
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
	public static int getStarAmount(List<StarMapReader> list)
	{
		return list.Count;
	}

	// INPUT: name of a star and list of stars
	// OUTPUT: the coordinates of the star that has the desired name within the list
	public static StarCoords getCoordsByName(string name, List<StarMapReader> list)
	{
		StarCoords coords = new StarCoords(0, 0, 0);

		foreach(StarMapReader star in list)
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

	
	// INPUT: file path of the file that contains the star info
	// OUTPUT: the contents of the file (stars and their properties) in a list
	public static List<StarMapReader> fileToList(string filePath)
	{
		if(!File.Exists(filePath))
		{
			Console.WriteLine("File not found");
		}

		List<StarMapReader> list = new List<StarMapReader>();

		foreach(string line in File.ReadLines(filePath))
		{
			string[] old_words = line.Split(' ');
			string[] new_words = Words.getProperties(old_words);
			List<string> names = Words.getWords(old_words);
			list.Add(new StarMapReader(Convert.ToSingle(new_words[0]), Convert.ToSingle(new_words[1]), Convert.ToSingle(new_words[2]), Convert.ToSingle(new_words[3]), Convert.ToSingle(new_words[4]), Convert.ToSingle(new_words[5]), names));
		}

		return list;
	}

	// INPUT: the contents of a txt file as a string
	// OUTPUT: the contents of the file (stars and their properties) in a list
	public static List<StarMapReader> stringToList(string text)
	{
		List<StarMapReader> list = new List<StarMapReader>();

		StringReader strReader = new StringReader(text);
		while(true)
		{
    		string line = strReader.ReadLine();
		    if(line != null)
		    {
		       	string[] old_words = line.Split(' ');
				string[] new_words = Words.getProperties(old_words);
				List<string> names = Words.getWords(old_words);
				list.Add(new StarMapReader(Convert.ToSingle(new_words[0]), Convert.ToSingle(new_words[1]), Convert.ToSingle(new_words[2]), Convert.ToSingle(new_words[3]), Convert.ToSingle(new_words[4]), Convert.ToSingle(new_words[5]), names));
		    }
		    else
		    {
		        break;
		    }
		}

		return list;
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
	// INPUT: an array of strings that contains all the words in a line separated by commas
	// OUTPUT: an array of strings that contains the first 6 words separated by commas (that contain numeric properties)
	public static string[] getProperties(string[] words)
	{
		string[] new_arr = new string[6];
		for(int i = 0; i < 6; i++)
		{
			new_arr[i] = words[i];
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

