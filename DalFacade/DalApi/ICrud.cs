using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface ICrud
    {
        public interface ICrud<T>
        {
            int Create(T item); //יוצר אובייקט ישות חדש 
            T? Read(int id); //קורא אובייקט ישות לפי המזהה שלו 
            List<T> ReadAll(); //קורא את כל האובייקטים של הישות
            void Update(T item); //מעדכן את אובייקט בישות
            void Delete(int id); //מוחק את האובייקט לפי המזהה שלו

        }
    }
}
