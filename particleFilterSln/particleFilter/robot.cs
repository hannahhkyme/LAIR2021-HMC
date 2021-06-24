using System;
namespace particleFilter
{
    public class Robot
    {
        Random random_num = new Random();
        // SETS TYPE OF MEMBER VARIABLE
        public double X;
        public double Y;
        public double Z;
        public double THETA;
        public double V;
        public Robot()
        {
            X = 1.0;
            Y = 2.0;
            Z = 3.0;
            THETA = Math.PI;
            V = 3.0;
        }


        void update_robot_position(double velocity, double ang_velocity )
        {

        }

        void calc_new_robot_position()
        {

        }

    }
}
