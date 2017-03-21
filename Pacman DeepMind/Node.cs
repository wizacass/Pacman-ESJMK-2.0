namespace Pacman_DeepMind
{
	using System.Collections.Generic;

	class Node
	{
		public int x { get; set; }
		public int y { get; set; }
		/// <summary>distance from Start</summary>
		public double G { get; set; }
		/// <summary>distance from Finish</summary>
		public double H { get; set; }
		/// <summary>sum of G + H</summary>
		public double F { get { return G + H; } }
		/// <summary>Node number from Start</summary>
		public int d { get; set; }

		//public NodeState State { get; set; }
		public Node ParentNode { get; set; } //previous Node
		//public List<Node> Neighbours;

		public Node(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Node(){ }
	}

	//enum NodeState { Untested, Open, Closed }
}