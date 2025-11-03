using AutomatizacionPOM.Pages.Helpers;
using Microsoft.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomatizacionPOM.Pages
{
    public class RegistroCompraPage
    {
        private IWebDriver driver;
        Utilities utilities;
        public RegistroCompraPage(IWebDriver driver)
        {
            this.driver = driver;
            utilities = new Utilities(driver);
        }
        public static readonly By txtCodigoBarra = By.XPath("//input[@id='idCodigoBarra']");
        public static readonly By nmrCantidad = By.Id("cantidad-0");
        public static readonly By nmrValorUnitario = By.XPath("(//input[@ng-model='item.PrecioUnitario'])[1]");
        public static readonly By nmrDescuento = By.XPath("//input[@ng-model='item.Descuento']");
        public static readonly By nmrFechaVencimineto = By.XPath("//input[@id='fechaVencimiento-0']");
        public static readonly By nmrFlete = By.XPath("//input[@id='flete']");
        public static readonly By nmrProveedor = By.XPath("//input[@id='DocumentoIdentidad']");
        public static readonly By nmrFechaEnvio = By.XPath("//input[@id='fechaRegistro']");
        public static readonly By slctDocumento = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[3]/span/span[1]/span");
        public static readonly By OptionFactura = By.XPath("//li[contains(text(),'FACTURA')]");
        public static readonly By OptionBoleta = By.XPath("//li[contains(text(),'BOLETA')]");
        public static readonly By nmrSerie = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[5]/input");
        public static readonly By nmrNumeroDocumento = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[6]/input");
        public static readonly By txtObseracion = By.XPath("//div[@class='panel-body no-pad-top']//textarea[@id='observacion']");
        public static readonly By OptionMercaderia = By.XPath("//select[@id='rolConcepto']/option[text()='Mercaderia']");
        public static readonly By OptionInsumo = By.XPath("//select[@id='rolConcepto']/option[text()='Insumo']");
        public static readonly By slctTipoPago = By.XPath("//div[@class='d-flex']//input[@id='radio1']");
        public static readonly By OptionDepCu = By.XPath("//label[@id='labelMedioPago-0-14']");
        public static readonly By OptionTransferencia = By.XPath("//label[@id='labelMedioPago-0-16']");
        public static readonly By OptionTDebito = By.XPath("//label[@id='labelMedioPago-0-18']");
        public static readonly By OptionTCredito = By.XPath("//label[@id='labelMedioPago-0-19']");
        public static readonly By OptionEfectivo = By.XPath("//label[@id='labelMedioPago-0-281']");
        public static readonly By txtObservacionPago = By.XPath("//div[@class='box box-primary box-solid']//textarea[@id='observacion']");
        public static readonly By OptionExoneradasIGV = By.XPath("//input[@id='radio-1']");
        public static readonly By OptionGravadas = By.XPath("//input[@id='radio-2']");
        public static readonly By OptionNoGravadas = By.XPath("//input[@id='radio-3']");
        public static readonly By OptionGravadasYnoGravadas = By.XPath("//input[@id='radio-4']");
        public static readonly By slctGuardarCompra = By.XPath("//button[contains(text(),'GUARDAR COMPRA')]");

        //public static readonly By TypeDocumentField = By.XPath("//body/div[@id='wrapper']/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[2]/facturacion-venta[1]/form[1]/div[1]/div[2]/div[1]/div[6]/selector-comprobante[1]/div[1]/ng-form[1]/div[1]/div[1]/span[1]/span[1]/span[1]");
        //public static readonly By PaymentInformation = By.XPath("//div[@class='box box-primary box-solid']//textarea[@id='informacion']");
        //public static readonly By SaveSaleButton = By.XPath("//button[normalize-space()='GUARDAR VENTA']");

        public void IngresarCodigoBarra(string codigo)
        {
            utilities.EnterText(txtCodigoBarra, codigo);
            utilities.Enter(txtCodigoBarra);
        }
        public void IngresarCantidad(string cantidad)
        {
            utilities.ClearAndEnterText(nmrCantidad, cantidad);
        }
        public void IngresarValorUnitario(string valorUnitario)
        {
            utilities.ClearAndEnterText(nmrValorUnitario, valorUnitario);
        }
        public void AplicaDescuento(string descuento)
        {
            utilities.ClearAndEnterText(nmrDescuento, descuento);
        }
        public void SeleccionFV(string fecha_vencimiento)
        {
            utilities.ClearAndEnterDate(nmrFechaVencimineto, fecha_vencimiento);
        }
        public void IngresarFlete(string flete)
        {
            utilities.ClearAndEnterText(nmrFlete, flete);
        }
        public void IngresarProveedor(string proveedor)
        {
            utilities.ClearAndEnterText(nmrProveedor, proveedor);
            utilities.Enter(nmrProveedor);
        }
        public void IngresarFechaEnvio(string fechaEnvio)
        {
            if (!string.IsNullOrWhiteSpace(fechaEnvio))
            {
                utilities.ClearAndEnterDate(nmrFechaEnvio, fechaEnvio);
            }
            else
            {
                Console.WriteLine("No se ingresó fecha de envío. El sistema mantiene la fecha por defecto.");
            }
        }

        public void SeleccionarTipoDocumento(string tipoDocumento)
        {
            utilities.ClickButton(slctDocumento);
            Thread.Sleep(500);

            if (tipoDocumento.ToUpper().Contains("FACTURA"))
                utilities.ClickButton(OptionFactura);
            else if (tipoDocumento.ToUpper().Contains("BOLETA"))
                utilities.ClickButton(OptionBoleta);

            Thread.Sleep(500);


        }

        public void IngresarSerie(string serie)
        {
            utilities.ClearAndEnterText(nmrSerie, serie);
        }

        public void IngresarNumeroDocumento(string numeroDoc)
        {
            utilities.ClearAndEnterText(nmrNumeroDocumento, numeroDoc);
        }
        public void IngresarObservacion(string observacion)
        {
            utilities.ClearAndEnterText(txtObseracion, observacion);
        }
        public void SeleccionarOpcionRol(string opcionRol)
        {
            By rolConceptoXPath = opcionRol.ToUpper() switch
            {
                "MERCADERIA" => OptionMercaderia,
                "INSUMO" => OptionInsumo,
                _ => throw new ArgumentException("Rol de concepto no válido", nameof(opcionRol))
            };
            utilities.ClickButton(rolConceptoXPath);
        }
        public void SeleccionarTipoPago(string tipoPago)
        {
            By tipoPagoXPath = tipoPago.ToUpper() switch
            {
                "DEP-CU" => OptionDepCu,
                "TRANFON" => OptionTransferencia,
                "TDEB" => OptionTDebito,
                "TCRE" => OptionTCredito,
                "EF" => OptionEfectivo,
                _ => throw new ArgumentException("Tipo de pago no válido", nameof(tipoPago))
            };
            utilities.ClickButton(tipoPagoXPath);
        }

        public void IngresarObservacionMetodoPago(string observacionPago)
        {
            utilities.ClearAndEnterText(txtObservacionPago, observacionPago);
        }
        public void SeleccionarTipoCompra(string tipoCompra)
        {
            switch (tipoCompra.ToUpper())
            {
                case "EXONERADAS IGV":
                    utilities.ClickButton(OptionExoneradasIGV);  
                    break;
                case "G":
                    utilities.ClickButton(OptionGravadas);  
                    break;
                case "NG":
                    utilities.ClickButton(OptionNoGravadas);  
                    break;
                case "G Y NG":
                    utilities.ClickButton(OptionGravadasYnoGravadas);  
                    break;
                default:
                    throw new ArgumentException("Opción no válida", nameof(tipoCompra));
            }
        }
        public void GuardarCompra()
        {
            utilities.ClickButton(slctGuardarCompra);
        }
    }
}
