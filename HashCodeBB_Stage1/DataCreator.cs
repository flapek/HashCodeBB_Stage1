using System;
using System.Collections.Generic;
using System.Text;

namespace HashCodeBB_Stage1
{
    class DataCreator
    {
        public DataCreator()
        {
        }

        public static string CreateString(List<int> order)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{order.Count}\n");
            for (int i = 0; i < order.Count; i++)
            {
                if (i == order.Count - 1)
                    builder.Append($"{order[i]}\n");
                else
                    builder.Append($"{order[i]} ");
            }

            return builder.ToString();
        }
    }
}
