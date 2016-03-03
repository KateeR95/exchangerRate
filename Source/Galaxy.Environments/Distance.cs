using System;
using System.Collections.Generic;
using Galaxy.Core.Actors;
namespace Galaxy.Environments
{
    internal static class Distance
    {
        public static int NearestEnemy(List<BaseActor> lis1, BaseActor actor)
        {
            int distance;
            int number = 0;

            if (lis1[0] != actor)
            {
                distance =
                    Convert.ToInt32(Math.Pow(lis1[0].Position.X - actor.Position.X, 2) +
                                    Math.Pow(lis1[0].Position.Y - actor.Position.Y, 2));

            }
            else
            {
                distance =
                    Convert.ToInt32(Math.Pow(lis1[1].Position.X - actor.Position.X, 2) +
                                    Math.Pow(lis1[1].Position.Y - actor.Position.Y, 2));
            }
            number = NearestEnemyСomparison(lis1, actor, distance);
            return number;
        }

        private static int NearestEnemyСomparison(List<BaseActor> lis1, BaseActor actor, int distance)
        {

            int distance2;

            int number = 0;
            for (int i = 0; i < lis1.Count; i++)
            {
                if (lis1[i] != actor)
                {
                    distance2 =
                        Convert.ToInt32(Math.Pow(lis1[i].Position.X - actor.Position.X, 2) +
                                        Math.Pow(lis1[i].Position.Y - actor.Position.Y, 2));

                    if (distance2 < distance)
                    {
                        number = i;
                        distance = distance2;
                    }
                }

            }
            return number;
        }
    }
}
