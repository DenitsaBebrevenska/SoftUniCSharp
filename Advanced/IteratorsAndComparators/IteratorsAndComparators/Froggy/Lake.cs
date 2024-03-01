using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> _stoneList;

        public Lake(int[] stones)
        {
            _stoneList = stones.ToList();
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _stoneList.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    yield return _stoneList[i];
                }
            }

            for (int i = _stoneList.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 2 == 0)
                {
                    yield return _stoneList[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
