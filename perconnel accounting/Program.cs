using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perconnel_accounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddWorkerDossier = 1;
            const int AllDossierOutput = 2;
            const int DeleteWorkerDossier = 3;
            const int FindWorkerDossier = 4;
            const int Close = 5;
            string[] workers = { };
            string[] post = { };
            bool isWork = true;
            Console.WriteLine("Добро пожаловать в кадровый учёт. Выберите пункт меню:");

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"{AddWorkerDossier} - Заполнить досье");
                Console.WriteLine($"{AllDossierOutput} - Вывести все досье");
                Console.WriteLine($"{DeleteWorkerDossier} - Удалить досье");
                Console.WriteLine($"{FindWorkerDossier} - Поиск по фамилии");
                Console.WriteLine($"{Close} - Выход");
                int userInput =Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case AddWorkerDossier:
                        AddWorker(ref workers, ref post);
                        break;
                    case AllDossierOutput:
                        ShowWorkerInfo(workers, post);
                        break;
                    case DeleteWorkerDossier:
                        DeleteWorker(ref workers, ref post);
                        break;
                    case FindWorkerDossier:
                        FindWorker(workers, post);
                        break;
                    case Close:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет в меню!\nНажмите любую клавишу для продожения...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static string[] AddWorkerInfo(string[] info, string newInfo)
        {
            string[] tempInfo = new string[info.Length + 1];

            for (int i = 0; i < info.Length; i++)
            {
                tempInfo[i] = info[i];
            }

            info = tempInfo;
            info[info.Length - 1] = newInfo;
            return info;
        }

        static void AddWorker(ref string[] fullName, ref string[] post)
        {
            string newWorker;
            string newPost;
            Console.Clear();
            Console.WriteLine("Введите ФИО нового сотрудника");
            newWorker = Console.ReadLine();
            fullName = AddWorkerInfo(fullName, newWorker);
            Console.WriteLine("Введите должность нового сотрудника");
            newPost = Console.ReadLine();
            post = AddWorkerInfo(post, newPost);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ShowWorkerInfo(string[] worker, string[] post)
        {
            Console.Clear();
            int workerNumber = 0;

            for (int i = 0; i < worker.Length; i++)
            {
                workerNumber++;
                Console.WriteLine($"{workerNumber}. {worker[i]} - {post[i]};");
            }
            Console.WriteLine("\nСписок сотрудников в базе данных.");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static string[] DeleteWorkerInfo(string[] info, int workerNumber)
        {
            string[] tempInfo = new string[info.Length - 1];

            for (int i = 0; i < workerNumber; i++)
            {
                tempInfo[i] = info[i];
            }

            for (int i = workerNumber; i < tempInfo.Length; i++)
            {
                tempInfo[i] = info[i + 1];
            }

            info = tempInfo;
            return info;
        }

        static void DeleteWorker(ref string[] fullName, ref string[] post)
        {
            int workerNumber;
            Console.Clear();
            Console.WriteLine("Введите номер сотрудника, досье которого хотите удалить");
            workerNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            fullName = DeleteWorkerInfo(fullName, workerNumber);
            post = DeleteWorkerInfo(post, workerNumber);
            Console.WriteLine("Досье удалено! Нажмите любую клавишу для проложения...");
            Console.ReadKey();
        }

        static void FindWorkerInfo(string[] fullName, string[] post, string findInfo)
        {
            int workerNumber = 0;
            bool isFind = false;
            string findFullName;

            for (int i = 0; i < fullName.Length; i++)
            {
                workerNumber++;

                if (fullName[i] == findInfo)
                {
                    string findPost = post[i];
                    findFullName = fullName[i];
                    Console.WriteLine($"Сотрудник {findFullName} находится под номером - {workerNumber}, и занимает должность - {findPost}.");
                    isFind = true;
                }
            }

            if (isFind == false)
            {
                Console.WriteLine("Такого сотрудника нет базе данных.");
            }
        }

        static void FindWorker(string[] fullName, string[] post)
        {
            string findInfo;
            Console.Clear();
            Console.WriteLine("Введите ФИО сотрудника, которого хотите найти");
            findInfo = Console.ReadLine();
            FindWorkerInfo(fullName, post, findInfo);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}