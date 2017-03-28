namespace Pacman_DeepMind.Extensions
{
    using System;
    using System.IO;
    using Genetic;
    using System.Collections.Generic;

    public static class Logger
    {
        public static void logNewSession()
        {
            StreamWriter log = new StreamWriter("Data.txt", true);

            log.Write("New session initialized at: ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            log.WriteLine("Generation: \t Turn: \t Idle: \t Score: \t Exit Status: ");


            log.Close();
        }

        public static void logData(int genCounter, int turnCounter, int idleCounter, int genScore, string exitStatus)
        {
            StreamWriter log = new StreamWriter("Data.txt", true);

            string gen   = String.Format("{0,4:D}", genCounter);
            string turn  = String.Format("{0,4:D}", turnCounter);
            string idle  = String.Format("{0,4:D}", idleCounter);
            string score = String.Format("{0,4:D}", genScore);

        //TODO: LogMutation
            log.WriteLine("\t " + gen + " \t\t " + turn + " \t " + idle + " \t " + score + " \t\t\t " + exitStatus);
            log.Close();
        }

        //TODO: Format Properly
        public static void logList(List<ResultItem> sortedList)
        {
            StreamWriter log = new StreamWriter("SortedData.txt", true);

            log.Write("Log data created at: ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            log.WriteLine("Score: \t Turn: \t \t Genes: ");

            foreach (var result in sortedList)
            {
                log.Write(result._score + " \t \t " + result._turnCount + " \t \t ");
                foreach (var gene in result.ListActiveGenes)
                {
                    log.Write(gene.geneName + ", ");
                }
                log.WriteLine();
            }

            log.WriteLine("Log ended. \n");
            log.Close();
        }

        public static void logEndSession()
        {
            StreamWriter log = new StreamWriter("Data.txt", true);

            log.Write("Session ended at: ");
            log.WriteLine("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            log.WriteLine();

            log.Close();
        }
        
    }
}
