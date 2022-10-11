using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCandidate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Candidate> CandidateList = new List<Candidate>();

            CandidateList.Add(new Candidate("Umar", 3.84, "Faisalabad"));
            CandidateList.Add(new Candidate("Hussain", 3.94, "Rawalpindi"));
            CandidateList.Add(new Candidate("Arshad", 2.40, "Lahore"));
            CandidateList.Add(new Candidate("Hassan", 1.81, "Faisalabad"));
            CandidateList.Add(new Candidate("Haseeb", 3.44, "Rawalpindi"));
            CandidateList.Add(new Candidate("Usman", 3.15, "Faisalabad"));
            CandidateList.Add(new Candidate("Rashid", 2.32, "Lahore"));
            CandidateList.Add(new Candidate("Ali", 3.63, "Rawalpindi"));
            CandidateList.Add(new Candidate("Adeel", 1.45, "Lahore"));
            CandidateList.Add(new Candidate("Hamza", 3.23, "Faisalabad"));
            CandidateList.Add(new Candidate("Asif", 3.01, "Rawalpindi"));
            CandidateList.Add(new Candidate("Huzaifa", 3.12, "Rawalpindi"));
            CandidateList.Add(new Candidate("Nadeem", 2.77, "Faisalabad"));
            CandidateList.Add(new Candidate("Kashif", 3.51, "Lahore"));
            CandidateList.Add(new Candidate("Ahmad", 3.11, "Lahore"));
            Console.WriteLine("Total Candidates who applied are as follows: \n");
            foreach (var cand in CandidateList)
            {
                Console.WriteLine("Name = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
            }
            Dictionary<string, List<Candidate>> CandDict = new Dictionary<string, List<Candidate>>();
            List<Candidate> CandCityGreat3 = new List<Candidate>();
            List<Candidate> CandCityLess3 = new List<Candidate>();
            List<string> cities = new List<string>() {"Lahore", "Rawalpindi", "Faisalabad"};
            List<string> cgpa = new List<string>() { "greater than 3", "less than 3"};
            List<Candidate> percent90 = new List<Candidate>();
            List<Candidate> percentless90 = new List<Candidate>();
            List<string> per = new List<string>() { "greater90", "less90"};

            for (int i = 0; i < cities.Count; i++)
            {

                foreach (var cand in CandidateList)
                {
                    if (cand.City == cities[i] && cand.Cgpa >= 3)
                    {
                        CandCityGreat3.Add(cand);
                    }
                    if (cand.City == cities[i] && cand.Cgpa < 3)
                    {
                        CandCityLess3.Add(cand);
                    }
                }

                CandDict.Add(cities[i] + cgpa[0], CandCityGreat3);
                CandCityGreat3 = new List<Candidate>();
                
                CandDict.Add(cities[i] + cgpa[1], CandCityLess3);
                CandCityLess3 = new List<Candidate>();
            }
            Console.WriteLine("\n\nSorted List is as follows: ");

            Console.WriteLine("\nStudents with {0} Cgpa are", cgpa[0]);
            for (int i = 0; i < cities.Count; i++)
            {
                foreach (var cand in CandDict[cities[i]+cgpa[0]])
                {
                    Console.WriteLine("Name = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
                }
            }

            for (int i = 0; i < cities.Count; i++)
            {
                foreach (var cand in CandDict[cities[i] + cgpa[0]])
                {
                    Console.WriteLine("Name = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
                    Console.Write("Enter Assignment 1 Marks: ");
                    double ass1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Assignment 2 Marks: ");
                    double ass2 = Convert.ToDouble(Console.ReadLine());
                    double avg = ((ass1 + ass2) / 2);
                    if (avg >= 90)
                    {
                        percent90.Add(cand);
                    }
                    else
                    {
                        percentless90.Add(cand);
                    }
                }
                CandDict.Add("aas1", percent90);
                percent90 = new List<Candidate>();

                //CandDict.Add(per[1], percentless90);
                //percentless90 = new List<Candidate>();
            }

            Console.WriteLine("\nStudents with Greater that 90% are: ");
            
            foreach (var cand in CandDict["aas1"])
            {
                Console.WriteLine("Name = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
            }
            
            Console.ReadLine();
        }
    }
}