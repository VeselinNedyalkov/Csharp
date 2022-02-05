using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public double LandingStrip { get => landingStrip; set => landingStrip = value; }
        private List<Drone> Drones { get => drones; set => drones = value; }
        public int Count { get => drones.Count; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }
            else if (Count >= Capacity)
            {
                return "Airfield is full.";
            }
            else
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }

        public bool RemoveDrone(string name)
        {
            bool isExist = false;
            if (Drones.Any(xdrone => xdrone.Name == name))
            {
                Drone remuveDrone = Drones.Single(xdrone => xdrone.Name == name);
                Drones.Remove(remuveDrone);
                isExist = true;
            }

            return isExist;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            List<Drone> temp = new List<Drone>(Drones);
            foreach (var drone in temp)
            {
                if (drone.Brand == brand)
                {
                    Drones.Remove(drone);
                    count++;
                }
            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            if (Drones.Any(xdrone => xdrone.Name == name))
            {
                Drones.Single(xdrone => xdrone.Name == name).Available = false;
                return Drones.Single(xdrone => xdrone.Name == name);
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = new List<Drone>();
            foreach (var drone in Drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    flyDrones.Add(drone);
                }
            }
            return flyDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
