namespace CloudCore.Core.VirtualWorker.WindowsService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.virtualWorkerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.virtualWorkerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // virtualWorkerProcessInstaller
            // 
            this.virtualWorkerProcessInstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.virtualWorkerProcessInstaller.Password = null;
            this.virtualWorkerProcessInstaller.Username = null;
            // 
            // virtualWorkerServiceInstaller
            // 
            this.virtualWorkerServiceInstaller.Description = "A service that hosts the CloudCore Virtual Worker. The CloudCore Virtual Worker i" +
    "s responsible for executing scheduled tasks and workflow activities defined in a" +
    " CloudCore database.";
            this.virtualWorkerServiceInstaller.DisplayName = "CloudCore Virtual Worker";
            this.virtualWorkerServiceInstaller.ServiceName = "CloudCore Virtual Worker Service";
            this.virtualWorkerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.virtualWorkerServiceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.virtualWorkerServiceInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.virtualWorkerProcessInstaller,
            this.virtualWorkerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller virtualWorkerProcessInstaller;
        private System.ServiceProcess.ServiceInstaller virtualWorkerServiceInstaller;
    }
}