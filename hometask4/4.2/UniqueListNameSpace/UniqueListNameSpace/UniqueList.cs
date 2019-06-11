using System;
using LinkedList;

namespace UniqueListNameSpace
{
    public class UniqueList : MyList
    {
        /// <summary>
        /// Method for adding elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public override void AddAt(int index, string data)
        {
            if (DoesElementExist(data))
            {
                throw new AddSameElementsException("You can not add this element!", data);
            }
            base.AddAt(index, data);
        }

        /// <summary>
        /// Method for removing elements.
        /// </summary>
        /// <param name="data">Value of the element.</param>
        public override void RemoveByData(string data)
        {
            if (!DoesElementExist(data))
            {
                throw new RemoveNotExistentElementException("You can not remove this element!", data);
            }
            base.RemoveByData(data);
        }

        public override void SetValueByPosition(int index, string data)
        {
            if (DoesElementExist(data))
            {
                throw new AddSameElementsException("You can not set this value!", data);
            }
            base.SetValueByPosition(index, data);
        }
    }
}
