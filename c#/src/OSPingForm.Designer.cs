namespace OSPing
{
    partial class OSPingForm
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
            this.pingResultView = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pingResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // pingResultView
            // 
            this.pingResultView.AllowUserToAddRows = false;
            this.pingResultView.AllowUserToDeleteRows = false;
            this.pingResultView.AllowUserToOrderColumns = true;
            this.pingResultView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pingResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pingResultView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.pingResultView.Location = new System.Drawing.Point(-1, 0);
            this.pingResultView.Name = "pingResultView";
            this.pingResultView.ReadOnly = true;
            this.pingResultView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.pingResultView.Size = new System.Drawing.Size(183, 351);
            this.pingResultView.TabIndex = 0;
            this.pingResultView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.pingResultView_ColumnHeaderMouseClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Location = new System.Drawing.Point(0, 351);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // OSPingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 374);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.pingResultView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OSPingForm";
            this.Text = "Old School World Ping";
            this.Load += new System.EventHandler(this.OSPingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pingResultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView pingResultView;
        private System.Windows.Forms.Button RefreshButton;
    }
}

