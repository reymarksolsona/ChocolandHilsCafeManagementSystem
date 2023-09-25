using EntitiesShared;
using EntitiesShared.InventoryManagement;
using Microsoft.Extensions.Options;
using Shared;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace PDFReportGenerators
{
    public class IngredientsInventoryPDFReport : IIngredientsInventoryPDFReport
    {

        private readonly IConverter _converter;
        private readonly UOMConverter _uOMConverter;
        private readonly OtherSettings _otherSettings;

        public IngredientsInventoryPDFReport(IConverter converter, IOptions<OtherSettings> otherSettings, UOMConverter uOMConverter)
        {
            _converter = converter;
            _uOMConverter = uOMConverter;
            _otherSettings = otherSettings.Value;
        }


        public string GetUOMFormatted(StaticData.UOM uom, decimal qtyValue)
        {
            string uomFormatted = "";

            switch (uom)
            {
                case StaticData.UOM.kg:
                    uomFormatted = _uOMConverter.gram_to_kg_format(qtyValue);
                    break;

                case StaticData.UOM.L:
                    uomFormatted = _uOMConverter.ml_to_L_format(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    uomFormatted = _uOMConverter.pc_format(qtyValue);
                    break;
                default:
                    uomFormatted = "0";
                    break;
            }

            return uomFormatted;
        }

        public void GenerateIngredientInventoryReport(List<IngredientModel> ingredients)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html> 
                            <html> 
                            <header>
                                <style>
                                    th, td{
                                        padding: 5px;
                                    }

                                    table#parent-table thead{
                                        text-align: left;
                                    }

                                    table {
                                        width: 100%;
                                        border-collapse: collapse;
                                    }
                                </style>
                            </header>
                            <body>");

            sb.Append($@"<h3>Payroll report</h3>
                    <table id='parent-table'>
                    <thead>
                        <thead>
                            <tr>
                                <th>Ingredient</th>
                                <th>Category</th>
                                <th>Rem. Qty value</th>
                                <th>Unit Cost</th>
                                <th>Expiration Date</th>
                            </tr>
                        </thead>
                    </thead>
                    <tbody> ");

            if (ingredients != null)
            {
                foreach (var ing in ingredients)
                {
                    if (ing.Inventory.ExpirationDate == DateTime.Now || ing.Inventory.ExpirationDate <= DateTime.Now.AddDays(_otherSettings.NumDaysNotifyUserForInventoryExpDate))
                    {
                        sb.Append($@"<tr>
                                <td>{ing.IngName}</td>
                                <td>{ing.Category.Category}</td>
                                <td>{this.GetUOMFormatted(ing.UOM, ing.Inventory.RemainingQtyValue)}</td>
                                <td>{ing.Inventory.UnitCost}</td>
                                <td style='color:red;'>{ing.Inventory.ExpirationDate.ToShortDateString()}</td>
                            </tr>");
                    }
                    else
                    {
                        sb.Append($@"<tr>
                                <td>{ing.IngName}</td>
                                <td>{ing.Category.Category}</td>
                                <td>{this.GetUOMFormatted(ing.UOM, ing.Inventory.RemainingQtyValue)}</td>
                                <td>{ing.Inventory.UnitCost}</td>
                                <td>{ing.Inventory.ExpirationDate.ToShortDateString()}</td>
                            </tr>");
                    }

                    
                }
            }
            
            sb.Append($@"</tbody>
                        </table>
                    </body>
                  </html>");

            this.GeneratePdfReport(sb.ToString(), $"Ingredient-Inventory-report-{DateTime.Now.ToString("yyyy-MM-dd")}");
        }

        private void GeneratePdfReport(string html, string fileName)
        {
            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Landscape;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 5, Bottom = 5 };
            globalSettings.Out = $@"{_otherSettings.InventoryPDFReportLoc}{fileName}.pdf";

            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;

            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";

            //HeaderSettings headerSettings = new HeaderSettings();
            //headerSettings.FontSize = 15;
            //headerSettings.FontName = "Ariel";
            //headerSettings.Right = "Page [page] of [toPage]";
            //headerSettings.Line = true;

            //FooterSettings footerSettings = new FooterSettings();
            //footerSettings.FontSize = 12;
            //footerSettings.FontName = "Ariel";
            //footerSettings.Center = "This is for demonstration purposes only.";
            //footerSettings.Line = true;


            //objectSettings.HeaderSettings = headerSettings;
            //objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;

            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            _converter.Convert(htmlToPdfDocument);
        }
    }
}
