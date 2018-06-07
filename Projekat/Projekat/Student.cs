using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Student
    {
        private string ime;
        private string prezime;
        private string godina;
        private string fakultet;
        private string dom;
        private string komentar;

        public Student(string ime, string prezime, string godina, string fakultet, string dom, string komentar)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.dom = dom;
            this.fakultet = fakultet;
            this.godina = godina;
            this.komentar = komentar;
        }
    }
}
