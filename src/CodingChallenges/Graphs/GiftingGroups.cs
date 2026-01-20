namespace CodingChallenges.Graphs;

/// <summary>
/// Amazon - HackerRank codeing demo
/// </summary>
public class GiftingGroups
{
    public static int countGroups(List<string> related)
    {
        List<int>[] groups = new List<int>[related.Count];
        for (int i = 0; i < related.Count; i++)
            groups[i] = new List<int> { i };

        int groupsCount = related.Count;

        for (int i = 0; i < related.Count - 1; i++)
        {
            var row = related[i];
            for (int j = i + 1; j < related.Count; j++)
            {
                if (row[j] == '1' && groups[i] != groups[j])
                {
                    MergeGroups(groups, i, j);
                    groupsCount--;
                }
            }
        }

        return groupsCount;
    }

    private static void MergeGroups(List<int>[] groups, int a, int b)
    {
        if (groups[b].Count > groups[a].Count)
        {
            MergeGroups(groups, b, a);
            return;
        }

        groups[a].AddRange(groups[b]);

        foreach (var sub in groups[b])
        {
            groups[sub] = groups[a];
        }
    }

    public static int countGroups_Opt(List<string> related)
    {
        int groupCount = related.Count;
        if (groupCount <= 1)
            return groupCount;

        int[] personGroup = new int[related.Count];
        for (int i = 1; i < related.Count; i++)
            personGroup[i] = i;

        for (int a = 0; a < related.Count - 1; a++)
        {
            for (int b = a + 1; b < related.Count; b++)
            {
                if (related[a][b] == '1')
                {
                    int groupA = getCurrentPersonsGroup(personGroup, a);
                    int groupB = getCurrentPersonsGroup(personGroup, b);
                    if (groupA != groupB)
                    {
                        groupCount--;
                        personGroup[Math.Max(groupA, groupB)] = personGroup[Math.Min(groupA, groupB)];
                    }
                }
            }
        }

        return groupCount;
    }

    private static int getCurrentPersonsGroup(int[] personGroup, int person)
    {
        if (personGroup[person] == person)
            return person;

        personGroup[person] = getCurrentPersonsGroup(personGroup, personGroup[person]);
        return personGroup[person];
    }


}
