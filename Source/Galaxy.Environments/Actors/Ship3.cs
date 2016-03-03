
using System.Diagnostics;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;


namespace Galaxy.Environments.Actors
{
    internal class Ship3 : DethAnimationActor
    {
        #region Constant

        private const long startFlyMs = 2000;
        private bool sign;

        #endregion

        #region Private fields

        protected bool m_flying;
        protected Stopwatch m_flyTimer;

        #endregion

        #region Constructors

        public Ship3(ILevelInfo info) : base(info)
        {
            Width = 30;
            Height = 30;
            ActorType = ActorType.Enemy;
        }

        public bool Movement
        {
            get { return sign; }
            set { sign = value; }
        }

        #endregion

        #region Overrides

        public override void Update()
        {
            base.Update();

            if (!IsAlive)
                return;

            if (!m_flying)
            {
                if (m_flyTimer.ElapsedMilliseconds <= startFlyMs) return;

                m_flyTimer.Stop();
                m_flyTimer = null;
                h_changePosition();
                m_flying = true;
            }
            else
            {
                h_changePosition();
            }
        }

        #endregion

        #region Overrides

        public override void Load()
        {
            Load(@"Assets\ship3.png");
            if (m_flyTimer == null)
            {
                m_flyTimer = new Stopwatch();
                m_flyTimer.Start();
            }
        }

        #endregion

        #region Private methods

        private void h_changePosition()
        {
            int mov;
            mov = Movement ? 3 : - 3;

            Position = new Point(Position.X + mov, Position.Y + 3);
            
        #endregion
        }
    }
}

