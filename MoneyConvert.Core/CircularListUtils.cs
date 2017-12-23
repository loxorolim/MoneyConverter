namespace MoneyConvert.Core
{
    /// <summary>
    /// Class with circular list methods.
    /// </summary>
    public static class CircularListUtils
    {
        /// <summary>
        /// Verifies if value exists on circular list of integers.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="values"></param>
        /// <returns> True if exists, false otherwise.</returns>
        public static bool Exists(int val, int[] values)
        {
            //Comentário para avaliador: A lógica é basicamente a seguinte. Primeiro determina-se o centro da lista. O centro é a 
            // posição onde os valores da esquerda ou da direita são ambos maiores ou menores do que o valor do centro.
            // Essa peculiaridade garante que teremos duas listas ordenadas, uma formada pelos valores à esquerda do centro e outra
            // formada pelos valores à direita do centro. A busca do centro é feita em ordem de log(n). As duas listas (a da esquerda e
            // a da direita) são ambas ordenadas dada a característica do problema. A partir daí, executa-se uma busca binária
            // verificar se o valor existe em uma delas. Se sim, retorna verdadeiro, caso contrário, retorna falso.

            int centerPosition = GetCenterPosition(values, 0, values.Length - 1);

            if (centerPosition == -1)
            {
                return values.MyBinarySearch(val, 0, values.Length - 1) == -1 ? false : true;
            }

            int leftSearch = values.MyBinarySearch(val, 0, centerPosition);

            if (leftSearch != -1)
            {
                return true;
            }

            int rightSearch = values.MyBinarySearch(val, centerPosition, values.Length - 1);

            if (rightSearch != -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines the position in array where the following criteria is met.
        /// All values on the left and on the right of this position are either all greater or all smaller 
        /// than the value of this position.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="startPos"></param>
        /// <param name="lastPos"></param>
        /// <returns> The position of the center. -1 if no center exists.</returns>
        public static int GetCenterPosition(int[] values, int startPos, int lastPos)
        {
            int middlePosition = startPos + ((lastPos - startPos) / 2);

            if (values.Length < 3)
            {
                return -1;
            }
            if (IsCenter(middlePosition, values))
            {
                return middlePosition;
            }
            if (startPos == lastPos)
            {
                return -1;
            }

            int leftCenterPosition = GetCenterPosition(values, startPos, middlePosition);

            if (leftCenterPosition != -1)
                return leftCenterPosition;

            int rightCenterPosition = GetCenterPosition(values, middlePosition + 1, lastPos);

            return rightCenterPosition;

        }

        /// <summary>
        /// Determines if the position is a center position in an array.
        /// </summary>
        /// <param name="middlePosition"></param>
        /// <param name="values"></param>
        /// <returns> True if it is center, false otherwise.</returns>
        public static bool IsCenter(int middlePosition, int[] values)
        {
            int middle = values[middlePosition];
            int left = middlePosition == 0 ? values[middlePosition] : values[middlePosition - 1];
            int right = middlePosition == values.Length - 1 ? values[middlePosition] : values[middlePosition + 1];

            if (left < middle && right < middle)
                return true;
            if (left > middle && right > middle)
                return true;

            return false;
        }

    }
}
