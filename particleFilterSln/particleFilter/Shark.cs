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

        void create()
        {
            // create particles (1000) of them and create them as a list
        }
        void update_particle_position()
        {
            // should update the particles position after 
        }
        void normalize()
        {
            // normalize all the particles' weights
        }
        void correct()
        {
            // adjust the new weights based on the new auv positions making sure to adjust higher weights with more copies of that particle,
            // return that new particle as the list of particles created initially
        }
        void updateWeights(double new_x, double new_y)
        {
            //update weights based on the new shark position
        }
        void calc_range_error()
        {
            // find the range error of the average particle to the real shark (helper func )
        }
        void calc_alpha_error()
        {
            //find the alpha error of the average particle to the real shark (helper func)
        }
    }
}