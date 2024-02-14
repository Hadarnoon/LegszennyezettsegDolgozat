using CA20240212;
using System;

var napok = new List<Nap>();
using var sr = new StreamReader(@"..\..\..\src\SO2.txt");
try
{
	while (!sr.EndOfStream)
	{
		napok.Add(new Nap(sr.ReadLine()));
	}
}
catch 
{
    Console.WriteLine("Hiba a fájl beolvasása során!");
}

foreach (var nap in napok) Console.WriteLine(nap);

Console.WriteLine("\n3.feladat:");
Karoslevego(napok);
Console.WriteLine("kiírva");

Console.WriteLine("\n4.feladat:");
LegmagasabbSO2(napok);

Console.WriteLine("\n5.feladat:");
Tisztalevego(napok);

Console.WriteLine("\n6.feladat:");
Atlag(napok);

Console.WriteLine("\n7.feladat");
Nemment60fole(napok);

Console.WriteLine("\n8.feladat");
Marcius1Legmagasabb(napok);

Console.WriteLine("\n9.feladat:");
Marcius12Atlag(napok);

Console.WriteLine("\n10.feladat:");
Melyikfeletobb(napok);

Console.WriteLine("\n11.feladat:");
OtNapJoLevego(napok);

static void Karoslevego(List<Nap> napok)
{
	using var sw = new StreamWriter(@"..\..\..\src\kiiras.txt");
	var lista = new List<string>();
	for (int i = 0; i < napok.Count; i++)
	{
		for (int j = 0; j < napok[i].orak.Count; j++)
		{
			if (napok[i].orak[j] > 250)
			{
				sw.WriteLine(($"március {i + 1}."));
				//lista.Add($"március {i}.");
				break;
			}
		}
	}
}

static void LegmagasabbSO2(List<Nap> napok){
	int max = 0;
	int ora = 0;
	int nap = 0;
	for (int i = 0; i < napok.Count; i++)
	{
		for (int j = 0; j < napok[i].orak.Count; j++)
		{
			if (napok[i].orak[j] > max)
			{
				max = napok[i].orak[j];
				ora = j + 1;
				nap = i + 1;
            }
		}
	}
    Console.WriteLine($"A legnagyobb érték március {nap}-én, {ora}kor volt");
}

static void Tisztalevego(List<Nap> napok)
{
	var tisztalevego = napok.SelectMany(e => e.orak).Count(e => e < 100);
    Console.WriteLine($"{tisztalevego} nap volt mikor 100 alatt volt a SO2");
}

static void Atlag(List<Nap> napok)
{
	var atlag = napok.SelectMany(e => e.orak).Average(e => e);
    Console.WriteLine($"Az átlagos SO2 ennyi volt: {atlag}");
}

static void Nemment60fole(List<Nap> napok)
{
	var hatvanalatt = new List<int>();
	
	for (int i = 0; i < napok.Count; i++)
	{
        var atnezes = new List<int>();
        for (int j = 0; j < napok[i].orak.Count; j++)
		{
			if (napok[i].orak[j] < 61)
			{
                atnezes.Add(napok[i].orak[j]);
            }

		}
		if (atnezes.Count == 24)
		{
			hatvanalatt.Add(i + 1);
		}
	}
	if (hatvanalatt.Any())
	{
        Console.WriteLine($"Az első olyan nap amikor nem ment 60 fölé: március {hatvanalatt.First()}.");
    }
	else
	{
        Console.WriteLine("Nem volt olyan nap ahol 60 alatt lett volna végig");
    }
    
}

static void Marcius1Legmagasabb(List<Nap> napok)
{
	var max = 0;
	var ora = 0;
	for (int i = 0; i < napok[0].orak.Count; i++)
	{
		if (napok[0].orak[i] > max)
		{
			max = napok[0].orak[i];
			ora = i + 1;
		}
	}
    Console.WriteLine($"A legnagyobb értéket {ora}-kor mérték és ennyi volt: {max}");
}

static void Marcius12Atlag(List<Nap> napok)
{
	var marcius12szamok = new List<int>();
	for (int i = 0; i < napok.Count; i++)
	{
		marcius12szamok.Add(napok[i].orak[11]);
	}
	var marcius12atlag = marcius12szamok.Average();
    Console.WriteLine($"Márciusban 12 órai mérések átlaga: {marcius12atlag}");
}

static void Melyikfeletobb(List<Nap> napok)
{
	var elsofele = 0;
	var masodikfele = 0;
	for (int i = 0; i < napok.Count; i++)
	{
		for (int j = 0; j < napok[i].orak.Count; j++)
		{
			if (i <= 14)
			{
				elsofele += napok[i].orak[j];
			}
			else
			{
				masodikfele += napok[i].orak[j];

            }
		}
	}
	if (elsofele > masodikfele)
	{
        Console.WriteLine("A hónap első felében magasabb volt az SO2 koncentráció");
    }
	else if (elsofele < masodikfele)
	{
        Console.WriteLine("A hónap második felében magasabb volt az SO2 koncentráció");
    }
	else
	{
        Console.WriteLine("Valamilyen anomáliának hála egyenlő volt a SO2 koncentráció a hónap két felében");
    }
}

static void OtNapJoLevego(List<Nap> napok)
{
	var szelesnapok = new List<int>();
	for (int i = 0; i < napok.Count; i++)
	{
		var atlag = new List<int>();
		for (int j = 0; j < napok[i].orak.Count; j++)
		{
			atlag.Add(napok[i].orak[j]);
		}
		if (atlag.Average() < 150)
		{
			szelesnapok.Add(i + 1);
		}
	}
    Console.WriteLine($"A következő napok voltak szelesek: Március{string.Join(" Március", szelesnapok)}");
}