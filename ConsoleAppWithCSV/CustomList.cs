using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
namespace ConsoleAppWithCSV
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity=4;
        public int Count{get{return _count;}}
        public int Capacity{get{return _capacity;}}
        private Type[] _array;
        public Type this[int index]
        {
            get{return _array[index];}
            set{_array[index]=value;}
        }
        public CustomList()
        {
            _array=new Type[_capacity];
        }
        public CustomList(int size)
        {
            _capacity=size;
            _array=new Type[_capacity];
        }
        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowArraySize();
            }
            _array[_count++]=element;
        }
        void GrowArraySize()
        {
            _capacity=_capacity*2;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
            //temp=null;
        }
        public void AddRange(CustomList<Type> elements)
        {
            _capacity=_count+elements.Count;
            Type[] temp=new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            int k=0;
            for(int i=_count;i<_capacity;i++)
            {
                temp[i]=elements[k++];
            }
            _array=temp;
            //incrementing the count pointer to new array count
            _count+=elements.Count;
            //temp=null;
        }
        public int IndexOf(Type element)
        {
            for(int i=0;i<_count;i++)
            {
                if(_array[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }
        public bool BinarySearch(string propertyName,string element,out Type currentUser)
        {
            //set to default incase found no user
            currentUser=default;
            //property name need to be searched
            PropertyInfo property=typeof(Type).GetProperty(propertyName);
            int low=0;
            int high=_count-1;
            int mid=0;
            while(low<=high)
            {
                //mid value
                mid=(low+high)/2;
                //getting property value through GetValue method
                if(property.GetValue(_array[mid]).Equals(element))
                {
                    //setting current user global  
                    currentUser=_array[mid];
                    return true;
                }
                else if(Comparator(property.GetValue(_array[mid]),element)>0)
                {
                    //return +1 if object's primary key greater than entered primary key
                    high=mid-1;
                }
                else
                {
                    //if less than
                    low=mid+1;
                }
            }
            return false;
        }

        public int Comparator(object value1,object value2)
        {
            //return 0 if equal, 1 if greater -1 if small
            return Comparer<object>.Default.Compare(value1,value2);
        }
        
    }
}