namespace CodingChallenges.Graphs.BFS;

/// <summary>
/// Related   : Graph (implicity), Breadth-First Search, Hash Table
/// Title     : 127. Word Ladder
/// Difficult : Hard
/// Link      : https://leetcode.com/problems/word-ladder
/// Approachs : Breadth-First Search
/// </summary>
/// MUITO SEMELHANTE AO DA CLASSE MinimumGeneticMutation
public class WordLadder
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = [.. wordList];
        if (!wordSet.Contains(endWord)) return 0;

        Queue<(string word, int steps)> queue = new();
        queue.Enqueue((beginWord, 1));
        HashSet<string> visited = [];
        visited.Add(beginWord);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();
            if (current == endWord)
                return steps;

            char[] wordLetters = current.ToCharArray();
            for (int i = 0; i < wordLetters.Length; i++)
            {
                char oldChar = wordLetters[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c == oldChar)
                        continue;
                    wordLetters[i] = c;
                    string newWord = new(wordLetters);
                    if (wordSet.Contains(newWord) && !visited.Contains(newWord))
                    {
                        visited.Add(newWord);
                        queue.Enqueue((newWord, steps + 1));
                    }
                }
                wordLetters[i] = oldChar; // restaura
            }
        }

        return 0;
    }
}

/*
Considere:
•	N = tamanho de wordList (número de palavras no dicionário)
•	L = tamanho de cada palavra (assume-se todas com mesmo tamanho)
•	Alfabeto = 26 letras

Complexidade de tempo (execução)
BFS (pior caso)
Cada palavra válida pode entrar na fila no máximo uma vez por causa do visited.
Para cada palavra dequeued (current), você gera vizinhos tentando trocar cada posição (L) por 26 letras:
•	Geração de candidatos: L * 26
•	Para cada candidato:
•	new string(wordLetters) custa O(L) (copia os caracteres para uma nova string)
•	HashSet.Contains e visited.Contains são O(1) amortizado (mas dependem do hash; o hash do string é O(L) na primeira vez que precisa ser computado)
Então, o custo dominante por palavra visitada fica:
•	O(L * 26 * L) = O(26 * L²) = O(L²)
Multiplicando pelo número de palavras visitadas (até N):
•	Tempo total: O(N * 26 * L²) = O(N * L²) (no pior caso)
Observação prática (importante): se você ignorar o custo de construir a string (assumindo O(1), o que não é verdade), muita gente cita O(N * L * 26). No seu código específico, o new string(...) torna O(N * L²) uma estimativa mais fiel.


Complexidade de espaço (memória)
Estruturas principais:
•	wordSet: armazena até N palavras → O(N)
•	visited: armazena até N palavras → O(N)
•	queue: no pior caso pode conter até N palavras → O(N)
•	Temporários por iteração:
•	char[] wordLetters: O(L)
•	newWord strings são alocadas muitas vezes, mas a maioria é lixo rapidamente (conta mais em GC do que em “big-O” de memória retida)
Memória retida (big-O):
•	Espaço: O(N * L) se você contabilizar o armazenamento das strings (cada uma com tamanho L)
•	Muitas análises simplificam para O(N) (assumindo L constante)
Resumo:
•	Tempo (pior caso): O(N * L²)
•	Espaço (retido): O(N * L) (ou O(N) se L for tratado como constante)
*/