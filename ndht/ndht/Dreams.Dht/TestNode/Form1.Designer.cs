namespace TestNode
{
    partial class Form1
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
            client.Abort();
            client.Join();

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
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxDump = new System.Windows.Forms.TextBox();
            this.buttonDump = new System.Windows.Forms.Button();
            this.textBoxStoreKey = new System.Windows.Forms.TextBox();
            this.textBoxStoreVal = new System.Windows.Forms.TextBox();
            this.buttonStore = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxFindVal = new System.Windows.Forms.TextBox();
            this.textBoxFindKey = new System.Windows.Forms.TextBox();
            this.textBoxNodeHexId = new System.Windows.Forms.TextBox();
            this.textBoxStoreKeyHex = new System.Windows.Forms.TextBox();
            this.textBoxFindKeyHex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 12);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(145, 20);
            this.textBoxId.TabIndex = 0;
            this.textBoxId.Text = "hola";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(164, 12);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(67, 20);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "4401";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(237, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxDump
            // 
            this.textBoxDump.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDump.Location = new System.Drawing.Point(13, 207);
            this.textBoxDump.Multiline = true;
            this.textBoxDump.Name = "textBoxDump";
            this.textBoxDump.Size = new System.Drawing.Size(438, 152);
            this.textBoxDump.TabIndex = 3;
            // 
            // buttonDump
            // 
            this.buttonDump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDump.Location = new System.Drawing.Point(108, 178);
            this.buttonDump.Name = "buttonDump";
            this.buttonDump.Size = new System.Drawing.Size(246, 23);
            this.buttonDump.TabIndex = 4;
            this.buttonDump.Text = "Dump";
            this.buttonDump.UseVisualStyleBackColor = true;
            this.buttonDump.Click += new System.EventHandler(this.buttonDump_Click);
            // 
            // textBoxStoreKey
            // 
            this.textBoxStoreKey.Location = new System.Drawing.Point(12, 74);
            this.textBoxStoreKey.Name = "textBoxStoreKey";
            this.textBoxStoreKey.Size = new System.Drawing.Size(105, 20);
            this.textBoxStoreKey.TabIndex = 5;
            // 
            // textBoxStoreVal
            // 
            this.textBoxStoreVal.Location = new System.Drawing.Point(125, 74);
            this.textBoxStoreVal.Name = "textBoxStoreVal";
            this.textBoxStoreVal.Size = new System.Drawing.Size(105, 20);
            this.textBoxStoreVal.TabIndex = 6;
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(238, 74);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(75, 23);
            this.buttonStore.TabIndex = 7;
            this.buttonStore.Text = "Store";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(237, 126);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 10;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // textBoxFindVal
            // 
            this.textBoxFindVal.Location = new System.Drawing.Point(123, 126);
            this.textBoxFindVal.Name = "textBoxFindVal";
            this.textBoxFindVal.ReadOnly = true;
            this.textBoxFindVal.Size = new System.Drawing.Size(105, 20);
            this.textBoxFindVal.TabIndex = 9;
            // 
            // textBoxFindKey
            // 
            this.textBoxFindKey.Location = new System.Drawing.Point(12, 126);
            this.textBoxFindKey.Name = "textBoxFindKey";
            this.textBoxFindKey.Size = new System.Drawing.Size(105, 20);
            this.textBoxFindKey.TabIndex = 8;
            // 
            // textBoxNodeHexId
            // 
            this.textBoxNodeHexId.Location = new System.Drawing.Point(12, 38);
            this.textBoxNodeHexId.Name = "textBoxNodeHexId";
            this.textBoxNodeHexId.ReadOnly = true;
            this.textBoxNodeHexId.Size = new System.Drawing.Size(298, 20);
            this.textBoxNodeHexId.TabIndex = 11;
            // 
            // textBoxStoreKeyHex
            // 
            this.textBoxStoreKeyHex.Location = new System.Drawing.Point(12, 100);
            this.textBoxStoreKeyHex.Name = "textBoxStoreKeyHex";
            this.textBoxStoreKeyHex.ReadOnly = true;
            this.textBoxStoreKeyHex.Size = new System.Drawing.Size(298, 20);
            this.textBoxStoreKeyHex.TabIndex = 12;
            // 
            // textBoxFindKeyHex
            // 
            this.textBoxFindKeyHex.Location = new System.Drawing.Point(12, 152);
            this.textBoxFindKeyHex.Name = "textBoxFindKeyHex";
            this.textBoxFindKeyHex.ReadOnly = true;
            this.textBoxFindKeyHex.Size = new System.Drawing.Size(298, 20);
            this.textBoxFindKeyHex.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 371);
            this.Controls.Add(this.textBoxFindKeyHex);
            this.Controls.Add(this.textBoxStoreKeyHex);
            this.Controls.Add(this.textBoxNodeHexId);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxFindVal);
            this.Controls.Add(this.textBoxFindKey);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.textBoxStoreVal);
            this.Controls.Add(this.textBoxStoreKey);
            this.Controls.Add(this.buttonDump);
            this.Controls.Add(this.textBoxDump);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxId);
            this.Name = "Form1";
            this.Text = "Test Dht Node";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxDump;
        private System.Windows.Forms.Button buttonDump;
        private System.Windows.Forms.TextBox textBoxStoreKey;
        private System.Windows.Forms.TextBox textBoxStoreVal;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFindVal;
        private System.Windows.Forms.TextBox textBoxFindKey;
        private System.Windows.Forms.TextBox textBoxNodeHexId;
        private System.Windows.Forms.TextBox textBoxStoreKeyHex;
        private System.Windows.Forms.TextBox textBoxFindKeyHex;
    }
}

