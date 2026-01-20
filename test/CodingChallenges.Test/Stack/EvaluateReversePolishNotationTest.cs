using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.Stack.Test;

public class EvaluateReversePolishNotationTest
{
    [Fact]
    public void Test01()
    {
        string[] tokens = ["2", "1", "+", "3", "*"];
        int expected = 9;

        int output = EvaluateReversePolishNotation.EvalRPN_v2(tokens);

        Assert.Equal(expected, output);
    }
}
