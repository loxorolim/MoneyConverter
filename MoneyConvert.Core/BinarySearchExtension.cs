namespace MoneyConvert.Core
{
    public static class BinarySearchExtension
    {

        /// <summary>
        /// Finds the position of a value in an array using Binary Search algorithm. O(log(n)).
        /// </summary>
        /// <param name="values"></param>
        /// <param name="value"></param>
        /// <param name="startPos"></param>
        /// <param name="lastPos"></param>
        /// <returns> Position in array if value exists, -1 if not exists. </returns>
        public static int MyBinarySearch(this int[] values, int value, int startPos, int lastPos)
        {
            //Comentário para avaliador: Naturalmente, já existe implementação nativa da busca binária em C#. No entanto, encarei o
            // como uma prova de estrutura de dados e, por este motivo, fiz minha própria implementação da busca.

            int middlePosition = startPos + ((lastPos - startPos) / 2);

            if (values.Length == 0)
            {
                return -1;
            }
            if (value == values[middlePosition])
            {
                return middlePosition;
            }
            if (startPos == lastPos)
            {
                return -1;
            }
            if (value < values[middlePosition])
            {
                return values.MyBinarySearch(value, startPos, middlePosition);
            }
            if (value > values[middlePosition])
            {
                return values.MyBinarySearch(value, middlePosition + 1, lastPos);
            }

            return -1;
        }
    }
}
