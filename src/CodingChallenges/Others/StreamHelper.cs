namespace CodingChallenges.Others;

// Amazon interview Live Coding (Problem Solving) 2025-12-12
// Descrição e testes no projeto de entrevistas
public class StreamHelper
{
    public static List<int> GetRepeatedFrames(Stream stream, int windowSize)
    {
        List<int> repeatedFrames = [];

        Dictionary<int, int> itensInWindows = [];
        Queue<int> windowsQueue = [];

        while (stream.HasNext())
        {
            int value = stream.Next();

            if (itensInWindows.ContainsKey(value))
            {
                repeatedFrames.Add(value);

                itensInWindows[value]++;

            }
            else
                itensInWindows[value] = 1;

            if (windowsQueue.Count == windowSize)
            {
                int removedValue = windowsQueue.Dequeue();

                if (itensInWindows[removedValue] == 1)
                    itensInWindows.Remove(removedValue);
                else
                    itensInWindows[removedValue]--;
            }

            windowsQueue.Enqueue(value);
        }

        return repeatedFrames;
    }
}


public class Stream
{
    private readonly int[] _data;
    private int _position = 0;

    public Stream(int[] data)
    {
        _data = data;
    }

    public int Next()
    {
        return _data[_position++];
    }

    public bool HasNext()
        => _position < _data.Length;
}