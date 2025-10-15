namespace ProjectUTS
{
    partial class CheckData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mapProgressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.jenisMapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ironDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.woodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cropDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.progress = new ProjectUTS.Progress();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenisMapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productionPerHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapProgressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenisMapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.jenisMapDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.productionPerHour,
            this.positionXDataGridViewTextBoxColumn,
            this.positionYDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.mapProgressBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1063, 237);
            this.dataGridView1.TabIndex = 0;
            // 
            // mapProgressBindingSource
            // 
            this.mapProgressBindingSource.DataMember = "MapProgress";
            this.mapProgressBindingSource.DataSource = this.bindingSource1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.nama});
            this.dataGridView2.DataSource = this.jenisMapBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(0, 441);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1063, 215);
            this.dataGridView2.TabIndex = 1;
            // 
            // jenisMapBindingSource
            // 
            this.jenisMapBindingSource.DataMember = "JenisMap";
            this.jenisMapBindingSource.DataSource = this.bindingSource1;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.clayDataGridViewTextBoxColumn,
            this.ironDataGridViewTextBoxColumn,
            this.woodDataGridViewTextBoxColumn,
            this.cropDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.playerBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(0, 46);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1072, 69);
            this.dataGridView3.TabIndex = 1;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataMember = "Player";
            this.playerBindingSource.DataSource = this.bindingSource1;
            // 
            // nama
            // 
            this.nama.DataPropertyName = "nama";
            this.nama.HeaderText = "nama";
            this.nama.MinimumWidth = 6;
            this.nama.Name = "nama";
            this.nama.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Progress Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Map Data";
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.Width = 125;
            // 
            // clayDataGridViewTextBoxColumn
            // 
            this.clayDataGridViewTextBoxColumn.DataPropertyName = "clay";
            this.clayDataGridViewTextBoxColumn.HeaderText = "clay";
            this.clayDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clayDataGridViewTextBoxColumn.Name = "clayDataGridViewTextBoxColumn";
            this.clayDataGridViewTextBoxColumn.Width = 125;
            // 
            // ironDataGridViewTextBoxColumn
            // 
            this.ironDataGridViewTextBoxColumn.DataPropertyName = "iron";
            this.ironDataGridViewTextBoxColumn.HeaderText = "iron";
            this.ironDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ironDataGridViewTextBoxColumn.Name = "ironDataGridViewTextBoxColumn";
            this.ironDataGridViewTextBoxColumn.Width = 125;
            // 
            // woodDataGridViewTextBoxColumn
            // 
            this.woodDataGridViewTextBoxColumn.DataPropertyName = "wood";
            this.woodDataGridViewTextBoxColumn.HeaderText = "wood";
            this.woodDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.woodDataGridViewTextBoxColumn.Name = "woodDataGridViewTextBoxColumn";
            this.woodDataGridViewTextBoxColumn.Width = 125;
            // 
            // cropDataGridViewTextBoxColumn
            // 
            this.cropDataGridViewTextBoxColumn.DataPropertyName = "crop";
            this.cropDataGridViewTextBoxColumn.HeaderText = "crop";
            this.cropDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cropDataGridViewTextBoxColumn.Name = "cropDataGridViewTextBoxColumn";
            this.cropDataGridViewTextBoxColumn.Width = 125;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.progress;
            this.bindingSource1.Position = 0;
            // 
            // progress
            // 
            this.progress.DataSetName = "Progress";
            this.progress.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // jenisMapDataGridViewTextBoxColumn
            // 
            this.jenisMapDataGridViewTextBoxColumn.DataPropertyName = "jenisMap";
            this.jenisMapDataGridViewTextBoxColumn.HeaderText = "jenisMap";
            this.jenisMapDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.jenisMapDataGridViewTextBoxColumn.Name = "jenisMapDataGridViewTextBoxColumn";
            this.jenisMapDataGridViewTextBoxColumn.Width = 125;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "level";
            this.levelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.Width = 125;
            // 
            // productionPerHour
            // 
            this.productionPerHour.DataPropertyName = "productionPerHour";
            this.productionPerHour.HeaderText = "productionPerHour";
            this.productionPerHour.MinimumWidth = 6;
            this.productionPerHour.Name = "productionPerHour";
            this.productionPerHour.Width = 125;
            // 
            // positionXDataGridViewTextBoxColumn
            // 
            this.positionXDataGridViewTextBoxColumn.DataPropertyName = "positionX";
            this.positionXDataGridViewTextBoxColumn.HeaderText = "positionX";
            this.positionXDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.positionXDataGridViewTextBoxColumn.Name = "positionXDataGridViewTextBoxColumn";
            this.positionXDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionYDataGridViewTextBoxColumn
            // 
            this.positionYDataGridViewTextBoxColumn.DataPropertyName = "positionY";
            this.positionYDataGridViewTextBoxColumn.HeaderText = "positionY";
            this.positionYDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.positionYDataGridViewTextBoxColumn.Name = "positionYDataGridViewTextBoxColumn";
            this.positionYDataGridViewTextBoxColumn.Width = 125;
            // 
            // CheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 656);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheckData";
            this.Text = "CheckData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapProgressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jenisMapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private Progress progress;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource mapProgressBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource jenisMapBindingSource;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ironDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn woodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cropDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisMapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productionPerHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionYDataGridViewTextBoxColumn;
    }
}