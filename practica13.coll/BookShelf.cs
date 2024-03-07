using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica13.coll
{
    internal class BookShelf
    {
        private string nazv;
        private string avtor;
        private string ganre;
        private int grade = 0;
        public void Set(string name, string avtor, string ganre, int grades)
        {
            this.nazv = name;
            this.avtor = avtor;
            this.ganre = ganre;
            this.grade = grades;
        }
        public string getNazv()
        {
            return nazv;
        }
        public string getAvtor()
        {
            return avtor;
        }
        public string getGanre()
        {
            return ganre;
        }
        public int getGrade()
        {
            return grade;
        }
    }
}
