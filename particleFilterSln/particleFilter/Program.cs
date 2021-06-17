using System;

namespace particleFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Particle little_particle = new Particle();

            Console.WriteLine(little_particle.x_p);
        }
    }

    class Particle
    {
        private int INITIAL_PARTICLE_RANGE;
        private int NUMBER_OF_PARTICLES;
        public double x_p;
        private double y_p;
        private double z_p;
        private double v_p;

        public Particle()
        {
            Random random_num = new Random();
            // Class Members
            INITIAL_PARTICLE_RANGE = 150;
            NUMBER_OF_PARTICLES = 1000;
            x_p = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            y_p = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            z_p = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            v_p = random_num.Next(0, 5);

        }
    }
}
