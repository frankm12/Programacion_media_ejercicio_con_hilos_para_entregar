using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programacion_media_ejercicio_con_hilos_para_entregar
{
    /*internal class Program
    {
        static int balance = 1000;
        static object lockObject = new object();
        static void Main(string[] args)
        {

            Thread cliente = new Thread(Metodo_de_transaccion);
            Thread.Sleep(3000);
            cliente.Start();
            Console.WriteLine();
            

            Thread cliente2 = new Thread(Metodo_de_transaccion);
            Thread.Sleep(3000);
            cliente2.Start();

            Console.ReadKey();

        }

        static void Metodo_de_transaccion ()
        {
            for (int i = 0; i < 50 ; i++)
            {
                lock (lockObject)
                {
                    if (balance <= 0)
                    {
                        Random aleatorio = new Random();
                        int numeroAleatorio = aleatorio.Next(1, 500);
                        int resultado = balance - numeroAleatorio;
                        Console.WriteLine($"el hilo: {Thread.CurrentThread.ManagedThreadId} retiro {numeroAleatorio}");
                        Console.WriteLine(balance);
                    }
                    else
                    {
                        Console.WriteLine($"el hilo: {Thread.CurrentThread.ManagedThreadId} no puede retirar por insuficiencia de fondos");
                    }
                }
            }
        }
    }*/

        internal class Program
    {
        //aqui declare mi balance en una variable static para que estuviera disponible en cualquier parte del codigo
        static int balance = 1000;
        static object lockObject = new object();
        static Random aleatorio = new Random();
        static void Main(string[] args)
        {
            //se pare los h
            Task tarea1 = new Task(() =>
            {
                Thread cliente = new Thread(Metodo_de_transaccion);

                cliente.Start();
            });

            tarea1.Start();


            Task tarea2 = new Task(() =>
            {
                Thread cliente = new Thread(Metodo_de_transaccion);

                cliente.Start();
            });

            tarea2.Start();
            Console.ReadKey();

        }

        static void Metodo_de_transaccion ()
        {
            for (int i = 0; i < 30 ; i++)
            {
                lock (lockObject)
                {
                    int numeroAleatorio = aleatorio.Next(10, 100);
                    if (balance >= numeroAleatorio)
                    {

                        int resultado = balance -= numeroAleatorio;
                        if (resultado < 0)
                        {

                        }
                        else
                        {
                            Console.WriteLine($"el hilo: {Thread.CurrentThread.ManagedThreadId} intenta retirar {numeroAleatorio}");
                            Console.WriteLine("La transaccion fue exitosa");
                            Console.WriteLine("Balance restante: "+balance);
                        }

                    }
                    else
                    {
                        Console.WriteLine($"el hilo: {Thread.CurrentThread.ManagedThreadId} Fracasco en retirar {numeroAleatorio}");
                        Console.WriteLine($"EL balance disponible es: {balance} por lo que no se pudo retirar");
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
