namespace SILVER_E.Admininistrador
{
    partial class frm_clients
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.DGV_DATA = new DevExpress.XtraGrid.GridControl();
            this.G_DATA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BTN_SAVE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_EDIT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_DELETE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_CLEAR = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_SHOW = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DATA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_DATA)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BTN_SAVE,
            this.BTN_EDIT,
            this.BTN_DELETE,
            this.BTN_CLEAR,
            this.BTN_SHOW});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(930, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "OPCIONES BASICAS";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_SAVE);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_EDIT);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_DELETE);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_CLEAR);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_SHOW);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "OPCIONES";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 712);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(930, 31);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("4c7855b9-bee9-4b43-ac42-46257f10f111");
            this.dockPanel1.Location = new System.Drawing.Point(0, 143);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(451, 200);
            this.dockPanel1.Size = new System.Drawing.Size(451, 569);
            this.dockPanel1.Text = "INFORMACION DEL CLIENTE";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(442, 542);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // DGV_DATA
            // 
            this.DGV_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_DATA.Location = new System.Drawing.Point(451, 143);
            this.DGV_DATA.MainView = this.G_DATA;
            this.DGV_DATA.Name = "DGV_DATA";
            this.DGV_DATA.Size = new System.Drawing.Size(479, 569);
            this.DGV_DATA.TabIndex = 3;
            this.DGV_DATA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.G_DATA});
            // 
            // G_DATA
            // 
            this.G_DATA.GridControl = this.DGV_DATA;
            this.G_DATA.Name = "G_DATA";
            // 
            // BTN_SAVE
            // 
            this.BTN_SAVE.Caption = "GUARDAR REGISTRO";
            this.BTN_SAVE.Id = 1;
            this.BTN_SAVE.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.save_32x32;
            this.BTN_SAVE.Name = "BTN_SAVE";
            // 
            // BTN_EDIT
            // 
            this.BTN_EDIT.Caption = "MODIFICAR REGISTRO";
            this.BTN_EDIT.Id = 2;
            this.BTN_EDIT.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.edit_32x32;
            this.BTN_EDIT.Name = "BTN_EDIT";
            // 
            // BTN_DELETE
            // 
            this.BTN_DELETE.Caption = "ELIMINAR REGISTRO";
            this.BTN_DELETE.Id = 3;
            this.BTN_DELETE.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.deletelist_32x32;
            this.BTN_DELETE.Name = "BTN_DELETE";
            // 
            // BTN_CLEAR
            // 
            this.BTN_CLEAR.Caption = "LIMPIAR CAMPOS";
            this.BTN_CLEAR.Id = 4;
            this.BTN_CLEAR.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.richeditclearformatting_32x32;
            this.BTN_CLEAR.Name = "BTN_CLEAR";
            // 
            // BTN_SHOW
            // 
            this.BTN_SHOW.Caption = "VER REGISTROS";
            this.BTN_SHOW.Id = 5;
            this.BTN_SHOW.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.show_32x32;
            this.BTN_SHOW.Name = "BTN_SHOW";
            // 
            // frm_clients
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 743);
            this.Controls.Add(this.DGV_DATA);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frm_clients";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "GESTION DE CLIENTES";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DATA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_DATA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraGrid.GridControl DGV_DATA;
        private DevExpress.XtraGrid.Views.Grid.GridView G_DATA;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarButtonItem BTN_SAVE;
        private DevExpress.XtraBars.BarButtonItem BTN_EDIT;
        private DevExpress.XtraBars.BarButtonItem BTN_DELETE;
        private DevExpress.XtraBars.BarButtonItem BTN_CLEAR;
        private DevExpress.XtraBars.BarButtonItem BTN_SHOW;
    }
}