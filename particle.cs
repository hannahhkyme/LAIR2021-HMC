using System;

public class Particle
{
    public Particle(){
        // Class Members
        int INITIAL_PARTICLE_RANGE = 150;
        int NUMBER_OF_PARTICLES = 1000;
        double x_p = rand.next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
        double y_p = rand.next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
        double z_p = rand.next(-INITIAL_PARTICLE_RANGE, INITIAL_PARTICLE_RANGE);
        double v_p = rand.next(0,5);
        double weight_p = 1/NUMBER_OF_PARTICLES;
        double theta_p = rand.next(-Math.PI, Math.PI);
    }
    static void Main(){
        var particle1 = Particle();
        Console.WriteLine(particle1.x_p);
    }
}