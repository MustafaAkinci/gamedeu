using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeuGame
{
	class DeuGame
	{
		public static void Main()
		{
			char[] A1 = new char[15];
			char[] A2 = new char[15];
			char[] A3 = new char[15];
			int player1 = 120;
			int player2 = 120;
			char[] charsDeu = new char[] { 'D', 'E', 'U' };
			char insertedLetter;
			int chosenArrayNum;
			int addingIndex = 0;
			int countA1 = 0;
			int countA2 = 0;
			int countA3 = 0;
			bool anyWinner = false;
			string winner = "";
			int winPoint = 0;

			List<string> names = new List<string> { "Derya", "Elife", "Fatih", "Ali", "Azra", "Sibel", "Cem", "Nazan", "Mehmet", "Nil", "Can", "Tarkan" };
			List<int> scores = new List<int> { 100, 100, 95, 90, 85, 80, 80, 70, 55, 50, 30, 30 };

			Random r = new Random();

			for (int i = 0; i < 45; i++)
			{

				// Randomly chosen letter is assigned to insertedLetter variable to insert the lists.
				insertedLetter = charsDeu[r.Next(0, 3)];
				// This can take 0-1-2, it will be used to assign A1-A2-A3 lists for char placement. Some conditions are added to prevent boundary exceptions.
				chosenArrayNum = r.Next(0, 3);
				if (A1[14] == 'D' || A1[14] == 'E' || A1[14] == 'U')
				{
					chosenArrayNum = r.Next(1, 3);
				}
				else if (A2[14] == 'D' || A2[14] == 'E' || A2[14] == 'U')
				{
					int[] zeroTwo = new int[] { 0, 2 };
					chosenArrayNum = zeroTwo[r.Next(zeroTwo.Length)];
				}
				else if (A3[14] == 'D' || A3[14] == 'E' || A3[14] == 'U')
				{
					chosenArrayNum = r.Next(0, 2);
				}

				// Insert the char into related array
				if (chosenArrayNum == 0)
				{
					A1[countA1] = insertedLetter;
					addingIndex = countA1;
					countA1++;
				}
				else if (chosenArrayNum == 1)
				{
					A2[countA2] = insertedLetter;
					addingIndex = countA2;
					countA2++;
				}
				else if (chosenArrayNum == 2)
				{
					A3[countA3] = insertedLetter;
					addingIndex = countA3;
					countA3++;
				}

				// Player points decrement after each round
				if (i % 2 == 0)
				{
					player1 -= 5;
				}
				else
				{
					player2 -= 5;
				}

				// Win Conditions
				if (insertedLetter == 'D' || insertedLetter == 'U')
				{
					if (chosenArrayNum == 0 && countA1 < 3)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
											(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 0 && countA1 >= 3 && countA1 <= 13)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D') ||

										(A1[addingIndex] == 'D' && A1[addingIndex + 1] == 'E' && A1[addingIndex + 2] == 'U') ||
										(A1[addingIndex] == 'U' && A1[addingIndex + 1] == 'E' && A1[addingIndex + 2] == 'D') ||

										(A1[addingIndex] == 'D' && A1[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'U') ||
										(A1[addingIndex] == 'U' && A1[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'D') ||

										(A1[addingIndex] == 'D' && A2[addingIndex + 1] == 'E' && A3[addingIndex + 2] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex + 1] == 'E' && A3[addingIndex + 2] == 'D') ||

										(A1[addingIndex] == 'D' && A2[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 0 && countA1 > 13)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D') ||
										(A1[addingIndex] == 'D' && A1[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'U') ||
										(A1[addingIndex] == 'U' && A1[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'D') ||
										(A1[addingIndex] == 'D' && A2[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 1 && countA2 < 3)
					{
						anyWinner = false;
					}
					else if (chosenArrayNum == 1 && countA2 >= 3 && countA2 <= 13)
					{
						if ((A2[addingIndex] == 'D' && A2[addingIndex + 1] == 'E' && A2[addingIndex + 2] == 'U') ||
										(A2[addingIndex] == 'U' && A2[addingIndex + 1] == 'E' && A2[addingIndex + 2] == 'D') ||
										(A2[addingIndex] == 'D' && A2[addingIndex - 1] == 'E' && A2[addingIndex - 2] == 'U') ||
										(A2[addingIndex] == 'U' && A2[addingIndex - 1] == 'E' && A2[addingIndex - 2] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 1 && countA2 > 13)
					{
						if ((A2[addingIndex] == 'D' && A2[addingIndex - 1] == 'E' && A2[addingIndex - 2] == 'U') ||
										(A2[addingIndex] == 'U' && A2[addingIndex - 1] == 'E' && A2[addingIndex - 2] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 2 && countA3 < 3)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 2 && countA3 >= 3 && countA3 <= 13)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D') ||

										(A3[addingIndex] == 'D' && A3[addingIndex + 1] == 'E' && A3[addingIndex + 2] == 'U') ||
										(A3[addingIndex] == 'U' && A3[addingIndex + 1] == 'E' && A3[addingIndex + 2] == 'D') ||

										(A3[addingIndex] == 'D' && A3[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'U') ||
										(A3[addingIndex] == 'U' && A3[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'D') ||

										(A1[addingIndex + 2] == 'D' && A2[addingIndex + 1] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex + 2] == 'U' && A2[addingIndex + 1] == 'E' && A3[addingIndex] == 'D') ||

										(A1[addingIndex - 2] == 'D' && A2[addingIndex - 1] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex - 2] == 'U' && A2[addingIndex - 1] == 'E' && A3[addingIndex] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 2 && countA3 > 13)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D') ||
										(A3[addingIndex] == 'D' && A3[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'U') ||
										(A3[addingIndex] == 'U' && A3[addingIndex - 1] == 'E' && A3[addingIndex - 2] == 'D') ||
										(A3[addingIndex] == 'D' && A2[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'U') ||
										(A3[addingIndex] == 'U' && A2[addingIndex - 1] == 'E' && A1[addingIndex - 2] == 'D'))
						{
							anyWinner = true;
						}
					}
				} // Condition D or U end bracket
				else if (insertedLetter == 'E')
				{
					if (chosenArrayNum == 0 && countA1 < 15 && countA1 > 1)
					{
						if ((A1[addingIndex - 1] == 'D' && A1[addingIndex] == 'E' && A1[addingIndex + 1] == 'U') ||
										(A1[addingIndex - 1] == 'U' && A1[addingIndex] == 'E' && A1[addingIndex + 1] == 'D'))
						{
							anyWinner = true;
						}
					}

					else if (chosenArrayNum == 1 && countA2 < 2)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 1 && countA2 >= 2 && countA1 <= 14)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D') ||

										(A2[addingIndex - 1] == 'D' && A2[addingIndex] == 'E' && A2[addingIndex + 1] == 'U') ||
										(A2[addingIndex - 1] == 'U' && A2[addingIndex] == 'E' && A2[addingIndex + 1] == 'D') ||

										(A1[addingIndex - 1] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex + 1] == 'U') ||
										(A1[addingIndex - 1] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex + 1] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 1 && countA2 > 14)
					{
						if ((A1[addingIndex] == 'D' && A2[addingIndex] == 'E' && A3[addingIndex] == 'U') ||
										(A1[addingIndex] == 'U' && A2[addingIndex] == 'E' && A3[addingIndex] == 'D'))
						{
							anyWinner = true;
						}
					}
					else if (chosenArrayNum == 2 && countA3 < 15 && countA3 > 1)
					{
						if ((A3[addingIndex - 1] == 'D' && A3[addingIndex] == 'E' && A3[addingIndex + 1] == 'U') ||
										(A3[addingIndex - 1] == 'U' && A3[addingIndex] == 'E' && A3[addingIndex + 1] == 'D'))
						{
							anyWinner = true;
						}
					}
				}

				// Printing Each Round
				if (i % 2 == 0)
				{
					Console.WriteLine("\nPlayer1:\t(P1-" + player1 + " P2-" + player2 + ")");
				}
				else
				{
					Console.WriteLine("\nPlayer2:\t(P1-" + player1 + " P2-" + player2 + ")");
				}
				Console.Write("A1 ");
				foreach (var v in A1)
				{
					Console.Write(v + " ");
				}
				Console.Write("\nA2 ");
				foreach (var v in A2)
				{
					Console.Write(v + " ");
				}
				Console.Write("\nA3 ");
				foreach (var v in A3)
				{
					Console.Write(v + " ");
				}
				Console.WriteLine("\n");

				// Detect which player win the game
				if (anyWinner == true)
				{
					if (i % 2 == 0)
					{
						winner = "Player1";
						winPoint = player1;
						Console.WriteLine("\nWinner: Player1");
					}
					else
					{
						winner = "Player2";
						winPoint = player2;
						Console.WriteLine("\nWinner: Player2");
					}
					i = 45;
				}
			} // End bracket for for loop

			// Tie condition
			if (anyWinner == false)
			{
				Console.WriteLine("Tie");
			}

			// Ranking
			for (int j = scores.Count() - 1; j > 0; j--)
			{
				if (winPoint == scores[j])
				{
					scores.Insert(j + 1, winPoint);
					names.Insert(j + 1, winner);
					j = -1;
				}
				else if (winPoint < scores[j])
				{
					scores.Insert(j + 1, winPoint);
					names.Insert(j + 1, winner);
					j = -1;
				}
				else if (winPoint > scores[0])
				{
					scores.Insert(0, winPoint);
					names.Insert(0, winner);
					j = -1;
				}
				else if (winPoint == scores[0])
				{
					scores.Insert(2, winPoint);
					names.Insert(2, winner);
					j = -1;
				}
			}
			// Print the ranked list
			Console.WriteLine("\nName\t\tScore");
			for (int k = 0; k < names.Count(); k++)
			{
				Console.WriteLine(names[k] + "\t\t" + scores[k]);
			}
			Console.ReadLine();
		}
	}
}
