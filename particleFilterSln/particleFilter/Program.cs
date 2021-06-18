﻿using System;

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
        public int NUMBER_OF_PARTICLES;
        public double W_P;
        public Particle()
        {

            // Class Members
            INITIAL_PARTICLE_RANGE = 150;
            NUMBER_OF_PARTICLES = 1000;
            X_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            Y_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            Z_P = random_num.Next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
            V_P = random_num.Next(0, 5);
            THETA_P = random_num.NextDouble() * (2 * Math.PI) + -Math.PI;
            W_P = 1 / NUMBER_OF_PARTICLES;
        }

        

        double angle_wrap(double ang)
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

            int RANDOM_VELOCITY = 5;
            double RANDOM_THETA = Math.PI / 2;
            // updates velocity of particles
            this.V_P += this.V_P + random_num.Next(0, RANDOM_VELOCITY);
            this.V_P = velocity_wrap(this.V_P);
            //change theta & pass through angle_wrap
            this.THETA_P += this.THETA_P + random_num.NextDouble() * (2*RANDOM_THETA) - RANDOM_THETA;
            this.THETA_P += this.THETA_P + angle_wrap(this.THETA_P);
            // change x & y coordinates to match
            this.X_P += this.V_P * Math.Cos(this.THETA_P) * dt;
            this.Y_P += this.V_P * Math.Sin(this.THETA_P) * dt;

        }


        double calc_particle_alpha(double x_auv, double y_auv, double theta_auv)
        {
            // calculates the alpha value of a particle

            double particleAlpha = angle_wrap(Math.Atan2((y_auv + Y_P), (X_P + -x_auv))) - theta_auv;
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

            double SIGMA_ALPHA = .05;
            double E = 2.71828;
            double DENOMINATOR = (2 * Math.Pow(SIGMA_ALPHA, 2));
            // constant = sqrt of 2Pi
            double constant = 2.506628;
            double dAlpha = Math.Pow(particleAlpha - auv_alpha, 2);
            double function_alpha = .001 + (1/(SIGMA_ALPHA * constant) * (Math.Pow(-angle_wrap(dAlpha) , E))/ DENOMINATOR);
            W_P = function_alpha;
            //range weight
            //print("auv alpha", auv_alpha)
            int SIGMA_RANGE = 10;
            double DENOMINATOR2 = (2 * Math.Pow(SIGMA_RANGE, 2));
            double function_weight = .001 + (1 / (SIGMA_RANGE * constant) * (Math.Pow((-particleRange - auv_range), 2)) / DENOMINATOR2);
           
          
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