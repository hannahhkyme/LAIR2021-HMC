using System;

namespace particleFilter
{
    class Particle
    {
        Random random_num = new Random();
        // SETS TYPE OF MEMBER VARIABLE
        public double X_P;
        public double Y_P;
        public double Z_P;
        public double THETA_P;
        public double V_P;
        public int INITIAL_PARTICLE_RANGE;
        

        public double W_P;
        public Particle()
        {

            // Class Members
            INITIAL_PARTICLE_RANGE = 150;
            // X_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            X_P = 2.0;
            //Y_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            Y_P = 1.5;
            //Z_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            Z_P = 3.0;
            //V_P = random_num.Next(0, 5);
            V_P = 1.0;
            //THETA_P = random_num.NextDouble() * (2 * Math.PI) + -Math.PI;
            THETA_P = 3.14/2;

            W_P = 0.5 ;
        }



        double angle_wrap(double ang)
        {
            if (-Math.PI <= ang & ang <= Math.PI)
            {
                return ang;
            }
            else
            {
                ang = ang % Math.PI;
                return angle_wrap(ang);
            }
        }
        double velocity_wrap(double vel)
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

        
        void updateParticles(double dt)
        {
            /*updates the particles location with random v and theta

                input (dt) is the amount of time the particles are "moving" 
                    generally set to .1, but it should be whatever the "time.sleep" is set to in the main loop
            */
            // pull out
            int RANDOM_VELOCITY = 5;
            double RANDOM_THETA = Math.PI / 2;

            // updates velocity of particles
            this.V_P += random_num.Next(0, RANDOM_VELOCITY);
            this.V_P = velocity_wrap(this.V_P);

            //change theta & pass through angle_wrap
            this.THETA_P += random_num.NextDouble() * (2*RANDOM_THETA) - RANDOM_THETA;
            this.THETA_P = angle_wrap(this.THETA_P);

            // change x & y coordinates to match
            this.X_P += this.V_P * Math.Cos(this.THETA_P) * dt;
            this.Y_P += this.V_P * Math.Sin(this.THETA_P) * dt;

        }


        double calc_particle_alpha(double x_auv, double y_auv, double theta_auv)
        {
            // calculates the alpha value of a particle

            double particleAlpha = angle_wrap(Math.Atan2((Y_P - y_auv), (X_P  - x_auv))) - theta_auv;
            return particleAlpha;
        }


        double calc_particle_range(double x_auv,double y_auv)
        {
            //calculates the range from the particle to the auv
            double particleRange = Math.Sqrt(Math.Pow((y_auv - this.Y_P), 2) + Math.Pow((x_auv - this.X_P), 2));
            return particleRange;
        }

        void weight(double auv_alpha, double particleAlpha, double auv_range, double particleRange)
        {
            /* calculates the weight according to alpha, then the weight according
             * they are multiplied together to get the final weight */

            double SIGMA_ALPHA = .5;
            double E = 2.71828;
            double DENOMINATOR = (2 * Math.Pow(SIGMA_ALPHA, 2));
            // constant = sqrt of 2Pi
            //double constant = 2.506628;
            double constant = 1.2;
            double newdAlpha = angle_wrap(particleAlpha - auv_alpha);
            double dAlpha = Math.Pow(newdAlpha, 2);
            double function_alpha = .001 + (Math.Pow(E, -dAlpha)) / DENOMINATOR;
           
            this.W_P = function_alpha;
  
            double SIGMA_RANGE = 100.0;
            // double DENOMINATOR2 = ( Math.Pow(SIGMA_RANGE, 2));
            double dRange = Math.Pow(particleRange - auv_range, 2);
            double function_range = .001 + (1 / (SIGMA_RANGE * constant) * Math.Pow(E, -dRange)) / 20000;

            this.W_P *= function_range;

        }

        static void Main(string[] args)
        {
            Particle little_particle = new Particle();

            //Testing Update Particles

            /*
            Console.WriteLine(little_particle.X_P);
            Console.WriteLine(little_particle.Y_P);
            little_particle.updateParticles(1.0);
            Console.WriteLine(little_particle.X_P);
            Console.WriteLine(little_particle.Y_P);
            */

            //Testing Calc Particle Alpha


            little_particle.THETA_P = 6.28;
            little_particle.angle_wrap(little_particle.THETA_P);
            Console.WriteLine("theta p");
            Console.WriteLine(little_particle.THETA_P);

            //Console.WriteLine(little_particle.calc_particle_range(5, 5.5));
            double particle_range = little_particle.calc_particle_range(5, 5.5);
            Console.WriteLine("particle_range");
            Console.WriteLine(particle_range);
            Console.WriteLine("particle_alpha");
            //Console.WriteLine(little_particle.calc_particle_alpha(5,5.5,Math.PI));
            double particle_alpha = little_particle.calc_particle_alpha(5, 5.5, Math.PI);
            Console.WriteLine(particle_alpha);
            Console.WriteLine("Weight before");
            Console.WriteLine(little_particle.W_P);
            little_particle.weight(1.57 , particle_alpha, 8.0, particle_range);
            Console.WriteLine("Weight After");
            Console.WriteLine(little_particle.W_P);

        }
    }
}
