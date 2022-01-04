using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvd;

namespace MultivalueDictionaryProject
{
    public class App
    {
        MultiValueDicationary<string, string> mvd = new MultiValueDicationary<string, string>();

        //Method to start application
        public void Start()
        {
            string command = GetChoice();

            while (true)
            {
                try
                {

                    switch (command)
                    {
                        case "KEYS":
                            GetKeys();
                            command = GetChoice();
                            break;
                        case "MEMBERS":
                            string key = Console.ReadLine();
                            GetMembers(key);
                            command = GetChoice();
                            break;
                        case "ADD":
                            Add();
                            command = GetChoice();
                            break;
                        case "REMOVE":
                            string member = Console.ReadLine();
                            Remove(member);
                            command = GetChoice();
                            break;
                        case "REMOVEALL":
                            string removeKey = Console.ReadLine();
                            RemoveAll(removeKey);
                            command = GetChoice();
                            break;
                        case "CLEAR":
                            Clear();
                            command = GetChoice();
                            break;
                        case "KEYEXISTS":
                            string findKey = Console.ReadLine();
                            KeyExists(findKey);
                            command = GetChoice();
                            break;
                        case "MEMBEREXISTS":
                            string findMember = Console.ReadLine();
                            MemberExists(findMember);
                            command = GetChoice();
                            break;
                        case "ALLMEMBERS":
                            AllMembers();
                            command = GetChoice();
                            break;
                        case "ITEMS":
                            Items();
                            command = GetChoice();
                            break;
                        case "COUNT":
                            string countKey = Console.ReadLine();
                            Count(countKey);
                            break;
                        case "INTERSECT":
                            string intersectKeys = Console.ReadLine();
                            Intersect(intersectKeys);
                            command = GetChoice();
                            break;
                        case "EXIT":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Not a valid command.\n");
                            command = GetChoice();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    command = GetChoice();
                    continue;
                }


            }
        }


        public void Intersect(string keys)
        {
            var keyList = keys.Split(' ');

            var intersectingValues = mvd.IntersectingValues(keyList.ToList());

            intersectingValues.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
        }
        //Get keys in dictionary
        public void GetKeys()
        {
            foreach (var item in mvd.Keys)
            {
                Console.WriteLine($"{item}\n");
            }
        }

        //Checks to see if key exists
        public void KeyExists(string key)
        {
            Console.WriteLine($"{mvd.KeyExists(key)}\n");
        }

        //Checks to see if member exists in dictionary
        public void MemberExists(string member)
        {
            var pair = member.Split(' ');
            Console.WriteLine($"{mvd.MemberExists(pair[0], pair[1])}\n");
        }

        //Gets all members in dictionary
        public void GetMembers(string key)
        {

            foreach (var item in mvd.Members(key))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        //Adds entry to dictionary
        public void Add()
        {
            var item = Console.ReadLine();
            var pair = item.Split(' ');
            mvd.Add(pair[0], pair[1]);
            Console.WriteLine("Added\n");
        }

        //Displays all items in dictionary
        public void Items()
        {
            foreach (var item in mvd)
            {
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"{item.Key}: {value}");
                }
            }

            Console.WriteLine();
        }

        //Removes a value from a key
        public void Remove(string member)
        {
            var item = member.Split(' ');
            mvd.Remove(item[0], item[1]);
            Console.WriteLine("Removed\n");
        }

        //Removes all values from a key and removes key from dictionary
        public void RemoveAll(string key)
        {
            mvd.RemoveAll(key);
            Console.WriteLine("Removed\n");
        }

        //DIsplays all members in dictionary
        public void AllMembers()
        {
            foreach (var item in mvd.AllMembers())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        //Reads command from console
        public string GetChoice()
        {
            Console.WriteLine("Enter a command.");
            return Console.ReadLine().ToUpper();
        }


        //Clears all items in dictionary
        public void Clear()
        {
            mvd.Clear();
            Console.WriteLine("Cleared\n");
        }


        //Gets count of values for a certain key
        public void Count(string key)
        {
            Console.WriteLine($"{key}: {mvd.MemberCount(key)} values\n");
        }

    }
}
