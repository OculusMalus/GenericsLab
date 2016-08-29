using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListCLassTask 
{
    class GenericList<T> : IComparer, IEnumerable
    {
        public T[] arrayOfListItems;
        public GenericList()
        {
            arrayOfListItems = new T[1];
        }

        public int Length
        {
            get { return arrayOfListItems.Length; }
        }

        public T this[int index]
        {
            get
            {
                return arrayOfListItems[index];
            }

            set
            {
                arrayOfListItems[index] = value;
            }

        }

        public void StoreListToArray(GenericList<T> list)
        {

            for (int i = 0; i < arrayOfListItems.Length; i++)
            {
                arrayOfListItems[i] = list[i];
                
                //Console.WriteLine(arrayOfListItems[i]);
            }
            Console.WriteLine(arrayOfListItems);
        }

        public Array Add(T itemToAdd)
        {
            T[] temporaryArray = new T[arrayOfListItems.Length + 1];

            for (int i = 0; i < arrayOfListItems.Length; i++)
            {
                temporaryArray[i] = arrayOfListItems[i];
            }

            temporaryArray[arrayOfListItems.Length] = itemToAdd;
            arrayOfListItems = new T[temporaryArray.Length];
            if (arrayOfListItems.Length == temporaryArray.Length)
            {
                arrayOfListItems = new T[temporaryArray.Length * 2];
            }
            arrayOfListItems = temporaryArray;
            return arrayOfListItems;
        }



        public void Remove(T itemToRemove)
        {
            T[] temporaryArray = new T[arrayOfListItems.Length - 1];        //make a temporary array

            int index = Array.IndexOf(arrayOfListItems, itemToRemove);      //find item to remove
            for (int i = index; i < arrayOfListItems.Length - 1; i++)
            {
                arrayOfListItems[i] = arrayOfListItems[i + 1];              //shift contents of array to fill in the hole
            }

            for (int i = 0; i < arrayOfListItems.Length - 1; i++)           //copy contents of array into a temporary array
            {
                temporaryArray[i] = arrayOfListItems[i];
            }
            arrayOfListItems = new T[temporaryArray.Length];                //resize original array and copy contents back
            arrayOfListItems = temporaryArray;

            for (int i = 0; i < arrayOfListItems.Length; i++)
            { Console.WriteLine("{0}", arrayOfListItems[i]); }
            //Console.ReadKey();
            //return arrayOfListItems;
        }

        public override string ToString()
        {
            string newString = ("");
            for (int i=0; i<arrayOfListItems.Length-1; i++)
            {
                if (arrayOfListItems[i] != null)
                {
                    string arrayItemString = arrayOfListItems[i].ToString() + " ";
                    newString += arrayItemString;
                }
                                
            }

            Console.WriteLine("{0}", newString);
            return newString;
        }

        public static GenericList<T> operator +(GenericList<T> list1, GenericList<T> list2)
        {
            GenericList<T> list3 = new GenericList<T>();                                    //create the list to return

            T[] temporaryArray = new T[list1.Length - 1];                    //create the array to temp store whatever the class contains
            for (int i = 0; i < list1.Length - 1; i++)
            {
                temporaryArray[i] = list1[i];                              //store list one in an array 
            }

            for (int i = 0; i < list2.Length - 1; i++)                           //use add method to make one big array
            {
                list1.Add(list2[i]);
            }

            for (int i = 0; i < list3.Length; i++)                          //copy the whole thing over to list3
            {
                list3[i] = temporaryArray[i];
                Console.WriteLine(list3[i]);
            }

            return list3;
        }

        public static GenericList<T> operator -(GenericList<T> list3, GenericList<T> list2)
        {
            GenericList<T> list1 = new GenericList<T>();                                    //create the list to return
            for (int i = 0; i < list3.Length - 1; i++)
            {
                list3.Remove(list2[i]);
            }
            return list1;
        }

        private int ListCount()
        {
            if (arrayOfListItems[0] == null)
            {
                return 0;
            }
            int i = 1;
            while (arrayOfListItems[i] != null)
            {
                i++;
            }

            return i;
        }

        //public GenericList<T> ZipperLists (GenericList<T> list1, GenericList<T> list2)
        //{
        //    arrayOfListItems = new T[list1.arrayOfListItems.Length + list2.arrayOfListItems.Length];

        //    GenericList<T> zippedList = new GenericList<T>();
            
        //    for(int i=0; i<(list1.arrayOfListItems.Length)-1; i++)
        //    {
        //        zippedList.arrayOfListItems[i * 2] = list1.arrayOfListItems[i];
        //        zippedList.arrayOfListItems[i * 2 + 1] = list2.arrayOfListItems[i]; 
        //    }
        //    return zippedList;
        //}

        public void SortList(GenericList<T> list)
        {
            T[] temporaryArray = new T[arrayOfListItems.Length];
            temporaryArray = arrayOfListItems;
            Array.Sort(temporaryArray);
            arrayOfListItems = temporaryArray;
            foreach (T item in arrayOfListItems)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public T[] GenericSort()
        {
            for (int i = 0; i < arrayOfListItems.Length - 1; i++)
            {
                T[] temporaryArray = new T[1];                              //parking spot for swapping items
                for (int j = 0; j < arrayOfListItems.Length - 1; j++)
                {
                    var result = Comparer<T>.Default.Compare(arrayOfListItems[i], arrayOfListItems[i + 1]);
                    if (result < 0)
                    {
                        temporaryArray[0] = arrayOfListItems[i+1];
                        arrayOfListItems[i + 1] = arrayOfListItems[i];
                        arrayOfListItems[1] = temporaryArray[0];
                    }
                }      
            }
            return arrayOfListItems;
        }

        
        

        private void EqualityComparer(T t1, T t2)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < arrayOfListItems.Length-1; i++)
            {
                yield return arrayOfListItems[i];
            }
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}



