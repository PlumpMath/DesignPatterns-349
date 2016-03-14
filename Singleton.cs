using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Singleton
    {
        private static Singleton _instance;
        private List<string> servers;
        private Random r = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        private Singleton()
        {
            servers = new List<string>(new string[] { "Server_1", "Server_2", "Server_3", "Server_4", "Server_5" });
        }

        /*
         * another way to implement based on .net framework, it already ensures the thread safty
        */

        //private static readonly Singleton _instance = new Singleton();    
        //public static Singleton getInstance()
        //{
        //    return _instance;
        //}

        public static Singleton getInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }

        public string nextServer()
        {           
            return servers[r.Next(servers.Count)];
        }
    }
}
