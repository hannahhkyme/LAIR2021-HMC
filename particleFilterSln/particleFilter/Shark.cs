using System;
namespace particleFilter
{
    public class Shark
    {
        Random random_num = new Random();
        // SETS TYPE OF MEMBER VARIABLE
        public double X_S;
        public double Y_S;
        public double Z_S;
        public double THETA_S;
        public double V_S;
        public double Current_Time;
        public Shark()
        {
            X_S = 1.0;
            Y_S = 2.0;
            Z_S = 3.0;
            THETA_S = Math.PI;
            V_S = 3.0;
            Current_Time = 0.1;
        }


        void update_shark_position()
        {

        }
    }
}
