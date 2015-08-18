using System;
using System.Collections.Generic;
using CloudCore.VSExtension.PropertyPages.Base;
using Microsoft.VisualStudio.Shell.Interop;

namespace CloudCore.VSExtension.ProcessProperties
{
    public class ProcessPropertyPagePropertyStore : IDisposable, IPropertyStore
    {
        private bool disposed = false;

        private List<ProcessPropertyPageProjectFlavorCfg> configs = new List<ProcessPropertyPageProjectFlavorCfg>();

        public event StoreChangedDelegate StoreChanged;

        #region IPropertyStore Members
        /// <summary>
        /// Use the data passed in to initialize the Properties. 
        /// </summary>
        /// <param name="dataObject">
        /// This is normally only one our configuration object, which means that 
        /// there will be only one elements in configs.
        /// If it is null, we should release it.
        /// </param>
        public void Initialize(object[] dataObjects)
        {
            // If we are editing multiple configuration at once, we may get multiple objects.
            foreach (object dataObject in dataObjects)
            {
                if (dataObject is IVsCfg)
                {
                    // This should be our configuration object, so retrive the specific
                    // class so we can access its properties.
                    ProcessPropertyPageProjectFlavorCfg config = ProcessPropertyPageProjectFlavorCfg.GetProcessPropertyPageProjectFlavorCfgFromIVsCfg((IVsCfg)dataObject);

                    if (!configs.Contains(config))
                    {
                        configs.Add(config);
                    }
                }
            }
        }

        /// <summary>
        /// Set the value of the specified property in storage.
        /// </summary>
        /// <param name="propertyName">Name of the property to set.</param>
        /// <param name="propertyValue">Value to set the property to.</param>
        public void Persist(string propertyName, string propertyValue)
        {
            // If the value is null, make it empty.
            if (propertyValue == null)
            {
                propertyValue = String.Empty;
            }

            foreach (ProcessPropertyPageProjectFlavorCfg config in configs)
            {
                // Set the property
                config[propertyName] = propertyValue;
            }
            if (StoreChanged != null)
            {
                StoreChanged();
            }
        }

        /// <summary>
        /// Retreive the value of the specified property from storage
        /// </summary>
        /// <param name="propertyName">Name of the property to retrieve</param>
        /// <returns></returns>
        public string PropertyValue(string propertyName)
        {
            string value = null;
            if (configs.Count > 0)
                value = configs[0][propertyName];
            foreach (ProcessPropertyPageProjectFlavorCfg config in configs)
            {
                if (config[propertyName] != value)
                {
                    // multiple config with different value for the property
                    value = String.Empty;
                    break;
                }
            }

            return value;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                configs.Clear();
            }
            disposed = true;
        }
        #endregion
    }
}
