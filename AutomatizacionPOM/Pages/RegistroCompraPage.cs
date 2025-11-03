using AutomatizacionPOM.Pages.Helpers;
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
        //
        public static readonly By nmrProveedor = By.XPath("//input[@id='DocumentoIdentidad']");
        public static readonly By nmrFechaEnvio = By.XPath("//input[@id='fechaRegistro']");
        public static readonly By slctDocumento = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[3]/span/span[1]/span");
        public static readonly By OptionFactura = By.XPath("//li[contains(text(),'FACTURA')]");
        public static readonly By OptionBoleta = By.XPath("//li[contains(text(),'BOLETA')]");
        public static readonly By nmrSerie = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[5]/input");
        public static readonly By nmrNumeroDocumento = By.XPath("//body/div[1]/div/section/div/div/div/form/div[1]/div[1]/div[2]/div/div[6]/input");
        public static readonly By txtObseracion = By.XPath("//div[@class='panel-body no-pad-top']//textarea[@id='observacion']");
        public static readonly By slctTipoEntregaInmediata = By.XPath("//input[@id='radioEntrega1']");
        public static readonly By slctTipoEntregaDiferida = By.XPath("//input[@id='radioEntrega2']");
        public static readonly By slctTipoAlmacenDestinoUno = By.XPath("//input[@id='radioEntrega3']");
        public static readonly By slctTipoAlmacenDestinoVarios = By.XPath("//input[@id='radioEntrega4']");
        public static readonly By slctRol = By.XPath("//span[@id='select2-rolConcepto-container']/ancestor::span[contains(@class,'select2-selection--single')]");
        public static readonly By slctRolMercaderia = By.XPath("//li[contains(@id,'select2-rolConcepto-result') and contains(text(),'Mercaderia')]");
        public static readonly By slctRolInsumo = By.XPath("//li[contains(@id,'select2-rolConcepto-result') and contains(text(),'Insumo')]");
        public static readonly By slctAlmacen = By.XPath("");
        public static readonly By slctTipoPago = By.XPath("");
        public static readonly By slctSubTipoPago = By.XPath("");
        public static readonly By nmrMontoPago = By.XPath("");
        public static readonly By slctTipoCompra = By.XPath("");
        public static readonly By slctGuardarCompra = By.XPath("");




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
        public void SeleccionarTipoEntrega(string tipoEntrega)
        {
            if (tipoEntrega.Equals("INMEDIATA", StringComparison.OrdinalIgnoreCase))
            {
                utilities.ClickButton(slctTipoEntregaInmediata);
            }
            else if (tipoEntrega.Equals("DIFERIDA", StringComparison.OrdinalIgnoreCase))
            {
                utilities.ClickButton(slctTipoEntregaDiferida);
            }
            else
            {
                throw new ArgumentException("Tipo de entrega no válido. Usa 'INMEDIATA' o 'DIFERIDA'.");
            }

            Thread.Sleep(500);
        }
        public void SeleccionarAlmacenDestino(string tipoAlmacen)
        {
            if (tipoAlmacen.Equals("UNO", StringComparison.OrdinalIgnoreCase))
            {
                utilities.ClickButton(slctTipoAlmacenDestinoUno);
            }
            else if (tipoAlmacen.Equals("VARIOS", StringComparison.OrdinalIgnoreCase))
            {
                utilities.ClickButton(slctTipoAlmacenDestinoVarios);
            }
            else
            {
                throw new ArgumentException("Tipo de almacén no válido. Usa 'UNO' o 'VARIOS'.");
            }

            Thread.Sleep(500);
        }
        public void SeleccionarRol(string rol)
        {
            utilities.ClickButton(slctRol);
            Thread.Sleep(500);

            if (rol.Equals("Mercaderia", StringComparison.OrdinalIgnoreCase))
                utilities.ClickButton(slctRolMercaderia);
            else if (rol.Equals("Insumo", StringComparison.OrdinalIgnoreCase))
                utilities.ClickButton(slctRolInsumo);
            else
                throw new ArgumentException("Rol no válido. Usa 'Mercaderia' o 'Insumo'.");

            Thread.Sleep(500);
        }
        public void SeleccionarAlmacen(string almacen)
        {
            utilities.ClickButton(slctAlmacen);
            utilities.SelectOption(slctAlmacen, almacen);
        }
        public void SeleccionarTipoPago()
        {
            utilities.ClickButton(slctTipoPago);
        }
        public void SeleccionarSubTipoPago()
        {
            utilities.ClickButton(slctSubTipoPago);
        }
        public void IngresarCantidadMetodoPago(string montoPago)
        {
            utilities.ClearAndEnterText(nmrMontoPago, montoPago);
        }
        public void SeleccionarTipoCompra()
        {
            utilities.ClickButton(slctTipoCompra);
        }
        public void GuardarCompra()
        {
            utilities.ClickButton(slctGuardarCompra);
        }
    }
}
