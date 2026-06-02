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
            this.dgvItemsPrevistos = new System.Windows.Forms.DataGridView();
            this.dgvItensNaoPrevistos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsPrevistos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensNaoPrevistos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemsPrevistos
            // 
            this.dgvItemsPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsPrevistos.Location = new System.Drawing.Point(75, 72);
            this.dgvItemsPrevistos.Name = "dgvItemsPrevistos";
            this.dgvItemsPrevistos.RowHeadersWidth = 62;
            this.dgvItemsPrevistos.RowTemplate.Height = 28;
            this.dgvItemsPrevistos.Size = new System.Drawing.Size(453, 344);
            this.dgvItemsPrevistos.TabIndex = 0;
            // 
            // dgvItensNaoPrevistos
            // 
            this.dgvItensNaoPrevistos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensNaoPrevistos.Location = new System.Drawing.Point(590, 72);
            this.dgvItensNaoPrevistos.Name = "dgvItensNaoPrevistos";
            this.dgvItensNaoPrevistos.RowHeadersWidth = 62;
            this.dgvItensNaoPrevistos.RowTemplate.Height = 28;
            this.dgvItensNaoPrevistos.Size = new System.Drawing.Size(453, 344);
            this.dgvItensNaoPrevistos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // FormModoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 703);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvItensNaoPrevistos);
            this.Controls.Add(this.dgvItemsPrevistos);
            this.Name = "FormModoCompra";
            this.Text = "FormModoCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsPrevistos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensNaoPrevistos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemsPrevistos;
        private System.Windows.Forms.DataGridView dgvItensNaoPrevistos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}