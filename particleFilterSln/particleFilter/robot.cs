using System;
namespace particleFilter
{
    public class Robot
    {
        Random random_num = new Random();
        // SETS TYPE OF MEMBER VARIABLE
        public double X_R;
        public double Y_R;
        public double Z_R;
        public double THETA_R;
        public double V_R;
        public double Current_Time;
        public Robot()
        {
            X_R = 1.0;
            Y_R = 2.0;
            Z_R = 3.0;
            THETA_R = Math.PI;
            V_R = 3.0;
            Current_Time = 0.1;
        }


        void update_robot_position(double velocity, double ang_velocity )
        {

        }



        void calc_new_robot_position()
        {

        }

    }
}
