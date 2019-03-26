/* Name: Elia Anagnostou
*  File: Endpoint.cs
*
*  Desc: A class that defines endpoints used for constellations.
*
*/


using System;

class Endpoint
{
	string _start;
	string _end;

	public Endpoint(string start, string end)
	{
		_start = start;
		_end = end;
	}

	public string getEndpoint()
	{
		return _start + ", " + _end;
	}

	public string getStart()
	{
		return _start;
	}

	public string getEnd()
	{
		return _end;
	}
}