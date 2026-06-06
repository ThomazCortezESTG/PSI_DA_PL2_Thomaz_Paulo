namespace iShopping.Views
{
    partial class FormModoCompra
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbArtigo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvItensPrevistos = new System.Windows.Forms.DataGridView();
            this.dgvItensNaoPrevistos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.btnAlterarItem = new System.Windows.Forms.Button();
            this.lblOrcamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPrevistos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensNaoPrevistos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Coral;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1147, 610);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(243, 51);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(1147, 545);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(243, 51);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.BackColor = System.Drawing.Color.White;
            this.btnRemoverItem.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverItem.Location = new System.Drawing.Point(500, 598);
            this.btnRemoverItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(243, 51);
            this.btnRemoverItem.TabIndex = 22;
            this.btnRemoverItem.Text = "- Remover Item";
            this.btnRemoverItem.UseVisualStyleBackColor = false;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.BackColor = System.Drawing.Color.White;
            this.btnAdicionarItem.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarItem.Location = new System.Drawing.Point(500, 528);
            this.btnAdicionarItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(243, 51);
            this.btnAdicionarItem.TabIndex = 21;
            this.btnAdicionarItem.Text = "+ Adicionar Item";
            this.btnAdicionarItem.UseVisualStyleBackColor = false;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantidade.Location = new System.Drawing.Point(250, 628);
            this.nudQuantidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(229, 35);
            this.nudQuantidade.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 624);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 37);
            this.label4.TabIndex = 19;
            this.label4.Text = "Quantidade:";
            // 
            // cmbArtigo
            // 
            this.cmbArtigo.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArtigo.FormattingEnabled = true;
            this.cmbArtigo.Location = new System.Drawing.Point(250, 582);
            this.cmbArtigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbArtigo.Name = "cmbArtigo";
            this.cmbArtigo.Size = new System.Drawing.Size(229, 38);
            this.cmbArtigo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 577);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 37);
            this.label3.TabIndex = 17;
            this.label3.Text = "Artigo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(250, 528);
            this.cmbTipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(229, 38);
            this.cmbTipo.TabIndex = 16;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tipo de Artigo:";
            // 
            // dgvItensPrevistos
            // 
            this.dgvItensPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensPrevistos.Location = new System.Drawing.Point(55, 80);
            this.dgvItensPrevistos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItensPrevistos.Name = "dgvItensPrevistos";
            this.dgvItensPrevistos.RowHeadersWidth = 82;
            this.dgvItensPrevistos.RowTemplate.Height = 33;
            this.dgvItensPrevistos.Size = new System.Drawing.Size(647, 414);
            this.dgvItensPrevistos.TabIndex = 14;
            this.dgvItensPrevistos.SelectionChanged += new System.EventHandler(this.dgvItensPrevistos_SelectionChanged);
            // 
            // dgvItensNaoPrevistos
            // 
            this.dgvItensNaoPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensNaoPrevistos.Location = new System.Drawing.Point(743, 80);
            this.dgvItensNaoPrevistos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItensNaoPrevistos.Name = "dgvItensNaoPrevistos";
            this.dgvItensNaoPrevistos.RowHeadersWidth = 82;
            this.dgvItensNaoPrevistos.RowTemplate.Height = 33;
            this.dgvItensNaoPrevistos.Size = new System.Drawing.Size(647, 414);
            this.dgvItensNaoPrevistos.TabIndex = 25;
            this.dgvItensNaoPrevistos.SelectionChanged += new System.EventHandler(this.dgvItensNaoPrevistos_SelectionChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(786, 525);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 37);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(333, 37);
            this.label5.TabIndex = 27;
            this.label5.Text = "Lista de compras previstas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(736, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(433, 37);
            this.label6.TabIndex = 28;
            this.label6.Text = "Carrinho de compras não previstas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 671);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 37);
            this.label7.TabIndex = 29;
            this.label7.Text = "Preço unitário:";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(250, 676);
            this.txtPreco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(228, 31);
            this.txtPreco.TabIndex = 31;
            // 
            // btnAlterarItem
            // 
            this.btnAlterarItem.BackColor = System.Drawing.Color.White;
            this.btnAlterarItem.Font = new System.Drawing.Font("Segoe UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarItem.Location = new System.Drawing.Point(500, 666);
            this.btnAlterarItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAlterarItem.Name = "btnAlterarItem";
            this.btnAlterarItem.Size = new System.Drawing.Size(243, 51);
            this.btnAlterarItem.TabIndex = 32;
            this.btnAlterarItem.Text = "Guardar alterações";
            this.btnAlterarItem.UseVisualStyleBackColor = false;
            this.btnAlterarItem.Click += new System.EventHandler(this.btnAlterarItem_Click);
            // 
            // lblOrcamento
            // 
            this.lblOrcamento.AutoSize = true;
            this.lblOrcamento.BackColor = System.Drawing.Color.White;
            this.lblOrcamento.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrcamento.Location = new System.Drawing.Point(786, 680);
            this.lblOrcamento.Name = "lblOrcamento";
            this.lblOrcamento.Size = new System.Drawing.Size(155, 37);
            this.lblOrcamento.TabIndex = 33;
            this.lblOrcamento.Text = "Orçamento:";
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 744);
            this.Controls.Add(this.lblOrcamento);
            this.Controls.Add(this.btnAlterarItem);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvItensNaoPrevistos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnRemoverItem);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbArtigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvItensPrevistos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensNaoPrevistos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbArtigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvItensPrevistos;
        private System.Windows.Forms.DataGridView dgvItensNaoPrevistos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Button btnAlterarItem;
        private System.Windows.Forms.Label lblOrcamento;
    }
}