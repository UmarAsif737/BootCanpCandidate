using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampCandidate
{
    class Program
    {
        //Making a function to show a list of Total Candidates
        //Time complexity for this function is O(k) where k = 15.
        static void ShowCand(List<Candidate> CandidateList)
        {
            foreach (var cand in CandidateList)
            {
                Console.WriteLine("\tName = {0}\tCGPA = {1}\tCity = {2} ", cand.Name, cand.Cgpa, cand.City);
            }
        }

        //A function made to display candidates w.r.t city or cgpa.
        //SpecificShow takes 5 parameters.
        //First is Dictionary of Candidates, Second is list of cities and third is list of cgpa
        //Fourth string show tells the function whether he wants to display results based on city or cgpa
        //Basically show is a list containg string. show[0] = "city", show[1] = "cgpa"
        //Once it is decided that you want to show based on city or cgpa. Next step is to select which city or cgpa.
        //Fifth parameter k decides which city or cgpa to show. For city k = 0 means Lahore
        //Time complexity for this function is O(l*(k)) = O(30) where t(n) = l*(k). where loop = l = 3, show_cand = k = 10
        static void SpecificShow(Dictionary<string, List<Candidate>> candDict, List<string> cities, List<string> cgpa, string show, int k)
        {   
            int i = 0;
            string key="0";
            int loop=1;

            if (show == "cgpa") 
            {
                Console.WriteLine("\nSorted List of Students with {0} or equal to 3.00 CGPA are\n", cgpa[k]);                
                loop =  cities.Count;
            }
            else if (show == "cities")
            {
                Console.WriteLine("\nSorted List of Students that are from {0}\n", cities[k]);
                loop = cgpa.Count;
            }
            

            for (i = 0; i < loop; i++)
            {
                if (show == "cgpa") 
                {
                    key = cities[i] + cgpa[k];
                }
                else if (show == "city") 
                {
                    key = cities[k] + cgpa[i];
                }
                
                //Dispaying results based on parameters
                foreach (var cand in candDict[key])
                {
                    Console.WriteLine("\tName = {0}\tCGPA = {1}\tCity = {2} ", cand.Name, cand.Cgpa, cand.City);
                }
            }
        }

        //Making a function to show a list of Candidates stored in a key of CandDict dictionary with greater than 90 percentage
        //Time complexity for this function is O(k) where k = 10.
        static void ShowCand(Dictionary<string, List<Candidate>> candDict, string key)
        {
            foreach (var cand in candDict[key])
            {
                Console.WriteLine("\tName = {0}\tCGPA = {1}\tPercentage = {2} \tCity = {3}", cand.Name, cand.Cgpa, cand.Avg, cand.City);
            }
        }

        static void Main(string[] args)
        {
            List<Candidate> candidateList = new List<Candidate>(); //Making List candidateList taking Candidate as datatype 
            
            //Task 1
            //Creating 15 Objects of candidate and adding it in a list in a single step.
            candidateList.Add(new Candidate("Umar", 3.84, "Faisalabad"));
            candidateList.Add(new Candidate("Hussain", 3.94, "Rawalpindi"));
            candidateList.Add(new Candidate("Arshad", 3.40, "Lahore"));
            candidateList.Add(new Candidate("Hassan", 1.81, "Faisalabad"));
            candidateList.Add(new Candidate("Haseeb", 3.44, "Lahore"));
            candidateList.Add(new Candidate("Usman", 3.15, "Faisalabad"));
            candidateList.Add(new Candidate("Rashid", 2.32, "Lahore"));
            candidateList.Add(new Candidate("Ali", 3.63, "Rawalpindi"));
            candidateList.Add(new Candidate("Adeel", 1.45, "Lahore"));
            candidateList.Add(new Candidate("Hamza", 3.23, "Faisalabad"));
            candidateList.Add(new Candidate("Asif", 3.01, "Rawalpindi"));
            candidateList.Add(new Candidate("Huzaifa", 3.12, "Rawalpindi"));
            candidateList.Add(new Candidate("Nadeem", 2.77, "Faisalabad"));
            candidateList.Add(new Candidate("Kashif", 3.51, "Lahore"));
            candidateList.Add(new Candidate("Ahmad", 3.11, "Lahore"));

            //Making a dictionary with string as a key and list of type Candidate as a value.
            Dictionary<string, List<Candidate>> candDict = new Dictionary<string, List<Candidate>>();

            
            List<Candidate> candCityGreat3 = new List<Candidate>();  //List of candidate of every city with >= 3 CGPA.
            List<Candidate> candCityLess3 = new List<Candidate>();  //List of candidate of every city with < 3 CGPA.
            List<Candidate> percent90 = new List<Candidate>();  //List of candidate of every city with >= 90 Percent marks.
            List<Candidate> percentLess90 = new List<Candidate>();  //List of candidate of every city with < 90 Percent marks.
            List<string> cities = new List<string>() { "Lahore", "Rawalpindi", "Faisalabad" };  //List of every city.
            List<string> cgpa = new List<string>() { "greater than", "less than" }; //List of every CGPA type.
            List<string> per = new List<string>() { "great90", "less90" };  //List of every percent type.
            List<string> show = new List<string>() { "city", "cgpa" };  //List of based on city or CGPA
            Candidate candGreat90;  //Candidate object for >90 percent
            Candidate candiLess90;  //Candidate object for <90 percent
            double assign1; 
            double assign2;
            double avg;

            //Showing Task 1
            //Time complexity for task 1 is O(k) where k = 15.
            Console.WriteLine("\t\t\tTask 1");
            Console.WriteLine("\nTotal Candidates who applied are as follows: \n");

            ShowCand(candidateList); //Calling a function to show candidate list.

            //Task 2
            //Time complexity for task 2 is O(c*l) = O(45) 

            //Placing candidates with city and cgpa in a dictionary of candidates.
            //Seperate key for every city with >= 3 CGPA and < 90 CGPA.
            //Like for city Lahore with greater than 3 cgpa , the key is "Lahoregreater than"
            //Time complexity for this function is O(c*l) = O(45) where t(n) = c * l. where cities = c = 3, cand = l = 15                      
            for (int i = 0; i < cities.Count; i++)
            {

                foreach (var cand in candidateList)
                {
                    if (cand.City == cities[i] && cand.Cgpa >= 3) {
                        candCityGreat3.Add(cand);
                    }
                    else if (cand.City == cities[i] && cand.Cgpa < 3) 
                    {
                        candCityLess3.Add(cand);
                    }
                }

                candDict.Add(cities[i] + cgpa[0], candCityGreat3);
                candCityGreat3 = new List<Candidate>(); //Creating new object every time.

                candDict.Add(cities[i] + cgpa[1], candCityLess3);
                candCityLess3 = new List<Candidate>();
            }

            //Showing Task 2
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 2");

            SpecificShow(candDict, cities, cgpa, show[1], 0);   //Time complexity for this function is O(l*(s + k)) = O(36) 
            
            //Task 3
            //Time complexity for task 3 is O(c*l) = O(30)                      
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 3");
            Console.WriteLine("\nPlease enter the marks of the assignments of students one by one:\n");

            //Asking marks of both assignments from the user. Based on that storing on the list.
            //Time complexity for this function is O(c*l) = O(30) where t(n) = c * l where cities = s = 3, cand = l = 10                      
            for (int i = 0; i < cities.Count; i++)
            {
                foreach (var cand in candDict[cities[i] + cgpa[0]])
                {
                    Console.WriteLine("\tName = {0}\tCGPA = {1}\tCity = {2} ", cand.Name, cand.Cgpa, cand.City);
                    Console.Write("\t\tEnter Assignment 1 Marks: ");
                    assign1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("\t\tEnter Assignment 2 Marks: ");
                    assign2 = Convert.ToDouble(Console.ReadLine());
                    avg = ((assign1 + assign2) / 2);
                    if (avg >= 90)
                    {
                        candGreat90 = new Candidate(cand.Name, cand.Cgpa,cand.City,avg);
                        percent90.Add(candGreat90);
                    }
                    else
                    {
                        candiLess90 = new Candidate(cand.Name, cand.Cgpa, cand.City,avg);
                        percentLess90.Add(candiLess90);
                    }
                }
            }
            candDict.Add(per[0], percent90);
            candDict.Add(per[1], percentLess90);

            //Task 4
            //Time complexity for task 4 is O(k) where k = 10.
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 4");       
            Console.WriteLine("\nStudents with Greater that 90% are: \n");

            ShowCand(candDict, per[0]);

            //Task 5
            //Time complexity for task 5 is O(l*(k)) = O(30).
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 5");

            SpecificShow(candDict, cities, cgpa, show[0], 1);

            //Task 6
            //Time complexity for task 6 is O(k) where k = 10.
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("\n\t\t\tTask 6");

            List<Candidate> sortList = percent90.OrderByDescending(x => x.Avg).ToList();

            candDict[per[0]] = sortList;
            ShowCand(candDict, per[0]);

            Console.ReadLine();
        }
    }
}
