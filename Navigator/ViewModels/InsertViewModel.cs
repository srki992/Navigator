using Navigator.Commands;
using Navigator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigator.ViewModels
{
    public class InsertViewModel : INotifyPropertyChanged, IInsertViewModel
    {
        //KandidatiService ObjKandidatiService;
        IKandidatiService ObjKandidatiService;
        public InsertViewModel(IKandidatiService ObjKandidatiService)
        {
            this.ObjKandidatiService = ObjKandidatiService;
            //ObjKandidatiService = new KandidatiService();
            _SaveCommand = new RelayCommand(Insert);
            EndDate = DateTime.Today;
        }
        public delegate void OnDatabaseSubmitInsert();
        public static event OnDatabaseSubmitInsert Osvezi;
        #region Propertiji
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        private string _txtIme;
        public string txtIme
        {
            get { return _txtIme; }
            set { _txtIme = value; OnPropertyChanged("txtIme"); }
        }
        private string _txtPrezime;
        public string txtPrezime
        {
            get { return _txtPrezime; }
            set { _txtPrezime = value; OnPropertyChanged("txtPrezime"); }
        }
        private string _txtJMBG;
        public string txtJMBG
        {
            get { return _txtJMBG; }
            set { _txtJMBG = value; OnPropertyChanged("txtJMBG"); }
        }
        public DateTime EndDate { get; set; }
        private DateTime _txtGodRodjenja = DateTime.Now;
        public DateTime txtGodRodjenja
        {
            get { return _txtGodRodjenja; }
            set { _txtGodRodjenja = value; OnPropertyChanged("txtGodRodjenja"); }
        }
        private string _txtEmail;
        public string txtEmail
        {
            get { return _txtEmail; }
            set { _txtEmail = value; OnPropertyChanged("txtEmail"); }
        }
        private string _txtTelefon;
        public string txtTelefon
        {
            get { return _txtTelefon; }
            set { _txtTelefon = value; OnPropertyChanged("txtTelefon"); }
        }
        private string _txtNapomena;
        public string txtNapomena
        {
            get { return _txtNapomena; }
            set { _txtNapomena = value; OnPropertyChanged("txtNapomena"); }
        }
        private string _txtZapNakKonk;
        public string txtZapNakKonk
        {
            get { return _txtZapNakKonk; }
            set { _txtZapNakKonk = value; OnPropertyChanged("txtZapNakKonk"); }
        }
        #endregion
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Insert
        private RelayCommand _SaveCommand;


        public RelayCommand SaveCommand
        {
            get { return _SaveCommand; }
        }

        public void Insert()
        {
            if (!String.IsNullOrEmpty(txtIme) &
                !String.IsNullOrEmpty(txtPrezime) &
                !String.IsNullOrEmpty(txtJMBG) &          
                !String.IsNullOrEmpty(Convert.ToString(txtGodRodjenja)) &
                !String.IsNullOrEmpty(txtEmail) &
                !String.IsNullOrEmpty(txtTelefon) &
                !String.IsNullOrEmpty(txtNapomena) &
                !String.IsNullOrEmpty(txtZapNakKonk) )
            {
                 try
                 {
                    Kandidat kandidat = new Kandidat
                    {
                        ime= txtIme,prezime= txtPrezime, jmbg= txtJMBG,
                        god_rodjenja= Convert.ToString(txtGodRodjenja),
                        email= txtEmail,telefon= txtTelefon,napomena= txtNapomena,zaposlen_nakon_konkursa= txtZapNakKonk
                    };
                    var IsSaved = ObjKandidatiService.Add(kandidat);
 
                    if (IsSaved)
                    {
                        Message = "Kandidat je upisan.";
                        Osvezi();
                    }
                    else
                    {
                        Message = "Doslo je do greske.";
                    }
                }
                 catch (Exception ex)
                 {
                     Message = ex.Message;
                 }
            }
        }
        #endregion
    }
}
