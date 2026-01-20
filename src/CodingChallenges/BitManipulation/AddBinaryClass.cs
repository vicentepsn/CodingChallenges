using System.Text;

namespace CodingChallenges.BitManipulation;

/// <summary>
/// Groups    : Bit Manipulation
/// Title     : 67. Add Binary
/// Difficult : Easy
/// Link      : https://leetcode.com/problems/add-binary
/// Approach  : -
/// </summary>
public class AddBinaryClass
{
    public string AddBinary(string a, string b)
    {
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;
        var sb = new StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;

            if (i >= 0)
            {
                sum += a[i] - '0';
                i--;
            }
            if (j >= 0)
            {
                sum += b[j] - '0';
                j--;
            }

            sb.Insert(0, (sum % 2).ToString()); // adiciona o bit resultante
            //sb.Append((sum % 2).ToString());
            carry = sum / 2; // atualiza o carry
        }

        return sb.ToString();
        //return RevertStringBits(sb);
    }

    //private string RevertStringBits(StringBuilder bits)
    //{
    //    char[] result = new char[bits.Length];
    //    for (int i = 0; i < bits.Length; i++)
    //        result[i] = bits[bits.Length - 1 - i];
    //    return new string(result);
    //}

    public string AddBinary_v2(string a, string b)
    {
        StringBuilder result = new();

        int aIdx = a.Length - 1;
        int bIdx = b.Length - 1;
        bool carry = false;
        char bit = ' ';

        while (aIdx >= 0 && bIdx >= 0){
            if (a[aIdx] == '1' && b[bIdx] == '1'){
                bit = carry == true ? '1' : '0';
                carry = true;
            }
            else if (a[aIdx] == '1' || b[bIdx] == '1'){
                bit = carry == true ? '0' : '1';
                // carry does not change
            }
            else{
                bit = carry == true ? '1' : '0';
                carry = false;
            }
            result.Append(bit);
            aIdx--;
            bIdx--;
        }
        while (aIdx >= 0){
            if (a[aIdx] == '1' && carry)
                bit = '0';
            else {
                bit = (a[aIdx] == '1' || carry) ? '1' : '0';
                carry = false;
            }
            result.Append(bit);
            aIdx--;
        }
        while (bIdx >= 0){
            if (b[bIdx] == '1' && carry)
                bit = '0';
            else {
                bit = (b[bIdx] == '1' || carry) ? '1' : '0';
                carry = false;
            }
            result.Append(bit);
            bIdx--;
        }
        if (carry) 
            result.Append('1');
        
        return new string(result.ToString().Reverse().ToArray());
    }
}
