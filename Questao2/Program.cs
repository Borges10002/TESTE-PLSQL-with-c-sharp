using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Questao2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

public class Program
{
    static readonly HttpClient client = new HttpClient();

    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }


    public static  int getTotalScoredGoals(string teamName, int year)
    {
        int totalGoals = 0;

        int totalGoalsTime1 = 0;
        int totalGoalsTime2 = 0;

        Jogos list1 = new Jogos();       

        list1 = Api.getTotalScoredGoalsTime1(teamName, year, 1);

        foreach (var item in list1.data)
        {
            totalGoalsTime1 += item.team1goals;
        }

        for (int i = 2; i <= list1.total_pages; i++)
        {
            list1 = Api.getTotalScoredGoalsTime1(teamName, year, i);

            foreach (var item in list1.data)
            {
                totalGoalsTime1 += item.team1goals;
            }

        }


        Jogos list2 = new Jogos();
        list2 = Api.getTotalScoredGoalsTime2(teamName, year, 1);

        foreach (var item in list2.data)
        {
            totalGoalsTime2 += item.team2goals;
        }

        for (int i = 2; i <= list2.total_pages; i++)
        {
            list2 = Api.getTotalScoredGoalsTime2(teamName, year, i);

            foreach (var item in list2.data)
            {
                totalGoalsTime2 += item.team2goals;
            }
        }

        totalGoals = (totalGoalsTime1 + totalGoalsTime2);


        return totalGoals;
    }

}
