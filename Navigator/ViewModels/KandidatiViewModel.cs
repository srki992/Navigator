using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Navigator.Models;
using System.Collections.ObjectModel;
using Navigator.Commands;
using Navigator.Views;
using Navigator.StartUp;
using Autofac;

namespace Navigator.ViewModels
{
    public class KandidatiViewModel : INotifyPropertyChanged, IKandidatiViewModel
    {
        //KandidatiService ObjKandidatiService;
        IKandidatiService ObjKandidatiService;
        IInsertViewModel insertViewModel;
        IUpdateViewModel updateViewModel;
        IDeleteViewModel deleteViewModel;
        public KandidatiViewModel(IKandidatiService ObjKandidatiService, IInsertViewModel insertViewModel, IUpdateViewModel updateViewModel, IDeleteViewModel deleteViewModel)
        {
            this.deleteViewModel = deleteViewModel;
            this.insertViewModel = insertViewModel;
            this.updateViewModel = updateViewModel;
            this.ObjKandidatiService = ObjKandidatiService;
            //ObjKandidatiService = new KandidatiService();
            LoadData();

            _SearchCommand = new RelayCommand(Search);
            _InsertCommand = new RelayCommand(Insert);
            _UpdateCommand = new RelayCommand(Update);
            _DeleteCommand = new RelayCommand(Delete);
            //_OsveziCommand = new RelayCommand(Osvezi);

            UpdateViewModel.Osvezi += UpdateViewModel_Osvezi;
            InsertViewModel.Osvezi += InsertViewModel_Osvezi;
            DeleteViewModel.Osvezi += DeleteViewModel_Osvezi;
        }

        private void DeleteViewModel_Osvezi()
        {
            LoadData();
        }

        private void InsertViewModel_Osvezi()
        {
            LoadData();
        }

        private void UpdateViewModel_Osvezi()
        {
            LoadData();
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region Search
        private RelayCommand _SearchCommand;

        public RelayCommand SearchCommand
        {
            get { return _SearchCommand; }
        }

        public void Search()
        {
            if(!String.IsNullOrEmpty(txtSearchUnos))
            {
                try
                {
                    var rezultat = ObjKandidatiService.Search(txtSearchUnos);
                    if(rezultat.Count == 0)
                    {
                        Message = "Nema rezultata za pretragu: " + txtSearchUnos;
                    }
                    else
                    {
                        ListaKandidata = new ObservableCollection<Kandidat>(rezultat);
                        Message = "Uspesno izvrsena pretraga.";
                    }
                }
                catch (Exception ex)
                {
                    Message = "Greska " + ex.Message.ToString();
                }
            }
            else
            {
                Message = "Polje za pretragu je prazno,molimo unesite vrednost.";
            }
        }
        #endregion

        #region Insert
        private RelayCommand _InsertCommand;
        public RelayCommand InsertCommand
        {
            get { return _InsertCommand; }
        }

        public void Insert()
        {
            try
            {
                var container = Bootstrap.Instance.Container;
                var insertWindow = container.Resolve<InsertWindow>();
                insertWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Update
        private RelayCommand _UpdateCommand;
        public RelayCommand UpdateCommand
        {
            get { return _UpdateCommand; }
        }

        public void Update()
        {
            try
            {
                var container = Bootstrap.Instance.Container;
                var updateWindow = container.Resolve<UpdateWindow>();
                updateWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


        #region Delete
        private RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return _DeleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var container = Bootstrap.Instance.Container;
                var deleteWindow = container.Resolve<DeleteWindow>();
                deleteWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


        
        #region Refresh grida
        //private RelayCommand _OsveziCommand;
        //public RelayCommand OsveziCommand
        //{
        //    get { return _OsveziCommand; }
        //}

        //public void Osvezi()
        //{
        //    try
        //    {
        //        LoadData();
        //        Message = "Prikaz je osvezen.";
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message;
        //    }
        //}
        #endregion

        private ObservableCollection<Kandidat> _listaKandidata;

        public ObservableCollection<Kandidat> ListaKandidata
        {
            get
            {
                return _listaKandidata;
            }
            set
            {
                _listaKandidata = value;
                OnPropertyChanged("ListaKandidata");
            }
        }
        public void LoadData()
        {
            ListaKandidata = new ObservableCollection<Kandidat>(ObjKandidatiService.GetAll());
        }


        private string _txtSearchUnos;

        public string txtSearchUnos
        {
            get
            {
                return _txtSearchUnos;
            }
            set
            {
                _txtSearchUnos = value;
                OnPropertyChanged("txtSearchUnos");
            }
        }

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
