using System;

namespace SandBox.Addition
{
    public class AdditionArrayList
    {
        /*
         sayıları binary'e dönüştürsün
         and xor ve left shifting metodları olacak
         and sonucu carry(elde) ve b olacak ama left shifting uygulanan bir b
         aynı sayılara xor uygulanacak, sonucu b olacak
         b 0 olana yani elde kalmayana kadar devam edecek
         sonuç a
         */
        #region ..Fields..

        #endregion

        #region ..Public Calls..
        public int Add(int A, int B)
        {
            if (B == 0) return A;
            
            List<int> binaryA = ToBinary(A);
            List<int> binaryB = ToBinary(B);
            var result = ArrangeArrays(binaryA, binaryB);
            //
            return Calculate(result.binaryA, result.binaryB);
        }

        private (List<int> binaryA, List<int> binaryB) ArrangeArrays(List<int> binaryA, List<int> binaryB)
        {
            if (binaryA.Count > binaryB.Count) { 
                binaryB = FillWithZeros(binaryB);
            }
            else if (binaryB.Count > binaryA.Count)
            {
                binaryA = FillWithZeros(binaryA);
            }

            return (FillWithZeros(binaryA), FillWithZeros(binaryB));
        }

        private List<int> FillWithZeros(List<int> binaryNumber)
        {
            int length = 0;
            while ((binaryNumber.Count + length) % 16 != 0)
            {
                binaryNumber.Insert(0, 0);
            }

            return binaryNumber;
        }
        #endregion

        #region ..Private Calls..
        private int Calculate(List<int> binaryA, List<int> binaryB)
        {
            if (IsBinaryZero(binaryB)) return ToNumber(binaryA);
            //
            var carry = AndGate(binaryA, binaryB);
            var xorResult = XorGate(binaryA, binaryB);
            var leftShifting = LeftShifting(carry);
            //
            return Calculate(xorResult, leftShifting);
        }

        private bool IsBinaryZero(List<int> binaryNumber2)
        {            
            foreach (var item in binaryNumber2)
            {
                if(item != 0) return false;
            }
            return true;
        }

        private List<int> XorGate(List<int> binaryA, List<int> binaryB)
        {
            var xorResult = new int[binaryA.Count];
            for (int i = 0; i < binaryA.Count; i++)
            {
                xorResult[i] = binaryA[i] == binaryB[i] ? 0 : 1;
            }
            return xorResult.ToList();
        }

        private List<int> AndGate(List<int> binaryA, List<int> binaryB)
        {
            var carry = new int[binaryA.Count];
            for (int i = 0; i < binaryA.Count; i++)
            {
                carry[i] = binaryA[i] == 1 && binaryB[i] == 1 ? 1 : 0;
            }
            return carry.ToList();
        }

        private List<int> LeftShifting(List<int> carryB)
        {
            var binaryResult = new int[carryB.Count];
            for(int i = 0; i < carryB.Count - 1; i++)
            {
                binaryResult[i] = carryB[i + 1];
            }
            binaryResult[carryB.Count - 1] = 0;
            return binaryResult.ToList();
        }

        public List<int> ToBinary(int number)
        {
            string binaryString = Convert.ToString(number, 2);
            return binaryString.ToCharArray().Select(x => Convert.ToInt32(Convert.ToString(x))).ToList();
        }

        public int ToNumber(List<int> binaryNumber)
        {
            var total = 0;
            var multiplier = 1;
            var charNumber = binaryNumber.Select(x => Convert.ToChar(x));
            for (int i = binaryNumber.Count - 1; i > 0; i--)
            {
                total = total + (binaryNumber[i] * multiplier);
                multiplier = multiplier * 2;
            }
            return total;
        } 
        #endregion
    }
}
