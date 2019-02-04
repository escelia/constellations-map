using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class HelloWorld
{
	public static void Main()
	{
		//Console.WriteLine(obj.readFile());
		
		/*
		string liney = "0.933979 0.179802 -0.308796 4128 2.04 188 DIPHDA; DENEB KAITOS";
		string[] wordies = liney.Split(' ');
		List<string> listy = Words.getWords(wordies);
		string[] finalprops = Words.getProperties(wordies);
		
		foreach(string name in listy)
		{
			Console.WriteLine(name);
		}
		*/
		
		string path = @"/Users/eliaanagnostou/Documents/cs71/01-constellations/StarMap/Maps/Hydra.txt";
		string text = @"0.994772 0.023164 -0.099456 28 4.61 3
0.972490 0.024187 0.231685 87 5.55 4
0.435119 0.012234 0.900290 144 5.57 7
0.998442 0.033711 -0.044468 315 6.43 11
0.998448 0.035746 -0.042707 352 6.18 14
0.873265 0.031968 0.486196 358 2.07 15 ALPHERATZ
0.512379 0.020508 0.858515 432 2.28 21 CAPH; CAS BETA
0.949168 0.037455 0.312534 448 5.57 22
0.882312 0.036017 -0.469285 493 5.42 24
0.697240 0.028641 -0.716265 496 3.88 25
0.980198 0.042952 0.193306 560 5.54 26
0.693047 0.031231 0.720216 571 5.01 27
0.135171 0.005924 -0.990805 636 5.29 30
0.962619 0.047354 -0.266689 693 4.89 33
0.883455 0.044652 -0.466383 720 5.41 34
0.816743 0.041844 -0.575482 739 5.24 35
0.963482 0.055705 0.261913 886 2.83 39 ALGENIB";
		List<StarMapReader> starList = StarMapReader.stringToList(text);

		//foreach(StarMapReader star in starList)
		//{
		//	Console.Write(star.getNames().Any());
		//}
		Console.WriteLine(StarMapReader.getCoordsByName("ALPHERATZ", starList).getX());

		//Console.WriteLine(StarMapReader.getStarAmount(starList));

		//Constellation con = Constellation.fileToList(path);
		//Console.WriteLine(con.getEndpointAt(3));
		
	}
}




