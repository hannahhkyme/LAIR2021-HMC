using System;

namespace particleFilter
{
    class Particle
    {
        Random random_num = new Random();
        private int INITIAL_PARTICLE_RANGE;
        public int initial_particle_range
        {
            get { return INITIAL_PARTICLE_RANGE; }
            set { INITIAL_PARTICLE_RANGE = 150; }
        }
        private int NUMBER_OF_PARTICLES;
        public int number_of_particles
        {
            get { return NUMBER_OF_PARTICLES; }
            set { NUMBER_OF_PARTICLES = 1000; }
        }
        public double X_P;
        public double x_p
        {
            get { return X_P; }
            set {X_P = random_num.Next(-initial_particle_range, initial_particle_range); }
        }
        public double Y_P;
        public double y_p
        {
            get { return Y_P; }
            set
            {
                Y_P = random_num.Next(-initial_particle_range, initial_particle_range);
            }
        }
        public double Z_P;
        public double z_p
        {
            get { return Z_P; }
            set
            {
                Z_P = random_num.Next(-initial_particle_range, initial_particle_range);
            }
        }
        public double V_P;
        public double v_p
        {
            get { return V_P; }
            set
            {
                Y_P = random_num.Next(0, 5);
            }
        }
        public double THETA_P;
        public double theta_p
        {
            get { return THETA_P; }
            set
            {
                THETA_P = random_num.NextDouble() * (2 * Math.PI) + -Math.PI;
            }
        }

        public Particle()
        {

            // Class Members
            INITIAL_PARTICLE_RANGE = 150;
            NUMBER_OF_PARTICLES = 1000;
            X_P = random_num.Next(-initial_particle_range, initial_particle_range);
            Y_P = random_num.Next(-initial_particle_range, initial_particle_range);
            Z_P = random_num.Next(-initial_particle_range, initial_particle_range);
            V_P = random_num.Next(0, 5);
            THETA_P = random_num.NextDouble() * (2 * Math.PI) + -Math.PI;
        }
        // GETTER AND SETTERS
        
        static double angle_wrap(double ang)
        {
            if (-Math.PI <= ang & ang <= Math.PI)
            {
                return ang;
            }
            else if (ang > Math.PI) {
                ang += (-2 * Math.PI);
                return angle_wrap(ang);
            }
            else {
                ang += (2 * Math.PI);
                return angle_wrap(ang);
            }
        }

        static double velocity_wrap(double vel)
        {
            if (vel <= 5)
            {
                return vel;
            }
            else
            {
                vel += -5;
                return velocity_wrap(vel);
            }
        }
        static void Main(string[] args)
        {
            Particle little_particle = new Particle();
            Console.WriteLine(little_particle.initial_particle_range);
            Console.WriteLine(angle_wrap(little_particle.theta_p));
            Console.WriteLine(velocity_wrap(little_particle.v_p));
            Console.WriteLine(little_particle.x_p);
        }
    }
}
