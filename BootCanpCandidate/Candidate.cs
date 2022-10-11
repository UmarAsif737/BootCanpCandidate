using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCandidate
{
    public class Candidate
    {
        
        private string name;
        private double cgpa;
        private string city;
     
        
        
        public Candidate(string name, double cgpa, string city)
        {
            this.name = name;
            this.cgpa = cgpa;
            this.city = city;
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public double Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
       
    }

}
