using System;
using System.Drawing;
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

    FileStream fileStream;
    FileInfo fileInfo;

    while (true)
    {
       
        var arquivosEntrada = Directory.EnumerateFiles(diretorio_entrada);

        int novaAltura = 200;

        foreach (var arquivo in arquivosEntrada)
        {
            fileStream = new FileStream(arquivo, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            fileInfo = new FileInfo(arquivo);

            string caminho = Environment.CurrentDirectory + @"\" + diretorio_redimensionados 
                + @"\" + DateTime.Now.Millisecond.ToString() +"_"+ fileInfo.Name;

            string caminhoFinalizado = Environment.CurrentDirectory + @"\" + diretorio_finalizados 
                + @"\" + fileInfo.Name;

            Redimensionador(Image.FromStream(fileStream), novaAltura, caminho);

            fileStream.Close();

            fileInfo.MoveTo(caminhoFinalizado);
        }
        Thread.Sleep(new TimeSpan(0, 0, 5));
    }
}




static void Redimensionador(Image imagem, int altura, string caminho)
{
    double ratio = (double)altura / imagem.Height;
    int novaLargura = (int)(imagem.Width * ratio);
    int novaAltura = (int)(imagem.Height * ratio);

    Bitmap novaImagem = new Bitmap(novaLargura, novaAltura);

    using (Graphics g = Graphics.FromImage(novaImagem))
    {
        g.DrawImage(imagem, 0, 0, novaLargura, novaAltura);
    }

    novaImagem.Save(caminho);
    imagem.Dispose();
}
