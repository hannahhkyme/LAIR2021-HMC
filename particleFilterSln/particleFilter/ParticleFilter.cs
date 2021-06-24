using System;
namespace particleFilter
{
    public class ParticleFilter
    {

        public double x_shark;
        public double y_shark;
        public double z_shark;
        public double x_auv;
        public double y_auv;
        public double z_auv;
        public ParticleFilter()
        {
            x_shark = 1.0;
            y_shark = 2.0;
            z_shark = 2.0;
            x_auv = 2.0;
            y_auv = 3.0;
            z_auv = 2.0;
        }
        void create()
        {
            // creates a list of 1000 particles
        }
        void update()
        {
            // updates particles while simulated
            // returns new list of updated particles
        }
        void update_weights(double new_x_shark, double new_shark_y)
        {
            // normalize new weights for each new shark measurement
        }
        void correct()
        {
            //corrects the particles, adding more copies of particles based on how high the weight is
        }
        void calc_range_error()
        {
            // calculates the average particles position to the true sharks' position
        }
        void calc_alpha_error()
        {
            // calculates the average particles position to the true sharks' position
        }
    }
}