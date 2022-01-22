using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private double flourType;
        private double backingTechnique;
        private double grams;
        private double BaseCaloriesPerGram = 2;

        public Dough(string flour, string backing,double grams)
        {
            Flour = flour;
            Backing = backing;
            Grams = grams;
        }
        //check what type is the flour and give velue to calories
        public string Flour 
        {
            get => flourType.ToString();
            set 
            { 
                if (value.ToLower() == "white")
                {
                    flourType = 1.5;
                }
                else if (value.ToLower() == "wholegrain")
                {
                    flourType = 1;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
                
        }
        //check what type is the backing and give velue to calories

        public string Backing 
        {
            get => backingTechnique.ToString();
            set
            {
                if (value.ToLower() == "crispy")
                {
                    backingTechnique = 0.9;
                }
                else if(value.ToLower() == "chewy")
                {
                    backingTechnique = 1.1;
                }
                else if (value.ToLower() == "homemade")
                {
                    backingTechnique = 1;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            } 
        }
        //verified the grams
        public double Grams 
        { 
            get => grams;
            set
            {
                if (value >= 1 && value <= 200)
                {
                    grams = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
            }
        }
        //calculate the calories
        public double CalculateCalories()
        {
            return (BaseCaloriesPerGram * grams) * backingTechnique * flourType;
        }
    }
}
