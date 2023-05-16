using System;
using System.Threading;

Console.WriteLine("Iniciando nosso projeto");

Thread thrad = new Thread(Redimensionar);
thrad.Start();  

Console.Read();


static void Redimensionar()
{

    string diretorio_entrada = "Arquivos_Entrada";
    string diretorio_finalizados = "Arquivos_Finalizados";
    string diretorio_redimensionados = "Arquivos_Redimensionados";

    if (!Directory.Exists(diretorio_entrada))
    {
        Directory.CreateDirectory(diretorio_entrada);
    }

      if (!Directory.Exists(diretorio_finalizados))
    {
        Directory.CreateDirectory(diretorio_finalizados);
    }

      if (!Directory.Exists(diretorio_redimensionados))
    {
        Directory.CreateDirectory(diretorio_redimensionados);
    }


    while (true)
    {
        Thread.Sleep(new TimeSpan(0, 0, 3));
    }
}
