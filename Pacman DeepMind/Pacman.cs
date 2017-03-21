﻿using System;

namespace Pacman_DeepMind
{
    class Pacman
    {
        private int _x, _y, _xx, _yy;
        public DIRECTION _dir;

        public Pacman(int x, int y)
        {
            _x = x;
            _y = y;
            _xx = 0;
            _yy = 0;
            _dir = DIRECTION.STOP;
        }

        public void Input()
        {
            if(Console.KeyAvailable)
            {
                char c = Console.ReadKey().KeyChar;

                switch (c)
                {
                    case 'w':
                        _dir = DIRECTION.UP;
                        break;
                    case 'a':
                        _dir = DIRECTION.LEFT;
                        break;
                    case 's':
                        _dir = DIRECTION.DOWN;
                        break;
                    case 'd':
                        _dir = DIRECTION.RIGHT;
                        break;
                    case 'x':
                        _dir = DIRECTION.STOP;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Movement()
        {
            switch (_dir)
            {
                case DIRECTION.STOP:
                    _xx = 0;
                    _yy = 0;
                    break;
                case DIRECTION.UP:
                    _xx = -1;
                    _yy = 0;
                    break;
                case DIRECTION.DOWN:
                    _xx = 1;
                    _yy = 0;
                    break;
                case DIRECTION.RIGHT:
                    _xx = 0;
                    _yy = 1;
                    break;
                case DIRECTION.LEFT:
                    _xx = 0;
                    _yy = -1;
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            _x += _xx;
            _y += _yy;
        }

        public void SetDir(DIRECTION dir)
        {
            _dir = dir;
        }

        public DIRECTION GetDir()
        {
            return _dir;
        }

        public int getX()
        {
            return _x;
        }

        public int getY()
        {
            return _y;
        }
    }
}