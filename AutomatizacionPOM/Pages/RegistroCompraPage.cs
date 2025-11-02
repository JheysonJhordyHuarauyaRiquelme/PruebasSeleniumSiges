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
        public IWebElement SelectDocumento => driver.FindElement(By.XPath("//span[contains(@class,'select2-selection--single')]"));
        public static readonly By nmrSerie = By.XPath("//label[text()='SERIE']/following-sibling::input");




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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var js = (IJavaScriptExecutor)driver;

            // 1️⃣ Esperar el botón visible del select2
            var select2 = wait.Until(d =>
                d.FindElement(By.XPath("//span[contains(@class,'select2-selection--single')]")));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", select2);
            js.ExecuteScript("arguments[0].click();", select2);

            // 2️⃣ Esperar a que aparezca la lista (en cualquier parte del DOM)
            wait.Until(d =>
            {
                var dropdowns = d.FindElements(By.XPath("//ul[contains(@class,'select2-results__options')]"));
                return dropdowns.Any(dd => dd.Displayed);
            });

            // 3️⃣ Buscar la opción por texto visible
            var option = wait.Until(d =>
                d.FindElement(By.XPath($"//li[contains(@class,'select2-results__option') and normalize-space(text())='{tipoDocumento}']")));

            js.ExecuteScript("arguments[0].click();", option);

            Console.WriteLine($"✅ Documento '{tipoDocumento}' seleccionado correctamente.");
        }




        public void IngresarSerie(string serie)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement input = wait.Until(d =>
                {
                    var element = d.FindElement(nmrSerie);
                    return (element.Displayed && element.Enabled) ? element : null;
                });

                input.Clear();
                input.SendKeys(serie);
                Console.WriteLine($"Serie '{serie}' ingresada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ingresar la serie: {ex.Message}");
            }
        }


    }
}
