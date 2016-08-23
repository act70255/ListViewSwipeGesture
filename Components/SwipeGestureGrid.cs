using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Components
{
    public class SwipeGestureGrid : Grid
    {
        #region Private Member
        private double _gestureX { get; set; }
        private double _gestureY { get; set; }
        private bool IsSwipe { get; set; }
        #endregion
        #region Public Member
        #region Events
        #region Tapped
        public event EventHandler Tapped;
        protected void OnTapped(EventArgs e)
        {
            if (Tapped != null)
                Tapped(this, e);
        }
        #endregion
        #region SwipeUP
        public event EventHandler SwipeUP;
        protected void OnSwipeUP(EventArgs e)
        {
            if (SwipeUP != null)
                SwipeUP(this, e);
        }
        #endregion
        #region SwipeDown
        public event EventHandler SwipeDown;
        protected void OnSwipeDown(EventArgs e)
        {
            if (SwipeDown != null)
                SwipeDown(this, e);
        }
        #endregion
        #region SwipeRight
        public event EventHandler SwipeRight;
        protected void OnSwipeRight(EventArgs e)
        {
            if (SwipeRight != null)
                SwipeRight(this, e);
        }
        #endregion
        #region SwipeLeft
        public event EventHandler SwipeLeft;
        protected void OnSwipeLeft(EventArgs e)
        {
            if (SwipeLeft != null)
                SwipeLeft(this, e);
        }
        #endregion
        #endregion
        public double Height
        {
            get
            {
                return HeightRequest;
            }
            set
            {
                HeightRequest = value;
            }
        }
        public double Width
        {
            get
            {
                return WidthRequest;
            }
            set
            {
                WidthRequest = value;
            }
        }
        public SwipeEnum SwpieType { get; set; }
        public enum SwipeEnum
        {
            /// <summary>
            /// Y less then 0
            /// </summary>
            SwipeUP,
            /// <summary>
            /// Y more then 0
            /// </summary>
            SwipeDoun,
            /// <summary>
            /// X more them 0
            /// </summary>
            SwpieRight,
            /// <summary>
            /// X less then 0
            /// </summary>
            SwipeLeft,
            /// <summary>
            /// 手勢未判定完成
            /// </summary>
            Unknown,
        }
        #endregion
        public SwipeGestureGrid()
        {
            PanGestureRecognizer panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += PanGesture_PanUpdated;

            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;

            GestureRecognizers.Add(panGesture);
            GestureRecognizers.Add(tapGesture);
        }
        
        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (!IsSwipe)
                    OnTapped(null);

                IsSwipe = false;
            }
            catch (Exception ex)
            {

            }
        }
        
        private void PanGesture_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            try
            {
                switch (e.StatusType)
                {
                    case GestureStatus.Running:
                        {
                            _gestureX = e.TotalX;
                            _gestureY = e.TotalY;
                        }
                        break;
                    case GestureStatus.Completed:
                        {
                            IsSwipe = true;
                            //Debug.WriteLine("{0}  {1}", _gestureX, _gestureY);
                            if (Math.Abs(_gestureX) > Math.Abs(_gestureY))
                            {
                                if (_gestureX > 0)
                                {
                                    OnSwipeRight(null);
                                }
                                else
                                {
                                    OnSwipeLeft(null);
                                }
                            }
                            else
                            {
                                if (_gestureY > 0)
                                {
                                    OnSwipeDown(null);
                                }
                                else
                                {
                                    OnSwipeUP(null);
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
