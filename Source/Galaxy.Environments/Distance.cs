using System;
using System.Collections.Generic;
using Galaxy.Core.Actors;
namespace Galaxy.Environments
{
    internal static class Distance
    {
        public static BaseActor NearestEnemyСomparison(List<BaseActor> lis1, BaseActor actor)
        {
            int distance = Int32.MaxValue;
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
            BaseActor toRemove = lis1[number];
            return toRemove;
        }
    }
}
