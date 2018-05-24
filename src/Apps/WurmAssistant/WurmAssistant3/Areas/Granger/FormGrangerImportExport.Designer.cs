﻿using AldursLab.WurmAssistant3.Utils.WinForms;

namespace AldursLab.WurmAssistant3.Areas.Granger
{
    partial class FormGrangerImportExport
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
            this.comboBoxExportedHerd = new System.Windows.Forms.ComboBox();
            this.buttonExportXml = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.textBoxImportedHerd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExportCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelImportError = new AldursLab.WurmAssistant3.Utils.WinForms.LabelAutowrap();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveXmlFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveCsvFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxExportedHerd
            // 
            this.comboBoxExportedHerd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportedHerd.FormattingEnabled = true;
            this.comboBoxExportedHerd.Location = new System.Drawing.Point(6, 40);
            this.comboBoxExportedHerd.Name = "comboBoxExportedHerd";
            this.comboBoxExportedHerd.Size = new System.Drawing.Size(188, 21);
            this.comboBoxExportedHerd.TabIndex = 0;
            // 
            // buttonExportXml
            // 
            this.buttonExportXml.Location = new System.Drawing.Point(6, 67);
            this.buttonExportXml.Name = "buttonExportXml";
            this.buttonExportXml.Size = new System.Drawing.Size(75, 23);
            this.buttonExportXml.TabIndex = 1;
            this.buttonExportXml.Text = "Export XML";
            this.buttonExportXml.UseVisualStyleBackColor = true;
            this.buttonExportXml.Click += new System.EventHandler(this.buttonExportXml_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(6, 67);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 2;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // textBoxImportedHerd
            // 
            this.textBoxImportedHerd.Location = new System.Drawing.Point(6, 41);
            this.textBoxImportedHerd.Name = "textBoxImportedHerd";
            this.textBoxImportedHerd.Size = new System.Drawing.Size(188, 20);
            this.textBoxImportedHerd.TabIndex = 3;
            this.textBoxImportedHerd.TextChanged += new System.EventHandler(this.textBoxImportedHerd_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonExportCsv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxExportedHerd);
            this.groupBox1.Controls.Add(this.buttonExportXml);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // buttonExportCsv
            // 
            this.buttonExportCsv.Location = new System.Drawing.Point(87, 67);
            this.buttonExportCsv.Name = "buttonExportCsv";
            this.buttonExportCsv.Size = new System.Drawing.Size(75, 23);
            this.buttonExportCsv.TabIndex = 3;
            this.buttonExportCsv.Text = "Export CSV";
            this.buttonExportCsv.UseVisualStyleBackColor = true;
            this.buttonExportCsv.Click += new System.EventHandler(this.buttonExportCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose herd to export:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelImportError);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonImport);
            this.groupBox2.Controls.Add(this.textBoxImportedHerd);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 101);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import";
            // 
            // labelImportError
            // 
            this.labelImportError.ForeColor = System.Drawing.Color.Red;
            this.labelImportError.Location = new System.Drawing.Point(87, 64);
            this.labelImportError.Name = "labelImportError";
            this.labelImportError.Size = new System.Drawing.Size(107, 0);
            this.labelImportError.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "New name for imported herd:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            // 
            // saveXmlFileDialog
            // 
            this.saveXmlFileDialog.FileName = "myherd.xml";
            this.saveXmlFileDialog.Filter = "XML files (*.xml)|*.xml";
            // 
            // saveCsvFileDialog
            // 
            this.saveCsvFileDialog.FileName = "myherd.csv";
            this.saveCsvFileDialog.Filter = "CSV files (*.csv)|*.csv";
            // 
            // FormGrangerImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 132);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGrangerImportExport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import / Export Herds";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxExportedHerd;
        private System.Windows.Forms.Button buttonExportXml;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TextBox textBoxImportedHerd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveXmlFileDialog;
        private LabelAutowrap labelImportError;
        private System.Windows.Forms.Button buttonExportCsv;
        private System.Windows.Forms.SaveFileDialog saveCsvFileDialog;
    }
}