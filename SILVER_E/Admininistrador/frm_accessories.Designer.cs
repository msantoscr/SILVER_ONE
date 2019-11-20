namespace SILVER_E.Admininistrador
{
    partial class frm_accessories
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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BTN_SAVE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_EDIT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_DELETE = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_CLEAN = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_SHOW = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_PRINT = new DevExpress.XtraBars.BarButtonItem();
            this.BTN_PREVIEW = new DevExpress.XtraBars.BarButtonItem();
            this.SHOW_PANEL = new DevExpress.XtraBars.BarButtonItem();
            this.HIDE_PANEL = new DevExpress.XtraBars.BarButtonItem();
            this.VIEW_AUTOFILTER = new DevExpress.XtraBars.BarButtonItem();
            this.HIDE_AUTOFILTER = new DevExpress.XtraBars.BarButtonItem();
            this.LBL_RESULT = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageCategory2 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.C_ACTIVE_INACTIVE = new DevExpress.XtraEditors.CheckEdit();
            this.TXT_NAME = new DevExpress.XtraEditors.TextEdit();
            this.TXT_OBSERVATIONS = new DevExpress.XtraEditors.TextEdit();
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TXT_ID = new DevExpress.XtraEditors.TextEdit();
            this.LabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.DGV_DATA = new DevExpress.XtraGrid.GridControl();
            this.G_DATA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLAVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESCRIPCION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colUSUARIOCREADOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSUARIOMODIFICA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFECHAMODIFICACION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFECHADEREGISTRO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C_ACTIVE_INACTIVE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_OBSERVATIONS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DATA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_DATA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.BTN_CLEAN,
            this.BTN_SHOW,
            this.BTN_PRINT,
            this.BTN_PREVIEW,
            this.SHOW_PANEL,
            this.HIDE_PANEL,
            this.VIEW_AUTOFILTER,
            this.HIDE_AUTOFILTER,
            this.LBL_RESULT});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1,
            this.ribbonPageCategory2});
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.Size = new System.Drawing.Size(1077, 179);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BTN_SAVE
            // 
            this.BTN_SAVE.Caption = "GUARDAR REGISTRO";
            this.BTN_SAVE.Id = 1;
            this.BTN_SAVE.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.save_32x32;
            this.BTN_SAVE.Name = "BTN_SAVE";
            this.BTN_SAVE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SAVE_ItemClick);
            // 
            // BTN_EDIT
            // 
            this.BTN_EDIT.Caption = "MODIFICAR REGISTRO";
            this.BTN_EDIT.Enabled = false;
            this.BTN_EDIT.Id = 2;
            this.BTN_EDIT.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.renamedatasource_32x32;
            this.BTN_EDIT.Name = "BTN_EDIT";
            this.BTN_EDIT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_EDIT_ItemClick);
            // 
            // BTN_DELETE
            // 
            this.BTN_DELETE.Caption = "ELIMINAR REGISTRO";
            this.BTN_DELETE.Enabled = false;
            this.BTN_DELETE.Id = 3;
            this.BTN_DELETE.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.deletelist_32x32;
            this.BTN_DELETE.Name = "BTN_DELETE";
            this.BTN_DELETE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_DELETE_ItemClick);
            // 
            // BTN_CLEAN
            // 
            this.BTN_CLEAN.Caption = "LIMPIAR CAMPOS";
            this.BTN_CLEAN.Id = 4;
            this.BTN_CLEAN.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.richeditclearformatting_32x32;
            this.BTN_CLEAN.Name = "BTN_CLEAN";
            this.BTN_CLEAN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_CLEAN_ItemClick);
            // 
            // BTN_SHOW
            // 
            this.BTN_SHOW.Caption = "VER REGISTROS";
            this.BTN_SHOW.Id = 5;
            this.BTN_SHOW.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.show_32x32;
            this.BTN_SHOW.Name = "BTN_SHOW";
            this.BTN_SHOW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_SHOW_ItemClick);
            // 
            // BTN_PRINT
            // 
            this.BTN_PRINT.Caption = "IMPRESION RAPIDA";
            this.BTN_PRINT.Id = 6;
            this.BTN_PRINT.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.printer_32x32;
            this.BTN_PRINT.Name = "BTN_PRINT";
            this.BTN_PRINT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_PRINT_ItemClick);
            // 
            // BTN_PREVIEW
            // 
            this.BTN_PREVIEW.Caption = "VISTA PREVIA";
            this.BTN_PREVIEW.Id = 7;
            this.BTN_PREVIEW.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.preview_32x32;
            this.BTN_PREVIEW.Name = "BTN_PREVIEW";
            this.BTN_PREVIEW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTN_PREVIEW_ItemClick);
            // 
            // SHOW_PANEL
            // 
            this.SHOW_PANEL.Caption = "MOSTRAR PANEL DE BUSQUEDA";
            this.SHOW_PANEL.Id = 8;
            this.SHOW_PANEL.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.inlinesizelegend_32x32;
            this.SHOW_PANEL.Name = "SHOW_PANEL";
            this.SHOW_PANEL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SHOW_PANEL_ItemClick);
            // 
            // HIDE_PANEL
            // 
            this.HIDE_PANEL.Caption = "OCULTAR PANEL DE BUSQUEDA";
            this.HIDE_PANEL.Enabled = false;
            this.HIDE_PANEL.Id = 9;
            this.HIDE_PANEL.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.legendnone_32x32;
            this.HIDE_PANEL.Name = "HIDE_PANEL";
            this.HIDE_PANEL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.HIDE_PANEL_ItemClick);
            // 
            // VIEW_AUTOFILTER
            // 
            this.VIEW_AUTOFILTER.Caption = "VER AUTOFILTROS";
            this.VIEW_AUTOFILTER.Id = 10;
            this.VIEW_AUTOFILTER.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.masterfilter_32x32;
            this.VIEW_AUTOFILTER.Name = "VIEW_AUTOFILTER";
            this.VIEW_AUTOFILTER.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.VIEW_AUTOFILTER_ItemClick);
            // 
            // HIDE_AUTOFILTER
            // 
            this.HIDE_AUTOFILTER.Caption = "OCULTAR AUTOFILTROS";
            this.HIDE_AUTOFILTER.Enabled = false;
            this.HIDE_AUTOFILTER.Id = 11;
            this.HIDE_AUTOFILTER.ImageOptions.LargeImage = global::SILVER_E.Properties.Resources.ignoremasterfilter_32x32;
            this.HIDE_AUTOFILTER.Name = "HIDE_AUTOFILTER";
            this.HIDE_AUTOFILTER.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.HIDE_AUTOFILTER_ItemClick);
            // 
            // LBL_RESULT
            // 
            this.LBL_RESULT.Caption = "...";
            this.LBL_RESULT.Id = 12;
            this.LBL_RESULT.ImageOptions.Image = global::SILVER_E.Properties.Resources.tableproperties_32x32;
            this.LBL_RESULT.Name = "LBL_RESULT";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonPageCategory1.Text = "IMPRESION Y EXPORTACION";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "OPCIONES IMPRIMIR Y EXPORTAR";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BTN_PRINT);
            this.ribbonPageGroup2.ItemLinks.Add(this.BTN_PREVIEW);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "IMPRIMIR Y EXPORTAR";
            // 
            // ribbonPageCategory2
            // 
            this.ribbonPageCategory2.Name = "ribbonPageCategory2";
            this.ribbonPageCategory2.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage3});
            this.ribbonPageCategory2.Text = "BUSQUEDAS Y FILTROS AVANZADOS";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "OPCIONES BUSQUEDAS Y FILTROS";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.SHOW_PANEL);
            this.ribbonPageGroup3.ItemLinks.Add(this.HIDE_PANEL);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "BUSQUEDAS AVANZADAS";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.VIEW_AUTOFILTER);
            this.ribbonPageGroup4.ItemLinks.Add(this.HIDE_AUTOFILTER);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "FILTROS AVANZADOS";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_CLEAN);
            this.ribbonPageGroup1.ItemLinks.Add(this.BTN_SHOW);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "OPCIONES";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.LBL_RESULT);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 719);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1077, 40);
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
            this.dockPanel1.ID = new System.Guid("dac1e735-9b52-4a91-b220-c8065f14501c");
            this.dockPanel1.Location = new System.Drawing.Point(0, 179);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(320, 200);
            this.dockPanel1.Size = new System.Drawing.Size(320, 540);
            this.dockPanel1.Text = "INFORMACION DEL ACCESORIO";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.C_ACTIVE_INACTIVE);
            this.dockPanel1_Container.Controls.Add(this.TXT_NAME);
            this.dockPanel1_Container.Controls.Add(this.TXT_OBSERVATIONS);
            this.dockPanel1_Container.Controls.Add(this.LabelControl1);
            this.dockPanel1_Container.Controls.Add(this.TXT_ID);
            this.dockPanel1_Container.Controls.Add(this.LabelControl2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 27);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(308, 508);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // C_ACTIVE_INACTIVE
            // 
            this.C_ACTIVE_INACTIVE.Location = new System.Drawing.Point(7, 325);
            this.C_ACTIVE_INACTIVE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.C_ACTIVE_INACTIVE.Name = "C_ACTIVE_INACTIVE";
            this.C_ACTIVE_INACTIVE.Properties.Caption = "ACTIVO/INACTIVO";
            this.C_ACTIVE_INACTIVE.Properties.ValueChecked = 1;
            this.C_ACTIVE_INACTIVE.Properties.ValueUnchecked = 0;
            this.C_ACTIVE_INACTIVE.Size = new System.Drawing.Size(169, 20);
            this.C_ACTIVE_INACTIVE.TabIndex = 51;
            // 
            // TXT_NAME
            // 
            this.TXT_NAME.Location = new System.Drawing.Point(7, 138);
            this.TXT_NAME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_NAME.Name = "TXT_NAME";
            this.TXT_NAME.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_NAME.Size = new System.Drawing.Size(196, 22);
            this.TXT_NAME.TabIndex = 47;
            // 
            // TXT_OBSERVATIONS
            // 
            this.TXT_OBSERVATIONS.Location = new System.Drawing.Point(7, 244);
            this.TXT_OBSERVATIONS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_OBSERVATIONS.Name = "TXT_OBSERVATIONS";
            this.TXT_OBSERVATIONS.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXT_OBSERVATIONS.Size = new System.Drawing.Size(294, 22);
            this.TXT_OBSERVATIONS.TabIndex = 50;
            // 
            // LabelControl1
            // 
            this.LabelControl1.Location = new System.Drawing.Point(7, 114);
            this.LabelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(37, 16);
            this.LabelControl1.TabIndex = 48;
            this.LabelControl1.Text = "CLAVE";
            // 
            // TXT_ID
            // 
            this.TXT_ID.Location = new System.Drawing.Point(7, 28);
            this.TXT_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_ID.Name = "TXT_ID";
            this.TXT_ID.Properties.ReadOnly = true;
            this.TXT_ID.Size = new System.Drawing.Size(117, 22);
            this.TXT_ID.TabIndex = 46;
            this.TXT_ID.TextChanged += new System.EventHandler(this.TXT_ID_TextChanged);
            // 
            // LabelControl2
            // 
            this.LabelControl2.Location = new System.Drawing.Point(7, 220);
            this.LabelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl2.Name = "LabelControl2";
            this.LabelControl2.Size = new System.Drawing.Size(79, 16);
            this.LabelControl2.TabIndex = 49;
            this.LabelControl2.Text = "DESCRIPCION";
            // 
            // DGV_DATA
            // 
            this.DGV_DATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_DATA.Location = new System.Drawing.Point(320, 179);
            this.DGV_DATA.MainView = this.G_DATA;
            this.DGV_DATA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGV_DATA.MenuManager = this.ribbon;
            this.DGV_DATA.Name = "DGV_DATA";
            this.DGV_DATA.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.DGV_DATA.Size = new System.Drawing.Size(757, 540);
            this.DGV_DATA.TabIndex = 3;
            this.DGV_DATA.UseEmbeddedNavigator = true;
            this.DGV_DATA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.G_DATA});
            // 
            // G_DATA
            // 
            this.G_DATA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCLAVE,
            this.colDESCRIPCION,
            this.gridColumn1,
            this.colUSUARIOCREADOR,
            this.colUSUARIOMODIFICA,
            this.colFECHAMODIFICACION,
            this.colFECHADEREGISTRO});
            this.G_DATA.GridControl = this.DGV_DATA;
            this.G_DATA.Name = "G_DATA";
            this.G_DATA.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.G_DATA.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.G_DATA.OptionsBehavior.Editable = false;
            this.G_DATA.OptionsView.ColumnAutoWidth = false;
            this.G_DATA.OptionsView.ShowFooter = true;
            this.G_DATA.DoubleClick += new System.EventHandler(this.G_DATA_DoubleClick);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colCLAVE
            // 
            this.colCLAVE.FieldName = "CLAVE";
            this.colCLAVE.Name = "colCLAVE";
            this.colCLAVE.Visible = true;
            this.colCLAVE.VisibleIndex = 1;
            // 
            // colDESCRIPCION
            // 
            this.colDESCRIPCION.FieldName = "DESCRIPCION";
            this.colDESCRIPCION.Name = "colDESCRIPCION";
            this.colDESCRIPCION.Visible = true;
            this.colDESCRIPCION.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "ACTIVO/INACTIVO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // colUSUARIOCREADOR
            // 
            this.colUSUARIOCREADOR.FieldName = "USUARIO CREADOR";
            this.colUSUARIOCREADOR.Name = "colUSUARIOCREADOR";
            this.colUSUARIOCREADOR.Visible = true;
            this.colUSUARIOCREADOR.VisibleIndex = 4;
            // 
            // colUSUARIOMODIFICA
            // 
            this.colUSUARIOMODIFICA.FieldName = "USUARIO MODIFICA";
            this.colUSUARIOMODIFICA.Name = "colUSUARIOMODIFICA";
            this.colUSUARIOMODIFICA.Visible = true;
            this.colUSUARIOMODIFICA.VisibleIndex = 5;
            // 
            // colFECHAMODIFICACION
            // 
            this.colFECHAMODIFICACION.FieldName = "FECHA MODIFICACION";
            this.colFECHAMODIFICACION.Name = "colFECHAMODIFICACION";
            this.colFECHAMODIFICACION.Visible = true;
            this.colFECHAMODIFICACION.VisibleIndex = 6;
            // 
            // colFECHADEREGISTRO
            // 
            this.colFECHADEREGISTRO.FieldName = "FECHA DE REGISTRO";
            this.colFECHADEREGISTRO.Name = "colFECHADEREGISTRO";
            this.colFECHADEREGISTRO.Visible = true;
            this.colFECHADEREGISTRO.VisibleIndex = 7;
            // 
            // frm_accessories
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 759);
            this.Controls.Add(this.DGV_DATA);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frm_accessories";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "GESTION DE ACCESORIOS";
            this.Load += new System.EventHandler(this.frm_accessories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C_ACTIVE_INACTIVE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_NAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_OBSERVATIONS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DATA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G_DATA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BTN_SAVE;
        private DevExpress.XtraBars.BarButtonItem BTN_EDIT;
        private DevExpress.XtraBars.BarButtonItem BTN_DELETE;
        private DevExpress.XtraBars.BarButtonItem BTN_CLEAN;
        private DevExpress.XtraBars.BarButtonItem BTN_SHOW;
        private DevExpress.XtraBars.BarButtonItem BTN_PRINT;
        private DevExpress.XtraBars.BarButtonItem BTN_PREVIEW;
        private DevExpress.XtraBars.BarButtonItem SHOW_PANEL;
        private DevExpress.XtraBars.BarButtonItem HIDE_PANEL;
        private DevExpress.XtraBars.BarButtonItem VIEW_AUTOFILTER;
        private DevExpress.XtraBars.BarButtonItem HIDE_AUTOFILTER;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        public DevExpress.XtraGrid.GridControl DGV_DATA;
        public DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        internal DevExpress.XtraEditors.CheckEdit C_ACTIVE_INACTIVE;
        internal DevExpress.XtraEditors.TextEdit TXT_NAME;
        internal DevExpress.XtraEditors.TextEdit TXT_OBSERVATIONS;
        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.TextEdit TXT_ID;
        internal DevExpress.XtraEditors.LabelControl LabelControl2;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCLAVE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESCRIPCION;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colUSUARIOCREADOR;
        private DevExpress.XtraGrid.Columns.GridColumn colUSUARIOMODIFICA;
        private DevExpress.XtraGrid.Columns.GridColumn colFECHAMODIFICACION;
        private DevExpress.XtraGrid.Columns.GridColumn colFECHADEREGISTRO;
        public DevExpress.XtraGrid.Views.Grid.GridView G_DATA;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarStaticItem LBL_RESULT;
    }
}