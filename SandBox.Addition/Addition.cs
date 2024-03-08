using System;

namespace SandBox.Addition
{
    public class Addition
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

            int[] binaryA = ToBinary(A);
            int[] binaryB = ToBinary(B, binaryA.Length);
            var result = ArrangeArrays(binaryA, binaryB);
            //
            return Calculate(result.binaryA, result.binaryB);
        }

        private (int[] binaryA, int[] binaryB) ArrangeArrays(int[] binaryA, int[] binaryB)
        {
            if (binaryA.Length > binaryB.Length) { 
                var zeroArray = new int[binaryA.Length - binaryB.Length];
                binaryB = Merge(zeroArray, binaryB);
            }
            else if (binaryB.Length > binaryA.Length)
            {
                var zeroArray = new int[binaryB.Length - binaryA.Length];
                binaryA = Merge(zeroArray, binaryA);
            }

            return (FillWithZeros(binaryA), FillWithZeros(binaryB));
        }

        private int[] FillWithZeros(int[] binaryNumber)
        {
            int length = 0;
            while ((binaryNumber.Length + length) % 16 != 0)
            {
                length++;
            }

            int[] finalArray = new int[length + binaryNumber.Length];
            new int[length].CopyTo(finalArray, 0);
            binaryNumber.CopyTo(finalArray, length);

            return finalArray;
        }

        private int[] Merge(int[] zeroArray, int[] number)
        {
            int[] mergedArray = new int[zeroArray.Length + number.Length];
            zeroArray.CopyTo(mergedArray, 0);
            number.CopyTo(mergedArray, zeroArray.Length);

            return mergedArray;
        }
        #endregion

        #region ..Private Calls..
        private int Calculate(int[] binaryA, int[] binaryB)
        {
            if (IsBinaryZero(binaryB)) return ToNumber(binaryA);
            //
            var carry = AndGate(binaryA, binaryB);
            var xorResult = XorGate(binaryA, binaryB);
            var leftShifting = LeftShifting(carry);
            //
            return Calculate(xorResult, leftShifting);
        }

        private bool IsBinaryZero(int[] binaryNumber2)
        {            
            foreach (var item in binaryNumber2)
            {
                if(item != 0) return false;
            }
            return true;
        }

        private int[] XorGate(int[] binaryA, int[] binaryB)
        {
            var binaryBResult = new int[binaryA.Length];
            for (int i = 0; i < binaryA.Length; i++)
            {
                binaryBResult[i] = binaryA[i] == binaryB[i] ? 0 : 1;
            }
            return binaryBResult;
        }

        private int[] AndGate(int[] binaryA, int[] binaryB)
        {
            var binaryBResult = new int[binaryA.Length];
            for (int i = 0; i < binaryA.Length; i++)
            {
                binaryBResult[i] = binaryA[i] == 1 && binaryB[i] == 1 ? 1 : 0;
            }
            return binaryBResult;
        }

        private int[] LeftShifting(int[] carryB)
        {
            var binaryResult = new int[carryB.Length];
            for(int i = 0; i < carryB.Length - 1; i++)
            {
                binaryResult[i] = carryB[i + 1];
            }
            binaryResult[carryB.Length - 1] = 0;
            return binaryResult;
        }

        public int[] ToBinary(int number, int? length = null)
        {
            string binaryString = Convert.ToString(number, 2);
            return binaryString.ToCharArray().Select(x => Convert.ToInt32(Convert.ToString(x))).ToArray();
        }

        public int ToNumber(int[] binaryNumber)
        {
            var total = 0;
            var multiplier = 1;
            var charNumber = binaryNumber.Select(x => Convert.ToChar(x));
            for (int i = binaryNumber.Length - 1; i > 0; i--)
            {
                total = total + (binaryNumber[i] * multiplier);
                multiplier = multiplier * 2;
            }
            return total;
        } 
        #endregion
    }
}
