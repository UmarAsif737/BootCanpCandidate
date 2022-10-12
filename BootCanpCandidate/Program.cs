using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCandidate
{
    class Program
    {
        static void ShowCand(List<Candidate> CandidateList)
        {
            foreach (var cand in CandidateList)
            {
                Console.WriteLine("\tName = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
            }
        }

        static void ShowCand(Dictionary<string, List<Candidate>> CandDict, string key)
        {
            foreach (var cand in CandDict[key])
            {
                Console.WriteLine("\tName = {0} , CGPA = {1} , City = {2}, Marks = {3}", cand.Name, cand.Cgpa, cand.City, cand.Avg);
            }
        }

        static void SpecificShow(Dictionary<string, List<Candidate>> CandDict, List<string> cities, List<string> cgpa, string show, int k)
        {   

            int i = 0;
            string key;
            int loop;
            if (show.ToLower() == "cgpa")
            {
                Console.WriteLine("\nSorted List of Students with {0} or equal to 3.00 CGPA are\n", cgpa[k]);                
                key = cities[i] + cgpa[k];
                loop =  cities.Count;
            }
            else
            {
                Console.WriteLine("\nSorted List of Students that are from {0}\n", cities[k]);
                key = cities[k] + cgpa[i]; 
                loop = cgpa.Count;
            }
            for (i = 0; i < loop; i++)
            {
                foreach (var cand in CandDict[key])
                {
                    Console.WriteLine("\tName = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
                }

            }
            

        }

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

            Console.WriteLine("\t\t\tTask 1");
            Console.WriteLine("\nTotal Candidates who applied are as follows: \n");

            ShowCand(CandidateList);

            Dictionary<string, List<Candidate>> CandDict = new Dictionary<string, List<Candidate>>();
            List<Candidate> CandCityGreat3 = new List<Candidate>();
            List<Candidate> CandCityLess3 = new List<Candidate>();
            List<Candidate> percent90 = new List<Candidate>();
            List<Candidate> percentless90 = new List<Candidate>();
            List<string> cities = new List<string>() { "Lahore", "Rawalpindi", "Faisalabad" };
            List<string> cgpa = new List<string>() { "greater than", "less than" };
            List<string> per = new List<string>() { "greater90", "less90" };
            List<string> show = new List<string>() { "city", "cgpa" };
            Candidate candi;
            Candidate candiLess;
            double ass1;
            double ass2;
            double avg;

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
            
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 2");

            SpecificShow(CandDict, cities, cgpa, show[1], 0);
       
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 3");
            Console.WriteLine("\nPlease enter the marks of the assignments of students one by one:\n");

            for (int i = 0; i < cities.Count; i++)
            {
                foreach (var cand in CandDict[cities[i] + cgpa[0]])
                {
                    Console.WriteLine("\tName = {0} , CGPA = {1} , City = {2} ", cand.Name, cand.Cgpa, cand.City);
                    Console.Write("\t\tEnter Assignment 1 Marks: ");
                    ass1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\t\tEnter Assignment 2 Marks: ");
                    ass2 = Convert.ToDouble(Console.ReadLine());
                    avg = ((ass1 + ass2) / 2);
                    if (avg >= 90)
                    {
                        candi = new Candidate(cand.Name, cand.Cgpa,cand.City,avg);
                        percent90.Add(candi);
                    }
                    else
                    {
                        candiLess = new Candidate(cand.Name, cand.Cgpa, cand.City,avg);
                        percentless90.Add(candiLess);
                    }
                }
            }
            CandDict.Add(per[0], percent90);
            CandDict.Add(per[1], percentless90);

            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 4");       
            Console.WriteLine("\nStudents with Greater that 90% are: \n");

            ShowCand(CandDict, per[0]);

            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 5");

            SpecificShow(CandDict, cities, cgpa, show[0], 1);

            Console.ReadLine();
        }
    }
}
