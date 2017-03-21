namespace Pacman_DeepMind.Extensions
{
    using System;
    using Genetic;

    public static class Converter
    {
        public static DIRECTION DirectionToDIRECTION(Directions? direction)
        {
            DIRECTION ret;

            if (direction == null)
            {
                ret = DIRECTION.STOP;
            }
            else if (direction == Directions.Up)
            {
                ret = DIRECTION.UP;
            }
            else if (direction == Directions.Down)
            {
                ret = DIRECTION.DOWN;
            }
            else if (direction == Directions.Left)
            {
                ret = DIRECTION.LEFT;
            }
            else if (direction == Directions.Right)
            {
                ret = DIRECTION.RIGHT;
            }
            else
            {
                throw new Exception("Unexpected Directions value.");
            }

            return ret;
        }
    }
}
