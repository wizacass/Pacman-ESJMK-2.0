using Genetic;
using System;
using System.Threading;

namespace Pacman_DeepMind
{
    using Extensions;

    public enum DIRECTION
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        STOP
    }

    class Game
    {
        Level level;
        Pacman pacman;
        Ghost ghost;
        SimpleAI ai;
        PathFinding path;

        public int _score { get; private set; }
        public int _turnCounter { get; private set; }
        private int _idleCounter = 0;
        private int _idleMax = 99;
        private int _maxScore;
        private int _aiCounter = 0;
        private static int _generation = 0;
        private bool _isIdle = false;
        private bool _isChasing = true;
        private string _exitStatus;

        public Game(PacManGameParameters pgp)
        {
            Console.Title = "Pacman AI Project";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;

            //GameStart();
            //GameLoop(pgp);
            //GameEnd();
        }

        public void GameStart()
        {
            level   = new Level("level1");
            pacman  = new Pacman(level.pX, level.pY);
            ghost   = new Ghost(level.gX, level.gY);
            ai      = new SimpleAI(level);
            path    = new PathFinding(level);

            _score = 0;
            _turnCounter = 0;

            _maxScore = level.GetScore();

            _generation++;
        }

        public void GameLoop(PacManGameParameters pgp)
        {
            var isWorking = true;

            int? pacManPrevX = null;
            int? pacManPrevY = null;

            while(isWorking)
            {
                Console.Clear();
                Console.WriteLine("\tPacman Deep Mind");
                Console.WriteLine("   Score: " + _score + "\tMax: " + _maxScore);
                Console.WriteLine("Curent turn: " + _turnCounter + " \tIdle for: " + _idleCounter + " turns");
                Console.WriteLine("Generation: " + _generation);

                //SetPacManData(pacman.getX(), pacman.getY());
                //SetGhostData(ghost.getX(), ghost.getY());
                //level.Draw();

                PacManEnvironment pe = new PacManEnvironment(level._board, pacman.getX(), pacman.getY(), pacManPrevX, pacManPrevY);       
                Directions? directions = pgp.GetMoveDirection(pe);

                pacManPrevX = pacman.getX();
                pacManPrevY = pacman.getY();

                //pacman.Input();
                //ghost.Input();

                pacman.SetDir(Converter.DirectionToDIRECTION(directions));
                pacman.SetDir(level.Check(pacman.getX(), pacman.getY(), pacman.GetDir()));
                pacman.Movement();

                //ghost.SetDir(path.FindDir(pacman.getX(), pacman.getY(), ghost.getX(), ghost.getY(), pacman.GetDir()));

                if (_isChasing)
                {
                    ghost.SetDir(path.A_Star(ghost.getX(), ghost.getY(), pacman.getX(), pacman.getY(), ghost.GetDir()));
                    _aiCounter++;
                    if (_aiCounter > 20)
                    {
                        _isChasing = false;
                        _aiCounter = 0;
                    }
                        
                }
                else
                {
                    ghost.SetDir(path.A_Star(ghost.getX(), ghost.getY(), 16, 27, ghost.GetDir()));
                    _aiCounter++;
                    if (_aiCounter > 10)
                    {
                        _isChasing = true;
                        _aiCounter = 0;
                    }
                }
                
                ghost.SetDir(level.Check(ghost.getX(), ghost.getY(), ghost.GetDir()));
                ghost.Movement();

                SetPacManData(pacman.getX(), pacman.getY());
                SetGhostData(ghost.getX(), ghost.getY());

                pacman.Update();
                ghost.Update();
                

                /*
                isWorking = ai.MoveNext();
                Tuple<int, int> coords = ai.Current;
                SetData(coords.Item1, coords.Item2);
                */
                if (_isIdle == true)
                    _idleCounter++;
                else
                    _idleCounter = 0;

                _turnCounter++;

                level.Draw();
                Thread.Sleep(100);

                if(_score == _maxScore)
                {
                    _exitStatus = "Victory!";
                    isWorking = false;
                }

                if(pacman.getX() == ghost.getX() && pacman.getY() == ghost.getY())
                {
                    _exitStatus = "Eaten";
                    isWorking = false;
                }

                if (_idleCounter > _idleMax)
                {
                    _exitStatus = "Lost";
                    isWorking = false;
                }
            }
        }

        private void SetPacManData(int pX, int pY)
        {
            _score = level.CheckScore(pX, pY, _score, out _isIdle);

            level.SetPac(pX, pY);
        }

        private void SetGhostData(int gX, int gY)
        {
            level.SetGhost(gX, gY, ghost.GetDir());
        }

        public void GameEnd()
        {
            Logger.logData(_generation, _turnCounter, _idleCounter, _score, _exitStatus);

            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
