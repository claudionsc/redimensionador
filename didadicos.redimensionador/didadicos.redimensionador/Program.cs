using System;
using System.Threading;

Console.WriteLine("Iniciando nosso projeto");

Thread thrad = new Thread(Redimensionar);
thrad.Start();  

Console.Read();


static void Redimensionar()
{
    #region "Diretorios"
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
    #endregion

    while (true)
    {
        //Meu programa vai olhar para a pasta de entrada
        //SE tiver arquivo ele irá redimensionar
        var arquivos_entrada = Directory.EnumerateFiles(diretorio_entrada);

        foreach (var item in arquivos_entrada )
        {
            Console.WriteLine(item);
        };

        //Ler o tamanho que irá redimensionar
        //Redimensiona
        //Copia os arquivos redimensionados para a pasta de redimensionados
        //Move o arquivo de entrada para a pasta de finalizados

        Thread.Sleep(new TimeSpan(0, 0, 3));
    }
}
