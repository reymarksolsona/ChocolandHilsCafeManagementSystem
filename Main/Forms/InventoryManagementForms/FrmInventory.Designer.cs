
namespace Main.Forms.InventoryManagementForms
{
    partial class FrmInventory
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuIngredient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSItemIngredientInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSItemProductInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelMainContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.ContextMenuIngredient.SuspendLayout();
            this.ContextMenuProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDown = this.ContextMenuIngredient;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem1.Text = "Ingredient";
            // 
            // ContextMenuIngredient
            // 
            this.ContextMenuIngredient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSItemIngredientInventory});
            this.ContextMenuIngredient.Name = "ContextMenuIngredient";
            this.ContextMenuIngredient.OwnerItem = this.toolStripMenuItem1;
            this.ContextMenuIngredient.Size = new System.Drawing.Size(125, 26);
            this.ContextMenuIngredient.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuIngredient_ItemClicked);
            // 
            // TSItemIngredientInventory
            // 
            this.TSItemIngredientInventory.Name = "TSItemIngredientInventory";
            this.TSItemIngredientInventory.Size = new System.Drawing.Size(124, 22);
            this.TSItemIngredientInventory.Text = "Inventory";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDown = this.ContextMenuProducts;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "Product";
            // 
            // ContextMenuProducts
            // 
            this.ContextMenuProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSItemProductInventory});
            this.ContextMenuProducts.Name = "ContextMenuProducts";
            this.ContextMenuProducts.OwnerItem = this.toolStripMenuItem2;
            this.ContextMenuProducts.Size = new System.Drawing.Size(125, 26);
            this.ContextMenuProducts.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuProducts_ItemClicked);
            // 
            // TSItemProductInventory
            // 
            this.TSItemProductInventory.Name = "TSItemProductInventory";
            this.TSItemProductInventory.Size = new System.Drawing.Size(124, 22);
            this.TSItemProductInventory.Text = "Inventory";
            // 
            // PanelMainContainer
            // 
            this.PanelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMainContainer.Location = new System.Drawing.Point(0, 24);
            this.PanelMainContainer.Name = "PanelMainContainer";
            this.PanelMainContainer.Size = new System.Drawing.Size(800, 426);
            this.PanelMainContainer.TabIndex = 1;
            // 
            // FrmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelMainContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmInventory";
            this.Text = "FrmInventory";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextMenuIngredient.ResumeLayout(false);
            this.ContextMenuProducts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip ContextMenuIngredient;
        private System.Windows.Forms.ToolStripMenuItem TSItemIngredientInventory;
        private System.Windows.Forms.Panel PanelMainContainer;
        private System.Windows.Forms.ContextMenuStrip ContextMenuProducts;
        private System.Windows.Forms.ToolStripMenuItem TSItemProductInventory;
    }
}