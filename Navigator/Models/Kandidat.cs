using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace Navigator.Models
{
    public class Kandidat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        private string _ime;
        private string _prezime;
        private string _jmbg;
        private string _god_rodjenja;//DateTime
        private string _email;
        private string _telefon;
        private string _napomena;
        private string _zaposlen_nakon_konkursa;
        private string _datum_izmene;//DateTime

        public int id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }
        public string ime
        {
            get { return _ime; }
            set { _ime = value; OnPropertyChanged("ime"); }
        }
        public string prezime
        {
            get { return _prezime; }
            set { _prezime = value; OnPropertyChanged("prezime"); }
        }
        public string jmbg
        {
            get { return _jmbg; }
            set { _jmbg = value; OnPropertyChanged("jmbg"); }
        }
        public string god_rodjenja
        {
            get { return _god_rodjenja; }
            set { _god_rodjenja = value; OnPropertyChanged("god_rodjenja"); }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("email"); }
        }
        public string telefon
        {
            get { return _telefon; }
            set { _telefon = value; OnPropertyChanged("telefon"); }
        }
        public string napomena
        {
            get { return _napomena; }
            set { _napomena = value; OnPropertyChanged("napomena"); }
        }
        public string zaposlen_nakon_konkursa
        {
            get { return _zaposlen_nakon_konkursa; }
            set { _zaposlen_nakon_konkursa = value; OnPropertyChanged("zaposlen_nakon_konkursa"); }
        }
        public string datum_izmene
        {
            get { return _datum_izmene; }
            set { _datum_izmene = value; OnPropertyChanged("datum_izmene"); }
        }
    }
}
