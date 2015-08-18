using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProcessViewer.Library;
using ProcessViewer.Library.Common;
using ProcessViewer.Resources;
using System.Linq;

namespace ProcessViewer.ViewModel
{
    public class DatabaseViewModel : WizardPageViewModelBase
    {
        #region Fields

        readonly RegLibrary _regLib;
        private ReadOnlyCollection<OptionViewModel<DBVersion>> _availableVersions;

        #endregion

        #region Constructor

        public DatabaseViewModel(DrawItem drawItem)
            : base(drawItem)
        {
            _regLib = new RegLibrary();
            _regLib.LoadValues();
            ServerName = _regLib.Server;
            DatabaseName = _regLib.Database;
            UserName = _regLib.UserName;
            Password = _regLib.Password;
            Integrated = _regLib.Integrated;
        }

        #endregion 

        #region Avalaible Versions

        public ReadOnlyCollection<OptionViewModel<DBVersion>> AvailableVersions
        {
            get
            {
                if (_availableVersions == null)
                    CreateAvailableVersions();

                return _availableVersions;
            }
        }

        void CreateAvailableVersions()
        {
            var list = new List<OptionViewModel<DBVersion>>();

            try
            {

                list.Add(new OptionViewModel<DBVersion>("CloudCore Alpha 1 or later.", DBVersion.Version1));
                list.Add(new OptionViewModel<DBVersion>("CloudCore Beta or later.", DBVersion.Version2));

                foreach (var option in list)
                {
                    if (option.GetValue() == DrawItem.Version)
                        option.IsSelected = true;

                    option.PropertyChanged += OnOptionsPropertyChanged;
                }

                list.Sort();

                _availableVersions = new ReadOnlyCollection<OptionViewModel<DBVersion>>(list);

            }
            catch (Exception) { }
        }

        void OnOptionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var option = sender as OptionViewModel<DBVersion>;

            DrawItem.ResetRevisions = true;

            if (option.IsSelected)
                DrawItem.Version = option.GetValue();
        }

        #endregion

        #region Properties

        #region DisplayName

        public override string DisplayName
        {
            get { return Strings.PageDisplayName_Database; }
        }
        
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean Integrated { get; set; }
        public string ConnectionString 
        {
            get 
            {
                if (Integrated)
                    return string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", ServerName, DatabaseName);
 
                return string.Format(@"Server={0};Database={1};User Id={2};password={3};", ServerName, DatabaseName, UserName, Password);
            }
        }

        #endregion 

        public bool SaveToRegistry()
        {
            _regLib.Server = ServerName;
            _regLib.Database = DatabaseName;
            _regLib.Integrated = Integrated;
            _regLib.UserName = UserName;
            _regLib.Password = Password;
            return _regLib.SaveAndTestValues();

        }

        #endregion

        #region Methods

        internal override bool IsValid()
        {
            return AvailableVersions.Where(r => r.IsSelected && r.IsEnabled).Count() > 0;
        }

        internal override bool StepBack()
        {
            return true;
        }

        #endregion 
    }
}
