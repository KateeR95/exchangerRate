using System.Drawing;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

namespace Galaxy.Environments.Actors
{
    class BulletBullet : BaseActor
    {
        #region Constant

        private static int speed = 5;

        #endregion

        #region Constructors

        public BulletBullet(ILevelInfo info)
            : base(info)
        {
            Width = 6;
            Height = 12;
            ActorType = ActorType.Enemy;
        }

        #endregion

        public override bool IsAlive
        {
            get { return base.IsAlive; }
            set
            {
                base.IsAlive = value;
                CanDrop = value;
            }
        }

        private void bulletERRemove()
        {
            if (Position.Y > 480 || Position.Y < 0)
            {
                IsAlive = false;
                CanDrop = true;
            }
        }

        #region Overrides

        public override void Load()
        {
            Load(@"Assets\bulletB.png");
        }


        public override void Update()
        {
            bulletERRemove();
            Position = new Point(Position.X + 3, Position.Y + speed);
            var LevelSize = Info.GetLevelSize();

            if (Position.Y > LevelSize.Height)
            {
                CanDrop = true;
            }
        }

        #endregion
    }
}
