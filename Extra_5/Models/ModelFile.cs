using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Extra_5.Models
{
    public class ModelFile
    {
        public delegate void MethodWithoutParameters();

        // Guarda o texto do ficheiro

        public string text { get; private set; }

        // Eventos

        public event MethodWithoutParameters CloseRead;
        public event MethodWithoutParameters CloseWrite;
        public event MethodWithoutParameters WordReplaced;

        public void ReadFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            text = sr.ReadToEnd();
            sr.Close();

            // Notifica que a leitura foi um sucesso e terminou, (ver View)

            if (CloseRead != null)
                CloseRead();
        }
        public void WriteFile(string fileName, string text)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(text);
            sw.Close();

            // Notifica que a escrita foi um sucesso e terminou, (ver View)
            if (CloseWrite != null)
                CloseWrite();
        }
        // Função que conta o nº de parágrafos do ficheiro lido e carregado para a tbFileText (MainWindow).
        public int CountParagraphs(string text)
        {
            int count = 0, index = 0;

            // Ciclo que percorre a string interira

            while (index < text.Length)
            {
                if (text[index] == '\t')
                    count++;
                index++;
            }
            return count;
        }
        // Função que conta o nº de palavras do ficheiro lido e carregado para a tbFileText (MainWindow).
        public int CountWords(string text)
        {
            int count = 0, index = 0;

            // No caso de a string começar com espaços, avança para o primeiro caractere

            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;

            // Avança até chegar ao fim da string

            while (index < text.Length)
            {
                // Avança até encontrar um espaço e só depois é que adiciona ao contador

                while (index < text.Length && !char.IsWhiteSpace(text[index]))
                    index++;
                count++;

                // No caso de ter dois espaços seguidos

                while (index < text.Length && char.IsWhiteSpace(text[index]))
                    index++;
            }
            return count;
        }
        // Função que conta o nº de caracteres (incluindo \n e espaços) do ficheiro lido e carregado para a tbFileText.
        // Não uso text.Length porque este contabiliza também o \r e o \t, algo que não quero que conte.
        public int CountCharacters(string text)
        {
            int count = 0, index = 0;

            while (index < text.Length)
            {
                if (text[index] != '\r' && text[index] != '\t')
                    count++;

                // Uma mudança de linha não equivale a um caractere, apenas um sperador branco.

                if (text[index] == '\r' && text[index + 1] == '\n' && text[index + 2] != '\r')
                    count--;
                index++;
            }
            return count;
        }
        // Função que conta o número de vezes que a palavra alunos/Alunos aparece no ficheiro lido e carregado para a tbFileText
        public int CountAlunos(string text)
        {
            int count = 0, index = 0;

            // Ciclo que percorre a string interira

            while (index < text.Length)
            {
                // Procura por A ou a, (início da palavra Alunos/alunos)

                if (text[index] == 'a' || text[index] == 'A')
                {
                    // Evita erros de memória não alocada

                    if (text.Length - index >= 6)
                    {
                        // Uma vez que a palavra alunos tem 6 caracteres podemos usar o método substring(index,6)
                        // Se fosse uma palavra random, em vez de 5 podiamos usar word.Length

                        if (text.Substring(index, 6) == "Alunos" || text.Substring(index, 6) == "alunos")
                        {
                            count++;
                            index += 5;
                            continue;
                        }
                    }
                }
                index++;
            }
           return count;
        }
        // Função que substitui todas as ocorrências de uma palavra por uma outra palavra
        public bool ReplaceWord(string text, string oldWord, string newWord)
        {
            if (text == null || oldWord == null || newWord == null)
                return false;
            // Verifica se existe alguma ocorrência da palavra a substituir
            if (!text.Contains(oldWord))
                return false;
            // Usamos o método .replace para substituir
            this.text = text.Replace(oldWord, newWord);
            if (WordReplaced != null)
                WordReplaced();
            return true;
        }
        // Função que apaga todo o texto entre parênteses.
        // Foi usado regex.
        public bool DeleteText(string text)
        {
            if (text == null)
                return false;
            // Verifica se existe algum texto entre parênteses
            if (!text.Contains('(') || !text.Contains(')'))
                return false;

            // Remove texto entre parênteses.
            text = Regex.Replace(text, @"\([^)]*\)", "");


            // No final atualiza o this.text para poder atualizar a MainWindow
            this.text = text;
            return true;
        }
    }
}
