namespace Pacman_DeepMind
{
	using System;
	using System.Collections.Generic;
	//using System.IO;

	class PathFinding
	{
		private Level _level;

		List<Node> Open;
		List<Node> Closed;
		List<Node> Neighbors;
		Node Current;
		Node temp = new Node();
		Stack<Node> Path = new Stack<Node>();

		/*
		private int _pX, _pY;
		private int _gX, _gY;

		public double distance;
		*/

		public PathFinding(Level level)
		{
			_level = level;
		}

		/*public void SetData(int pX, int pY, int gX, int gY)
		{
			_pX = pX;
			_pY = pY;
			_gX = gX;
			_gY = gY;
		}*/

		public double CalculateDistance(int x, int y, int x1, int y1)
		{
			double distance = Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
			return distance;
		}

		public DIRECTION FindDir(int x, int y, int x1, int y1, DIRECTION current)
		{
			DIRECTION dir = current;

			double currentDistance = CalculateDistance(x, y, x1, y1);

			if(currentDistance > CalculateDistance(x, y, x1 - 1, y1) && _level.isWalkable[x1 - 1, y1])
			{
				dir = DIRECTION.UP;
			}
			if (currentDistance > CalculateDistance(x, y, x1 + 1, y1) && _level.isWalkable[x1 + 1, y1])
			{
				dir = DIRECTION.DOWN;
			}
			if (currentDistance > CalculateDistance(x, y, x1, y1 - 1) && _level.isWalkable[x1, y1 - 1])
			{
				dir = DIRECTION.LEFT;
			}
			if (currentDistance > CalculateDistance(x, y, x1, y1 + 1) && _level.isWalkable[x1, y1 + 1])
			{
				dir = DIRECTION.RIGHT;
			}

			return dir;
		}

		/// <summary>
		/// Function that calculates best path from piont A to point B using A* algorithm
		/// <returns>
		/// returns a direction where to go
		/// </returns>
		/// </summary>
		public DIRECTION A_Star(int Start_x, int Start_y, int Finish_x, int Finish_y, DIRECTION current)
		{
			Open = new List<Node>();
			Closed = new List<Node>();
			Neighbors = new List<Node>();

			DIRECTION dir = current;
			Current = new Node();
			Node Start = new Node(Start_x, Start_y);    //Start Node
			Node Finish = new Node(Finish_x, Finish_y);		//Finish Node
			Start.d = 0;
			Open.Add(Start);

			while (true)
			{
				if(Open.Count > 0)
				{
					Current = Open[Cheapest(Open)];
					Open.Remove(Current);
					Closed.Add(Current);
				}

				if (Current.x == Finish.x && Current.y == Finish.y)
					break;

				Neighbors = GetNeighbors(Current, _level);

				foreach( Node n in Neighbors)
				{
					if (!(_level.isWalkable[n.x, n.y]) || (IsInList(n, Closed)) )
						continue;

					bool InListOpen = IsInList(n, Open);

					if (InListOpen)
					{
						n.d = Open[PlaceInList(n, Open)].d;
					}

					if (!(InListOpen) || (Current.d + 1 < n.d))
					{
						n.G = CalculateDistance(n.x, n.y, Start_x, Start_y);
						n.H = CalculateDistance(n.x, n.y, Finish_x, Finish_y);
						n.ParentNode = Current;
						n.d = Current.d + 1;

						if (!InListOpen)
							Open.Add(n);

					}
				}
			}

			temp = Current;
			//Path.Push(temp);

			while (temp.ParentNode != Start)
			{
				//Path.Push(temp.ParentNode);
				temp = temp.ParentNode;
			}

			//StreamWriter Out = new StreamWriter("Nodes.txt", true);

			//temp = Path.Pop();

			//Out.WriteLine("({0};{1}) ", temp.x, temp.y);

			if (Start.x < temp.x)
			{
				//Out.WriteLine("return DIRECTION.DOWN");
				dir = DIRECTION.DOWN;
			}
			if (Start.x > temp.x)
			{
				//Out.WriteLine("return DIRECTION.UP");
				dir = DIRECTION.UP;
			}
			if (Start.y < temp.y)
			{
				//Out.WriteLine("return DIRECTION.RIGHT");
				dir = DIRECTION.RIGHT;
			}
			if (Start.y > temp.y)
			{
				//Out.WriteLine("return DIRECTION.LEFT");
				dir = DIRECTION.LEFT;
			}
			//Out.Close();
			return dir;
		}

		static bool IsInList(Node n, List<Node> list)
		{
			foreach(Node l in list)
			{
				if (n.x == l.x && n.y == l.y)
					return true;
			}
			return false;
		}

		static int PlaceInList(Node n, List<Node> list)
		{
			int i = 0;
			foreach (Node l in list)
			{
				if (n.x == l.x && n.y == l.y)
					return i;
				i++;
			}
			return 0;
		}

		/// <summary>
		/// Used for getting Node with smallest F cost
		/// </summary>
		/// <param name="list"> List of Nodes(Open)</param>
		/// <returns>
		/// returns the indexs of Node in Node list
		/// </returns>
		static int Cheapest(List<Node> list)
		{
			int m = 0;
			if(list.Count > 0)
			{
				for (int i = 1; i < list.Count; i++)
					if (list[m].F > list[i].F)
						m = i;
			}
			return m;
		}

		static private List<Node> GetNeighbors(Node from, Level _level)
		{
			List<Node> Neighbors = new List<Node>();
			
			if (from.y > 0)		// ^
				Neighbors.Add(new Node(from.x, from.y - 1));

			if (from.x < _level.x)		// >
				Neighbors.Add(new Node(from.x + 1, from.y));

			if (from.x > 0)		// <
				Neighbors.Add(new Node(from.x - 1, from.y));

			if (from.y < _level.y)		// \/
				Neighbors.Add(new Node(from.x, from.y + 1));

			return Neighbors;
		}


	}
}
