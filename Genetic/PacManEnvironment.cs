namespace Genetic
{
    public class PacManEnvironment
    {
        private char[,] _board;
        //private int _pacManPositionY;

        public char[,] Board { get { return _board; } }
        public int PacManPositionX { get; private set; }
        public int PacManPositionY { get; private set; }
        public int? PacManPreviousPositionX { get; private set; }
        public int? PacManPreviousPositionY { get; private set; }
<<<<<<< HEAD
        public int GhostPositionX { get; private set; }
        public int GhostPositionY { get; private set; }
=======
		public int GhostPositionX { get; private set; }
		public int GhostPositionY { get; private set; }
>>>>>>> refs/remotes/origin/genes

		public PacManEnvironment(
            char[,] board,
            int pacManPositionX,
            int pacManPositionY,
            int? pacManPreviousPositionX,
            int? pacManPreviousPositionY,
<<<<<<< HEAD
            int ghostPositionX,
            int ghostPositionY)
=======
			int ghostPositionX,
			int ghostPositionY
			)
>>>>>>> refs/remotes/origin/genes
        {
            _board = board;
            PacManPositionX = pacManPositionX;
            PacManPositionY = pacManPositionY;
            PacManPreviousPositionX = pacManPreviousPositionX;
            PacManPreviousPositionY = pacManPreviousPositionY;
<<<<<<< HEAD
            GhostPositionX = ghostPositionX;
            GhostPositionY = ghostPositionY;
=======
			GhostPositionX = ghostPositionX;
			GhostPositionY = ghostPositionY;
>>>>>>> refs/remotes/origin/genes
        }
    }
}
