namespace CodingChallenges.Graphs.BFS;

/// <summary>
/// Related   : Graph (implicity), Breadth-First Search, Hash Table
/// Title     : 433. Minimum Genetic Mutation
/// Difficult : Medium
/// Link      : https://leetcode.com/problems/minimum-genetic-mutation
/// Approachs : Breadth-First Search
/// </summary>
/// MUITO SEMELHANTE AO DA CLASSE WordLadder
public class MinimumGeneticMutation
{
    // Versão gerada pelo CGPT
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        HashSet<string> bankSet = [..bank];
        if (!bankSet.Contains(endGene)) return -1;

        char[] choices = ['A', 'C', 'G', 'T'];
        Queue<(string gene, int steps)> queue = new ();
        queue.Enqueue((startGene, 0));
        HashSet<string> visited = [];
        visited.Add(startGene);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();
            if (current == endGene)
                return steps;

            char[] geneArray = current.ToCharArray();
            for (int i = 0; i < geneArray.Length; i++)
            {
                char oldChar = geneArray[i];
                foreach (char c in choices)
                {
                    if (c == oldChar)
                        continue;
                    geneArray[i] = c;
                    string newGene = new (geneArray);
                    if (bankSet.Contains(newGene) && !visited.Contains(newGene))
                    {
                        visited.Add(newGene);
                        queue.Enqueue((newGene, steps + 1));
                    }
                }
                geneArray[i] = oldChar; // restaura
            }
        }

        return -1;
    }
}

/*
🧬 Entendendo o enunciado
- Cada gene é uma string de 8 caracteres formada apenas por 'A', 'C', 'G', 'T'.
- Uma mutação é definida como alterar apenas 1 caractere da string.
- Exemplo: "AACCGGTT" → "AACCGGTA" (mudou o último caractere de T para A).
- Só podemos considerar mutações que existem no banco (bank).
Ou seja, não basta mudar um caractere, o resultado precisa estar listado no banco para ser válido.
- O objetivo é calcular o mínimo número de mutações necessárias para transformar startGene em endGene.
- Se não for possível chegar ao endGene usando apenas genes válidos do banco, retornamos -1.

🔎 Exemplos adicionais
startGene = "AAAAACCC"
endGene   = "AACCCCCC"
bank      = ["AAAACCCC", "AAACCCCC", "AACCCCCC"]


- "AAAAACCC" → "AAAACCCC" (1 mutação)
- "AAAACCCC" → "AAACCCCC" (2 mutações)
- "AAACCCCC" → "AACCCCCC" (3 mutações)
Resultado: 3
startGene = "AAAAACCC"
endGene   = "AACCCCCC"
bank      = ["AAAACCCC", "AAACCCCC"]


- Não existe "AACCCCCC" no banco, então não conseguimos chegar ao fim.
Resultado: -1
startGene = "AACCGGTT"
endGene   = "AACCGGTA"
bank      = ["AACCGGTA"]


- Uma única mutação válida.
Resultado: 1

💡 Estratégia de solução
Esse problema é um grafo implícito:
- Cada gene é um nó.
- Existe uma aresta entre dois genes se eles diferem em apenas 1 caractere.
- O banco define quais nós são válidos.
- Precisamos encontrar o menor caminho de startGene até endGene.
👉 Isso é um clássico caso de BFS (Breadth-First Search).

🖥️ Código em C#
using System;
using System.Collections.Generic;

✅ Como funciona o código
- Colocamos o startGene na fila com 0 passos.
- A cada passo, tentamos todas as mutações possíveis (mudando 1 caractere para 'A', 'C', 'G', 'T').
- Se a mutação está no banco e ainda não foi visitada, adicionamos à fila.
- Quando chegamos ao endGene, retornamos o número de passos.
- Se a fila esvaziar sem encontrar o endGene, retornamos -1.

Quer que eu monte uma simulação passo a passo mostrando como o BFS percorre os genes em um dos exemplos (tipo o exemplo 2 que dá resultado 2)?
*/