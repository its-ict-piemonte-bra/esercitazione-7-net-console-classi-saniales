using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    /// <summary>
    /// Questa classe gestisce un vettore di interi e fornisce
    /// diversi metodi di appoggio.
    /// </summary>
    public class Vettore
    {
        /// <summary>
        /// Il vettore di interi gestito
        /// </summary>
        public int[] vettore;
        //public int[] _vettore;

        /// <summary>
        /// Crea una nuova istanza vuota dell'oggetto Vettore
        /// </summary>
        public Vettore()
        {
            // Metodo costruttore 1: vuoto
            vettore = new int[0];
        }

        /// <summary>
        /// Crea una nuova istanza dell'oggetto Vettore,
        /// a partire dall'array specificato
        /// </summary>
        /// <param name="vettore">L'array da gestire</param>
        /// <exception cref="ArgumentNullException">Quando si passa un array null</exception>
        public Vettore(int[] vettore)
        {
            if (vettore == null)
            {
                throw new ArgumentNullException("Non è possibile inizializzare la classe con un vettore nullo");
            }

            this.vettore = vettore;
            //_vettore = vettore;
        }

        /// <summary>
        /// Calcola il valore medio di tutte le celle
        /// </summary>
        /// <returns>Il valore medio</returns>
        public float ValoreMedio()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Non si può fare la media su un vettore vuoto");
            }

            float sum = 0;

            foreach (int value in vettore)
            {
                sum += value;
            }

            return sum / vettore.Length;
        }

        /// <summary>
        /// Restituisce se un vettore è vuoto oppure no
        /// </summary>
        /// <returns>true se il vettore è vuoto, altrimenti false</returns>
        public bool isEmpty()
        {
            return vettore.Length == 0;
        }

        /// <summary>
        /// Restituisce il valore massimo all'interno del vettore
        /// </summary>
        /// <returns>Il valore massimo</returns>
        /// <exception cref="InvalidOperationException">Se il vettore è vuoto</exception>
        public int ValoreMassimo()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Non si può ottenere il massimo valore di un vettore vuoto");
            }

            int max = vettore[0];

            for (int i = 1; i < vettore.Length; i++)
            {
                if (vettore[i] > max)
                {
                    max = vettore[i];
                }
            }

            return max;
        }

        /// <summary>
        /// Restituisce il valore minimo all'interno del vettore
        /// </summary>
        /// <returns>Il valore minimo</returns>
        /// <exception cref="InvalidOperationException">Se il vettore è vuoto</exception>
        public int ValoreMinimo()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("Non si può ottenere il massimo valore di un vettore vuoto");
            }

            int min = vettore[0];

            for (int i = 1; i < vettore.Length; i++)
            {
                if (vettore[i] < min)
                {
                    min = vettore[i];
                }
            }

            return min;
        }

        /// <summary>
        /// Stampa solamente i numeri pari a video, uno per riga
        /// </summary>
        public void printEvenNumbers()
        {
            for (int i = 0; i < vettore.Length; i++)
            {
                if (vettore[i] % 2 == 0)
                {
                    Console.WriteLine(vettore[i]);
                }
            }
        }

        /// <summary>
        /// Ordina l'array con l'algoritmo di ordinamento per selezione
        /// </summary>
        public void sort()
        {
            for (int i = 0; i < vettore.Length - 1; i++)
            {
                int minIndex = i;
                int min = vettore[i];

                for (int j = i + 1; j < vettore.Length; j++)
                {
                    if (vettore[j] < min)
                    {
                        minIndex = j;
                        min = vettore[j];
                    }
                }

                // ottimizzazione, scambio solo se necessario
                if (minIndex != i)
                {
                    int temp = vettore[i];
                    vettore[i] = vettore[minIndex];
                    vettore[minIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Restituisce la rappresentazione del vettore, sotto forma di 
        /// stringa CSV (valori separati da virgola)
        /// </summary>
        /// <returns>La rappresentazione del vettore</returns>
        /// <example>
        /// int[] sorgente = new int[] { 1, 2, 3, 4, 5 };
        /// Vettore v = new Vettore(sorgente);
        /// Console.WriteLine(v); // [ 1, 2, 3, 4, 5 ]
        /// </example>
        public override string ToString()
        {
            string result = "[ ";

            if (!isEmpty())
            {
                for (int i = 0; i < vettore.Length - 1; i++)
                {
                    result += $"{vettore[i]}, ";
                }

                result += $"{vettore[vettore.Length - 1]} ";
            }

            result += "]";

            return result;
        }

        /// <summary>
        /// Serializza l'oggetto sul file specificato
        /// </summary>
        /// <param name="path">Il percorso del file</param>
        public void Serialize(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(vettore.ToString());
            writer.Close();
        }

        /// <summary>
        /// Carica un nuovo oggetto vettore a partire dal file
        /// specificato come parametro
        /// </summary>
        /// <param name="path">Il percorso del file</param>
        /// <returns>L'oggetto Vettore generato</returns>
        public static Vettore Deserialize(string path)
        {

        }
    }
}
