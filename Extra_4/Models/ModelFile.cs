using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Extra_4.Models
{
    public class ModelFile
    {
        public string numero { get; private set; }
        public string nome { get; private set; }
        public string curso { get; private set; }

        public delegate void MethodWithoutParameters();

        public event MethodWithoutParameters CloseRead;
        public event MethodWithoutParameters CloseWrite;

        public void ReadFile(string file)
        {
            // Leitura do ficheiro file

            StreamReader sr = new StreamReader(file);
            numero = sr.ReadLine();
            nome = sr.ReadLine();
            curso = sr.ReadLine();
            sr.Close();

            if (CloseRead != null)
                CloseRead();
        }
        public void WriteFile(string file, string numero, string nome, string curso)
        {
            // Escrita no ficheiro file

            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(numero);
            sw.WriteLine(nome);
            sw.WriteLine(curso);
            sw.Close();

            if (CloseWrite != null)
                CloseWrite();
        }
    }
}
