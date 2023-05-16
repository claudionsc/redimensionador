using System;
using System.Threading;

Console.WriteLine("Iniciando nosso projeto");

Thread thrad = new System.Threading.Thread(Redimensionar);
thrad.Start();  
static void Redimensionar()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);

        Thread.Sleep(new TimeSpan(0, 0, 3));
    }
}
