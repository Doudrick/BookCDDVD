namespace BookCDDVD
{
    partial class frmBookCDDVDShop
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnCreateBook = new System.Windows.Forms.Button();
            this.btnCreateBookCIS = new System.Windows.Forms.Button();
            this.btnCreateDVD = new System.Windows.Forms.Button();
            this.btnCreateCDOrchestra = new System.Windows.Forms.Button();
            this.btnCreateCDChamber = new System.Windows.Forms.Button();
            this.grpControlsNewEntry = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpProduct = new System.Windows.Forms.GroupBox();
            this.grpCDChamber = new System.Windows.Forms.GroupBox();
            this.txtCDChamberInstrumentList = new System.Windows.Forms.ComboBox();
            this.lblInstruments = new System.Windows.Forms.Label();
            this.grpCDOrchestra = new System.Windows.Forms.GroupBox();
            this.txtCDOrchestraConductor = new System.Windows.Forms.TextBox();
            this.lblConductor = new System.Windows.Forms.Label();
            this.grpCDClassical = new System.Windows.Forms.GroupBox();
            this.txtCDClassicalArtists = new System.Windows.Forms.TextBox();
            this.txtCDClassicalLabel = new System.Windows.Forms.TextBox();
            this.lblArtists = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.grpDVD = new System.Windows.Forms.GroupBox();
            this.txtDVDRunTime = new System.Windows.Forms.TextBox();
            this.txtDVDReleaseDate = new System.Windows.Forms.TextBox();
            this.txtDVDLeadActor = new System.Windows.Forms.TextBox();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.lblLeadActor = new System.Windows.Forms.Label();
            this.grpBookCIS = new System.Windows.Forms.GroupBox();
            this.txtBookCISCISArea = new System.Windows.Forms.ComboBox();
            this.lblCISArea = new System.Windows.Forms.Label();
            this.grpBook = new System.Windows.Forms.GroupBox();
            this.txtBookPages = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookISBNRight = new System.Windows.Forms.TextBox();
            this.txtBookISBNLeft = new System.Windows.Forms.TextBox();
            this.lbldash = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtProductQuantity = new System.Windows.Forms.TextBox();
            this.txtProductTitle = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductUPC = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblUPC = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpControlsNewEntry.SuspendLayout();
            this.grpProduct.SuspendLayout();
            this.grpCDChamber.SuspendLayout();
            this.grpCDOrchestra.SuspendLayout();
            this.grpCDClassical.SuspendLayout();
            this.grpDVD.SuspendLayout();
            this.grpBookCIS.SuspendLayout();
            this.grpBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(284, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Data Entry and Display for Book CD DVD Shop";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.DarkRed;
            this.lblInstruction.Location = new System.Drawing.Point(75, 34);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(0, 13);
            this.lblInstruction.TabIndex = 1;
            // 
            // btnCreateBook
            // 
            this.btnCreateBook.Location = new System.Drawing.Point(6, 19);
            this.btnCreateBook.Name = "btnCreateBook";
            this.btnCreateBook.Size = new System.Drawing.Size(100, 23);
            this.btnCreateBook.TabIndex = 2;
            this.btnCreateBook.Text = "Create Book";
            this.btnCreateBook.UseVisualStyleBackColor = true;
            this.btnCreateBook.Click += new System.EventHandler(this.btnCreateBook_Click);
            // 
            // btnCreateBookCIS
            // 
            this.btnCreateBookCIS.Location = new System.Drawing.Point(143, 19);
            this.btnCreateBookCIS.Name = "btnCreateBookCIS";
            this.btnCreateBookCIS.Size = new System.Drawing.Size(100, 23);
            this.btnCreateBookCIS.TabIndex = 3;
            this.btnCreateBookCIS.Text = "Create CIS Book";
            this.btnCreateBookCIS.UseVisualStyleBackColor = true;
            this.btnCreateBookCIS.Click += new System.EventHandler(this.btnCreateBookCIS_Click);
            // 
            // btnCreateDVD
            // 
            this.btnCreateDVD.Location = new System.Drawing.Point(286, 19);
            this.btnCreateDVD.Name = "btnCreateDVD";
            this.btnCreateDVD.Size = new System.Drawing.Size(100, 23);
            this.btnCreateDVD.TabIndex = 4;
            this.btnCreateDVD.Text = "Create DVD";
            this.btnCreateDVD.UseVisualStyleBackColor = true;
            this.btnCreateDVD.Click += new System.EventHandler(this.btnCreateDVD_Click);
            // 
            // btnCreateCDOrchestra
            // 
            this.btnCreateCDOrchestra.Location = new System.Drawing.Point(417, 19);
            this.btnCreateCDOrchestra.Name = "btnCreateCDOrchestra";
            this.btnCreateCDOrchestra.Size = new System.Drawing.Size(133, 23);
            this.btnCreateCDOrchestra.TabIndex = 5;
            this.btnCreateCDOrchestra.Text = "Create DVD Orchestra";
            this.btnCreateCDOrchestra.UseVisualStyleBackColor = true;
            this.btnCreateCDOrchestra.Click += new System.EventHandler(this.btnCreateCDOrchestra_Click);
            // 
            // btnCreateCDChamber
            // 
            this.btnCreateCDChamber.Location = new System.Drawing.Point(582, 19);
            this.btnCreateCDChamber.Name = "btnCreateCDChamber";
            this.btnCreateCDChamber.Size = new System.Drawing.Size(133, 23);
            this.btnCreateCDChamber.TabIndex = 6;
            this.btnCreateCDChamber.Text = "Create CD Chamber";
            this.btnCreateCDChamber.UseVisualStyleBackColor = true;
            this.btnCreateCDChamber.Click += new System.EventHandler(this.btnCreateCDChamber_Click);
           
            // grpControlsNewEntry
            // 
            this.grpControlsNewEntry.Controls.Add(this.btnCreateBook);
            this.grpControlsNewEntry.Controls.Add(this.btnCreateBookCIS);
            this.grpControlsNewEntry.Controls.Add(this.btnCreateDVD);
            this.grpControlsNewEntry.Controls.Add(this.btnCreateCDOrchestra);
            this.grpControlsNewEntry.Controls.Add(this.btnCreateCDChamber);
            this.grpControlsNewEntry.Location = new System.Drawing.Point(26, 25);
            this.grpControlsNewEntry.Name = "grpControlsNewEntry";
            this.grpControlsNewEntry.Size = new System.Drawing.Size(721, 58);
            this.grpControlsNewEntry.TabIndex = 15;
            this.grpControlsNewEntry.TabStop = false;
            this.grpControlsNewEntry.Text = "Controls for Creating a New Entry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(174, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 16;
            // 
            // grpProduct
            // 
            this.grpProduct.Controls.Add(this.grpCDChamber);
            this.grpProduct.Controls.Add(this.grpCDOrchestra);
            this.grpProduct.Controls.Add(this.grpCDClassical);
            this.grpProduct.Controls.Add(this.grpDVD);
            this.grpProduct.Controls.Add(this.grpBookCIS);
            this.grpProduct.Controls.Add(this.grpBook);
            this.grpProduct.Controls.Add(this.txtProductQuantity);
            this.grpProduct.Controls.Add(this.txtProductTitle);
            this.grpProduct.Controls.Add(this.txtProductPrice);
            this.grpProduct.Controls.Add(this.txtProductUPC);
            this.grpProduct.Controls.Add(this.lblQuantity);
            this.grpProduct.Controls.Add(this.lblTitle2);
            this.grpProduct.Controls.Add(this.lblPrice);
            this.grpProduct.Controls.Add(this.lblUPC);
            this.grpProduct.Location = new System.Drawing.Point(78, 133);
            this.grpProduct.Name = "grpProduct";
            this.grpProduct.Size = new System.Drawing.Size(600, 342);
            this.grpProduct.TabIndex = 18;
            this.grpProduct.TabStop = false;
            this.grpProduct.Text = "Product";
            // 
            // grpCDChamber
            // 
            this.grpCDChamber.Controls.Add(this.txtCDChamberInstrumentList);
            this.grpCDChamber.Controls.Add(this.lblInstruments);
            this.grpCDChamber.Location = new System.Drawing.Point(318, 282);
            this.grpCDChamber.Name = "grpCDChamber";
            this.grpCDChamber.Size = new System.Drawing.Size(271, 54);
            this.grpCDChamber.TabIndex = 22;
            this.grpCDChamber.TabStop = false;
            this.grpCDChamber.Text = "CD Chamber Music";
            // 
            // txtCDChamberInstrumentList
            // 
            this.txtCDChamberInstrumentList.FormattingEnabled = true;
            this.txtCDChamberInstrumentList.Location = new System.Drawing.Point(77, 22);
            this.txtCDChamberInstrumentList.Name = "txtCDChamberInstrumentList";
            this.txtCDChamberInstrumentList.Size = new System.Drawing.Size(188, 21);
            this.txtCDChamberInstrumentList.TabIndex = 22;
            // 
            // lblInstruments
            // 
            this.lblInstruments.AutoSize = true;
            this.lblInstruments.Location = new System.Drawing.Point(15, 26);
            this.lblInstruments.Name = "lblInstruments";
            this.lblInstruments.Size = new System.Drawing.Size(61, 13);
            this.lblInstruments.TabIndex = 20;
            this.lblInstruments.Text = "Instruments";
            // 
            // grpCDOrchestra
            // 
            this.grpCDOrchestra.Controls.Add(this.txtCDOrchestraConductor);
            this.grpCDOrchestra.Controls.Add(this.lblConductor);
            this.grpCDOrchestra.Location = new System.Drawing.Point(18, 282);
            this.grpCDOrchestra.Name = "grpCDOrchestra";
            this.grpCDOrchestra.Size = new System.Drawing.Size(283, 54);
            this.grpCDOrchestra.TabIndex = 21;
            this.grpCDOrchestra.TabStop = false;
            this.grpCDOrchestra.Text = "CD Orchestral Music";
            // 
            // txtCDOrchestraConductor
            // 
            this.txtCDOrchestraConductor.Location = new System.Drawing.Point(66, 23);
            this.txtCDOrchestraConductor.Name = "txtCDOrchestraConductor";
            this.txtCDOrchestraConductor.Size = new System.Drawing.Size(211, 20);
            this.txtCDOrchestraConductor.TabIndex = 21;
            // 
            // lblConductor
            // 
            this.lblConductor.AutoSize = true;
            this.lblConductor.Location = new System.Drawing.Point(6, 26);
            this.lblConductor.Name = "lblConductor";
            this.lblConductor.Size = new System.Drawing.Size(56, 13);
            this.lblConductor.TabIndex = 19;
            this.lblConductor.Text = "Conductor";
            // 
            // grpCDClassical
            // 
            this.grpCDClassical.Controls.Add(this.txtCDClassicalArtists);
            this.grpCDClassical.Controls.Add(this.txtCDClassicalLabel);
            this.grpCDClassical.Controls.Add(this.lblArtists);
            this.grpCDClassical.Controls.Add(this.lblLabel);
            this.grpCDClassical.Location = new System.Drawing.Point(18, 222);
            this.grpCDClassical.Name = "grpCDClassical";
            this.grpCDClassical.Size = new System.Drawing.Size(571, 54);
            this.grpCDClassical.TabIndex = 20;
            this.grpCDClassical.TabStop = false;
            this.grpCDClassical.Text = "CDClassical";
            // 
            // txtCDClassicalArtists
            // 
            this.txtCDClassicalArtists.Location = new System.Drawing.Point(289, 22);
            this.txtCDClassicalArtists.Name = "txtCDClassicalArtists";
            this.txtCDClassicalArtists.Size = new System.Drawing.Size(276, 20);
            this.txtCDClassicalArtists.TabIndex = 3;
            // 
            // txtCDClassicalLabel
            // 
            this.txtCDClassicalLabel.Location = new System.Drawing.Point(44, 22);
            this.txtCDClassicalLabel.Name = "txtCDClassicalLabel";
            this.txtCDClassicalLabel.Size = new System.Drawing.Size(163, 20);
            this.txtCDClassicalLabel.TabIndex = 2;
            // 
            // lblArtists
            // 
            this.lblArtists.AutoSize = true;
            this.lblArtists.Location = new System.Drawing.Point(248, 25);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(35, 13);
            this.lblArtists.TabIndex = 1;
            this.lblArtists.Text = "Artists";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(6, 26);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(33, 13);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label";
            // 
            // grpDVD
            // 
            this.grpDVD.Controls.Add(this.txtDVDRunTime);
            this.grpDVD.Controls.Add(this.txtDVDReleaseDate);
            this.grpDVD.Controls.Add(this.txtDVDLeadActor);
            this.grpDVD.Controls.Add(this.lblRunTime);
            this.grpDVD.Controls.Add(this.lblReleaseDate);
            this.grpDVD.Controls.Add(this.lblLeadActor);
            this.grpDVD.Location = new System.Drawing.Point(18, 162);
            this.grpDVD.Name = "grpDVD";
            this.grpDVD.Size = new System.Drawing.Size(571, 54);
            this.grpDVD.TabIndex = 19;
            this.grpDVD.TabStop = false;
            this.grpDVD.Text = "DVD";
            // 
            // txtDVDRunTime
            // 
            this.txtDVDRunTime.Location = new System.Drawing.Point(514, 20);
            this.txtDVDRunTime.Name = "txtDVDRunTime";
            this.txtDVDRunTime.Size = new System.Drawing.Size(42, 20);
            this.txtDVDRunTime.TabIndex = 7;
            // 
            // txtDVDReleaseDate
            // 
            this.txtDVDReleaseDate.Location = new System.Drawing.Point(349, 19);
            this.txtDVDReleaseDate.Name = "txtDVDReleaseDate";
            this.txtDVDReleaseDate.Size = new System.Drawing.Size(100, 20);
            this.txtDVDReleaseDate.TabIndex = 6;
            // 
            // txtDVDLeadActor
            // 
            this.txtDVDLeadActor.Location = new System.Drawing.Point(71, 19);
            this.txtDVDLeadActor.Name = "txtDVDLeadActor";
            this.txtDVDLeadActor.Size = new System.Drawing.Size(194, 20);
            this.txtDVDLeadActor.TabIndex = 5;
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Location = new System.Drawing.Point(455, 23);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(53, 13);
            this.lblRunTime.TabIndex = 4;
            this.lblRunTime.Text = "Run Time";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(271, 22);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseDate.TabIndex = 3;
            this.lblReleaseDate.Text = "Release Date";
            // 
            // lblLeadActor
            // 
            this.lblLeadActor.AutoSize = true;
            this.lblLeadActor.Location = new System.Drawing.Point(6, 22);
            this.lblLeadActor.Name = "lblLeadActor";
            this.lblLeadActor.Size = new System.Drawing.Size(59, 13);
            this.lblLeadActor.TabIndex = 2;
            this.lblLeadActor.Text = "Lead Actor";
            // 
            // grpBookCIS
            // 
            this.grpBookCIS.Controls.Add(this.txtBookCISCISArea);
            this.grpBookCIS.Controls.Add(this.lblCISArea);
            this.grpBookCIS.Location = new System.Drawing.Point(18, 107);
            this.grpBookCIS.Name = "grpBookCIS";
            this.grpBookCIS.Size = new System.Drawing.Size(571, 49);
            this.grpBookCIS.TabIndex = 9;
            this.grpBookCIS.TabStop = false;
            this.grpBookCIS.Text = "CIS Book";
            // 
            // txtBookCISCISArea
            // 
            this.txtBookCISCISArea.FormattingEnabled = true;
            this.txtBookCISCISArea.Location = new System.Drawing.Point(61, 19);
            this.txtBookCISCISArea.Name = "txtBookCISCISArea";
            this.txtBookCISCISArea.Size = new System.Drawing.Size(121, 21);
            this.txtBookCISCISArea.TabIndex = 1;
            // 
            // lblCISArea
            // 
            this.lblCISArea.AutoSize = true;
            this.lblCISArea.Location = new System.Drawing.Point(6, 24);
            this.lblCISArea.Name = "lblCISArea";
            this.lblCISArea.Size = new System.Drawing.Size(49, 13);
            this.lblCISArea.TabIndex = 0;
            this.lblCISArea.Text = "CIS Area";
            // 
            // grpBook
            // 
            this.grpBook.Controls.Add(this.txtBookPages);
            this.grpBook.Controls.Add(this.txtBookAuthor);
            this.grpBook.Controls.Add(this.txtBookISBNRight);
            this.grpBook.Controls.Add(this.txtBookISBNLeft);
            this.grpBook.Controls.Add(this.lbldash);
            this.grpBook.Controls.Add(this.lblPages);
            this.grpBook.Controls.Add(this.lblAuthor);
            this.grpBook.Controls.Add(this.lblISBN);
            this.grpBook.Location = new System.Drawing.Point(18, 48);
            this.grpBook.Name = "grpBook";
            this.grpBook.Size = new System.Drawing.Size(571, 53);
            this.grpBook.TabIndex = 8;
            this.grpBook.TabStop = false;
            this.grpBook.Text = "Book";
            // 
            // txtBookPages
            // 
            this.txtBookPages.Location = new System.Drawing.Point(514, 17);
            this.txtBookPages.Name = "txtBookPages";
            this.txtBookPages.Size = new System.Drawing.Size(51, 20);
            this.txtBookPages.TabIndex = 7;
            // 
            // txtBookAuthor
            // 
            this.txtBookAuthor.Location = new System.Drawing.Point(231, 17);
            this.txtBookAuthor.Name = "txtBookAuthor";
            this.txtBookAuthor.Size = new System.Drawing.Size(220, 20);
            this.txtBookAuthor.TabIndex = 6;
            // 
            // txtBookISBNRight
            // 
            this.txtBookISBNRight.Location = new System.Drawing.Point(111, 20);
            this.txtBookISBNRight.Name = "txtBookISBNRight";
            this.txtBookISBNRight.Size = new System.Drawing.Size(44, 20);
            this.txtBookISBNRight.TabIndex = 5;
            // 
            // txtBookISBNLeft
            // 
            this.txtBookISBNLeft.Location = new System.Drawing.Point(44, 20);
            this.txtBookISBNLeft.Name = "txtBookISBNLeft";
            this.txtBookISBNLeft.Size = new System.Drawing.Size(44, 20);
            this.txtBookISBNLeft.TabIndex = 4;
            this.txtBookISBNLeft.Tag = "book";
            // 
            // lbldash
            // 
            this.lbldash.AutoSize = true;
            this.lbldash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldash.Location = new System.Drawing.Point(94, 23);
            this.lbldash.Name = "lbldash";
            this.lbldash.Size = new System.Drawing.Size(11, 13);
            this.lbldash.TabIndex = 3;
            this.lbldash.Text = "-";
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(471, 20);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(37, 13);
            this.lblPages.TabIndex = 2;
            this.lblPages.Text = "Pages";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(190, 23);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Author";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(6, 23);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(32, 13);
            this.lblISBN.TabIndex = 0;
            this.lblISBN.Text = "ISBN";
            // 
            // txtProductQuantity
            // 
            this.txtProductQuantity.Location = new System.Drawing.Point(556, 22);
            this.txtProductQuantity.Name = "txtProductQuantity";
            this.txtProductQuantity.Size = new System.Drawing.Size(33, 20);
            this.txtProductQuantity.TabIndex = 7;
            // 
            // txtProductTitle
            // 
            this.txtProductTitle.Location = new System.Drawing.Point(307, 22);
            this.txtProductTitle.Name = "txtProductTitle";
            this.txtProductTitle.Size = new System.Drawing.Size(191, 20);
            this.txtProductTitle.TabIndex = 6;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(190, 22);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(64, 20);
            this.txtProductPrice.TabIndex = 5;
            // 
            // txtProductUPC
            // 
            this.txtProductUPC.Location = new System.Drawing.Point(50, 22);
            this.txtProductUPC.Name = "txtProductUPC";
            this.txtProductUPC.Size = new System.Drawing.Size(87, 20);
            this.txtProductUPC.TabIndex = 4;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(504, 25);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Location = new System.Drawing.Point(274, 25);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(27, 13);
            this.lblTitle2.TabIndex = 2;
            this.lblTitle2.Text = "Title";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(153, 26);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Price";
            // 
            // lblUPC
            // 
            this.lblUPC.AutoSize = true;
            this.lblUPC.Location = new System.Drawing.Point(15, 26);
            this.lblUPC.Name = "lblUPC";
            this.lblUPC.Size = new System.Drawing.Size(29, 13);
            this.lblUPC.TabIndex = 0;
            this.lblUPC.Text = "UPC";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(501, 507);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(364, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(96, 507);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 21;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(586, 507);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // frmBookCDDVDShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 646);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpControlsNewEntry);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmBookCDDVDShop";
            this.Text = "BookCDDVDShop";
            this.Load += new System.EventHandler(this.frmBookCDDVDShop_Load);
            this.grpControlsNewEntry.ResumeLayout(false);
            this.grpProduct.ResumeLayout(false);
            this.grpProduct.PerformLayout();
            this.grpCDChamber.ResumeLayout(false);
            this.grpCDChamber.PerformLayout();
            this.grpCDOrchestra.ResumeLayout(false);
            this.grpCDOrchestra.PerformLayout();
            this.grpCDClassical.ResumeLayout(false);
            this.grpCDClassical.PerformLayout();
            this.grpDVD.ResumeLayout(false);
            this.grpDVD.PerformLayout();
            this.grpBookCIS.ResumeLayout(false);
            this.grpBookCIS.PerformLayout();
            this.grpBook.ResumeLayout(false);
            this.grpBook.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lbldash;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblUPC;
        private System.Windows.Forms.Label lblInstruments;
        private System.Windows.Forms.Label lblConductor;
        private System.Windows.Forms.Label lblArtists;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label lblLeadActor;
        private System.Windows.Forms.Label lblCISArea;
        public System.Windows.Forms.Button btnCreateBook;
        public System.Windows.Forms.TextBox txtProductTitle;
        public System.Windows.Forms.Button btnCreateBookCIS;
        public System.Windows.Forms.Button btnCreateDVD;
        public System.Windows.Forms.Button btnCreateCDOrchestra;
        public System.Windows.Forms.Button btnCreateCDChamber;
        public System.Windows.Forms.TextBox txtBookPages;
        public System.Windows.Forms.TextBox txtBookAuthor;
        public System.Windows.Forms.TextBox txtBookISBNRight;
        public System.Windows.Forms.TextBox txtBookISBNLeft;
        public System.Windows.Forms.TextBox txtProductQuantity;
        public System.Windows.Forms.TextBox txtProductPrice;
        public System.Windows.Forms.TextBox txtProductUPC;
        public System.Windows.Forms.ComboBox txtCDChamberInstrumentList;
        public System.Windows.Forms.TextBox txtCDOrchestraConductor;
        public System.Windows.Forms.TextBox txtCDClassicalArtists;
        public System.Windows.Forms.TextBox txtCDClassicalLabel;
        public System.Windows.Forms.TextBox txtDVDRunTime;
        public System.Windows.Forms.TextBox txtDVDReleaseDate;
        public System.Windows.Forms.TextBox txtDVDLeadActor;
        public System.Windows.Forms.ComboBox txtBookCISCISArea;
        public System.Windows.Forms.GroupBox grpProduct;
        public System.Windows.Forms.GroupBox grpCDChamber;
        public System.Windows.Forms.GroupBox grpCDOrchestra;
        public System.Windows.Forms.GroupBox grpDVD;
        public System.Windows.Forms.GroupBox grpBookCIS;
        public System.Windows.Forms.GroupBox grpCDClassical;
        public System.Windows.Forms.GroupBox grpControlsNewEntry;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox grpBook;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

