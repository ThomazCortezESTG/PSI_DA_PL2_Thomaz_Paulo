namespace iShopping.Views
{
    partial class FormEstatisticas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUtilizadores = new System.Windows.Forms.Button();
            this.btnEstatisticas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnOrcamentos = new System.Windows.Forms.Button();
            this.btnArtigos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.buttonTiposArtigo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpComprasFechadas = new System.Windows.Forms.GroupBox();
            this.dgvComprasFechadas = new System.Windows.Forms.DataGridView();
            this.grpOrcamento = new System.Windows.Forms.GroupBox();
            this.dgvOrcamentoMes = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpSugestaoLista = new System.Windows.Forms.GroupBox();
            this.btnGerarLista = new System.Windows.Forms.Button();
            this.lblSemanaAtual = new System.Windows.Forms.Label();
            this.dgvSugestaoLista = new System.Windows.Forms.DataGridView();
            this.grpSugestaoOrcamento = new System.Windows.Forms.GroupBox();
            this.lblResultadoOrcamento = new System.Windows.Forms.Label();
            this.btnGerarOrcamento = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpComprasFechadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).BeginInit();
            this.grpOrcamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentoMes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.grpSugestaoLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoLista)).BeginInit();
            this.grpSugestaoOrcamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 63);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(506, 31);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(58, 27);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelUser
            // 
            this.labelUser.BackColor = System.Drawing.Color.White;
            this.labelUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(125, 6);
            this.labelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(444, 23);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "Bem vindo, user!";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "iShopping";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(6, 73);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnUtilizadores);
            this.splitContainer1.Panel1.Controls.Add(this.btnEstatisticas);
            this.splitContainer1.Panel1.Controls.Add(this.btnCompras);
            this.splitContainer1.Panel1.Controls.Add(this.btnOrcamentos);
            this.splitContainer1.Panel1.Controls.Add(this.btnArtigos);
            this.splitContainer1.Panel1.Controls.Add(this.btnInicio);
            this.splitContainer1.Panel1.Controls.Add(this.buttonTiposArtigo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(572, 298);
            this.splitContainer1.SplitterDistance = 102;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnUtilizadores
            // 
            this.btnUtilizadores.BackColor = System.Drawing.Color.White;
            this.btnUtilizadores.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilizadores.Location = new System.Drawing.Point(2, 254);
            this.btnUtilizadores.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUtilizadores.Name = "btnUtilizadores";
            this.btnUtilizadores.Size = new System.Drawing.Size(94, 39);
            this.btnUtilizadores.TabIndex = 15;
            this.btnUtilizadores.Text = "Utilizadores";
            this.btnUtilizadores.UseVisualStyleBackColor = false;
            this.btnUtilizadores.Click += new System.EventHandler(this.btnUtilizadores_Click);
            // 
            // btnEstatisticas
            // 
            this.btnEstatisticas.BackColor = System.Drawing.Color.LightGreen;
            this.btnEstatisticas.Enabled = false;
            this.btnEstatisticas.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstatisticas.Location = new System.Drawing.Point(2, 212);
            this.btnEstatisticas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEstatisticas.Name = "btnEstatisticas";
            this.btnEstatisticas.Size = new System.Drawing.Size(94, 39);
            this.btnEstatisticas.TabIndex = 14;
            this.btnEstatisticas.Text = "Estatísticas";
            this.btnEstatisticas.UseVisualStyleBackColor = false;
            this.btnEstatisticas.Click += new System.EventHandler(this.btnEstatisticas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.White;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.Location = new System.Drawing.Point(2, 170);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(94, 39);
            this.btnCompras.TabIndex = 13;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.BackColor = System.Drawing.Color.White;
            this.btnOrcamentos.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrcamentos.Location = new System.Drawing.Point(2, 128);
            this.btnOrcamentos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(94, 39);
            this.btnOrcamentos.TabIndex = 12;
            this.btnOrcamentos.Text = "Orçamentos";
            this.btnOrcamentos.UseVisualStyleBackColor = false;
            this.btnOrcamentos.Click += new System.EventHandler(this.btnOrcamentos_Click);
            // 
            // btnArtigos
            // 
            this.btnArtigos.BackColor = System.Drawing.Color.White;
            this.btnArtigos.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArtigos.Location = new System.Drawing.Point(2, 86);
            this.btnArtigos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnArtigos.Name = "btnArtigos";
            this.btnArtigos.Size = new System.Drawing.Size(94, 39);
            this.btnArtigos.TabIndex = 11;
            this.btnArtigos.Text = "Artigos";
            this.btnArtigos.UseVisualStyleBackColor = false;
            this.btnArtigos.Click += new System.EventHandler(this.btnArtigos_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.White;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(2, 2);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(94, 39);
            this.btnInicio.TabIndex = 10;
            this.btnInicio.Text = "Início";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // buttonTiposArtigo
            // 
            this.buttonTiposArtigo.BackColor = System.Drawing.Color.White;
            this.buttonTiposArtigo.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTiposArtigo.Location = new System.Drawing.Point(2, 44);
            this.buttonTiposArtigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonTiposArtigo.Name = "buttonTiposArtigo";
            this.buttonTiposArtigo.Size = new System.Drawing.Size(94, 39);
            this.buttonTiposArtigo.TabIndex = 9;
            this.buttonTiposArtigo.Text = "Tipos de Artigo";
            this.buttonTiposArtigo.UseVisualStyleBackColor = false;
            this.buttonTiposArtigo.Click += new System.EventHandler(this.buttonTiposArtigo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 292);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpComprasFechadas);
            this.tabPage1.Controls.Add(this.grpOrcamento);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(454, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Estatísticas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpComprasFechadas
            // 
            this.grpComprasFechadas.Controls.Add(this.dgvComprasFechadas);
            this.grpComprasFechadas.Location = new System.Drawing.Point(3, 140);
            this.grpComprasFechadas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpComprasFechadas.Name = "grpComprasFechadas";
            this.grpComprasFechadas.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpComprasFechadas.Size = new System.Drawing.Size(443, 127);
            this.grpComprasFechadas.TabIndex = 1;
            this.grpComprasFechadas.TabStop = false;
            this.grpComprasFechadas.Text = "Compras Fechadas - Artigos Previstos vs Não Previstos";
            // 
            // dgvComprasFechadas
            // 
            this.dgvComprasFechadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasFechadas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvComprasFechadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComprasFechadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasFechadas.Location = new System.Drawing.Point(3, 15);
            this.dgvComprasFechadas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvComprasFechadas.Name = "dgvComprasFechadas";
            this.dgvComprasFechadas.ReadOnly = true;
            this.dgvComprasFechadas.RowHeadersWidth = 82;
            this.dgvComprasFechadas.RowTemplate.Height = 33;
            this.dgvComprasFechadas.Size = new System.Drawing.Size(437, 110);
            this.dgvComprasFechadas.TabIndex = 1;
            // 
            // grpOrcamento
            // 
            this.grpOrcamento.Controls.Add(this.dgvOrcamentoMes);
            this.grpOrcamento.Location = new System.Drawing.Point(3, 3);
            this.grpOrcamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpOrcamento.Name = "grpOrcamento";
            this.grpOrcamento.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpOrcamento.Size = new System.Drawing.Size(443, 133);
            this.grpOrcamento.TabIndex = 0;
            this.grpOrcamento.TabStop = false;
            this.grpOrcamento.Text = "Orçamento vs Total de Compras por Mês";
            // 
            // dgvOrcamentoMes
            // 
            this.dgvOrcamentoMes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrcamentoMes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrcamentoMes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrcamentoMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrcamentoMes.Location = new System.Drawing.Point(3, 18);
            this.dgvOrcamentoMes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvOrcamentoMes.Name = "dgvOrcamentoMes";
            this.dgvOrcamentoMes.ReadOnly = true;
            this.dgvOrcamentoMes.RowHeadersWidth = 82;
            this.dgvOrcamentoMes.RowTemplate.Height = 33;
            this.dgvOrcamentoMes.Size = new System.Drawing.Size(437, 112);
            this.dgvOrcamentoMes.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpSugestaoLista);
            this.tabPage2.Controls.Add(this.grpSugestaoOrcamento);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(454, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Apoio à Decisão";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpSugestaoLista
            // 
            this.grpSugestaoLista.Controls.Add(this.btnGerarLista);
            this.grpSugestaoLista.Controls.Add(this.lblSemanaAtual);
            this.grpSugestaoLista.Controls.Add(this.dgvSugestaoLista);
            this.grpSugestaoLista.Location = new System.Drawing.Point(3, 87);
            this.grpSugestaoLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSugestaoLista.Name = "grpSugestaoLista";
            this.grpSugestaoLista.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSugestaoLista.Size = new System.Drawing.Size(443, 177);
            this.grpSugestaoLista.TabIndex = 2;
            this.grpSugestaoLista.TabStop = false;
            this.grpSugestaoLista.Text = "Sugestão de Lista de Compras";
            // 
            // btnGerarLista
            // 
            this.btnGerarLista.BackColor = System.Drawing.Color.White;
            this.btnGerarLista.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarLista.Location = new System.Drawing.Point(342, 18);
            this.btnGerarLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGerarLista.Name = "btnGerarLista";
            this.btnGerarLista.Size = new System.Drawing.Size(94, 39);
            this.btnGerarLista.TabIndex = 18;
            this.btnGerarLista.Text = "Gerar Sugestão";
            this.btnGerarLista.UseVisualStyleBackColor = false;
            this.btnGerarLista.Click += new System.EventHandler(this.btnGerarLista_Click);
            // 
            // lblSemanaAtual
            // 
            this.lblSemanaAtual.AutoSize = true;
            this.lblSemanaAtual.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemanaAtual.Location = new System.Drawing.Point(3, 24);
            this.lblSemanaAtual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSemanaAtual.Name = "lblSemanaAtual";
            this.lblSemanaAtual.Size = new System.Drawing.Size(169, 19);
            this.lblSemanaAtual.TabIndex = 17;
            this.lblSemanaAtual.Text = "Semana atual do mês: X";
            // 
            // dgvSugestaoLista
            // 
            this.dgvSugestaoLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSugestaoLista.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSugestaoLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSugestaoLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugestaoLista.Location = new System.Drawing.Point(3, 61);
            this.dgvSugestaoLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSugestaoLista.Name = "dgvSugestaoLista";
            this.dgvSugestaoLista.ReadOnly = true;
            this.dgvSugestaoLista.RowHeadersWidth = 82;
            this.dgvSugestaoLista.RowTemplate.Height = 33;
            this.dgvSugestaoLista.Size = new System.Drawing.Size(437, 110);
            this.dgvSugestaoLista.TabIndex = 1;
            // 
            // grpSugestaoOrcamento
            // 
            this.grpSugestaoOrcamento.Controls.Add(this.lblResultadoOrcamento);
            this.grpSugestaoOrcamento.Controls.Add(this.btnGerarOrcamento);
            this.grpSugestaoOrcamento.Location = new System.Drawing.Point(2, 3);
            this.grpSugestaoOrcamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSugestaoOrcamento.Name = "grpSugestaoOrcamento";
            this.grpSugestaoOrcamento.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSugestaoOrcamento.Size = new System.Drawing.Size(443, 81);
            this.grpSugestaoOrcamento.TabIndex = 1;
            this.grpSugestaoOrcamento.TabStop = false;
            this.grpSugestaoOrcamento.Text = "Sugestão de Orçamento para o Próximo Mês";
            // 
            // lblResultadoOrcamento
            // 
            this.lblResultadoOrcamento.AutoSize = true;
            this.lblResultadoOrcamento.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResultadoOrcamento.Location = new System.Drawing.Point(104, 39);
            this.lblResultadoOrcamento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultadoOrcamento.Name = "lblResultadoOrcamento";
            this.lblResultadoOrcamento.Size = new System.Drawing.Size(169, 13);
            this.lblResultadoOrcamento.TabIndex = 17;
            this.lblResultadoOrcamento.Text = "(clica Gerar para ver a sugestão)";
            // 
            // btnGerarOrcamento
            // 
            this.btnGerarOrcamento.BackColor = System.Drawing.Color.White;
            this.btnGerarOrcamento.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarOrcamento.Location = new System.Drawing.Point(7, 28);
            this.btnGerarOrcamento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGerarOrcamento.Name = "btnGerarOrcamento";
            this.btnGerarOrcamento.Size = new System.Drawing.Size(94, 39);
            this.btnGerarOrcamento.TabIndex = 16;
            this.btnGerarOrcamento.Text = "Gerar Sugestão";
            this.btnGerarOrcamento.UseVisualStyleBackColor = false;
            this.btnGerarOrcamento.Click += new System.EventHandler(this.btnGerarOrcamento_Click);
            // 
            // FormEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 379);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormEstatisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEstatisticas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpComprasFechadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasFechadas)).EndInit();
            this.grpOrcamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentoMes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.grpSugestaoLista.ResumeLayout(false);
            this.grpSugestaoLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugestaoLista)).EndInit();
            this.grpSugestaoOrcamento.ResumeLayout(false);
            this.grpSugestaoOrcamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonTiposArtigo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnOrcamentos;
        private System.Windows.Forms.Button btnArtigos;
        private System.Windows.Forms.Button btnEstatisticas;
        private System.Windows.Forms.Button btnUtilizadores;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpOrcamento;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpComprasFechadas;
        private System.Windows.Forms.DataGridView dgvOrcamentoMes;
        private System.Windows.Forms.DataGridView dgvComprasFechadas;
        private System.Windows.Forms.GroupBox grpSugestaoLista;
        private System.Windows.Forms.DataGridView dgvSugestaoLista;
        private System.Windows.Forms.GroupBox grpSugestaoOrcamento;
        private System.Windows.Forms.Button btnGerarOrcamento;
        private System.Windows.Forms.Label lblSemanaAtual;
        private System.Windows.Forms.Label lblResultadoOrcamento;
        private System.Windows.Forms.Button btnGerarLista;
    }
}