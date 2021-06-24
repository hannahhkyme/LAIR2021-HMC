using System;
namespace particleFilter
{
    public class ParticleFilter
    {

        public int NUMBER_OF_PARTICLES;
        public double Current_Time;
        public ParticleFilter()
        {
            Current_Time = 0;
            NUMBER_OF_PARTICLES = 1000;
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