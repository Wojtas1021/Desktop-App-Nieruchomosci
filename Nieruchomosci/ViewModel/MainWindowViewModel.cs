using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        private BaseCommand _CreateCommand;
        private BaseCommand getCommand(BaseCommand _command, WorkspaceViewModel workspace)
        {
            if (_command == null)
                _command = new BaseCommand(() => Create(workspace));
            return _command;
        }
        public ICommand CreateUchwalaCommand
        {
            get
            {
                if (_CreateCommand == null)
                    _CreateCommand = new BaseCommand(() => Create(new NowaUchwalaViewModel()));
                return _CreateCommand;
            }
        }
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel("Wspolnota", new BaseCommand(()=>this.CreateWspolnota())),
                new CommandViewModel("Wspolnoty", new BaseCommand(()=>this.ShowAllWspolnoty())),
                new CommandViewModel("Budynek", new BaseCommand(()=>this.Create(new NowyBudynekViewModel()))),
                new CommandViewModel("Budynki", new BaseCommand(()=>this.ShowAllBudynki())),
                new CommandViewModel("Właściciel", new BaseCommand(()=>this.Create(new DodajWlascicielaViewModel()))),
                new CommandViewModel("Faktura",new BaseCommand(()=>this.Create(new NowaFakturaViewModel()))),
                new CommandViewModel("Faktury", new BaseCommand(()=>this.ShowAllFaktura())),
                new CommandViewModel("Lokale", new BaseCommand(()=>this.ShowAllLokal())),
                new CommandViewModel("Kontrahent",new BaseCommand(()=>this.Create(new NowyKontrahentViewModel()))),
                new CommandViewModel("Kontrahenci", new BaseCommand(()=>this.ShowAllKontrahent())),
                //new CommandViewModel("Uchwała",new BaseCommand(()=>this.Create(new NowaUchwalaViewModel()))),
                //new CommandViewModel("Najemca", new BaseCommand(()=>this.Create(new DodajNajemceViewModel()))),
                //new CommandViewModel("Wpis do wykazu", new BaseCommand(()=>this.Create(new WpisDoWykazuViewModel()))),
                new CommandViewModel("Raport usługi", new BaseCommand(()=>this.Create(new RaportUslugiViewModel()))),
                new CommandViewModel("Adresy", new BaseCommand(()=>this.ShowAllAdresy())),
                new CommandViewModel("Adres",new BaseCommand(()=>this.Create(new NowyAdresViewModel()))),
                new CommandViewModel("Jednostki miary", new BaseCommand(()=>this.ShowJednostkiMiary())),
                new CommandViewModel("Oplaty", new BaseCommand(()=>this.ShowAllOplaty())),
                new CommandViewModel("Rachunki bankowe", new BaseCommand(()=>this.ShowAllRachunkiBankowe())),
                new CommandViewModel("StawkiVat", new BaseCommand(()=>this.ShowAllStawkiVat())),
                new CommandViewModel("Uslugi", new BaseCommand(()=>this.ShowAllUslugi())),
                new CommandViewModel("Właściciele", new BaseCommand(()=>this.ShowAllWlasciciele())),
                new CommandViewModel("Nowa usługa",new BaseCommand(()=>this.Create(new NowaUslugaViewModel()))),
                new CommandViewModel("Czynsze", new BaseCommand(()=>this.Create(new CzynszeViewModel()))),
                new CommandViewModel("Bilans", new BaseCommand(()=>this.Create(new RaportBilansViewModel()))),
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }

        #endregion
        #region PrivateHelpers
        private void Create(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateWspolnota()
        {
            NowaWspolnotaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is NowaWspolnotaViewModel) as NowaWspolnotaViewModel;
            if (workspace == null)
            {
                workspace = new NowaWspolnotaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        //private void CreateKontrahent()
        //{
        //    NowyKontrahentViewModel workspace =
        //        this.Workspaces.FirstOrDefault(vm => vm is NowyKontrahentViewModel) as NowyKontrahentViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new NowyKontrahentViewModel();
        //        this.Workspaces.Add(workspace);
        //    }
        //    this.SetActiveWorkspace(workspace);
        //}
        private void ShowAllWspolnoty()
        {
            WszystkieWspolnotyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieWspolnotyViewModel)
                as WszystkieWspolnotyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWspolnotyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKontrahent()
        {
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel)
                as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktura()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllLokal()
        {
            WszystkieLokaleViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieLokaleViewModel)
                as WszystkieLokaleViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieLokaleViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllBudynki()
        {
            WszystkieBudynkiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieBudynkiViewModel)
                as WszystkieBudynkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieBudynkiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllOplaty()
        {
            WszystkieOplatyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieOplatyViewModel)
                as WszystkieOplatyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieOplatyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllAdresy()
        {
            WszystkieAdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
                as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowJednostkiMiary()
        {
            JednostkiMiaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is JednostkiMiaryViewModel)
                as JednostkiMiaryViewModel;
            if (workspace == null)
            {
                workspace = new JednostkiMiaryViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRachunkiBankowe()
        {
            WszystkieRachunkiBankoweViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRachunkiBankoweViewModel)
                as WszystkieRachunkiBankoweViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRachunkiBankoweViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStawkiVat()
        {
            StawkiVatViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is StawkiVatViewModel)
                as StawkiVatViewModel;
            if (workspace == null)
            {
                workspace = new StawkiVatViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllUslugi()
        {
            WszystkieUslugiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiViewModel)
                as WszystkieUslugiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUslugiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllWlasciciele()
        {
            WszyscyWlascicieleViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyWlascicieleViewModel)
                as WszyscyWlascicieleViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyWlascicieleViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string name)
        {
            if (name == "FakturyAdd")
                Create(new NowaFakturaViewModel());
            if (name == "WspólnotyAdd")
                this.CreateWspolnota();
            if (name == "AdresyAdd")
                Create(new NowyAdresViewModel());
            if (name == "AdresyShow")
                this.ShowAllAdresy();
            if (name == "WłaścicieleAdd")
                Create(new DodajWlascicielaViewModel());
            if (name == "BudynkiAdd")
                Create(new NowyBudynekViewModel());
            if (name == "KontrahenciAdd")
                Create(new NowyKontrahentViewModel());
            if (name == "UslugiAdd")
                Create(new NowaUslugaViewModel());
            if (name == "KontrahenciShow")
                this.ShowAllKontrahent();
        }
        #endregion
    }
}