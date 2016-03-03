
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using System.Drawing;


namespace Galaxy.Environments.Actors
{
  
    public class EnemyBullet : BaseActor
     {
            #region Constant
            private static int speed = 10;
            #endregion
  
 
            #region Constructors

            public EnemyBullet(ILevelInfo info) : base(info)
             {
                 Width = 6;
                 Height = 12;
                ActorType = ActorType.Enemy;
             }
            private int si;

            public int Svo
            {
                get { return si; }
                set { si = value; }
            }

           #endregion
            public override bool IsAlive
            {
                get
                {
                    return base.IsAlive;
                }
                set
                {
                    base.IsAlive = value;
                    CanDrop = value;
                }
            }
            private void bulletERRemove()
            {
                var LevelSize = Info.GetLevelSize();
                if (Position.Y > LevelSize.Height || Position.Y < 0)
                {
                    IsAlive = false;
                    CanDrop = true;
                }

            }
 
        #region Overrides
 
        public override void Load()
        {
            Load(@"Assets\bullet.png");
        }

        public override void Update()
        {
            Position = new Point(Position.X, Position.Y + speed);
            bulletERRemove();
        }

        #endregion
 }
} 


