using System;

namespace ERC102
{
		class Program
		{
			static string decy = "d";
			static string bin = "b";
			static string endinstruction = "wyjscie";
			static int nieprawidlowa = -1;

			static void Main(string[] args)
			{
				bool endvalue = true;
				do
				{
					wyswietl("Aby przejsc do konwersji na system binarny wciśnij b," +
						" aby przejść do konwersji na system dziesiętny wciśnij d,\n aby wyjść napisz wyjscie");

					string inst = wczytajtekst("Podaj instrukcję:").ToLower();
					if (inst.Equals(endinstruction))
					{
						endvalue = false;
					}
					else
					{
						if (inst.Equals(decy))
						{
							string liczba = wczytajtekst("Podaj liczbę");
							string opis;
							int wynik = ondecy(liczba, 2, out opis);
							wyswietl(opis);
						}
						else if (inst.Equals(bin))
						{

							string opis;
							int liczba = inputnumber("Podaj liczbę do zamiany ");
							string wynik = decynabin(liczba, 2, out opis);
							wyswietl(opis);
						}
						else
						{
							werror("Nieznana instrukcja");
						}
						koniec("Koniec programu, nacisnij dowolny przycisk");
					}

				} while (endvalue);
			}
			static void koniec(string komunikat)
			{
				menuinfo(komunikat);
				Console.ReadKey();
				Console.Clear();
			}
			static void menuinfo(string tekst)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(tekst);
			}
			static void wyswietl(string tekst)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(tekst);
			}
			static void werror(string tekst)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(tekst);
			}
			static string wczytajtekst(string komunikat)
			{
				menuinfo(komunikat);
				Console.ForegroundColor = ConsoleColor.White;
				return Console.ReadLine();
			}
			static int inputnumber(string komunikat, string error = "Nieprawidłowa wartość")
			{
				int wynik = 0;
				menuinfo(komunikat);
				Console.ForegroundColor = ConsoleColor.White;
				while (!int.TryParse(Console.ReadLine(), out wynik))
				{
					werror(error);
					Console.ForegroundColor = ConsoleColor.White;
				}
				return wynik;
			}
			static int obliczwartosc(char cyfra)
			{
				if (cyfra >= '0' && cyfra <= '9')
				{
					return int.Parse(cyfra.ToString());
				}
				return nieprawidlowa;
			}
			static bool poprawnosc(string liczba, int podstawa)
			{
				for (int i = 0; i < liczba.Length; i++)
				{
					char aktualnyznak = liczba[i];
					int wartosc = obliczwartosc(aktualnyznak);
					if (wartosc == nieprawidlowa || wartosc >= podstawa)
					{
						return false;
					}
				}
				return true;
			}
			static char obliczCyfre(int wartosc)
			{
				if (wartosc >= 0)
				{
					if (wartosc <= 9)
					{

						return char.Parse(wartosc.ToString());
					}
				}
				return char.Parse(nieprawidlowa.ToString());
			}
			static int ondecy(string liczba, int podstawa, out string opis)
			{
				bool poprawna = poprawnosc(liczba, podstawa);
				if (!poprawna)
				{
					opis = " Nieprawidłowa liczba:" + liczba + " dla systemu: " + podstawa;
					return nieprawidlowa;

				}
				int wynik = 0;
				int a = 1;
				for (int i = liczba.Length - 1; i >= 0; i--)
				{
					char aktualna = liczba[i];
					int wartosc = obliczwartosc(aktualna);
					int wymnozone = wartosc * a;
					wynik += wymnozone;
					a *= podstawa;
				}
				opis = "Wynik operacji to " + wynik;
				return wynik;
			}
			static string decynabin(int liczba, int podstawa, out string opis)
			{
				bool poprawna = liczba >= 0;
				if (!poprawna)
				{
					opis = " Nieprawidłowa liczba:" + liczba + " dla systemu: " + podstawa;
					return nieprawidlowa.ToString();
				}
				System.Text.StringBuilder reszty = new System.Text.StringBuilder();
				int liczbadopodzielenia = liczba;
				while (liczbadopodzielenia != 0)
				{
					int reszta = liczbadopodzielenia % podstawa;
					char resztacyfrowo = obliczCyfre(reszta);
					int wynik = liczbadopodzielenia / podstawa;
					liczbadopodzielenia = wynik;
					reszty.Append(resztacyfrowo);
				}
				string resztystring = reszty.ToString();
				char[] resztyoddolu = new char[resztystring.Length];
				for (int i = 0; i < resztystring.Length; i++)
				{

					resztyoddolu[i] = resztystring[resztystring.Length - 1 - i];
				}
				string ostatecznie = new string(resztyoddolu);
				opis = "Wynik to " + ostatecznie;
				return ostatecznie;
			}
		}
	}
