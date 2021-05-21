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
    public class DeleteViewModel : INotifyPropertyChanged, IDeleteViewModel
    {

        //KandidatiService ObjKandidatiService;
        IKandidatiService ObjKandidatiService;
        public DeleteViewModel(IKandidatiService ObjKandidatiService)
        {
            this.ObjKandidatiService = ObjKandidatiService;
            //bjKandidatiService = new KandidatiService();
            _SaveCommand = new RelayCommand(Delete);
        }
        public delegate void OnDatabaseSubmitDelete();
        public static event OnDatabaseSubmitDelete Osvezi;
        #region Delete
        private RelayCommand _SaveCommand;


        public RelayCommand SaveCommand
        {
            get { return _SaveCommand; }
        }

        
        #endregion
        public void Delete()
        {
            if (!String.IsNullOrEmpty(txtJMBG))
            {
                try
                {
                    var IsSaved = ObjKandidatiService.Delete(txtJMBG);

                    if (IsSaved)
                    {
                        Message = "Kandidat je obrisan.";
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
        #region Propertiji
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private string _txtJMBG;
        public string txtJMBG
        {
            get { return _txtJMBG; }
            set { _txtJMBG = value; OnPropertyChanged("txtJMBG"); }
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
    }
}
