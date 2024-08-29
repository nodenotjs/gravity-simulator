using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravidade
{
    class Settings
    {
        public static bool accTrace = false;
        public static bool details = false;
        public static bool paused = true;
        public static bool drawLineAtPlanets = false;
        public static bool showCoords = false;
        public static bool ipForces = false;
        public static bool rForce = false;
        public static bool slowMotion = false;

        public static bool pFormOpened = false;

        public static bool moving = false;
        public static Vector2 pointClick = new Vector2();
        public static Vector2 pointMove = new Vector2();
        public static float motionMultipler => 1f;

        public static int updatesTimesInSecond = 250;
    }
}
