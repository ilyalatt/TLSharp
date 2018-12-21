using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleSharp.TL
{
    public class TLVector<T> : TLObject, IList<T>
    {
        [TLObject(481674261)]
        private readonly List<T> _lists = new List<T>();

        public T this[int index]
        {
            get => _lists[index];
            set => _lists[index] = value;
        }

        public override int Constructor => 481674261;

        public int Count => _lists.Count;

        public bool IsReadOnly => ((IList<T>)_lists).IsReadOnly;

        public void Add(T item)
        {
            _lists.Add(item);
        }

        public void Clear()
        {
            _lists.Clear();
        }

        public bool Contains(T item)
        {
            return _lists.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _lists.CopyTo(array, arrayIndex);
        }

        public override void DeserializeBody(BinaryReader br)
        {
            var count = br.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                if (typeof(T) == typeof(int))
                {
                    _lists.Add((T)Convert.ChangeType(br.ReadInt32(), typeof(T)));
                }
                else if (typeof(T) == typeof(long))
                {
                    _lists.Add((T)Convert.ChangeType(br.ReadInt64(), typeof(T)));
                }
                else if (typeof(T) == typeof(string))
                {
                    _lists.Add((T)Convert.ChangeType(StringUtil.Deserialize(br), typeof(T)));
                }
                else if (typeof(T) == typeof(double))
                {
                    _lists.Add((T)Convert.ChangeType(br.ReadDouble(), typeof(T)));
                }
                else if (typeof(T).BaseType == typeof(TLObject))
                {
                    var constructor = br.ReadInt32();
                    var type = TLContext.GetType(constructor);
                    var obj = Activator.CreateInstance(type);
                    type.GetMethod("DeserializeBody").Invoke(obj, new object[] { br });
                    _lists.Add((T)Convert.ChangeType(obj, type));
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _lists.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _lists.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _lists.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _lists.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _lists.RemoveAt(index);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(_lists.Count());

            foreach (var item in _lists)
            {
                if (typeof(T) == typeof(int))
                {
                    var res = (int)Convert.ChangeType(item, typeof(int));

                    bw.Write(res);
                }
                else if (typeof(T) == typeof(long))
                {
                    var res = (long)Convert.ChangeType(item, typeof(long));
                    bw.Write(res);
                }
                else if (typeof(T) == typeof(string))
                {
                    var res = (string)(Convert.ChangeType(item, typeof(string)));
                    StringUtil.Serialize(res, bw);
                }
                else if (typeof(T) == typeof(double))
                {
                    var res = (double)Convert.ChangeType(item, typeof(double));
                    bw.Write(res);
                }
                else if (typeof(T).BaseType == typeof(TLObject))
                {
                    var res = (TLObject)(object)item;
                    res.SerializeBody(bw);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lists.GetEnumerator();
        }
    }
}
